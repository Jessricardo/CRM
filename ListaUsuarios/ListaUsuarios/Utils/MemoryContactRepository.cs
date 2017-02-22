﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaUsuarios
{
	public class MemoryContactRepository : IContactRepository
	{
		static List<Contact> contacts;
		static MemoryContactRepository()
		{
			contacts = new List<Contact>();
			contacts.Add(new Contact()
			{
				contactName = "Jose Luis",
				contactStreet = "Random St",
				contactEmail = "some@email.com",
				contactClass = "Contact",
			});
			contacts.Add(new Contact()
			{
				contactName = "Yeratzy Espinoza",
				contactStreet = "Other Random St",
				contactEmail = "someother@email.com",
				contactClass = "Contact",
			});
		}
		public void Crear(Contact c)
		{
			contacts.Add(c);
		}

		public void Delete(Contact c)
		{
			throw new NotImplementedException();
		}

		public List<Contact> Read()
		{
			return contacts;
		}

		public Contact readById(int id)
		{
			return contacts.FirstOrDefault(c => c.contactId == id);
		}

		public void Update(Contact c)
		{
			throw new NotImplementedException();
		}
	}
}