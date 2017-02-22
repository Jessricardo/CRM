using System;
namespace ListaUsuarios
{
	//Entity
	public class Contact
	{
		public int contactId{	get;	set;}
		public string contactName {	get;	set;}
		public string contactEmail { get; set; }
		public string contactStreet { get; set; }
		public string contactCellphone { get; set; }
		public string contactClass { get; set; }
		public string contactPicture { get; set; }
		public string contactState { get; set; }
		public string contactCountry { get; set; }
	}

	public class CreateConcat
	{
		public int contactId { get; set; }
		public string contactName { get; set; }
		public string contactEmail { get; set; }
		public string contactStreet { get; set; }
		public string contactCellphone { get; set; }
		public string contactClass { get; set; }
	}
}
