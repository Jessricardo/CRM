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
			//creamos objetos 
			Contact Item = new Contact("Paul", "German", "millan", "6671609241", "paul_millan","direccion","23","M","THE BEST");
			Contact Item2 = new Contact("Abraham", "Gaxiola", "millan", "6671609241", "abraham_gaxiola","direccion","23","M","THE BEST");
			//agregamos a la lista
			tableItems.Add(Item);
			tableItems.Add(Item2);

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