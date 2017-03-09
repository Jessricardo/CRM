
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ListaUsuarios.Droid
{
	[Activity(Label = "Detalles")]
	public class Detalle : Activity
	{
		IContactRepository db;
		Button btnEliminar, btnActualizar;
		Contact contacto;
		EditText nombre, clase, telefono, correo, pais, estado, calle;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Detalle);
			// Create your application here
			int id = Intent.GetIntExtra("contacto",0);
			if (id > 0)
			{
				string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbCRM.db3");
				db = new SQLiteContactRepository(dbPath);
				contacto = db.readById(id);
				nombre = FindViewById<EditText>(Resource.Id.edtNombre);
				clase = FindViewById<EditText>(Resource.Id.edtPuesto);
				telefono = FindViewById<EditText>(Resource.Id.edtTelefono);
				correo = FindViewById<EditText>(Resource.Id.edtCorreo);
				pais = FindViewById<EditText>(Resource.Id.edtPais);
				estado = FindViewById<EditText>(Resource.Id.edtEstado);
				calle = FindViewById<EditText>(Resource.Id.edtCalle);
				nombre.Text = contacto.contactName;
				clase.Text = contacto.contactClass;
				telefono.Text = contacto.contactCellphone;
				correo.Text = contacto.contactEmail;
				pais.Text = contacto.contactCountry;
				estado.Text = contacto.contactState;
				calle.Text = contacto.contactStreet;

			}
			btnEliminar = FindViewById<Button>(Resource.Id.btnEliminar);
			btnActualizar = FindViewById<Button>(Resource.Id.btnEditar);
			btnActualizar.Click += delegate {
				
			};
			btnEliminar.Click += delegate
			{
				AlertDialog.Builder alert = new AlertDialog.Builder(this);
				alert.SetTitle("Eliminar");
				alert.SetMessage("¿Estás seguro(a) de eliminar el contacto?");
				alert.SetPositiveButton("Borrar", (senderAlert, args) =>
				{
					db.Delete(contacto);
					Toast.MakeText(this, "¡Eliminado!", ToastLength.Long).Show();
					StartActivity(typeof(MainActivity));
				});

				alert.SetNegativeButton("Cancelar", (senderAlert, args) =>
				{
				});

				Dialog dialog = alert.Create();
				dialog.Show();

			};

		}
		private void Actualizar(object sender, EventArgs e)
		{
			contacto.contactName = nombre.Text;
			contacto.contactCellphone = telefono.Text;
			contacto.contactClass = clase.Text;
			contacto.contactEmail = correo.Text;
			contacto.contactStreet = calle.Text;
			contacto.contactState = estado.Text;
			contacto.contactCountry = pais.Text;
			db.Update(contacto);
			Toast.MakeText(this, "¡Actualizado!", ToastLength.Long).Show();
			StartActivity(typeof(MainActivity));
		}

}
}
