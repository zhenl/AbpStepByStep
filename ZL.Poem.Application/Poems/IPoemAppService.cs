using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace ZL.Poem.Application.Poems
{
    public interface IPoemAppService : IApplicationService
    {
        /// <summary>
        /// 获取诗人分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoetDto> GetPagedPoets(PagedResultRequestDto dto);

        /// <summary>
        /// 查询诗人，按名字模糊查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoetDto> SearchPoets(SearchPoetDto dto);

        /// <summary>
        /// 获取诗的分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoemDto> GetPagedPoems(PagedResultRequestDto dto);


        /// <summary>
        /// 按条件查询诗，条件是关键字（模糊查询），作者(精确查询)，分类（属于所有分类）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PagedResultDto<PoemDto> SearchPoems(SearchPoemDto dto);

        /// <summary>
        /// 增加分类，如果已经存在，不增加，返回-1，如果增加成功，返回新增记录的id
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int AddCategory(CategoryDto category);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(CategoryDto category);

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        List<CategoryDto> GetAllCategories();

        /// <summary>
        /// 将诗关联到分类
        /// </summary>
        /// <param name="categoryPoem"></param>
        void AddPoemToCategory(CategoryPoemDto categoryPoem);

        /// <summary>
        /// 解除诗和分类的关联
        /// </summary>
        /// <param name="categoryPoem"></param>
        void RemovePoemFromCategory(CategoryPoemDto categoryPoem);


        List<CategoryPoemDto> GetCategoryPoems();

        /// <summary>
        /// 列出诗的分类
        /// </summary>
        /// <param name="poemid"></param>
        /// <returns></returns>
        List<CategoryDto> GetPoemCategories(int poemid);

        /// <summary>
        /// 列出分类的诗
        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        List<PoemDto> GetPoemsOfCategory(int categoryid);

    }
}