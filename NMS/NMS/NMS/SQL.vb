Imports System.Data.OleDb
Module SQL
      Dim sSQL As String
      Dim da As OleDbDataAdapter
      Dim ds As DataSet
      Dim cmd As OleDbCommand

      Public Function student(ByVal pgpid As String) As ArrayList
            pgpid = pgpid.Replace("'", "''")
            sSQL = "SELECT * FROM student where(pgpid='" & pgpid & "')"

            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "student")

            Dim list As New ArrayList
            If (ds.Tables("student").Rows.Count = 1) Then
                  list.Add("NAME : " & ds.Tables("student").Rows(0).Item("name").ToString.Trim.ToUpper)
                  list.Add("ROOM NO : " & ds.Tables("student").Rows(0).Item("roomnumber").ToString.Trim.ToUpper)
                  Dim photopath As String = "photos\emptyphoto.jpg"
                  If FileIO.FileSystem.FileExists("photos\" & pgpid & ".jpg") Then
                        photopath = "photos\" & pgpid & ".jpg"
                  End If
                  list.Add(photopath)
            End If
            Return list
      End Function
      Public Sub getlist_itemname(ByRef mylist As ListBox, ByVal itemid As String, ByVal itemname As String)
            mylist.Items.Clear()
            If itemid Is Nothing Then
                  itemid = ""
            End If
            If itemname Is Nothing Then
                  itemname = ""
            End If
            itemid = itemid.Replace("'", "''")
            itemname = itemname.Replace("'", "''")
            sSQL = "SELECT DISTINCT itemname,itemid from menuitem where(itemid like '" & itemid & "%' and itemname like '%" & itemname & "%' )" & _
                           "UNION " & _
                          "SELECT DISTINCT itemname,itemid from stockitem where(itemid like '" & itemid & "%' and itemname like '%" & itemname & "%' )"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                  mylist.Items.Add(New ListItemCat(ds.Tables("TT").Rows(k1).Item("itemname").ToString.ToUpper, ds.Tables("TT").Rows(k1).Item("itemid").ToString.ToUpper))
            Next
            mylist.DisplayMember = "ItemName"
            mylist.ValueMember = "ItemIdPrefix"
      End Sub
      Public Sub getlist_cat(ByRef mylist As ListBox)
            mylist.Items.Clear()
            mylist.Items.Add(New ListItemCat("ALL(*)", ""))
            sSQL = "SELECT DISTINCT groupname,itemidprefix from itemid"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                  mylist.Items.Add(New ListItemCat(ds.Tables("TT").Rows(k1).Item("groupname").ToString.ToUpper, ds.Tables("TT").Rows(k1).Item("itemidprefix").ToString.ToUpper))
            Next
            mylist.DisplayMember = "ItemName"
            mylist.ValueMember = "ItemIdPrefix"
      End Sub
      Public Function Autocomp_itemname() As AutoCompleteStringCollection
            Dim MySource As New AutoCompleteStringCollection
            sSQL = "SELECT DISTINCT itemname from menuitem UNION select DISTINCT itemname from stockitem UNION SELECT DISTINCT comboname as itemname from combo"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "itemname")
            For k1 = 0 To ds.Tables("itemname").Rows.Count - 1
                  MySource.Add(ds.Tables("itemname").Rows(k1).Item("itemname").ToString.ToUpper)
            Next
            Return MySource
      End Function
      Public Function fillgridrow(ByRef gridrow As DataGridViewRow, ByVal itemname As String) As Boolean
            Dim flag As Boolean = False
            If itemname Is Nothing Then
                  itemname = ""
            End If
            itemname = itemname.Replace("'", "''")
            sSQL = "SELECT itemid,itemname,sellingprice FROM stockitem where(itemname='" & itemname & "')"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            If (ds.Tables("TT").Rows.Count = 1) Then
                  gridrow.Cells("type").Value = 1 'stockitem
                  gridrow.Cells("itemid").Value = ds.Tables("TT").Rows(0).Item("itemid").ToString.ToUpper
                  gridrow.Cells("itemname").Value = ds.Tables("TT").Rows(0).Item("itemname").ToString.ToUpper
                  gridrow.Cells("sellingprice").Value = ds.Tables("TT").Rows(0).Item("sellingprice")
                  If gridrow.Cells("qty").Value Is Nothing Or gridrow.Cells("qty").Value = "" Then
                        gridrow.Cells("qty").Value = 1
                  End If
                  flag = True
            End If

            sSQL = "SELECT itemid,itemname,sellingprice FROM menuitem where(itemname='" & itemname & "')"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT1")
            If (ds.Tables("TT1").Rows.Count = 1) Then
                  gridrow.Cells("type").Value = 2 'menuitem
                  gridrow.Cells("itemid").Value = ds.Tables("TT1").Rows(0).Item("itemid").ToString.ToUpper
                  gridrow.Cells("itemname").Value = ds.Tables("TT1").Rows(0).Item("itemname").ToString.ToUpper
                  gridrow.Cells("sellingprice").Value = ds.Tables("TT1").Rows(0).Item("sellingprice")
                  If gridrow.Cells("qty").Value Is Nothing Or gridrow.Cells("qty").Value = "" Then
                        gridrow.Cells("qty").Value = 1
                  End If
                  flag = True
            End If

            For k1 = 0 To NMS.listcombocat.Items.Count - 1
                  If itemname.ToUpper = DirectCast(NMS.listcombocat.Items(k1), ListItemcombo).comboname Then
                        flag = True
                        Dim list As List(Of List(Of String))
                        list = DirectCast(NMS.listcombocat.Items(k1), ListItemcombo).menu
                        gridrow.Cells("type").Value = 3 'comboitem
                        gridrow.Cells("itemid").Value = itemname.ToUpper
                        gridrow.Cells("itemname").Value = itemname.ToUpper
                        gridrow.Cells("sellingprice").Value = CDbl(list(list.Count - 1)(2))
                        gridrow.Cells("qty").Value = 1
                        Exit For
                  End If
            Next

            Return flag
      End Function
      Public Sub getlist_comboname(ByRef mylist As ListBox)
            mylist.Items.Clear()
            sSQL = "SELECT DISTINCT comboname from combo"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            Dim list As New List(Of String)
            For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                  list.Add(ds.Tables("TT").Rows(k1).Item("comboname").ToString.ToUpper)
            Next
            For k1 = 0 To list.Count - 1
                  mylist.Items.Add(New ListItemcombo(list(k1)))
            Next
            mylist.DisplayMember = "comboname"
            mylist.ValueMember = "menu"
      End Sub
      Public Function get_sellingprice(ByVal itemid As String, ByRef type As String) As Double
            itemid = itemid.Replace("'", "''")
            sSQL = "SELECT sellingprice  FROM stockitem WHERE(itemid='" & itemid & "')"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            If ds.Tables("TT").Rows.Count < 1 Then
                  sSQL = "SELECT sellingprice  FROM menuitem WHERE(itemid='" & itemid & "')"
                  da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
                  ds = New DataSet
                  da.Fill(ds, "TT")
                  type = "2"
                  Return CDbl(ds.Tables("TT").Rows(0).Item(0).ToString)
            Else
                  type = "1"
                  Return CDbl(ds.Tables("TT").Rows(0).Item(0).ToString)
            End If
      End Function
      Public Sub updatebillno(ByVal billno As Int64)
            sSQL = "UPDATE billno SET  billno=" & billno + 1
            Dim cmd1 As New OleDbCommand(sSQL, My.MyApplication.conn)
            cmd1.ExecuteNonQuery()
      End Sub
      Public Function findbillno() As String

            Dim year As Long
            Dim billno As Long
            Dim billnostr As String

            sSQL = "SELECT curyear,billno FROM billno"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            year = ds.Tables("TT").Rows(0).Item("curyear")
            billno = ds.Tables("TT").Rows(0).Item("billno")

            If year <> Now.Year Mod 100 Then
                  year = Now.Year Mod 100
                  billno = 10000
                  Dim TsSQL As String = String.Format("UPDATE billno SET curyear={0},billno={1}", year.ToString, billno.ToString)
                  Dim cmd1 As New OleDbCommand(TsSQL, My.MyApplication.conn)
                  cmd1.ExecuteNonQuery()
            End If

            billnostr = year & "-" & billno
            While True
                  sSQL = String.Format("SELECT transid FROM transactiontbl where(transid='{0}')", billnostr)
                  da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
                  ds = New DataSet
                  da.Fill(ds, "TT")
                  If ds.Tables("TT").Rows.Count = 0 Then
                        Exit While
                  Else
                        billno += 1
                  End If
                  billnostr = year & "-" & billno
            End While
            Return billnostr
      End Function
      Private Sub updateqty(ByVal itemid As String, ByVal qty As String) 'This is only for stockitem
            itemid = itemid.Replace("'", "''")
            sSQL = "UPDATE stockitem SET  qty = qty - " & qty & " WHERE(itemid='" & itemid & "')"
            Dim cmd1 As New OleDbCommand(sSQL, My.MyApplication.conn)
            cmd1.ExecuteNonQuery()
      End Sub
      Public Sub update_transactiontbl(ByRef gridorder As DataGridView, ByVal stransid As String)
            Dim pgpid As String = "'" & NMS.txtpgpid.Text.Replace("'", "''") & "'"
            Dim transid As String = "'" & stransid & "'"
            Dim timeordered As String = Now.ToOADate().ToString

            For k1 = 0 To gridorder.RowCount - 1
                  If gridorder.Rows(k1).Cells("itemname").Value Is Nothing Then
                        Exit For
                  End If
                  Dim itemid As String = "'" & gridorder.Rows(k1).Cells("itemid").Value.ToString.Replace("'", "''") & "'"
                  Dim itemname As String = "'" & gridorder.Rows(k1).Cells("itemname").Value.ToString.Replace("'", "''") & "'"
                  Dim itemdes As String = ""
                  Select Case CInt(gridorder.Rows(k1).Cells("type").Value)
                        Case 1
                              itemdes = "'STOCKITEM'"
                              updateqty(gridorder.Rows(k1).Cells("itemid").Value.ToString, gridorder.Rows(k1).Cells("qty").Value.ToString)
                        Case 2
                              itemdes = "'MENUITEM'"
                        Case 3
                              itemdes = "COMBO"
                              For kk = 0 To NMS.listcombocat.Items.Count - 1
                                    If gridorder.Rows(k1).Cells("itemname").Value.ToString = DirectCast(NMS.listcombocat.Items(kk), ListItemcombo).comboname Then
                                          Dim list As List(Of List(Of String))
                                          list = DirectCast(NMS.listcombocat.Items(kk), ListItemcombo).menu
                                          For kkk = 0 To list.Count - 2
                                                itemdes = itemdes & "#" & list(kkk)(0) & ":" & list(kkk)(1) & ":" & list(kkk)(2)
                                                If list(kkk)(4) = "1" Then
                                                      updateqty(list(kkk)(3), gridorder.Rows(k1).Cells("qty").Value.ToString)
                                                End If
                                          Next
                                          Exit For
                                    End If
                              Next
                              itemdes = "'" & itemdes.Replace("'", "''") & "'"
                  End Select
                  Dim qty As String = gridorder.Rows(k1).Cells("qty").Value.ToString
                  Dim sellingprice As String = gridorder.Rows(k1).Cells("sellingprice").Value.ToString
                  Dim total As String = gridorder.Rows(k1).Cells("total").Value.ToString

                  sSQL = "INSERT INTO transactiontbl (pgpid,transid,itemid,itemname,itemdes,qty,sellingprice,total,timeordered) " & _
                               "VALUES (" & pgpid & "," & transid & "," & itemid & "," & itemname & "," & itemdes & "," & qty & "," & sellingprice & "," & total & "," & timeordered & ")"

                  cmd = New OleDbCommand(sSQL, My.MyApplication.conn)
                  cmd.ExecuteNonQuery()
            Next
            MEvents.Update_lastupdated()
      End Sub

      Public Sub updateprevorederdisp(ByRef gridprevdisp As DataGridView, ByVal transid As String)
            sSQL = "SELECT itemname,qty,sellingprice,total FROM transactiontbl WHERE(transid='" & transid & "')"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            gridprevdisp.Rows.Clear()
            Dim total As Double = 0
            For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                  With ds.Tables("TT").Rows(k1)
                        gridprevdisp.Rows.Add()
                        gridprevdisp.Rows(gridprevdisp.RowCount - 1).Cells("previtem").Value = .Item("itemname")
                        gridprevdisp.Rows(gridprevdisp.RowCount - 1).Cells("prevtotal").Value = "(" & .Item("qty").ToString & " X " & .Item("sellingprice").ToString & " = " & .Item("total").ToString & ")"
                        total += .Item("total")
                  End With
            Next
            gridprevdisp.Rows.Add()
            gridprevdisp.Rows(gridprevdisp.RowCount - 1).Cells("previtem").Value = "TOTAL"
            gridprevdisp.Rows(gridprevdisp.RowCount - 1).Cells("prevtotal").Value = total.ToString

            Dim newfont As Font = New Font(gridprevdisp.DefaultCellStyle.Font.FontFamily, gridprevdisp.DefaultCellStyle.Font.Size, FontStyle.Bold)
            With gridprevdisp.Rows(gridprevdisp.RowCount - 1)
                  With .Cells("previtem").Style
                        .ForeColor = Color.Black
                        .BackColor = Color.MistyRose
                        .SelectionForeColor = Color.Black
                        .SelectionBackColor = Color.MistyRose
                        .Font = newfont
                  End With
                  With .Cells("prevtotal").Style
                        .ForeColor = Color.Black
                        .BackColor = Color.MistyRose
                        .SelectionForeColor = Color.Black
                        .SelectionBackColor = Color.MistyRose
                        .Font = newfont
                  End With
            End With
      End Sub
      Public Sub initGmail()
            Try
                  sSQL = "SELECT * FROM gmailid"
                  da = New OleDbDataAdapter(sSQL, My.MyApplication.connEvent)
                  ds = New DataSet
                  da.Fill(ds, "TT")
                  NMS.Gmail_Username = ds.Tables("TT").Rows(0).Item("gmailid").ToString()
                  NMS.Gmail_Password = ds.Tables("TT").Rows(0).Item("password").ToString()
            Catch ex As Exception
            End Try
      End Sub
      Public Function Get_timearchivedinmin() As Double
            Try
                  sSQL = "SELECT timearchivedinmin FROM datetrack"
                  da = New OleDbDataAdapter(sSQL, My.MyApplication.connEvent)
                  ds = New DataSet
                  da.Fill(ds, "TT")
                  Return ds.Tables("TT").Rows(0).Item("timearchivedinmin")
            Catch ex As Exception
                  Return 24 * 60
            End Try
      End Function
End Module
