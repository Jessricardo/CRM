// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ListaUsuarios.iOS
{
    [Register ("addViewController")]
    partial class addViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAddDetalle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCorreo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDireccion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEstado { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNombre { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPais { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPuesto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtTelefono { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddDetalle != null) {
                btnAddDetalle.Dispose ();
                btnAddDetalle = null;
            }

            if (txtCorreo != null) {
                txtCorreo.Dispose ();
                txtCorreo = null;
            }

            if (txtDireccion != null) {
                txtDireccion.Dispose ();
                txtDireccion = null;
            }

            if (txtEstado != null) {
                txtEstado.Dispose ();
                txtEstado = null;
            }

            if (txtNombre != null) {
                txtNombre.Dispose ();
                txtNombre = null;
            }

            if (txtPais != null) {
                txtPais.Dispose ();
                txtPais = null;
            }

            if (txtPuesto != null) {
                txtPuesto.Dispose ();
                txtPuesto = null;
            }

            if (txtTelefono != null) {
                txtTelefono.Dispose ();
                txtTelefono = null;
            }
        }
    }
}