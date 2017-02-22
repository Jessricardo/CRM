using System;
using System.Collections.Generic;

namespace ListaUsuarios
{
	public interface IContactRepository
	{
		void Crear(Contact c);
		Contact readById(int id);
		List<Contact> Read();
		void Update(Contact c);
		void Delete(Contact c);

	}
}
