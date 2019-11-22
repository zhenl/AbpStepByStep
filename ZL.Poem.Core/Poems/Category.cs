using Abp.Domain.Entities;
using System.Collections.Generic;

namespace ZL.Poem.Core.Poems
{
    /// <summary>
    /// 诗的分类
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// 该分类中包含的诗
        /// </summary>
        public virtual ICollection<CategoryPoem> CategoryPoems { get; set; }
    }
}