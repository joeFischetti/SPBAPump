using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SPBAPump
{
	class MainDisplay : MasterDetailPage
    {
        MasterPage masterPage;
        ContentPage loginPage;
		public static Profile currentUser;

        public MainDisplay()
        {
            var loginButton = new Button { Text = "login" };
            loginButton.Clicked += loginSuccess;

            loginPage = new ContentPage() {

                Content = new StackLayout {
                    Children = {
                    loginButton
                    }

                }
            };

			//login();
			currentUser = new Profile();

			currentUser.FirstName = "Joe";
			currentUser.LastName = "Fischetti";
			currentUser.Address = "Some road";
			currentUser.City = "Some Town";
			currentUser.State = "Some State";
			currentUser.Zip = 12345;
			currentUser.Phone = "1234567890";
			currentUser.Email = "joe@isdev.software";

            masterPage = new MasterPage();
            Master = masterPage;
            Detail = new NavigationPage(new DetailPage());

            masterPage.ListView.ItemSelected += OnItemSelected;

        }


        async void login()
        {
            await Navigation.PushModalAsync(loginPage);
        }

        async void loginSuccess(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;

			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			
			}
        }
    }
}
