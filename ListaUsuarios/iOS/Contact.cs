using System;
namespace ListaUsuarios.iOS
{
	public class Contact
	{
		public Contact(string nombre, string apellidoP, string apellidoM, string telefono, string correo,
		               string direccion, string edad, string genero, string puesto)
		{
			this.nombre = nombre;
			this.apellidoM = apellidoM;
			this.apellidoP = apellidoP;
			this.telefono = telefono;
			this.correo = correo;
			this.direccion = direccion;
			this.edad = edad;
			this.puesto = puesto;
			this.genero = genero;

		}

		public string nombre { get; set;}
		public string apellidoP { get; set; }
		public string apellidoM { get; set; }
		public string telefono { get; set; }
		public string correo { get; set; }
		public string direccion { get; set; }
		public string edad { get; set; }
		public string genero { get; set; }
		public string puesto { get; set; }
	}
}
