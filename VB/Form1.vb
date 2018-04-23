Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraVerticalGrid

Namespace TabOffFromLastRow
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private textEdit1 As DevExpress.XtraEditors.TextEdit
		Private WithEvents vGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
		Private textEdit2 As DevExpress.XtraEditors.TextEdit
		Private editorRow1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
		Private editorRow2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
		Private editorRow3 As DevExpress.XtraVerticalGrid.Rows.EditorRow
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.textEdit1 = New DevExpress.XtraEditors.TextEdit()
			Me.vGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
			Me.editorRow1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
			Me.editorRow2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
			Me.editorRow3 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
			Me.textEdit2 = New DevExpress.XtraEditors.TextEdit()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' textEdit1
			' 
			Me.textEdit1.EditValue = "textEdit1"
			Me.textEdit1.Location = New System.Drawing.Point(13, 7)
			Me.textEdit1.Name = "textEdit1"
			Me.textEdit1.Size = New System.Drawing.Size(94, 20)
			Me.textEdit1.TabIndex = 0
			' 
			' vGridControl1
			' 
			Me.vGridControl1.Location = New System.Drawing.Point(13, 35)
			Me.vGridControl1.Name = "vGridControl1"
			Me.vGridControl1.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() { Me.editorRow1, Me.editorRow2, Me.editorRow3})
			Me.vGridControl1.Size = New System.Drawing.Size(207, 208)
			Me.vGridControl1.TabIndex = 1
'			Me.vGridControl1.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.vGridControl1_KeyDown);
'			Me.vGridControl1.EditorKeyDown += New System.Windows.Forms.KeyEventHandler(Me.vGridControl1_KeyDown);
			' 
			' editorRow1
			' 
			Me.editorRow1.Name = "editorRow1"
			Me.editorRow1.Properties.Caption = "Row 1"
			Me.editorRow1.Properties.Value = "Value 1"
			' 
			' editorRow2
			' 
			Me.editorRow2.Name = "editorRow2"
			Me.editorRow2.Properties.Caption = "Row 2"
			Me.editorRow2.Properties.Value = "Value 2"
			' 
			' editorRow3
			' 
			Me.editorRow3.Name = "editorRow3"
			Me.editorRow3.Properties.Caption = "Row 3"
			Me.editorRow3.Properties.Value = "Value 3"
			' 
			' textEdit2
			' 
			Me.textEdit2.EditValue = "textEdit2"
			Me.textEdit2.Location = New System.Drawing.Point(13, 250)
			Me.textEdit2.Name = "textEdit2"
			Me.textEdit2.Size = New System.Drawing.Size(94, 20)
			Me.textEdit2.TabIndex = 2
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(120, 250)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(93, 20)
			Me.simpleButton1.TabIndex = 3
			Me.simpleButton1.Text = "Customize..."
'			Me.simpleButton1.Click += New System.EventHandler(Me.simpleButton1_Click);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(280, 325)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.textEdit2)
			Me.Controls.Add(Me.vGridControl1)
			Me.Controls.Add(Me.textEdit1)
			Me.Name = "Form1"
			Me.Text = "How to move focus from the last row to the first row when the Tab key is pressed"
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.vGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub vGridControl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles vGridControl1.KeyDown, vGridControl1.EditorKeyDown
			Dim grid As VGridControl = vGridControl1
            If e.KeyData = Keys.Tab AndAlso grid.FocusedRow Is grid.GetLastVisible() Then
                Dim needShowEditor As Boolean = (grid.State = VGridState.Editing)
                grid.FocusedRow = grid.Rows.FirstVisible
                If needShowEditor Then
                    grid.ShowEditor()
                End If
                'SelectNextControl(grid, true, true, false, true);
                e.Handled = True
            End If
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpleButton1.Click
			vGridControl1.RowsCustomization()
		End Sub
	End Class
End Namespace
