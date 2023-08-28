using TenTec.Windows.iGridLib;

namespace iGrid_DragAndDrop;

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

	#region Designer Fields
	public iGrid fGrid1;
	public iGrid fGrid2;
	#endregion

	private void Form1_Load(object sender, System.EventArgs e)
	{
		PopulateGrid(fGrid1);
		PopulateGrid(fGrid2);

		iGDragAndDropManager.SetupGrid(fGrid1);
		iGDragAndDropManager.SetupGrid(fGrid2);
	}
	private void PopulateGrid(iGrid grid)
	{
		grid.DefaultCol.CellStyle.TextAlign = iGContentAlignment.MiddleCenter;
		grid.Cols.Count = 5;
		grid.Rows.Count = 10;
		foreach (iGCell myCell in grid.Cells)
			myCell.Value = string.Format("{0}\n({1:00},{2:00})", grid.Name, myCell.RowIndex, myCell.ColIndex);
		grid.Cols.AutoWidth();
		grid.Rows.AutoHeight();
	}
    }