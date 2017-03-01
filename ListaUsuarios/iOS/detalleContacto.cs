using Foundation;
using System;
using UIKit;

namespace ListaUsuarios.iOS
{
    public partial class detalleContacto : UIViewController
    {
		public string nombre { set; get;}
        public detalleContacto (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			lblNombreBlanco.Text = nombre;
		}
    }
}