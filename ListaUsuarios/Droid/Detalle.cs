
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
		IContactRepository repo;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Detalle);
			// Create your application here
			int id = Intent.GetIntExtra("contacto",0);
			if (id > 0)
			{
				Contact contacto = repo.readById(id);
				var nombre = FindViewById<TextView>(Resource.Id.txtNombre);
				var clase = FindViewById<TextView>(Resource.Id.txtClase);
				var telefono = FindViewById<TextView>(Resource.Id.txtNumero);
				nombre.Text = contacto.contactName;
				clase.Text = contacto.contactClass;
				telefono.Text = contacto.contactCellphone;
			}
		}
	}
}
