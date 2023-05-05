namespace Zhaoxi.Manage.MentApi.Utility.InitDatabaseExt
{
    public class FunctionAttribute : Attribute
    {
        private string _Description;
        private MuType _MuType;

        public FunctionAttribute(MuType muType, string description)
        {
            _MuType = muType;
            _Description = description;
        }

        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public string GetDescription() => _Description;

        /// <summary>
        /// 功能类型
        /// </summary>
        /// <returns></returns>
        public MuType GetMuType() => _MuType;
    }

    /// <summary>
    /// 功能类型
    /// </summary>
    public enum MuType
    {
        /// <summary>
        /// 一级菜单页面
        /// </summary>
        Page = 1,
        /// <summary>
        /// 按钮功能
        /// </summary>
        Btn = 2
    }
}
