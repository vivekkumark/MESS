<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmanage
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
            Me.tbllayoutmanage = New System.Windows.Forms.TableLayoutPanel()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.butreport = New System.Windows.Forms.Button()
            Me.butback = New System.Windows.Forms.Button()
            Me.tbllayoutmanage.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'tbllayoutmanage
            '
            Me.tbllayoutmanage.ColumnCount = 1
            Me.tbllayoutmanage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tbllayoutmanage.Controls.Add(Me.TableLayoutPanel2, 0, 0)
            Me.tbllayoutmanage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbllayoutmanage.Location = New System.Drawing.Point(0, 0)
            Me.tbllayoutmanage.Name = "tbllayoutmanage"
            Me.tbllayoutmanage.RowCount = 2
            Me.tbllayoutmanage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
            Me.tbllayoutmanage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.91815!))
            Me.tbllayoutmanage.Size = New System.Drawing.Size(784, 562)
            Me.tbllayoutmanage.TabIndex = 0
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 4
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.25984!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.50394!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.butreport, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.butback, 0, 0)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 3
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(778, 95)
            Me.TableLayoutPanel2.TabIndex = 0
            '
            'butreport
            '
            Me.butreport.Dock = System.Windows.Forms.DockStyle.Fill
            Me.butreport.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butreport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.butreport.Location = New System.Drawing.Point(146, 49)
            Me.butreport.Name = "butreport"
            Me.TableLayoutPanel2.SetRowSpan(Me.butreport, 2)
            Me.butreport.Size = New System.Drawing.Size(129, 43)
            Me.butreport.TabIndex = 0
            Me.butreport.Text = "REPORT"
            Me.butreport.UseVisualStyleBackColor = True
            '
            'butback
            '
            Me.butback.Dock = System.Windows.Forms.DockStyle.Fill
            Me.butback.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.butback.ForeColor = System.Drawing.Color.Red
            Me.butback.Location = New System.Drawing.Point(3, 3)
            Me.butback.Name = "butback"
            Me.butback.Size = New System.Drawing.Size(137, 40)
            Me.butback.TabIndex = 1
            Me.butback.Text = "BACK"
            Me.butback.UseVisualStyleBackColor = True
            '
            'frmmanage
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 562)
            Me.Controls.Add(Me.tbllayoutmanage)
            Me.Name = "frmmanage"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "MANAGE"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.tbllayoutmanage.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)

      End Sub
      Friend WithEvents tbllayoutmanage As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents butreport As System.Windows.Forms.Button
      Friend WithEvents butback As System.Windows.Forms.Button
End Class
