using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;
using Android.Views;
using System.Collections.Generic;
using Android.Content;
using System.IO;

namespace ListaUsuarios.Droid
{
	[Activity(Label = "Sistema CRM", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity 
	{
		IContactRepository db;
		List<Contact> contactsItems;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbCRM.db3");
            db = new SQLiteContactRepository(dbPath);
            var list = this.FindViewById<ListView>(Resource.Id.list);
            contactsItems = db.Read();
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
