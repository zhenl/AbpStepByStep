using Shouldly;
using Xunit;
using ZL.Poem.Application.Poems;

namespace ZL.PoemApplication.Test
{
    public class PoemApplicationTest : PoemTestBase
    {
        private readonly IPoemAppService _appService;

        public PoemApplicationTest()
        {
            _appService = Resolve<IPoemAppService>();
        }

        [Fact]
        public void GetPoets_Test()
        {
            // Act
            var output = _appService.GetPagedPoets(new PagedResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBe(2);

            output.Items[0].Name.ShouldBe("李白");
        }

        [Fact]
        public void SearchPoets_Test()
        {
            // Act
            var output = _appService.SearchPoets(new SearchPoetDto { Keyword = "李", MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBe(1);

            output.Items[0].Name.ShouldBe("李白");
        }

        [Fact]
        public void SearchPomts_Test()
        {
            // Act
            var output = _appService.SearchPoems(new SearchPoemDto { AuthorName = "李白", MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBe(2);

            output.Items[0].Title.ShouldBe("静夜思");
        }

        [Fact]
        public void SearchPomtWithKeys_Test()
        {
            // Act
            var output = _appService.SearchPoems(new SearchPoemDto { Keyword = "静", MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBe(1);

            output.Items[0].Title.ShouldBe("静夜思");
        }

        [Fact]
        public void AddCategory_Test()
        {
            // Act
            var output = _appService.AddCategory(new CategoryDto { CategoryName = "唐诗三百首" });

            // Assert
            output.ShouldBe(2);

            output = _appService.AddCategory(new CategoryDto { CategoryName = "唐诗三百首" });
            output.ShouldBe(-1);
        }

        [Fact]
        public void RemoveCategory_Test()
        {
            // Act
            var output = _appService.AddCategory(new CategoryDto { CategoryName = "唐诗三百首" });

            // Assert
            output.ShouldBe(2);

            _appService.DeleteCategory(new CategoryDto { CategoryName = "唐诗三百首" });

            var categories = _appService.GetAllCategories();

            categories.Count.ShouldBe(1);
        }

        [Fact]
        public void SearchPomtWithCategories_Test()
        {
            var output = _appService.SearchPoems(new SearchPoemDto { Categories = new string[] { "小学古诗" }, MaxResultCount = 20, SkipCount = 0 });
            output.Items.Count.ShouldBe(3);
        }

        [Fact]
        public void GetCategoryPoems_Test()
        {
            var output = _appService.GetCategoryPoems();
            output.Count.ShouldBe(3);
        }


        [Fact]
        public void GetCategoryPoem_Test()
        {
            var output = _appService.GetPoemsOfCategory(1);
            output.Count.ShouldBe(3);
        }
    }
}


