 	using Foundation;
using System;
using UIKit;

namespace ListaUsuarios.iOS
{
    public partial class TableViewController : UITableViewController
    {
        public TableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			tvUsuarios = new UITableView(View.Bounds); // defaults to Plain style
			//string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			//tvUsuarios.Source = new TableSourceViewController(tableItems);
			Add(tvUsuarios);
			tvUsuarios.Source = new TableSourceViewController(tableItems, this);
		}
    }
}