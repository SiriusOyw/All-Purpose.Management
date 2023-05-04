namespace Zhaoxi.Manage.Common.ValidateRules
{
    public abstract class BaseAbstractAttribute : Attribute
    {
        public BaseAbstractAttribute(string? message)
        {
            _Message = message;
        }

        protected string? _Message { get; set; }

        public abstract (bool, string?) DoValidate(object oValue);
    }
}
