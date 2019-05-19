Public Class frmstockentry
      Dim stock_cellflag As Boolean = True
      Sub init()
            lblmsg.Text = ""
            gridstock.Rows.Clear()
            gridstock.RowTemplate.Height = 30
            gridstock.RowsDefaultCellStyle.Font = New Font(gridstock.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold)
            For k1 = 0 To 25
                  gridstock.Rows.Add()
            Next
            stock_getlist_itemname(listtotalitems)
      End Sub
      Private Sub butcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclose.Click
            Me.Close()
      End Sub
      Private Sub frmstockentry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            init()
      End Sub
      Private Sub Aligngrid()
            stock_cellflag = False
            Dim fr As Int16 = 0
            Dim k1 As Int16
            Dim k2 As Int16

            For k2 = 0 To gridstock.RowCount - 1
                  For k1 = 0 To gridstock.RowCount - 1
                        If gridstock.Rows(k1).Cells("itemname").Value Is Nothing Or gridstock.Rows(k1).Cells("itemname").Value = "" Then
                              Exit For
                        End If
                  Next
                  If Not (gridstock.Rows(k2).Cells("itemname").Value Is Nothing Or gridstock.Rows(k2).Cells("itemname").Value = "") And k1 < k2 Then
                        For c1 = 0 To gridstock.ColumnCount - 1
                              gridstock.Rows(k1).Cells(c1).Value = gridstock.Rows(k2).Cells(c1).Value
                              gridstock.Rows(k2).Cells(c1).Value = Nothing
                        Next
                  End If
            Next
            stock_cellflag = True
      End Sub
      Private Sub gridstock_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridstock.CellValueChanged
            If stock_cellflag Then
                  Try
                        Dim columnname As String = gridstock.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name
                        Select Case columnname
                              Case "itemname"
                                    If (SQL_STOCK.stock_fillgridrow(gridstock.Rows(e.RowIndex), gridstock.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = False) Then
                                          Dim iflag As Boolean = True
                                          If iflag Then
                                                stock_cellflag = False
                                                gridstock.Rows(e.RowIndex).Cells("itemid").Value = Nothing
                                                gridstock.Rows(e.RowIndex).Cells("itemname").Value = Nothing
                                                gridstock.Rows(e.RowIndex).Cells("qty").Value = Nothing
                                                stock_cellflag = True
                                          End If
                                    End If
                                    Aligngrid()
                        End Select

                        If columnname = "qty" Or columnname = "sellingprice" Then
                              Try
                                    If gridstock.Rows(e.RowIndex).Cells("itemname").Value Is Nothing Or gridstock.Rows(e.RowIndex).Cells("itemname").Value = "" Then
                                          stock_cellflag = False
                                          gridstock.Rows(e.RowIndex).Cells("qty").Value = Nothing
                                          stock_cellflag = True
                                          Exit Sub
                                    End If

                                    Dim test As Double = CDbl(gridstock.Rows(e.RowIndex).Cells("qty").Value)
                                    If gridstock.Rows(e.RowIndex).Cells("qty").Value.ToString.Contains(".") Or gridstock.Rows(e.RowIndex).Cells("qty").Value < 0 Then
                                          gridstock.Rows(e.RowIndex).Cells("qty").Value = Nothing
                                          gridstock.Rows(e.RowIndex).Cells("qty").Style.ForeColor = Color.Red
                                    Else
                                          gridstock.Rows(e.RowIndex).Cells("qty").Style.ForeColor = Color.Black
                                    End If
                              Catch ex As Exception
                                    gridstock.Rows(e.RowIndex).Cells("qty").Value = Nothing
                                    gridstock.Rows(e.RowIndex).Cells("qty").Style.ForeColor = Color.Red
                              End Try
                        End If
                  Catch ex As Exception

                  End Try
            End If
      End Sub

      Private Sub gridstock_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridstock.EditingControlShowing
            Dim MySource As New AutoCompleteStringCollection
            Dim columnname As String = gridstock.CurrentCell.OwningColumn.Name
            Select Case columnname
                  Case "itemname"
                        With DirectCast(e.Control, TextBox)
                              .AutoCompleteMode = AutoCompleteMode.Suggest
                              .AutoCompleteSource = AutoCompleteSource.CustomSource
                              .AutoCompleteCustomSource = SQL_STOCK.stock_autocomp_itemname
                              .CharacterCasing = CharacterCasing.Upper
                        End With
                  Case "qty"
                        DirectCast(e.Control, TextBox).AutoCompleteMode = AutoCompleteMode.None
            End Select
      End Sub
      Private Sub listtotalitems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listtotalitems.SelectedIndexChanged
            If (gridstock.Columns(gridstock.CurrentCell.ColumnIndex).Name = "itemname") Then
                  gridstock.CurrentCell.Value = listtotalitems.Text
            End If
      End Sub
      Private Sub gridstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridstock.KeyDown
            clearrow(e.KeyCode)
      End Sub
      Private Sub clearrow(ByVal keycode As Int16)           
            If keycode = Keys.Delete Then
                  Dim columnname As String = gridstock.CurrentCell.OwningColumn.Name
                  If columnname = "itemname" Then
                        stock_cellflag = False
                        For k1 = 0 To gridstock.CurrentRow.Cells.Count - 1
                              gridstock.CurrentRow.Cells(k1).Value = Nothing
                        Next
                        Aligngrid()
                        stock_cellflag = True
                  End If
            End If
      End Sub
      Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclear.Click
            clearrow(Keys.Delete)
      End Sub
      Private Sub butaddrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butaddrow.Click
            gridstock.Rows.Insert(gridstock.Rows.Count)
      End Sub
      Private Sub butupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butupdate.Click
            'checking
            lblmsg.Focus()
            If gridstock.Rows(0).Cells("itemname").Value Is Nothing Or gridstock.Rows(0).Cells("itemname").Value = "" Then
                  lblmsg.Text = " *  No Items in the list"
                  lblmsg.ForeColor = Color.Red                
                  Exit Sub
            End If

            For k1 = 0 To gridstock.RowCount - 1
                  With gridstock.Rows(k1)
                        If Not (.Cells("itemname").Value Is Nothing) And .Cells("qty").Value Is Nothing Then
                              lblmsg.Text = " *  Enter Qty"
                              lblmsg.ForeColor = Color.Red
                              Exit Sub
                        End If
                  End With
            Next
            SQL_STOCK.stock_update(gridstock)

            'Clearing

            stock_cellflag = False
            For k1 = 0 To gridstock.RowCount - 1
                  For k2 = 0 To gridstock.ColumnCount - 1
                        gridstock.Rows(k1).Cells(k2).Value = Nothing
                  Next
            Next
            stock_cellflag = True
            gridstock.CurrentCell = gridstock.Rows(0).Cells("itemname")

            lblmsg.ForeColor = Color.Green
            lblmsg.Text = " STOCK UPDATED SUCCESSFULLY"

      End Sub

      Private Sub lblmsg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblmsg.Leave
            lblmsg.Text = ""
      End Sub
End Class