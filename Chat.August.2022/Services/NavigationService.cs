namespace ShareInvest.Services
{
    public class NavigationService
    {
        public static NavigationService Instance
        {
            get
            {
                instance ??= new NavigationService();

                return instance;
            }
        }
        public Task NavigateToAsync<TViewModel>(object param) where TViewModel : ViewModels.Base.ViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), param);
        }
        public async Task NavigateBackAsync() => await CurrentApplication.MainPage.Navigation.PopAsync();
        public NavigationService()
        {
            mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }
        async Task InternalNavigateToAsync(Type viewModelType, object param)
        {
            var page = CreateAndBindPage(viewModelType, param);

            if (page is Views.Home)
                CurrentApplication.MainPage = page;

            else
            {
                if (CurrentApplication.MainPage is NavigationPage np)
                    await np.PushAsync(page);
            }
            await (page.BindingContext as ViewModels.Base.ViewModel).InitailizeAsync(param);
        }
        Page CreateAndBindPage(Type viewModelType, object _)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType is null)
                throw new Exception($"Mapping type for {viewModelType} is not a page");

            return Activator.CreateInstance(pageType) as Page;
        }
        Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (mappings.ContainsKey(viewModelType) is false)
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");

            return mappings[viewModelType];
        }
        void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(ViewModels.Home), typeof(Views.Home));
            mappings.Add(typeof(ViewModels.Detail), typeof(Views.Detail));
        }
        Application CurrentApplication => Application.Current;
        readonly Dictionary<Type, Type> mappings;
        static NavigationService instance;
    }
}