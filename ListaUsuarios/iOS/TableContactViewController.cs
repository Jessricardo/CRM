using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.IO;

namespace ListaUsuarios.iOS
{
    public partial class TableContactViewController : UIViewController
    {
		List<Contact> tableItems;
		UIViewController owner;
		UITableView tvContact;
        public TableContactViewController (IntPtr handle) : base (handle)
        {
        }
		public TableContactViewController(UIViewController owner) { this.owner = owner; }
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			var fileName = "dbCRM.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, fileName);

			IContactRepository connection = new SQLiteContactRepository(path);

			List <Contact> tableUpdated = connection.Read();
			//creamos tableview con sus parametros
			tvContact.Source = new TableSourceViewController(tableUpdated, this);
			tvContact.ReloadData();


		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var fileName = "dbCRM.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, fileName);

			IContactRepository connection = new SQLiteContactRepository(path);
			tableItems = connection.Read();
			tvContact = new UITableView
			{
				Frame = new CoreGraphics.CGRect(10, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableSourceViewController(tableItems, this)
			};
			View.AddSubview(tvContact);
			btnAdd.TouchUpInside += delegate
			{
				addViewController next = this.Storyboard.InstantiateViewController("addViewController") as addViewController;
				//	next.id = tableItems[0].contactId;
				this.NavigationController.PushViewController(next, true);
				//tableView.DeselectRow(indexPath, true);
				//owner.PresentViewController(okAlertController, true, null)
			};


		}
    }
}