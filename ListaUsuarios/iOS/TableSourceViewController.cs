using System;
using Foundation;
using UIKit;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ListaUsuarios.iOS
{
	public partial class TableSourceViewController : UITableViewSource
	{

	

		List<Contact> TableItems;


		string CellIdentifier = "TableCell";
		UIViewController owner;
		TableSourceViewController owner1;
		public TableSourceViewController(List<Contact> items, UIViewController owner)
		{
			TableItems = items;
			this.owner = owner;


		}
		public TableSourceViewController(List<Contact> items, TableSourceViewController owner1)
		{
			TableItems = items;
			this.owner1 = owner1;


		}
		public void actualizar()
		{
			var table = new UITableView();
			table.Source = new TableSourceViewController(TableItems, this);
			table.ReloadData();
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

			Contact item = TableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			string nombreCompleto = item.contactName;
			cell.TextLabel.Text = nombreCompleto;
			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//UIAlertController okAlertController = UIAlertController.Create("Fila seleccionada", TableItems[indexPath.Row].nombre, UIAlertControllerStyle.Alert);
			//okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			detalleContacto next = owner.Storyboard.InstantiateViewController("detalleContacto") as detalleContacto;
			//Console.WriteLine(">>>"+TableItems[indexPath.Row].nombre);
			next.id = TableItems[indexPath.Row].contactId;
			//next.apellidoP = TableItems[indexPath.Row].apellidoP;
			//next.apellidoM = TableItems[indexPath.Row].apellidoM;
			//next.correo = TableItems[indexPath.Row].correo;
			//next.direccion = TableItems[indexPath.Row].direccion;
			//next.edad = TableItems[indexPath.Row].edad;
			//next.telefono = TableItems[indexPath.Row].telefono;
			//next.puesto = TableItems[indexPath.Row].puesto;
			owner.NavigationController.PushViewController(next,true);
			tableView.DeselectRow(indexPath, true);
			//owner.PresentViewController(okAlertController, true, null);

		}

		public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
		{
			UIAlertController okAlertController = UIAlertController.Create("Contacto seleccionado", TableItems[indexPath.Row].contactName, UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			owner.PresentViewController(okAlertController, true, null);

			tableView.DeselectRow(indexPath, true);
		}



		//borrado con un deslizamiento
		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
		{
			switch (editingStyle)
			{
				case UITableViewCellEditingStyle.Delete:
					// remove the item from the underlying data source
					TableItems.RemoveAt(indexPath.Row);
					// delete the row from the table
					tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
					var fileName = "dbCRM.db3";
					var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					var libraryPath = Path.Combine(documentsPath, "..", "Library");
					var path = Path.Combine(libraryPath, fileName);
					IContactRepository a = new SQLiteContactRepository(path);
					Contact c = TableItems[indexPath.Row];
					a.Delete(c);

				break;
				case UITableViewCellEditingStyle.None:
					Console.WriteLine("Borrar: " + TableItems[indexPath.Row].contactName);
					break;
			}
		}
		public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
		{
			return true; // return false if you wish to disable editing for a specific indexPath or for all rows
		}
		public override string TitleForDeleteConfirmation(UITableView tableView, NSIndexPath indexPath)
		{   // Optional - default text is 'Delete'
			return "Borrar (" + TableItems[indexPath.Row].contactName + ")";
		}

	//	public override UITableViewCellEditingStyle EditingStyleForRow(UITableView
	//	tableView, NSIndexPath indexPath)

	//	{
	//		if (tableView.Editing)
	//		{
	//			if (indexPath.Row == tableView.NumberOfRowsInSection(0) - 1)
	//				return UITableViewCellEditingStyle.Insert;
	//			else
	//				return UITableViewCellEditingStyle.Delete;
	//		}
	//		else // not in editing mode, enable swipe-to-delete for all rows
	//			return UITableViewCellEditingStyle.Delete;
	//	}
	//	public override NSIndexPath CustomizeMoveTarget(UITableView tableView,
	//	NSIndexPath sourceIndexPath, NSIndexPath proposedIndexPath)
	//	{
	//		var numRows = tableView.NumberOfRowsInSection(0) - 1; // less the (add
	//		//new) one
		
	//if (proposedIndexPath.Row >= numRows)
	//			return NSIndexPath.FromRowSection(numRows - 1, 0);
	//		else
	//			return proposedIndexPath;
	//	}
	//	public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
	//	{
	//		return indexPath.Row < tableView.NumberOfRowsInSection(0) - 1;
	//	}
	//	//These two custom methods are used to add and remove the(add new) row when the table’s editing mode is enabled or disabled:
	//		public void WillBeginTableEditing(UITableView tableView)
	//				{
	//					tableView.BeginUpdates();
	//					// insert the 'ADD NEW' row at the end of table display
	//					tableView.InsertRows(new NSIndexPath[] {
	//					NSIndexPath.FromRowSection (tableView.NumberOfRowsInSection (0), 0)
	//				}, UITableViewRowAnimation.Fade);
	//		// create a new item and add it to our underlying data (it is not intended
	//		//to be permanent)
 //   TableItems.Add(new TableItem("(add new)"));
	//		tableView.EndUpdates(); // applies the changes
	//	}
	//	public void DidFinishTableEditing(UITableView tableView)
	//	{
	//		tableView.BeginUpdates();
	//		// remove our 'ADD NEW' row from the underlying data
	//		TableItems.RemoveAt((int)tableView.NumberOfRowsInSection(0) - 1); // zero
	//	//based:)
 //   // remove the row from the table display
	//		    tableView.DeleteRows(new NSIndexPath[] { NSIndexPath.FromRowSection
	//		(tableView.NumberOfRowsInSection (0) - 1, 0) }, UITableViewRowAnimation.Fade);
	//					tableView.EndUpdates(); // applies the changes
	//				}
	//	//Finally, this code instantiates the Edit and Done buttons, with lambdas that enable or disable edit mode when they’re touched:
	//		done = new UIBarButtonItem(UIBarButtonSystemItem.Done, (s, e) =>{
	//		    table.SetEditing (false, true);
	//		    NavigationItem.RightBarButtonItem = edit;
	//		    tableSource.DidFinishTableEditing(table);
	//		});

	//		edit = new UIBarButtonItem(UIBarButtonSystemItem.Edit, (s, e) =>{
	//		    if (table.Editing)
	//		        table.SetEditing (false, true); // if we've half-swiped a row
	//		    tableSource.WillBeginTableEditing(table);
	//		    table.SetEditing (true, true);
	//		    NavigationItem.LeftBarButtonItem = null;
	//		    NavigationItem.RightBarButtonItem = done;
	//		});



	}
}
