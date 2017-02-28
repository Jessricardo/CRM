﻿using System;
using Foundation;
using UIKit;
using System.Collections;
using System.Collections.Generic;

namespace ListaUsuarios.iOS
{
	public partial class TableSourceViewController : UITableViewSource
	{

	

		List<Contact> TableItems;


		string CellIdentifier = "TableCell";
		TableViewController owner;
		public TableSourceViewController(List<Contact> items, TableViewController owner)
		{
			TableItems = items;
			this.owner = owner;


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

			string nombreCompleto = item.nombre + " " + item.apellidoP;
			cell.TextLabel.Text = nombreCompleto;
			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			UIAlertController okAlertController = UIAlertController.Create("Fila seleccionada", TableItems[indexPath.Row].nombre, UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

			tableView.DeselectRow(indexPath, true);
			owner.PresentViewController(okAlertController, true, null);

		}

		public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
		{
			UIAlertController okAlertController = UIAlertController.Create("Contacto seleccionado", TableItems[indexPath.Row].nombre, UIAlertControllerStyle.Alert);
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
					break;
				case UITableViewCellEditingStyle.None:
					Console.WriteLine("Borrar: " + TableItems[indexPath.Row].nombre);
					break;
			}
		}
		public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
		{
			return true; // return false if you wish to disable editing for a specific indexPath or for all rows
		}
		public override string TitleForDeleteConfirmation(UITableView tableView, NSIndexPath indexPath)
		{   // Optional - default text is 'Delete'
			return "Borrar (" + TableItems[indexPath.Row].nombre + ")";
		}



	}
}