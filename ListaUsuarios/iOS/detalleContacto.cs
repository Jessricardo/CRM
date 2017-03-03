using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Collections;
namespace ListaUsuarios.iOS
{
    public partial class detalleContacto : UIViewController
    {
		Contact contacto;
		public string nombre { set; get;}
		public string apellidoP { set; get; }
		public string apellidoM { set; get; }
		public string correo { set; get; }
		public string telefono { set; get; }
		public string puesto { set; get; }
		public string direccion { set; get; }
		public string edad { set; get; }
        public detalleContacto (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{


			base.ViewDidLoad();
			//lblNombreBlanco.Text = nombre;
			txtNombre.Text = nombre;
			txtApellidoM.Text = apellidoM;
			txtApellidoP.Text = apellidoP;
			txtCorreo.Text =correo;
			txtPuesto.Text = puesto;
			txtDireccion.Text = direccion;
			txtEdad.Text = edad;
			txtTelefono.Text = telefono;
			//Accion al boton
			btnEditar.TouchUpInside += delegate 
			{
				
				
			};

		}
    }
}