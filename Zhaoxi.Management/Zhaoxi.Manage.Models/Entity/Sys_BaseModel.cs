using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Manage.Models.Entity
{
    /// <summary>
    /// 数据库表父类约束
    /// </summary>
    public abstract class Sys_BaseModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// 是否生效
        /// </summary>
        public bool IsEnabled { get; set; } = true;
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
