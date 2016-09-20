using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SPBAPump
{
    class DetailPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        ListView listView;

		List<LabelEntryItem> profileView;



        public DetailPage()
        {
            profileView = new List<LabelEntryItem>();

			updateProfileView();
            
            this.BackgroundColor = Color.Gray;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.End,
                Children = { new Label { Text = "Profile Information, tap a selection to modify" }, listView}

            };

			listView.ItemSelected += OnItemSelected;
        }




		private void updateProfileView()
		{
			profileView.Clear();

			profileView.Add(new LabelEntryItem
			{
				label = "First Name",
				entry = MainDisplay.currentUser.FirstName
			});

			profileView.Add(new LabelEntryItem
			{
				label = "Last name",
				entry = MainDisplay.currentUser.LastName
			});

			profileView.Add(new LabelEntryItem
			{
				label = "Address",
				entry = MainDisplay.currentUser.Address
			});

			profileView.Add(new LabelEntryItem
			{
				label = "City",
				entry = MainDisplay.currentUser.City
			});

			profileView.Add(new LabelEntryItem
			{
				label = "State",
				entry = MainDisplay.currentUser.State
			});

			profileView.Add(new LabelEntryItem
			{
				label = "Zip",
				entry = MainDisplay.currentUser.Zip.ToString()
			});

			profileView.Add(new LabelEntryItem
			{
				label = "Phone",
				entry = MainDisplay.currentUser.Phone
			});

			profileView.Add(new LabelEntryItem
			{
				label = "EMail Address",
				entry = MainDisplay.currentUser.Email
			});

			listView = new ListView
			{
				ItemsSource = profileView,

				ItemTemplate = new DataTemplate(() =>
				{
					var lineItem = new TextCell();

					lineItem.SetBinding(TextCell.TextProperty, "label");
					lineItem.SetValue(TextCell.TextColorProperty, Color.Black);

					lineItem.SetBinding(TextCell.DetailProperty, "entry");
					lineItem.SetValue(TextCell.DetailColorProperty, Color.Gray);

					return lineItem;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.Default
			};
		}


		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as LabelEntryItem;

			if (item != null)
			{
				switch (item.label)
				{
					case ("First Name"): changeFirstName();
						break;
					case ("Last Name"):  changeLastName();
						break;
					case ("Address"): changeAddress();
						break;
					case ("City"):  changeCity();
						break;
					case ("State"):  changeState();
						break;
					case ("Zip"): changeZip();
						break;
					case ("Phone"):  changePhone();
						break;
					case ("EMail"):	changeEmail();
						break;

					default:  break;
				}

				listView.SelectedItem = null;

			}

		}

		async void changeFirstName()
		{
			await Navigation.PushModalAsync(new ModifyProfileInformation(0, MainDisplay.currentUser.FirstName));

			updateProfileView();
		}

		async void changeLastName()
		{
			await Navigation.PushModalAsync(new ModifyProfileInformation(1, MainDisplay.currentUser.LastName));

			updateProfileView();
		}

		async void changeAddress()
		{
			await Navigation.PushModalAsync(new ModifyProfileInformation(2, MainDisplay.currentUser.Address));

			updateProfileView();
		}

		async void changeCity()
		{	
			await Navigation.PushModalAsync(new ModifyProfileInformation(3, MainDisplay.currentUser.City));

			updateProfileView();
		}

		async void changeState()
		{
			await Navigation.PushModalAsync(new ModifyProfileInformation(4, MainDisplay.currentUser.State));

			updateProfileView();
		}

		async void changeZip()
		{
			await Navigation.PushModalAsync(new ModifyProfileInformation(5, MainDisplay.currentUser.Zip.ToString()));

			updateProfileView();
		}

		async void changePhone()
		{
			await Navigation.PushModalAsync(new ModifyProfileInformation(6, MainDisplay.currentUser.Phone));

			updateProfileView();
		}

		async void changeEmail()
		{
			await Navigation.PushModalAsync(new ModifyProfileInformation(7, MainDisplay.currentUser.Email));

			updateProfileView();
		}



    }
}
