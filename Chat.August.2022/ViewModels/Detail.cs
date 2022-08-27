using ShareInvest.Services;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShareInvest.ViewModels
{
    public class Detail : Base.ViewModel
    {
        public ICommand BackCommand => new Command(OnBack);
        public override Task InitailizeAsync(object navigationData)
        {
            if (navigationData is Models.ChatApp.Message message)
            {
                User = message.Sender;
                Messages = new ObservableCollection<Models.ChatApp.Message>(MessageService.Instance.GetMessages(User));
            }
            return base.InitailizeAsync(navigationData);
        }
        public Models.ChatApp.User User
        {
            set
            {
                user = value;
                OnPropertyChanged();
            }
            get => user;
        }
        public ObservableCollection<Models.ChatApp.Message> Messages
        {
            set
            {
                messages = value;
                OnPropertyChanged();
            }
            get => messages;
        }
        void OnBack() => _ = NavigationService.Instance.NavigateBackAsync();
        Models.ChatApp.User user;
        ObservableCollection<Models.ChatApp.Message> messages;
    }
}