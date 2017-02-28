 	using Foundation;
using System;
using UIKit;
using System.Collections;
using System.Collections.Generic;
namespace ListaUsuarios.iOS
{
    public partial class TableViewController : UITableViewController
    {
		List<Contact> tableItems = new List<Contact>();

        public TableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			tvUsuarios = new UITableView(View.Bounds); // defaults to Plain style
													   //string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			Contact Item = new Contact("Paul","German","millan","6671609241");
			Contact Item2 = new Contact("Abraham", "Gaxiola", "millan", "6671609241");

			tableItems.Add(Item);
			tableItems.Add(Item2);
			tvUsuarios.Source = new TableSourceViewController(tableItems, this);
			Add(tvUsuarios);
			//tvUsuarios.Source = new TableSourceViewController(tableItems, this);
		}
    }
}