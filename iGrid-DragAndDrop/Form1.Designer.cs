namespace iGrid_DragAndDrop;

    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

	#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		this.fGrid1 = new TenTec.Windows.iGridLib.iGrid();
		this.fGrid2 = new TenTec.Windows.iGridLib.iGrid();
		((System.ComponentModel.ISupportInitialize)(this.fGrid1)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.fGrid2)).BeginInit();
		this.SuspendLayout();
		// 
		// fGrid1
		// 
		this.fGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.fGrid1.Location = new System.Drawing.Point(0, 0);
		this.fGrid1.Name = "fGrid1";
		this.fGrid1.Size = new System.Drawing.Size(245, 327);
		this.fGrid1.TabIndex = 0;
		// 
		// fGrid2
		// 
		this.fGrid2.Dock = System.Windows.Forms.DockStyle.Right;
		this.fGrid2.Location = new System.Drawing.Point(245, 0);
		this.fGrid2.Name = "fGrid2";
		this.fGrid2.Size = new System.Drawing.Size(245, 327);
		this.fGrid2.TabIndex = 1;
		// 
		// Form1
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(490, 327);
		this.Controls.Add(this.fGrid1);
		this.Controls.Add(this.fGrid2);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Name = "Form1";
		this.Text = "Form1";
		this.Load += new System.EventHandler(this.Form1_Load);
		((System.ComponentModel.ISupportInitialize)(this.fGrid1)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.fGrid2)).EndInit();
		this.ResumeLayout(false);

	}
	#endregion

}