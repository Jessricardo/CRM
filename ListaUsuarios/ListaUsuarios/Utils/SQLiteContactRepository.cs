using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

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
		}
		public void Crear(Contact c)
		{
			throw new NotImplementedException();
		}

		public void Delete(Contact c)
		{
			throw new NotImplementedException();
		}

		public List<Contact> Read()
		{
			//var table = db.Table<Contacto>();
			//return table.Select(c => c).ToList();
			throw new NotImplementedException();
		}

		public Contact readById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Contact c)
		{
			throw new NotImplementedException();
		}
	}
}
