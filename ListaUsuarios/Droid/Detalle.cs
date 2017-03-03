
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
		Button btnEliminar;
		Contact contacto;
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
				TextView nombre = FindViewById<TextView>(Resource.Id.txtNombre);
				TextView clase = FindViewById<TextView>(Resource.Id.txtClase);
				TextView telefono = FindViewById<TextView>(Resource.Id.txtNumero);
				nombre.Text = contacto.contactName;
				clase.Text = contacto.contactClass;
				telefono.Text = contacto.contactCellphone;

			}
			btnEliminar = FindViewById<Button>(Resource.Id.btnEliminar);
			btnEliminar.Click += delegate
			{
				db.Delete(contacto);
				Toast.MakeText(this, "¡Eliminado!", ToastLength.Long).Show();
				StartActivity(typeof(MainActivity));
			};
		}

}
}
