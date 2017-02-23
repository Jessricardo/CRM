using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;
using Android.Views;
using System.Collections.Generic;
using Android.Content;

namespace ListaUsuarios.Droid
{
	[Activity(Label = "Sistema CRM", MainLauncher = true, Icon = "@mipmap/icon")]
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
			list.ItemClick += MyListView_ItemClick;
		}
		void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Intent intento= new Intent(this, typeof(Detalle));
			intento.PutExtra("contacto",contactsItems[e.Position].contactId);
			StartActivity(intento);
		}

	}
}
