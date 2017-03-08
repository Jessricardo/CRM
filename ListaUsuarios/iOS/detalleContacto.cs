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

			var fileName = "dbCRM.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, fileName);

			IContactRepository connection = new SQLiteContactRepository(path);
			contacto=connection.readById(id);

			txtNombre.Text = contacto.contactName;
			txtCorreo.Text =contacto.contactEmail;
			txtPuesto.Text = contacto.contactClass;
			txtPuesto.Enabled = false;
			txtEdad.Text = "No asignado";
			txtEdad.Hidden = true;
			txtDireccion.Text = contacto.contactStreet;
			txtPais.Text = contacto.contactCountry;
			txtEstado.Text = contacto.contactState;
			txtTelefono.Text = contacto.contactCellphone;

			//Accion al boton
			btnEdi.TouchUpInside += delegate {

				Contact c2 = connection.readById(id);

				c2.contactName = txtNombre.Text;
				c2.contactCellphone = txtTelefono.Text;
				c2.contactClass = txtPuesto.Text;
				c2.contactCountry = txtPais.Text;
				c2.contactEmail = txtCorreo.Text;
				c2.contactStreet = txtDireccion.Text;
				c2.contactState = txtEstado.Text;




				connection.Update(c2);

				UIAlertController okAlertController = UIAlertController.Create("Contacto Editado", txtNombre.Text, UIAlertControllerStyle.Alert);
				okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				this.PresentViewController(okAlertController, true, null);
				this.NavigationController.PopViewController(true);

			};

			btnPromover.TouchUpInside += delegate
			{
				
				Contact c3 = connection.readById(id);
				if (c3.contactClass == "3")
				{
					c3.contactClass = "2";

					UIAlertController okAlertController = UIAlertController.Create("Contacto Promovido", txtNombre.Text, UIAlertControllerStyle.Alert);
					okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
					this.PresentViewController(okAlertController, true, null);
					this.NavigationController.PopViewController(true);
				}

				else if (c3.contactClass == "2")
				{
					c3.contactClass = "1";
					UIAlertController okAlertController = UIAlertController.Create("Contacto Promovido", txtNombre.Text, UIAlertControllerStyle.Alert);
					okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
					this.PresentViewController(okAlertController, true, null);
					this.NavigationController.PopViewController(true);
				}

				else if (c3.contactClass == "1")
				{
					UIAlertController okAlertController = UIAlertController.Create("El usuario no se puede promover porque es nivel 1", txtNombre.Text, UIAlertControllerStyle.Alert);
					okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
					this.PresentViewController(okAlertController, true, null);
				}
				else if (c3.contactClass == "0")
				{
					UIAlertController okAlertController = UIAlertController.Create("El usuario no se puede promover porque ya ha sido descartado", txtNombre.Text, UIAlertControllerStyle.Alert);
					okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
					this.PresentViewController(okAlertController, true, null);
				}
					

				

				connection.Update(c3);



			};

				btndescartar.TouchUpInside += delegate
				{

					Contact c3 = connection.readById(id);
					c3.contactClass = "0";

						connection.Update(c3);

						UIAlertController okAlertController = UIAlertController.Create("Contacto descartado exitosamente", txtNombre.Text, UIAlertControllerStyle.Alert);
						okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
						this.PresentViewController(okAlertController, true, null);
						this.NavigationController.PopViewController(true);

				};


		}
    }
}