using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Android.App;
using Android.Views;
using Android.Widget;

namespace ListaUsuarios.Droid
{
	public class ContactsAdapter : BaseAdapter<Contact>
	{
		List<Contact> items;
		Activity context;

		public ContactsAdapter(Activity context, List<Contact> items)
		{
			this.context = context;
			this.items = items;
		}

		public override Contact this[int position]
		{
			get
			{
				return items[position];
			}
		}

		public override int Count
		{
			get
			{
				return items.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null) 
				view = context.LayoutInflater.Inflate(Resource.Layout.SingleContactView, null);
		
			view.FindViewById<TextView>(Resource.Id.textView_contact_name).Text = items[position].contactName;
			return view;
		}

	}
}
