using System;
using Realms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealmApp3
{
    public partial class MainPage : ContentPage
    {
        private Realm _realm;

        public MainPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
        }
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = _realm.All<Friend>();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void TapItem(object sender, ItemTappedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.Item;
            FriendPage friendPage = new FriendPage
            {
                BindingContext = selectedFriend
            };
            await Navigation.PushAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            FriendPage friendPage = new FriendPage
            {
                BindingContext = new Friend()
            };
            await Navigation.PushAsync(friendPage);
        }
    }
}
