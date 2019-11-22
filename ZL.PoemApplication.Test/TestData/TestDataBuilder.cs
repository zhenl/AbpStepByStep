using ZL.Poem.Core.Poems;
using ZL.Poem.EF.EntityFramework;

namespace ZL.PoemApplication.Test.TestData
{
    public class TestDataBuilder
    {
        private readonly PoemDbContext _context;

        public TestDataBuilder(PoemDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.Poets.AddRange(
           new Poet { Name = "李白" },
           new Poet { Name = "杜甫" }
           );

            _context.Categories.Add(new Category { CategoryName = "小学古诗" });

            _context.Poems.AddRange(
                new ZL.Poem.Core.Poems.Poem { Title = "静夜思", Content = "床前明月光,疑是地上霜。", PoetID = 1 },
                new ZL.Poem.Core.Poems.Poem { Title = "望庐山瀑布", Content = "日照香炉生紫烟，遥看瀑布挂前川。", PoetID = 1 },
                new ZL.Poem.Core.Poems.Poem { Title = "望岳", Content = "岱宗夫如何", PoetID = 2 }
                );


            _context.CategoryPoems.Add(new CategoryPoem { CategoryId = 1, PoemId = 1 });
            _context.CategoryPoems.Add(new CategoryPoem { CategoryId = 1, PoemId = 2 });
            _context.CategoryPoems.Add(new CategoryPoem { CategoryId = 1, PoemId = 3 });
        }
    }
}

