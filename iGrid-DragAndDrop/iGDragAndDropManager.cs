using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenTec.Windows.iGridLib;

namespace iGrid_DragAndDrop;

    public class iGDragAndDropManager
    {
	/// <summary>
	/// The constant that is stored in the Tag property 
	/// of a grid to indicate that the left mouse button 
	/// was pressed over one of its cells.
	/// </summary>
	private const string cPressed = "Pressed";

	/// <summary>
	/// Stores the cell under the mouse pointer.
	/// Valuable only when dragging.
	/// </summary>
	private static iGCell fCellToDrop;

	/// <summary>
	/// Stores the grid which cell is being dragged at 
	/// the moment.
	/// </summary>
	private static iGrid fDragSourceGrid;

	private iGDragAndDropManager() { }

	public static void SetupGrid(iGrid grid)
	{
		grid.Header.Visible = false;

		#region Implement start of dragging
		grid.CellMouseDown += new iGCellMouseDownEventHandler(grid_CellMouseDown);
		grid.CellMouseMove += new iGCellMouseMoveEventHandler(grid_CellMouseMove);
		grid.CellMouseUp += new iGCellMouseUpEventHandler(grid_CellMouseUp);
		grid.CellMouseLeave += new iGCellMouseEnterLeaveEventHandler(grid_CellMouseLeave);
		#endregion

		#region Implement dropping
		grid.AllowDrop = true;
		grid.DragDrop += new DragEventHandler(grid_DragDrop);
		grid.DragOver += new DragEventHandler(grid_DragOver);
		grid.DragLeave += new EventHandler(grid_DragLeave);
		#endregion
	}

	private static void grid_CellMouseDown(object sender, iGCellMouseDownEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			#region Mark the grid that the left mouse button is pressed over one of its cells
			(sender as iGrid).Tag = cPressed;
			#endregion
		}
	}

	private static void grid_CellMouseMove(object sender, iGCellMouseMoveEventArgs e)
	{
		iGrid myGrid = sender as iGrid;

		// If the left mouse button has been pressed over one of the grid's cells.
		if (myGrid != null && object.ReferenceEquals(myGrid.Tag, cPressed))
		{
			iGCell myCell = myGrid.Cells[e.RowIndex, e.ColIndex];

			// If the mouse pointer is out of the pressed cell.
			if (!myCell.Bounds.Contains(e.MousePos))
			{
				#region Start dragging
				fDragSourceGrid = myGrid;
				fCellToDrop = null;
				myGrid.DoDragDrop(myCell.Value, DragDropEffects.Copy);
				#endregion
			}
		}
	}

	private static void grid_CellMouseUp(object sender, iGCellMouseUpEventArgs e)
	{
		#region Clear the mark about that the left mouse button was pressed over one of the grid's cells
		iGrid myGrid = sender as iGrid;
		myGrid.Tag = null;
		#endregion
	}

	private static void grid_CellMouseLeave(object sender, iGCellMouseEnterLeaveEventArgs e)
	{
		#region Clear the mark about that the left mouse button was pressed over one of the grid's cells
		iGrid myGrid = sender as iGrid;
		myGrid.Tag = null;
		#endregion
	}

	private static void grid_DragOver(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Text))
		{
			iGrid myGrid = sender as iGrid;
			if (myGrid != null)
			{
				#region Get the cell under the mouse pointer if any
				Point myPoint = new Point(e.X, e.Y);
				myPoint = myGrid.PointToClient(myPoint);
				fCellToDrop = myGrid.Cells.FromPoint(myPoint.X, myPoint.Y);
				#endregion

				if (fCellToDrop != null && fDragSourceGrid != myGrid)
				{
					#region Enable the drop operation
					fCellToDrop.Selected = true;
					e.Effect = DragDropEffects.Copy;
					return;
					#endregion
				}
			}
		}

		#region Disable the drop operation
		fCellToDrop = null;
		e.Effect = DragDropEffects.None;
		#endregion
	}

	private static void grid_DragDrop(object sender, DragEventArgs e)
	{
		if (fCellToDrop != null)
		{
			#region Drop
			fCellToDrop.Value = e.Data.GetData(DataFormats.Text).ToString();
			#endregion
		}
	}

	private static void grid_DragLeave(object sender, EventArgs e)
	{
		fCellToDrop = null;
	}
}
