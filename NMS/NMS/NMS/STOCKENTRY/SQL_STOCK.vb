Imports System.Data.OleDb
Module SQL_STOCK
      Dim sSQL As String
      Dim da As OleDbDataAdapter
      Dim ds As DataSet
      Dim cmd As OleDbCommand
      Public Function stock_autocomp_itemname() As AutoCompleteStringCollection
            Dim MySource As New AutoCompleteStringCollection
            sSQL = "select DISTINCT itemname from stockitem"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "itemname")
            For k1 = 0 To ds.Tables("itemname").Rows.Count - 1
                  MySource.Add(ds.Tables("itemname").Rows(k1).Item("itemname").ToString.ToUpper)
            Next
            Return MySource
      End Function

      Public Sub stock_getlist_itemname(ByRef mylist As ListBox)
            mylist.Items.Clear()
            sSQL = "select DISTINCT itemname from stockitem ORDER BY itemname"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                  mylist.Items.Add(ds.Tables("TT").Rows(k1).Item("itemname").ToString.ToUpper)
            Next
      End Sub

      Public Function stock_fillgridrow(ByRef gridrow As DataGridViewRow, ByVal itemname As String) As Boolean
            Dim flag As Boolean = False
            If itemname Is Nothing Then
                  itemname = ""
            End If
            itemname = itemname.Replace("'", "''")
            sSQL = "SELECT itemid,itemname FROM stockitem where(itemname='" & itemname & "')"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            If (ds.Tables("TT").Rows.Count = 1) Then                  
                  gridrow.Cells("itemid").Value = ds.Tables("TT").Rows(0).Item("itemid").ToString.ToUpper
                  gridrow.Cells("itemname").Value = ds.Tables("TT").Rows(0).Item("itemname").ToString.ToUpper                  
                  If gridrow.Cells("qty").Value Is Nothing Or gridrow.Cells("qty").Value = "" Then
                        gridrow.Cells("qty").Value = 1
                  End If
                  flag = True
            End If
            Return flag
      End Function
      Private Sub stock_updateqty(ByVal itemid As String, ByVal qty As String) 'This is only for stockitem
            sSQL = "UPDATE stockitem SET  qty = qty + " & qty & " WHERE(itemid='" & itemid & "')"
            Dim cmd1 As New OleDbCommand(sSQL, My.MyApplication.conn)
            cmd1.ExecuteNonQuery()
      End Sub
      Public Sub stock_update(ByRef gridstock As DataGridView)
            Dim curdate As String = Now.ToOADate().ToString
            For k1 = 0 To gridstock.RowCount - 1
                  With gridstock.Rows(k1)
                        If .Cells("itemname").Value Is Nothing Then
                              Exit For
                        End If
                        Dim itemname As String = "'" & .Cells("itemname").Value & "'"
                        Dim itemid As String = "'" & .Cells("itemid").Value & "'"
                        Dim qty As String = .Cells("qty").Value.ToString

                        'update stock qty
                        stock_updateqty(.Cells("itemid").Value.ToString, qty)

                        sSQL = "INSERT INTO stockentry (stockdate,itemid,itemname,qty) VALUES ( " & curdate & "," & itemid & "," & itemname & "," & qty & ")"
                        cmd = New OleDbCommand(sSQL, My.MyApplication.conn)
                        cmd.ExecuteNonQuery()
                  End With
            Next
            MEvents.Update_LastUpdated()
      End Sub
End Module
