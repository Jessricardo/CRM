using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;
using Android.Views;
using System.Collections.Generic;

namespace ListaUsuarios.Droid
{
	[Activity(Label = "ListaUsuarios", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity 
	{
		IContactRepository contacts;
		List<Contact> contactsItems;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			var list = this.FindViewById<ListView>(Resource.Id.list);
			contacts = new MemoryContactRepository();
			contactsItems = contacts.Read();
			list.Adapter = new ContactsAdapter(this, contactsItems);

		}


	}
}
