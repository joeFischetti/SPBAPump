using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SPBAPump
{
	class TransactionPage : ContentPage
	{
		Transaction[] transactions;
		ListView listView;

		public TransactionPage()
		{

			transactions = new Transaction[4];

			for (int i = 0; i < transactions.Length; i++)
			{
				transactions[i] = new Transaction
				{
					Date = new DateTime().AddMonths(i).AddHours(i).ToString(),
					MemberID = "" + i,
					Time = "" + i,
					Price = "1",
					PumpStart = "2",
					PumpEnd = "3",
					TotalPaid = "$1"

				};
			}

			listView = new ListView
			{
				ItemsSource = transactions,

				ItemTemplate = new DataTemplate(() =>
				{
					var lineItem = new TextCell();

					lineItem.SetBinding(TextCell.TextProperty, "Date");
					lineItem.SetValue(TextCell.TextColorProperty, Color.Black);

					lineItem.SetBinding(TextCell.DetailProperty, "Time");
					lineItem.SetValue(TextCell.DetailColorProperty, Color.Gray);

					return lineItem;
				}),

				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.Default
			};

			this.BackgroundColor = Color.Gray;

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.End,
				Children = { new Label { Text = "Select a transaction for more info" }, listView }

			};

			listView.ItemSelected += OnItemSelected;

		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as Transaction;

			if (item != null)
			{
				//Navigation.PushModalAsync(new ViewTicket(item));
			}
		}




	}
}
