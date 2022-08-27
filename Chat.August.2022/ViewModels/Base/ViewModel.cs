namespace ShareInvest.ViewModels.Base
{
    public class ViewModel : BindableObject
    {
        public virtual Task InitailizeAsync(object navigationData) => Task.FromResult(false);
    }
}