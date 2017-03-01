using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace ListaUsuarios.iOS
{
    public partial class TableContactViewController : UIViewController
    {
		List<Contact> tableItems = new List<Contact>();

        public TableContactViewController (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// defaults to Plain style
			  //string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			Contact Item = new Contact("Paul", "German", "millan", "6671609241", "");
			Contact Item2 = new Contact("Abraham", "Gaxiola", "millan", "6671609241", "");

			tableItems.Add(Item);
			tableItems.Add(Item2);


			var tvContact = new UITableView
			{
				Frame = new CoreGraphics.CGRect(10, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableSourceViewController(tableItems, this)
			};
			View.AddSubview(tvContact);


		}
    }
}