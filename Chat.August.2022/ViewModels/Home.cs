using ShareInvest.Models.ChatApp;
using ShareInvest.Services;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShareInvest.ViewModels
{
    public class Home : Base.ViewModel
    {
        public ObservableCollection<User> Users
        {
            set
            {
                users = value;
                OnPropertyChanged();
            }
            get => users;
        }
        public ObservableCollection<Models.ChatApp.Message> RecentChat
        {
            set
            {
                recentChat = value;
                OnPropertyChanged();
            }
            get => recentChat;
        }
        public Home() => LoadData();
        public ICommand DetailCommand => new Command<object>(OnNavigate);
        void OnNavigate(object param)
        {
            NavigationService.Instance.NavigateToAsync<Detail>(param);
        }
        void LoadData()
        {
            users = new ObservableCollection<Models.ChatApp.User>(MessageService.Instance.GetUsers());
            recentChat = new ObservableCollection<Models.ChatApp.Message>(MessageService.Instance.GetChats());
        }
        ObservableCollection<Models.ChatApp.Message> recentChat;
        ObservableCollection<Models.ChatApp.User> users;
    }
}