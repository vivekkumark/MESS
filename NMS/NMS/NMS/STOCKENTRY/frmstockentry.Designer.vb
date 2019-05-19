<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmstockentry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.gridstock = New System.Windows.Forms.DataGridView()
            Me.itemid = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
            Me.butaddrow = New System.Windows.Forms.Button()
            Me.butclear = New System.Windows.Forms.Button()
            Me.butclose = New System.Windows.Forms.Button()
            Me.butupdate = New System.Windows.Forms.Button()
            Me.lblmsg = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.listtotalitems = New System.Windows.Forms.ListBox()
            CType(Me.gridstock, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'gridstock
            '
            Me.gridstock.AllowUserToAddRows = False
            Me.gridstock.AllowUserToDeleteRows = False
            Me.gridstock.AllowUserToResizeColumns = False
            Me.gridstock.AllowUserToResizeRows = False
            Me.gridstock.BackgroundColor = System.Drawing.Color.White
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.gridstock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
            Me.gridstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.gridstock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemid, Me.itemname, Me.qty})
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle11.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.gridstock.DefaultCellStyle = DataGridViewCellStyle11
            Me.gridstock.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridstock.Location = New System.Drawing.Point(233, 3)
            Me.gridstock.Name = "gridstock"
            Me.gridstock.RowHeadersVisible = False
            DataGridViewCellStyle12.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gridstock.RowsDefaultCellStyle = DataGridViewCellStyle12
            Me.TableLayoutPanel1.SetRowSpan(Me.gridstock, 2)
            Me.gridstock.RowTemplate.Height = 35
            Me.gridstock.Size = New System.Drawing.Size(548, 465)
            Me.gridstock.TabIndex = 9
            '
            'itemid
            '
            Me.itemid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.itemid.DefaultCellStyle = DataGridViewCellStyle8
            Me.itemid.HeaderText = "ITEM ID"
            Me.itemid.Name = "itemid"
            Me.itemid.ReadOnly = True
            Me.itemid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.itemid.Visible = False
            '
            'itemname
            '
            Me.itemname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.itemname.DefaultCellStyle = DataGridViewCellStyle9
            Me.itemname.HeaderText = "ITEM NAME"
            Me.itemname.Name = "itemname"
            Me.itemname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'qty
            '
            Me.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.qty.DefaultCellStyle = DataGridViewCellStyle10
            Me.qty.HeaderText = "QTY"
            Me.qty.Name = "qty"
            Me.qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.gridstock, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.listtotalitems, 0, 1)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 562)
            Me.TableLayoutPanel1.TabIndex = 10
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 4
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.43396!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.56604!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.butclose, 3, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.butupdate, 2, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblmsg, 2, 1)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(233, 474)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 2
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(548, 85)
            Me.TableLayoutPanel2.TabIndex = 10
            '
            'TableLayoutPanel3
            '
            Me.TableLayoutPanel3.ColumnCount = 1
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.Controls.Add(Me.butaddrow, 0, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.butclear, 0, 1)
            Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 2
            Me.TableLayoutPanel2.SetRowSpan(Me.TableLayoutPanel3, 2)
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.Size = New System.Drawing.Size(129, 79)
            Me.TableLayoutPanel3.TabIndex = 2
            '
            'butaddrow
            '
            Me.butaddrow.Dock = System.Windows.Forms.DockStyle.Fill
            Me.butaddrow.Location = New System.Drawing.Point(3, 3)
            Me.butaddrow.Name = "butaddrow"
            Me.butaddrow.Size = New System.Drawing.Size(123, 33)
            Me.butaddrow.TabIndex = 0
            Me.butaddrow.Text = "ADD ROW"
            Me.butaddrow.UseVisualStyleBackColor = True
            '
            'butclear
            '
            Me.butclear.Dock = System.Windows.Forms.DockStyle.Fill
            Me.butclear.Location = New System.Drawing.Point(3, 42)
            Me.butclear.Name = "butclear"
            Me.butclear.Size = New System.Drawing.Size(123, 34)
            Me.butclear.TabIndex = 1
            Me.butclear.Text = "CLEAR"
            Me.butclear.UseVisualStyleBackColor = True
            '
            'butclose
            '
            Me.butclose.Dock = System.Windows.Forms.DockStyle.Fill
            Me.butclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butclose.ForeColor = System.Drawing.Color.Maroon
            Me.butclose.Location = New System.Drawing.Point(413, 3)
            Me.butclose.Name = "butclose"
            Me.butclose.Size = New System.Drawing.Size(132, 57)
            Me.butclose.TabIndex = 1
            Me.butclose.Text = "CLOSE"
            Me.butclose.UseVisualStyleBackColor = True
            '
            'butupdate
            '
            Me.butupdate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.butupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butupdate.ForeColor = System.Drawing.Color.Green
            Me.butupdate.Location = New System.Drawing.Point(276, 3)
            Me.butupdate.Name = "butupdate"
            Me.butupdate.Size = New System.Drawing.Size(131, 57)
            Me.butupdate.TabIndex = 0
            Me.butupdate.Text = "UPDATE STOCK"
            Me.butupdate.UseVisualStyleBackColor = True
            '
            'lblmsg
            '
            Me.lblmsg.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lblmsg.AutoSize = True
            Me.TableLayoutPanel2.SetColumnSpan(Me.lblmsg, 2)
            Me.lblmsg.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblmsg.Location = New System.Drawing.Point(386, 66)
            Me.lblmsg.Name = "lblmsg"
            Me.lblmsg.Size = New System.Drawing.Size(49, 16)
            Me.lblmsg.TabIndex = 3
            Me.lblmsg.Text = "lblmsg"
            Me.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(70, 4)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(89, 16)
            Me.Label1.TabIndex = 11
            Me.Label1.Text = "TOTAL ITEMS"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'listtotalitems
            '
            Me.listtotalitems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.listtotalitems.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.listtotalitems.FormattingEnabled = True
            Me.listtotalitems.ItemHeight = 16
            Me.listtotalitems.Location = New System.Drawing.Point(3, 28)
            Me.listtotalitems.Name = "listtotalitems"
            Me.listtotalitems.Size = New System.Drawing.Size(224, 440)
            Me.listtotalitems.TabIndex = 12
            '
            'frmstockentry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 562)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "frmstockentry"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "STOCK ENTRY"
            CType(Me.gridstock, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.ResumeLayout(False)

      End Sub
      Friend WithEvents gridstock As System.Windows.Forms.DataGridView
      Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents butupdate As System.Windows.Forms.Button
      Friend WithEvents butclose As System.Windows.Forms.Button
      Friend WithEvents butaddrow As System.Windows.Forms.Button
      Friend WithEvents butclear As System.Windows.Forms.Button
      Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents listtotalitems As System.Windows.Forms.ListBox
      Friend WithEvents itemid As System.Windows.Forms.DataGridViewTextBoxColumn
      Friend WithEvents itemname As System.Windows.Forms.DataGridViewTextBoxColumn
      Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
      Friend WithEvents lblmsg As System.Windows.Forms.Label
End Class
