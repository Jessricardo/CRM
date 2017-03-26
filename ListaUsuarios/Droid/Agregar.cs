
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace ListaUsuarios.Droid
{
	[Activity(Label = "Agregar")]
	public class Agregar : Activity
	{
        Button btnGuardar;
        IContactRepository db;
        Contact contacto;
		private EditText edtNombre, edtDomicilio, edtCorreo, edtTelefono, edtPais, edtEstado; 
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Agregar);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbCRM.db3");
            db = new SQLiteContactRepository(dbPath);
            contacto = new Contact();

			edtNombre = FindViewById<EditText>(Resource.Id.edtNombre);
			edtPais = FindViewById<EditText>(Resource.Id.edtPais);
			edtDomicilio = FindViewById<EditText>(Resource.Id.edtDomicilio);
			edtCorreo = FindViewById<EditText>(Resource.Id.edtEmail);
			edtTelefono = FindViewById<EditText>(Resource.Id.edtTelefono);
			edtEstado = FindViewById<EditText>(Resource.Id.edtEstado);

            btnGuardar = FindViewById<Button>(Resource.Id.btnGuardar);
            btnGuardar.Click += Guardar;
        }

        private void Guardar(object sender, EventArgs e)
        {
				contacto.contactName = edtNombre.Text;
				contacto.contactCellphone = edtTelefono.Text;
				contacto.contactClass = "3";
				contacto.contactEmail = edtCorreo.Text;
				contacto.contactStreet = edtDomicilio.Text;
				contacto.contactState = edtEstado.Text;
				contacto.contactCountry = edtPais.Text;
                db.Crear(contacto);
                Toast.MakeText(this, "¡Guardado!", ToastLength.Long).Show();
                StartActivity(typeof(MainActivity));
        }
    }
}
