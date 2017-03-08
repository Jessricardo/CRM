using Foundation;
using System;
using UIKit;
using System.IO;
using System.Collections.Generic;

namespace ListaUsuarios.iOS
{
    public partial class addViewController : UIViewController
    {

		public int id { set; get; }
		public List<Contact> TableItems { set; get;}
		Contact contacto;

        public addViewController (IntPtr handle) : base (handle)
        {
			
        }
		public override void ViewDidLoad()
		{


			base.ViewDidLoad();
			//lblNombreBlanco.Text = nombre;
			var fileName = "dbCRM.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, fileName);

			IContactRepository connection = new SQLiteContactRepository(path);
			//contacto = connection.readById(id);
			txtEdad.Hidden = true;
			//Accion al boton
			btnAddDetalle.TouchUpInside += delegate {

				Contact c1 = new Contact();
				c1.contactName = txtNombre.Text;
				c1.contactCellphone = txtTelefono.Text;
				c1.contactClass = "3";
				c1.contactEmail = txtCorreo.Text;
				c1.contactStreet = txtDireccion.Text;
				c1.contactState = txtEstado.Text;
				c1.contactCountry = txtPais.Text;
				connection.Crear(c1);
				UIAlertController okAlertController = UIAlertController.Create("Contacto Agregado", txtNombre.Text,UIAlertControllerStyle.Alert);
				okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				this.PresentViewController(okAlertController, true, null);
				this.NavigationController.PopViewController(true);
			
			};



		}
    }
}