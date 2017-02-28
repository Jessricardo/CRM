using System;
namespace ListaUsuarios.iOS
{
	public class Contact
	{
		public Contact(string nombre, string apellidoP, string apellidoM, string telefono)
		{
			this.nombre = nombre;
			this.apellidoM = apellidoM;
			this.apellidoP = apellidoP;
			this.telefono = telefono;
		}

		public string nombre { get; set;}
		public string apellidoP { get; set; }
		public string apellidoM { get; set; }
		public string telefono { get; set; }
	}
}
