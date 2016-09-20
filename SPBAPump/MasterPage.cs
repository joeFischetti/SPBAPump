using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SPBAPump
{

    public class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        ListView listView;

        Label header = new Label
        {
            Text = "SPBA",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            HorizontalOptions = LayoutOptions.Start
        };




        public MasterPage()
        {

            var masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Title = "My Profile",
                IconSource = "ic_tag_faces_white_24dp.png",
                TargetType = typeof(DetailPage)
            });
            
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Transaction History",
				IconSource = "ic_tag_faces_white_24dp.png",
				TargetType = typeof(TransactionPage)
			});

            masterPageItems.Add(new MasterPageItem
            {
                Title = "About",
                IconSource = "ic_help_white_24dp.png",
                TargetType = typeof(AboutPage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Contact",
                IconSource = "ic_chat_white_24dp.png",
                TargetType = typeof(ContactPage)
            });

            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetValue(TextCell.TextColorProperty, Color.Black);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };


            Padding = new Thickness(0, 40, 0, 0);
            Icon = "hamburger.png";
            Title = "SPBA Member App";
            this.BackgroundColor = Color.Gray;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {header,
                listView}

            };
        }
    }
}
