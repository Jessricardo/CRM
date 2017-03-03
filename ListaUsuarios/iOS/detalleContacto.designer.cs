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
    [Register ("detalleContacto")]
    partial class detalleContacto
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEditar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNombre { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtApellidoM { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtApellidoP { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCorreo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDireccion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEdad { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNombre { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPuesto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtTelefono { get; set; }

        [Action ("BtnEditar_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnEditar_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnEditar != null) {
                btnEditar.Dispose ();
                btnEditar = null;
            }

            if (lblNombre != null) {
                lblNombre.Dispose ();
                lblNombre = null;
            }

            if (txtApellidoM != null) {
                txtApellidoM.Dispose ();
                txtApellidoM = null;
            }

            if (txtApellidoP != null) {
                txtApellidoP.Dispose ();
                txtApellidoP = null;
            }

            if (txtCorreo != null) {
                txtCorreo.Dispose ();
                txtCorreo = null;
            }

            if (txtDireccion != null) {
                txtDireccion.Dispose ();
                txtDireccion = null;
            }

            if (txtEdad != null) {
                txtEdad.Dispose ();
                txtEdad = null;
            }

            if (txtNombre != null) {
                txtNombre.Dispose ();
                txtNombre = null;
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