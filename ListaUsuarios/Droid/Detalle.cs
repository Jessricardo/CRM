
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

namespace ListaUsuarios.Droid
{
	[Activity(Label = "Detalles")]
	public class Detalle : Activity
	{
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Detalle);
			// Create your application here
			int id = Intent.GetIntExtra("contacto",0);
			if (id > 0)
			{
				MemoryContactRepository repo = new MemoryContactRepository();
				Contact contacto = repo.readById(id);
				TextView nombre = FindViewById<TextView>(Resource.Id.txtNombre);
				TextView clase = FindViewById<TextView>(Resource.Id.txtClase);
				TextView telefono = FindViewById<TextView>(Resource.Id.txtNumero);
				nombre.Text = contacto.contactName;
				clase.Text = contacto.contactClass;
				telefono.Text = contacto.contactCellphone;
			}
		}
	}
}
