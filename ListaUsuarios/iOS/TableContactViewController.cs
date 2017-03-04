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

        public TableContactViewController (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//creamos objetos 
			//Contact Item = new Contact("Paul", "German", "millan", "6671609241", "paul_millan","direccion","23","M","THE BEST");
			//Contact Item2 = new Contact("Abraham", "Gaxiola", "millan", "6671609241", "abraham_gaxiola","direccion","23","M","THE BEST");
			//agregamos a la lista
			var fileName = "dbCRM.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, fileName);

			IContactRepository connection = new SQLiteContactRepository(path);
			//tableItems.Add(Item);
			//tableItems.Add(Item2);
			Contact c1 = new Contact();
			c1.contactName = "Paul";
			c1.contactCellphone = "6671609241";
			c1.contactClass = "VIP";
			c1.contactCountry = "Mexico";
			c1.contactEmail = "paul_millan@live.com.mx";
			c1.contactStreet = "sierra san jose";
			c1.contactPicture = "";
			c1.contactState = "Sinaloa";
			connection.Crear(c1);
			tableItems = connection.Read();
			//creamos tableview con sus parametros
			var tvContact = new UITableView
			{
				Frame = new CoreGraphics.CGRect(10, 0, View.Bounds.Width, View.Bounds.Height),
				Source = new TableSourceViewController(tableItems, this)
			};
			View.AddSubview(tvContact);


		}
    }
}