using System;
using Xamarin.Forms;

namespace SPBAPump
{
	public class ModifyProfileInformation : ContentPage
	{

		Button submitButton;
		int modifyType;
		Entry newValue;

		public ModifyProfileInformation(int typeCode, string modifyValue)
		{
			string modifyPrompt = "";
			modifyType = typeCode;


			switch (modifyType)
			{
				case 0:  modifyPrompt = "First name";
					break;
				case 1:  modifyPrompt = "Last Name";
					break;
				case 2:  modifyPrompt = "Address";
					break;
				case 3:  modifyPrompt = "City";
					break;
				case 4:  modifyPrompt = "State";
					break;
				case 5:  modifyPrompt = "Zip";
					break;
				case 6:  modifyPrompt = "Phone";
					break;
				case 7:  modifyPrompt = "Email";
					break;

			}

			var headerLabel = new Label { Text = modifyPrompt };
			newValue = new Entry{Text = modifyValue};

			submitButton = new Button { Text = "Submit" };

			submitButton.Clicked += submit;

			Content = new StackLayout()
			{
				Children = { headerLabel, newValue, submitButton }

			};


		}

		async void submit(object sender, EventArgs args)
		{
			switch (modifyType)
			{
				case 0:
					MainDisplay.currentUser.FirstName = newValue.Text;
					break;
				case 1:
					MainDisplay.currentUser.LastName = newValue.Text;
					break;
				case 2:
					MainDisplay.currentUser.Address = newValue.Text;
					break;
				case 3:
					MainDisplay.currentUser.City = newValue.Text;
					break;
				case 4:
					MainDisplay.currentUser.State = newValue.Text;
					break;
				case 5:
					MainDisplay.currentUser.Zip = Int32.Parse(newValue.Text);
					break;
				case 6:
					MainDisplay.currentUser.Phone = newValue.Text;
					break;
				case 7:
					MainDisplay.currentUser.Email = newValue.Text;
					break;

			}


			await Navigation.PopModalAsync();
		}

	}
}

