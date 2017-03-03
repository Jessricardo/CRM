
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
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Agregar);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbCRM.db3");
            db = new SQLiteContactRepository(dbPath);
            contacto = new Contact();
            btnGuardar = FindViewById<Button>(Resource.Id.btnGuardar);
            btnGuardar.Click += Guardar;
        }

        private void Guardar(object sender, EventArgs e)
        {
                db.Crear(contacto);
                Toast.MakeText(this, "¡Guardado!", ToastLength.Long).Show();
                StartActivity(typeof(MainActivity));
        }
    }
}
