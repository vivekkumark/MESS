<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrreport
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblmsg = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.picbox = New System.Windows.Forms.PictureBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblroomno = New System.Windows.Forms.Label()
            Me.txtpgpid = New System.Windows.Forms.TextBox()
            Me.lblname = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
            Me.dtpto = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.butthismonth = New System.Windows.Forms.Button()
            Me.chkall = New System.Windows.Forms.CheckBox()
            Me.buttoday = New System.Windows.Forms.Button()
            Me.butexport = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.butindreport = New System.Windows.Forms.Button()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.butexportindreport_row = New System.Windows.Forms.Button()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.picbox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 385.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.lblmsg, 2, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpfrom, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpto, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.butthismonth, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.chkall, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.buttoday, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.butexport, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 2, 7)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 9
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.30605!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 562)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'lblmsg
            '
            Me.lblmsg.AutoSize = True
            Me.lblmsg.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblmsg.ForeColor = System.Drawing.Color.Red
            Me.lblmsg.Location = New System.Drawing.Point(587, 428)
            Me.lblmsg.Name = "lblmsg"
            Me.lblmsg.Size = New System.Drawing.Size(53, 19)
            Me.lblmsg.TabIndex = 22
            Me.lblmsg.Text = "lblmsg"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.picbox)
            Me.GroupBox1.Controls.Add(Me.Label5)
            Me.GroupBox1.Controls.Add(Me.lblroomno)
            Me.GroupBox1.Controls.Add(Me.txtpgpid)
            Me.GroupBox1.Controls.Add(Me.lblname)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(202, 270)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(379, 155)
            Me.GroupBox1.TabIndex = 10
            Me.GroupBox1.TabStop = False
            '
            'picbox
            '
            Me.picbox.ImageLocation = ""
            Me.picbox.Location = New System.Drawing.Point(241, 9)
            Me.picbox.Name = "picbox"
            Me.picbox.Size = New System.Drawing.Size(138, 141)
            Me.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.picbox.TabIndex = 4
            Me.picbox.TabStop = False
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(29, 26)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(51, 19)
            Me.Label5.TabIndex = 1
            Me.Label5.Text = "PGPID"
            '
            'lblroomno
            '
            Me.lblroomno.AutoSize = True
            Me.lblroomno.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblroomno.ForeColor = System.Drawing.Color.Black
            Me.lblroomno.Location = New System.Drawing.Point(6, 116)
            Me.lblroomno.Name = "lblroomno"
            Me.lblroomno.Size = New System.Drawing.Size(82, 18)
            Me.lblroomno.TabIndex = 2
            Me.lblroomno.Text = "ROOM NO : "
            '
            'txtpgpid
            '
            Me.txtpgpid.AutoCompleteCustomSource.AddRange(New String() {"PGP", "ABM", "FPM"})
            Me.txtpgpid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.txtpgpid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
            Me.txtpgpid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtpgpid.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtpgpid.ForeColor = System.Drawing.Color.Red
            Me.txtpgpid.Location = New System.Drawing.Point(86, 19)
            Me.txtpgpid.Name = "txtpgpid"
            Me.txtpgpid.Size = New System.Drawing.Size(151, 29)
            Me.txtpgpid.TabIndex = 0
            '
            'lblname
            '
            Me.lblname.AutoSize = True
            Me.lblname.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblname.ForeColor = System.Drawing.Color.Navy
            Me.lblname.Location = New System.Drawing.Point(30, 81)
            Me.lblname.Name = "lblname"
            Me.lblname.Size = New System.Drawing.Size(57, 18)
            Me.lblname.TabIndex = 5
            Me.lblname.Text = "NAME : "
            '
            'Label2
            '
            Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(154, 69)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(42, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "FROM"
            '
            'Label3
            '
            Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(172, 111)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(24, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "TO"
            '
            'dtpfrom
            '
            Me.dtpfrom.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.dtpfrom.CalendarFont = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpfrom.Location = New System.Drawing.Point(288, 66)
            Me.dtpfrom.Name = "dtpfrom"
            Me.dtpfrom.Size = New System.Drawing.Size(206, 20)
            Me.dtpfrom.TabIndex = 1
            '
            'dtpto
            '
            Me.dtpto.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.dtpto.CalendarFont = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpto.Location = New System.Drawing.Point(288, 108)
            Me.dtpto.Name = "dtpto"
            Me.dtpto.Size = New System.Drawing.Size(206, 20)
            Me.dtpto.TabIndex = 2
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(302, 3)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(179, 26)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "REPORT WIZARD"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'butthismonth
            '
            Me.butthismonth.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.butthismonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butthismonth.Location = New System.Drawing.Point(587, 56)
            Me.butthismonth.Name = "butthismonth"
            Me.butthismonth.Size = New System.Drawing.Size(90, 40)
            Me.butthismonth.TabIndex = 5
            Me.butthismonth.Text = "THIS MONTH"
            Me.butthismonth.UseVisualStyleBackColor = True
            '
            'chkall
            '
            Me.chkall.AutoSize = True
            Me.chkall.Dock = System.Windows.Forms.DockStyle.Top
            Me.chkall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkall.Location = New System.Drawing.Point(202, 140)
            Me.chkall.Name = "chkall"
            Me.chkall.Size = New System.Drawing.Size(379, 17)
            Me.chkall.TabIndex = 7
            Me.chkall.Text = "COMPLETE TRANSACTION TBL"
            Me.chkall.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.chkall.UseVisualStyleBackColor = True
            '
            'buttoday
            '
            Me.buttoday.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.buttoday.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.buttoday.Location = New System.Drawing.Point(587, 102)
            Me.buttoday.Name = "buttoday"
            Me.buttoday.Size = New System.Drawing.Size(90, 32)
            Me.buttoday.TabIndex = 8
            Me.buttoday.Text = "TODAY"
            Me.buttoday.UseVisualStyleBackColor = True
            '
            'butexport
            '
            Me.butexport.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.butexport.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butexport.Location = New System.Drawing.Point(320, 170)
            Me.butexport.Name = "butexport"
            Me.butexport.Size = New System.Drawing.Size(143, 43)
            Me.butexport.TabIndex = 6
            Me.butexport.Text = "EXPORT REPORT"
            Me.butexport.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Maroon
            Me.Label4.Location = New System.Drawing.Point(249, 244)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(284, 23)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "INDIVIDUAL DETAILED REPORT"
            '
            'butindreport
            '
            Me.butindreport.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.butindreport.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butindreport.ForeColor = System.Drawing.Color.Maroon
            Me.butindreport.Location = New System.Drawing.Point(3, 8)
            Me.butindreport.Name = "butindreport"
            Me.butindreport.Size = New System.Drawing.Size(175, 61)
            Me.butindreport.TabIndex = 11
            Me.butindreport.Text = "INDIVIDUAL REPORT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TABLE)"
            Me.butindreport.UseVisualStyleBackColor = True
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 1
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.butexportindreport_row, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.butindreport, 0, 0)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(587, 270)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 2
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(194, 155)
            Me.TableLayoutPanel2.TabIndex = 23
            '
            'butexportindreport_row
            '
            Me.butexportindreport_row.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.butexportindreport_row.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butexportindreport_row.ForeColor = System.Drawing.Color.Maroon
            Me.butexportindreport_row.Location = New System.Drawing.Point(3, 85)
            Me.butexportindreport_row.Name = "butexportindreport_row"
            Me.butexportindreport_row.Size = New System.Drawing.Size(175, 61)
            Me.butexportindreport_row.TabIndex = 12
            Me.butexportindreport_row.Text = "INDIVIDUAL REPORT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(ROW)"
            Me.butexportindreport_row.UseVisualStyleBackColor = True
            '
            'usrreport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "usrreport"
            Me.Size = New System.Drawing.Size(784, 562)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.picbox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)

      End Sub
      Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
      Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
      Friend WithEvents Label2 As System.Windows.Forms.Label
      Friend WithEvents Label3 As System.Windows.Forms.Label
      Friend WithEvents butthismonth As System.Windows.Forms.Button
      Friend WithEvents butexport As System.Windows.Forms.Button
      Friend WithEvents chkall As System.Windows.Forms.CheckBox
      Friend WithEvents buttoday As System.Windows.Forms.Button
      Friend WithEvents Label4 As System.Windows.Forms.Label
      Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
      Friend WithEvents picbox As System.Windows.Forms.PictureBox
      Friend WithEvents Label5 As System.Windows.Forms.Label
      Friend WithEvents lblroomno As System.Windows.Forms.Label
      Friend WithEvents txtpgpid As System.Windows.Forms.TextBox
      Friend WithEvents lblname As System.Windows.Forms.Label
      Friend WithEvents butindreport As System.Windows.Forms.Button
      Friend WithEvents lblmsg As System.Windows.Forms.Label
      Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents butexportindreport_row As System.Windows.Forms.Button

End Class
