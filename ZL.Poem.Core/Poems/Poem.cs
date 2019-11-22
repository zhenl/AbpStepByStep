using Abp.Domain.Entities;
using System.Collections.Generic;

namespace ZL.Poem.Core.Poems
{
    /// <summary>
    /// 诗
    /// Volumn和Num是全唐诗中的卷和序号，
    /// </summary>
    public class Poem : Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 点评
        /// </summary>
        public virtual string Comments { get; set; }

        /// <summary>
        /// 卷（全唐诗）
        /// </summary>
        public virtual string Volumn { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public virtual string Num { get; set; }

        /// <summary>
        /// 诗人id
        /// </summary>
        public virtual int PoetID { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public virtual Poet Author { get; set; }


        /// <summary>
        /// 分类
        /// </summary>
        public virtual ICollection<CategoryPoem> PoemCategories { get; set; }
    }
}