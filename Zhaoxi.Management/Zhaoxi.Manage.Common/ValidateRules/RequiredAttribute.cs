namespace Zhaoxi.Manage.Common.ValidateRules
{
    public class RequiredAttribute : BaseAbstractAttribute
    {

        public RequiredAttribute(string? message) : base(message)
        {
        }

        public override (bool, string?) DoValidate(object oValue)
        {
            return oValue == null ? (false, _Message) : (true, string.Empty);
        }
    }
}
