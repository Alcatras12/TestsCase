using TestApiVk.BaseElement;


namespace TestApiVk
{
    public abstract class BaseForm
    {
        protected Label elements;
        protected string? name;


        public bool IsPageOpened() => elements.IsVisible();
    }
}