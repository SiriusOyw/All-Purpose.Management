using Zhaoxi.Manage.Common.ValidateRules;

namespace Zhaoxi.Manage.Models.DTO
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class SysUserDTO : BaseDTO
    {
        public int UserId { get; set; }
        [Required("用户名称不能为空")]
        public string? Name { get; set; }
        public string? Password { get; set; }
        /// <summary>
        /// 用户状态 0正常 1冻结 2删除
        /// </summary>
        public int Status { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        [Required("用户地址不能为空")]
        public string? Address { get; set; }
        public string? Email { get; set; }
        [ValueIsNum("QQ号必须为数字")]
        public long QQ { get; set; }
        public string? WeChat { get; set; }
        public int Sex { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
