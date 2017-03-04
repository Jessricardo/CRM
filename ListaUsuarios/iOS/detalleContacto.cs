using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Xamarin.Forms;

namespace ListaUsuarios.iOS
{
    public partial class detalleContacto : UIViewController
    {
		Contact contacto;

		public int id { set; get;}

        public detalleContacto (IntPtr handle) : base (handle)
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
			contacto=connection.readById(id);
			txtNombre.Text = contacto.contactName;

			txtCorreo.Text =contacto.contactEmail;
			txtPuesto.Text = contacto.contactClass;
			txtDireccion.Text = contacto.contactStreet+contacto.contactState;

			txtTelefono.Text = contacto.contactCellphone;
			//Accion al boton
			btnEditar.TouchUpInside += delegate 
			{
				Contact c1 = new Contact();
				c1.contactName = txtNombre.Text;
				c1.contactCellphone = txtTelefono.Text;
				c1.contactClass = txtPuesto.Text;
				//c1.contactCountry = txt;
				c1.contactEmail = txtCorreo.Text;
				c1.contactStreet = txtDireccion.Text;
				//c1.contactPicture = "";
				//	c1.contactState = ="";
				connection.Update(c1);
			};

		}
    }
}