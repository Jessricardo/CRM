using System;
using System.IO;
using System.Collections.Generic;
using SQLite;
using System.Linq;

namespace ListaUsuarios
{
	public class SQLiteContactRepository : IContactRepository
	{
		private string PATH;
		private SQLiteConnection db;
		public SQLiteContactRepository(string path)
		{
            PATH = path;
            db = new SQLiteConnection(PATH);
            db.CreateTable<Contact>();
        }
		public void Crear(Contact c)
		{
            db.Insert(c);
		}

		public void Delete(Contact c)
		{
			db.Delete<Contact>(c.contactId);
		}

		public List<Contact> Read()
		{
			var table = db.Table<Contact>();
			return table.Select(c => c).ToList();
		}

		public Contact readById(int id)
		{
			return db.Table<Contact>().FirstOrDefault(t => t.contactId == id);
		}

		public void Update(Contact c) 
		{
			db.Update(c);
		}
	}
}
