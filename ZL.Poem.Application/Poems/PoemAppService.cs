using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Linq;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.Application.Poems
{
    public class PoemAppService : ApplicationService, IPoemAppService
    {
        private readonly IRepository<Core.Poems.Poem> _poemRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Poet> _poetRepository;
        private readonly IRepository<CategoryPoem> _categoryPoemRepository;

        public PoemAppService(IRepository<Core.Poems.Poem> poemRepository
            , IRepository<Category> categoryRepository
            , IRepository<Poet> poetRepository
            , IRepository<CategoryPoem> categoryPoemRepository)
        {
            _poemRepository = poemRepository;
            _categoryRepository = categoryRepository;
            _poetRepository = poetRepository;
            _categoryPoemRepository = categoryPoemRepository;
        }

        public int AddCategory(CategoryDto category)
        {
            var cate = _categoryRepository.FirstOrDefault(o => o.CategoryName == category.CategoryName);

            if (cate == null)
            {
                return _categoryRepository.InsertAndGetId(new Category { CategoryName = category.CategoryName });
            }

            return -1;
        }

        public void AddPoemToCategory(CategoryPoemDto categoryPoem)
        {
            var categorypoem = _categoryPoemRepository.FirstOrDefault(o => o.CategoryId == categoryPoem.CategoryId && o.PoemId == categoryPoem.PoemId);
            if (categorypoem == null)
            {
                categorypoem = new CategoryPoem { CategoryId = categoryPoem.CategoryId, PoemId = categoryPoem.PoemId };
                _categoryPoemRepository.Insert(categorypoem);
            }
        }

        public void DeleteCategory(CategoryDto category)
        {
            if (category.Id > 0)
            {
                _categoryRepository.Delete(category.Id);
            }
            else if (!string.IsNullOrEmpty(category.CategoryName))
            {
                var cat = _categoryRepository.FirstOrDefault(o => o.CategoryName == category.CategoryName);
                if (cat != null)
                {
                    _categoryRepository.Delete(cat);
                }
            }

        }
        
        public List<CategoryDto> GetAllCategories()
        {
            return _categoryRepository.GetAll().ToList().MapTo<List<CategoryDto>>();
        }

        public List<CategoryPoemDto> GetCategoryPoems()
        {
            return _categoryPoemRepository.GetAll().ToList().MapTo<List<CategoryPoemDto>>();
        }

        public List<PoemDto> GetPoemsOfCategory(int categoryid)
        {
            var lst = _categoryPoemRepository.GetAllIncluding(o => o.Poem).Where(p => p.CategoryId == categoryid).Select(q => q.Poem);

            return lst.MapTo<List<PoemDto>>();
        }

        public PagedResultDto<PoemDto> GetPagedPoems(PagedResultRequestDto dto)
        {
            var count = _poemRepository.Count();
            var lst = _poemRepository.GetAllIncluding(c => c.Author).OrderBy(o => o.Id).PageBy(dto).ToList();

            return new PagedResultDto<PoemDto>
            {
                TotalCount = count,
                Items = lst.MapTo<List<PoemDto>>()
            };
        }

        public PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto)
        {
            var count = _poetRepository.Count();
            var lst = _poetRepository.GetAll().OrderBy(o => o.Id).PageBy(dto).ToList();

            return new PagedResultDto<PoetDto>
            {
                TotalCount = count,
                Items = lst.MapTo<List<PoetDto>>()
            };
        }

        public List<CategoryDto> GetPoemCategories(int poemid)
        {
            var lst = _categoryPoemRepository.GetAllIncluding(o => o.Category).Where(p => p.PoemId == poemid).Select(q => q.Category);

            return lst.MapTo<List<CategoryDto>>();
        }

        public void RemovePoemFromCategory(CategoryPoemDto categoryPoem)
        {
            var categorypoem = _categoryPoemRepository.FirstOrDefault(o => o.CategoryId == categoryPoem.CategoryId && o.PoemId == categoryPoem.PoemId);
            if (categorypoem != null)
            {
                _categoryPoemRepository.Delete(categorypoem);
            }
        }

        public PagedResultDto<PoemDto> SearchPoems(SearchPoemDto dto)
        {
            var res = _poemRepository.GetAllIncluding(c => c.Author);
            //
            if (!string.IsNullOrEmpty(dto.Keyword))
            {
                res = res.Where(o => o.Title.Contains(dto.Keyword));
            }
            if (!string.IsNullOrEmpty(dto.AuthorName))
            {
                res = res.Where(o => o.Author.Name == dto.AuthorName);
            }
            if (dto.Categories != null)
            {
                foreach (var category in dto.Categories)
                {
                    res = res.Where(o => o.PoemCategories.Any(q => q.Category.CategoryName == category));
                }
            }

            var count = res.Count();
            var lst = res.OrderBy(o => o.Id).PageBy(dto).ToList();

            return new PagedResultDto<PoemDto>
            {
                TotalCount = count,
                Items = lst.MapTo<List<PoemDto>>()
            };
        }

        public PagedResultDto<PoetDto> SearchPoets(SearchPoetDto dto)
        {
            var res = _poetRepository.GetAll();
            if (!string.IsNullOrEmpty(dto.Keyword))
            {
                res = res.Where(o => o.Name.Contains(dto.Keyword));
            }
            var count = res.Count();
            var lst = res.OrderBy(o => o.Id).PageBy(dto).ToList();

            return new PagedResultDto<PoetDto>
            {
                TotalCount = count,
                Items = lst.MapTo<List<PoetDto>>()
            };
        }
    }
}