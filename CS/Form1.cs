using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraVerticalGrid;

namespace TabOffFromLastRow
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
		private DevExpress.XtraEditors.TextEdit textEdit2;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow1;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow2;
		private DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow3;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.editorRow1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.editorRow2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.editorRow3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "textEdit1";
            this.textEdit1.Location = new System.Drawing.Point(13, 7);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(94, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Location = new System.Drawing.Point(13, 35);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.editorRow1,
            this.editorRow2,
            this.editorRow3});
            this.vGridControl1.Size = new System.Drawing.Size(207, 208);
            this.vGridControl1.TabIndex = 1;
            this.vGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vGridControl1_KeyDown);
            this.vGridControl1.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.vGridControl1_KeyDown);
            // 
            // editorRow1
            // 
            this.editorRow1.Name = "editorRow1";
            this.editorRow1.Properties.Caption = "Row 1";
            this.editorRow1.Properties.Value = "Value 1";
            // 
            // editorRow2
            // 
            this.editorRow2.Name = "editorRow2";
            this.editorRow2.Properties.Caption = "Row 2";
            this.editorRow2.Properties.Value = "Value 2";
            // 
            // editorRow3
            // 
            this.editorRow3.Name = "editorRow3";
            this.editorRow3.Properties.Caption = "Row 3";
            this.editorRow3.Properties.Value = "Value 3";
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "textEdit2";
            this.textEdit2.Location = new System.Drawing.Point(13, 250);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(94, 20);
            this.textEdit2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(120, 250);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(93, 20);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Customize...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(280, 325);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.textEdit1);
            this.Name = "Form1";
            this.Text = "How to move focus from the last row to the first row when the Tab key is pressed";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void vGridControl1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			VGridControl grid = vGridControl1;
			if(e.KeyData == Keys.Tab && grid.FocusedRow == grid.GetLastVisible()) {
				bool needShowEditor = (grid.State == VGridState.Editing);
				grid.FocusedRow = grid.Rows.FirstVisible;
				if(needShowEditor) grid.ShowEditor();
				//SelectNextControl(grid, true, true, false, true);
				e.Handled = true;
			}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e) {
			vGridControl1.RowsCustomization();
		}
	}
}
