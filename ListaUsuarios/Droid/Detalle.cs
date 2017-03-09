
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
		Button btnEliminar, btnActualizar,btnPromover;
		Contact contacto;
		TextView clase;
		EditText nombre, telefono, correo, pais, estado, calle;
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
				clase = FindViewById<TextView>(Resource.Id.edtPuesto);
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
			btnPromover = FindViewById<Button>(Resource.Id.btnPromover);
			btnPromover.Click += Promover;
			btnActualizar.Click += Actualizar;
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

		void Promover(object sender, EventArgs e)
		{
			switch (contacto.contactClass)
			{
				case "1":
					Toast.MakeText(this, "¡No puedes promover más!", ToastLength.Long).Show();
				break;
				case "2":
					contacto.contactClass = "1";
					db.Update(contacto);
					Toast.MakeText(this, "¡Promovido a Cliente!", ToastLength.Long).Show();
					StartActivity(typeof(MainActivity));
				break;
				case "3":
					contacto.contactClass = "2";
					db.Update(contacto);
					Toast.MakeText(this, "¡Promovido a Prospecto!", ToastLength.Long).Show();
					StartActivity(typeof(MainActivity));
				break;
					
			}
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
