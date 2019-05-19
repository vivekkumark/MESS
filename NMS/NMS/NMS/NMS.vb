Imports System.Data.OleDb

Public Class NMS
      Public Shared Gmail_Username As String = ""
      Public Shared Gmail_Password As String = ""

      Dim sSQL As String
      Dim da As OleDbDataAdapter
      Dim ds As DataSet
      Dim Rstudent As ArrayList
      Public cellflag As Boolean = True

      Public ETimer As Timer
      Sub init()
            SQL.initGmail()
            'ThreadTask_ScheduleArchive()
            'Timer
            ETimer = New Timer()
            AddHandler ETimer.Tick, AddressOf MEvents.Start_ScheduleArchive
            ETimer.Interval = (1000 * 60 * SQL.Get_timearchivedinmin) 'min * time
            'ETimer.Interval = (1000 * 10) 'min * time
            ETimer.Start()


            SQL.getlist_comboname(listcombocat)
            SQL.getlist_cat(listcat)
            lblcomboname.Text = ""
            lblcombooffer.Text = ""
            Try
                  listcombocat.SelectedIndex = 0
            Catch ex As Exception

            End Try
            lblpretransid.Text = ""
            lbltransid.Text = SQL.findbillno()
            lblmsg.Text = ""
            lblname.Text = ""
            lblroomno.Text = ""
            picbox.ImageLocation = ""
            listcat.SelectedIndex = 0
            gridorder.Rows.Clear()
            gridorder.RowTemplate.Height = 30
            gridorder.RowsDefaultCellStyle.Font = New Font(gridorder.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold)
            For k1 = 1 To 20
                  gridorder.Rows.Add()
                  gridorder.Columns("itemname").DefaultCellStyle.Font = New Font(gridorder.Columns("itemname").DefaultCellStyle.Font, FontStyle.Bold)
            Next
            gridorder.CurrentCell = gridorder.Rows(0).Cells("itemname")
      End Sub

      Private Sub NMS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            ETimer.Stop()
      End Sub
      Private Sub NMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
            If e.KeyCode = Keys.Up And e.Control Then
                  listcat.SelectedIndex = (listcat.Items.Count + listcat.SelectedIndex - 1) Mod listcat.Items.Count
                  e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Down And e.Control Then
                  listcat.SelectedIndex = (listcat.Items.Count + listcat.SelectedIndex + 1) Mod listcat.Items.Count
                  e.SuppressKeyPress = True
            End If
            If e.KeyCode = Keys.F5 Then
                  butbill_Click(sender, e)
                  e.SuppressKeyPress = True
            End If
      End Sub
      Private Sub NMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            init()
      End Sub
      Private Sub txtpgpid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpgpid.KeyDown
            If e.KeyCode = Keys.Enter Then
                  gridorder.Focus()
            End If
      End Sub
      Private Sub txtpgpid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpgpid.Leave
            lblmsg.Text = ""
      End Sub
      Private Sub txtpgpid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpgpid.TextChanged
            Rstudent = SQL.student(txtpgpid.Text)
            If (Rstudent.Count > 0) Then
                  lblname.Text = Rstudent(0)
                  lblroomno.Text = Rstudent(1)
                  picbox.ImageLocation = Rstudent(2)
            Else
                  Rstudent = Nothing
                  lblname.Text = ""
                  lblroomno.Text = ""
                  picbox.ImageLocation = ""
            End If
      End Sub
      Private Sub listitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles listitems.KeyDown
            If e.KeyCode = Keys.Enter Then
                  gridorder.Focus()
            End If
      End Sub
      Private Sub listitems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listitems.SelectedIndexChanged
            'listitems.BackColor = Color.LightGreen
            If (gridorder.Columns(gridorder.CurrentCell.ColumnIndex).Name = "itemname") Then
                  gridorder.CurrentCell.Value = listitems.Text
            End If
      End Sub
      Private Sub listcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listcat.SelectedIndexChanged
            Try
                  SQL.getlist_itemname(listitems, DirectCast(listcat.SelectedItem, ListItemCat).ItemIdPrefix, "")
                  listitems.BackColor = Color.LightGreen
            Catch ex As Exception
            End Try
      End Sub
      Private Sub gridorder_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridorder.EditingControlShowing
            Dim MySource As New AutoCompleteStringCollection
            Dim columnname As String = gridorder.CurrentCell.OwningColumn.Name
            Select Case columnname
                  Case "itemname"
                        With DirectCast(e.Control, TextBox)
                              .AutoCompleteMode = AutoCompleteMode.Suggest
                              .AutoCompleteSource = AutoCompleteSource.CustomSource
                              .AutoCompleteCustomSource = SQL.Autocomp_itemname
                              .CharacterCasing = CharacterCasing.Upper
                        End With
                  Case "qty"
                        With DirectCast(e.Control, TextBox)
                              .AutoCompleteMode = AutoCompleteMode.None
                        End With
            End Select
      End Sub
      Private Sub Calc_Total()
            Try
                  Dim total As Double = 0
                  For k1 = 0 To gridorder.Rows.Count - 1
                        If Not (gridorder.Rows(k1).Cells("total").Value Is Nothing) Then
                              If (CStr(gridorder.Rows(k1).Cells("total").Value) <> "") Then
                                    total += CDbl(gridorder.Rows(k1).Cells("total").Value)
                              End If
                        End If
                  Next
                  lbltotal.Text = "Total : " & total.ToString("N2")
                  lbltotal.ForeColor = Color.Black
            Catch ex As Exception
                  lbltotal.Text = "Total : Err"
                  lbltotal.ForeColor = Color.Red
            End Try
      End Sub
      Private Sub gridorder_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridorder.CellValueChanged
            If cellflag Then
                  Try
                        Dim columnname As String = gridorder.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name
                        Select Case columnname
                              Case "itemname"
                                    If (SQL.fillgridrow(gridorder.Rows(e.RowIndex), gridorder.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = False) Then
                                          Dim iflag As Boolean = True
                                          If iflag Then
                                                cellflag = False
                                                gridorder.Rows(e.RowIndex).Cells("type").Value = Nothing
                                                gridorder.Rows(e.RowIndex).Cells("itemid").Value = Nothing
                                                gridorder.Rows(e.RowIndex).Cells("itemname").Value = Nothing
                                                gridorder.Rows(e.RowIndex).Cells("sellingprice").Value = Nothing
                                                gridorder.Rows(e.RowIndex).Cells("qty").Value = Nothing
                                                gridorder.Rows(e.RowIndex).Cells("total").Value = Nothing
                                                Calc_Total()
                                                cellflag = True
                                          End If
                                    End If
                                    Aligngrid()
                              Case "total"
                                    Calc_Total()
                        End Select

                        If columnname = "qty" Or columnname = "sellingprice" Then
                              Try

                                    If gridorder.Rows(e.RowIndex).Cells("itemname").Value Is Nothing Or gridorder.Rows(e.RowIndex).Cells("itemname").Value = "" Then
                                          cellflag = False
                                          gridorder.Rows(e.RowIndex).Cells("qty").Value = Nothing
                                          cellflag = True
                                    End If

                                    If gridorder.Rows(e.RowIndex).Cells("qty").Value.ToString.Contains(".") Or gridorder.Rows(e.RowIndex).Cells("qty").Value < 0 Then
                                          gridorder.Rows(e.RowIndex).Cells("total").Value = "Err"
                                          gridorder.Rows(e.RowIndex).Cells("total").Style.ForeColor = Color.Red
                                    Else
                                          gridorder.Rows(e.RowIndex).Cells("total").Value = CDbl(gridorder.Rows(e.RowIndex).Cells("qty").Value) * CDbl(gridorder.Rows(e.RowIndex).Cells("sellingprice").Value)
                                          gridorder.Rows(e.RowIndex).Cells("total").Style.ForeColor = Color.Black
                                    End If
                              Catch ex As Exception
                                    If gridorder.Rows(e.RowIndex).Cells("itemname").Value Is Nothing Or gridorder.Rows(e.RowIndex).Cells("itemname").Value = "" Then
                                          gridorder.Rows(e.RowIndex).Cells("total").Value = Nothing
                                    Else
                                          gridorder.Rows(e.RowIndex).Cells("total").Value = "Err"
                                          gridorder.Rows(e.RowIndex).Cells("total").Style.ForeColor = Color.Red
                                    End If
                              End Try
                        End If

                  Catch ex As Exception

                  End Try
            End If
      End Sub
      Private Sub Aligngrid()
            cellflag = False
            Dim fr As Int16 = 0
            Dim k1 As Int16
            Dim k2 As Int16

            For k2 = 0 To gridorder.RowCount - 1
                  For k1 = 0 To gridorder.RowCount - 1
                        If gridorder.Rows(k1).Cells("itemname").Value Is Nothing Or gridorder.Rows(k1).Cells("itemname").Value = "" Then
                              Exit For
                        End If
                  Next
                  If Not (gridorder.Rows(k2).Cells("itemname").Value Is Nothing Or gridorder.Rows(k2).Cells("itemname").Value = "") And k1 < k2 Then
                        For c1 = 0 To gridorder.ColumnCount - 1
                              gridorder.Rows(k1).Cells(c1).Value = gridorder.Rows(k2).Cells(c1).Value
                              gridorder.Rows(k2).Cells(c1).Value = Nothing
                        Next
                  End If
            Next
            cellflag = True
      End Sub
      Private Sub gridorder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridorder.KeyDown
            clearrow(e.KeyCode)
      End Sub
      Private Sub clearrow(ByVal keycode As Int16)
            If keycode = Keys.Delete Then
                  Dim columnname As String = gridorder.CurrentCell.OwningColumn.Name
                  If columnname = "itemname" Then
                        cellflag = False
                        For k1 = 0 To gridorder.CurrentRow.Cells.Count - 1
                              gridorder.CurrentRow.Cells(k1).Value = Nothing
                        Next
                        Calc_Total()
                        Aligngrid()
                        cellflag = True
                  End If
            End If
      End Sub
      Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclear.Click
            clearrow(Keys.Delete)
      End Sub
      Private Sub butaddrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butaddrow.Click
            gridorder.Rows.Insert(gridorder.Rows.Count)
      End Sub
      Private Sub listcombocat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listcombocat.SelectedIndexChanged
            lblcomboname.Text = listcombocat.Text
            If listcombocat.SelectedIndex <> -1 Then
                  Dim list As List(Of List(Of String))
                  list = DirectCast(listcombocat.SelectedItem, ListItemcombo).menu
                  gridcombo.Rows.Clear()
                  For k1 = 0 To list.Count - 2
                        gridcombo.Rows.Add()
                        gridcombo.Rows(gridcombo.RowCount - 1).Cells("comboitemname").Value = list(k1)(0)
                        gridcombo.Rows(gridcombo.RowCount - 1).Cells("combosellingprice").Value = list(k1)(1)
                        gridcombo.Rows(gridcombo.RowCount - 1).Cells("price").Value = list(k1)(2)
                  Next
                  gridcombo.Rows.Add()
                  gridcombo.Rows(gridcombo.RowCount - 1).Cells("comboitemname").Value = list(list.Count - 1)(0)
                  gridcombo.Rows(gridcombo.RowCount - 1).Cells("combosellingprice").Value = list(list.Count - 1)(1)
                  gridcombo.Rows(gridcombo.RowCount - 1).Cells("price").Value = list(list.Count - 1)(2)

                  Dim newfont As Font = New Font(gridcombo.DefaultCellStyle.Font.FontFamily, gridcombo.DefaultCellStyle.Font.Size, FontStyle.Bold)
                  With gridcombo.Rows(gridcombo.RowCount - 1)
                        With .Cells("comboitemname").Style
                              .ForeColor = Color.Black
                              .BackColor = Color.MistyRose
                              .SelectionForeColor = Color.Black
                              .SelectionBackColor = Color.MistyRose
                              .Font = newfont
                        End With
                        With .Cells("combosellingprice").Style
                              .ForeColor = Color.Black
                              .BackColor = Color.MistyRose
                              .SelectionForeColor = Color.Black
                              .SelectionBackColor = Color.MistyRose
                              .Font = newfont
                        End With
                        With .Cells("price").Style
                              .ForeColor = Color.Black
                              .BackColor = Color.MistyRose
                              .SelectionForeColor = Color.Black
                              .SelectionBackColor = Color.MistyRose
                              .Font = newfont
                        End With
                  End With

                  lblcombooffer.Text = "You are saving Rs." & CStr(CDbl(list(list.Count - 1)(1)) - CDbl(list(list.Count - 1)(2)))
            Else
                  lblcombooffer.Text = ""
            End If
      End Sub
      Private Sub butaddcombo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butaddcombo.Click
            If listcombocat.SelectedIndex <> -1 Then
                  Dim list As List(Of List(Of String))
                  list = DirectCast(listcombocat.SelectedItem, ListItemcombo).menu
                  For k1 = 0 To gridorder.RowCount - 1
                        If gridorder.Rows(k1).Cells("itemname").Value Is Nothing Or gridorder.Rows(k1).Cells("itemname").Value = "" Then
                              gridorder.Rows(k1).Cells("itemname").Value = listcombocat.Text
                              Exit For
                        End If
                  Next
            End If
      End Sub
      Private Sub butbill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butbill.Click
            If Rstudent Is Nothing Then
                  lblmsg.Text = "---> * Enter Student's PGPID"
                  lblmsg.ForeColor = Color.Red
                  txtpgpid.Focus()
                  Exit Sub
            End If

            If gridorder.Rows(0).Cells("itemname").Value Is Nothing Or gridorder.Rows(0).Cells("itemname").Value = "" Then
                  lblmsg.Text = "---> * No Items in the list"
                  lblmsg.ForeColor = Color.Red
                  gridorder.Focus()
                  Exit Sub
            End If
            If lbltotal.Text = "Total : Err" Then
                  lblmsg.Text = "---> * Check The Qty"
                  lblmsg.ForeColor = Color.Red
                  Exit Sub
            End If
            SQL.update_transactiontbl(gridorder, lbltransid.Text)

            'Updating Sessions Orders
            gridprevorder.Rows.Insert(0)
            gridprevorder.ClearSelection()
            gridprevorder.Rows(0).Cells("pgpid").Value = txtpgpid.Text
            gridprevorder.Rows(0).Cells("studentname").Value = lblname.Text.Replace("NAME : ", "")
            gridprevorder.Rows(0).Cells("transid").Value = lbltransid.Text
            gridprevorder.Rows(0).Selected = True
            lblpretransid.Text = "ID : " & lbltransid.Text
            SQL.updateprevorederdisp(gridprevdisp, lbltransid.Text)

            'Event Sendmail
            MEvents.SendMail(txtpgpid.Text, lbltransid.Text)

            'Clearing
            txtpgpid.Text = ""
            cellflag = False
            For k1 = 0 To gridorder.RowCount - 1
                  For k2 = 0 To gridorder.ColumnCount - 1
                        gridorder.Rows(k1).Cells(k2).Value = Nothing
                  Next
            Next
            cellflag = True
            gridorder.CurrentCell = gridorder.Rows(0).Cells("itemname")
            lbltotal.Text = "Total"

            txtpgpid.Focus()
            lblmsg.Text = "Bill is added successfully"
            lblmsg.ForeColor = Color.Green
            SQL.updatebillno(lbltransid.Text.Split("-")(1))
            lbltransid.Text = SQL.findbillno()
      End Sub
      Private Sub gridprevorder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridprevorder.SelectionChanged
            If Not gridprevorder.CurrentRow.Cells("transid").Value Is Nothing Then
                  lblpretransid.Text = "ID : " & gridprevorder.CurrentRow.Cells("transid").Value
                  SQL.updateprevorederdisp(gridprevdisp, gridprevorder.CurrentRow.Cells("transid").Value)
            End If
      End Sub
      Private Sub butstockentry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butstockentry.Click
            frmstockentry.ShowDialog()
      End Sub

      Private Sub butmanage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butmanage.Click
            frmmanage.Show()
            Me.Visible = False
      End Sub
End Class
