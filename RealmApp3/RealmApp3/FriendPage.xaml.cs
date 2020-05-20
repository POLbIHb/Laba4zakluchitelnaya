using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmApp3
{
    public partial class FriendPage : ContentPage
    {
        Realm _realm;
        Transaction _transaction;

        public FriendPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
            _transaction = _realm.BeginWrite();
        }

        private void SaveFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                if (friend.Id == null)
                {
                    friend.Id = Guid.NewGuid().ToString();
                    _realm.Add(friend);
                }

                _transaction.Commit();
            }
            this.Navigation.PopAsync();
        }
        private void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            _realm.Remove(friend);
            _transaction.Commit();

            this.Navigation.PopAsync();
        }

        protected override void OnDisappearing()
        {
            _transaction?.Dispose();
            base.OnDisappearing();
        }
    }
}