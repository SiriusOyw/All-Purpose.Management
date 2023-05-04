namespace Zhaoxi.Manage.Common.ValidateRules
{
    /// <summary>
    /// 自己支持了一个验证了是否为数字
    /// </summary>
    public class ValueIsNumAttribute : BaseAbstractAttribute
    {
        public ValueIsNumAttribute(string? message) : base(message)
        {
        }

        public override (bool, string?) DoValidate(object oValue)
        {
            if (oValue is int || oValue is long)
                return (true, string.Empty);
            return (false, _Message);
        }
    }
}
