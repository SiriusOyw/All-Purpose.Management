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
        protected Sys_BaseModel()
        {
        }

        protected Sys_BaseModel(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
