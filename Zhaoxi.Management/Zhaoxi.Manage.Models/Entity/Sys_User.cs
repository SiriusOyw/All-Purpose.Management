using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Manage.Models.Entity
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [SugarTable("Sys_User")]
    public class Sys_User
    {
        [SugarColumn(ColumnName = "UserId", IsIdentity = true, IsPrimaryKey = true)]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        /// <summary>
        /// 用户状态 0正常 1冻结 2删除
        /// </summary>
        public int Status { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public long QQ { get; set; }
        public string? WeChat { get; set; }
        public int Sex { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
