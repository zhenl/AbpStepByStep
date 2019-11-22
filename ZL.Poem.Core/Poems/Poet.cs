using Abp.Domain.Entities;
using System.Collections.Generic;

namespace ZL.Poem.Core.Poems
{
    /// <summary>
    /// 诗人，从ABP Entity派生
    /// </summary>
    public class Poet : Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 写的诗
        /// </summary>
        public virtual ICollection<Poem> Poems { get; set; }

    }
}