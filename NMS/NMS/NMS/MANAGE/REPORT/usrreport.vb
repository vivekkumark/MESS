Imports System.Data.OleDb
Public Class usrreport
      Dim sSQL As String
      Dim Rstudent As ArrayList
      Dim da As OleDbDataAdapter
      Dim ds As DataSet
      Dim cmd As OleDbCommand

      Dim da1 As OleDbDataAdapter
      Dim ds1 As DataSet
      Dim cmd1 As OleDbCommand
      Private Sub usrreport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            lblmsg.Text = ""
            onoff(True)
            thismonth()
      End Sub
      Private Sub onoff(ByVal flag As Boolean)
            lblmsg.Visible = flag
            GroupBox1.Visible = flag
            butindreport.Visible = flag
            Label4.Visible = flag
      End Sub

      Private Function getamount(ByVal pgpid As String, ByRef flag As Double) As Double
            If chkall.Checked Then
                  sSQL = "SELECT sum(total) as TL FROM transactiontbl WHERE (pgpid='" & pgpid & "')"
            Else
                  sSQL = "SELECT sum(total) as TL FROM transactiontbl WHERE (pgpid='" & pgpid & "' AND timeordered >= " & dtpfrom.Value.ToOADate.ToString & " AND timeordered <" & dtpto.Value.AddDays(1).ToOADate.ToString & " )"
                  'If dtpfrom.Value = dtpto.Value Then
                  '      sSQL = "SELECT sum(total) as TL FROM transactiontbl WHERE (pgpid='" & pgpid & "' AND timeordered >= " & dtpfrom.Value.ToOADate.ToString & " AND timeordered <" & dtpto.Value.AddDays(1).ToOADate.ToString & " )"
                  'Else
                  '      sSQL = "SELECT sum(total) as TL FROM transactiontbl WHERE (pgpid='" & pgpid & "' AND timeordered BETWEEN " & dtpfrom.Value.ToOADate.ToString & " AND " & dtpto.Value.ToOADate.ToString & " )"
                  'End If
            End If
            da1 = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds1 = New DataSet
            da1.Fill(ds1, "TT")
            Dim total As Double = 0
            If ds1.Tables("TT").Rows.Count < 1 Or IsDBNull(ds1.Tables("TT").Rows(0).Item(0)) Then
                  flag = False
                  Return total
            Else
                  flag = True
                  total = ds1.Tables("TT").Rows(0).Item(0)
                  Return total
            End If
      End Function
      Private Sub getindlist(ByVal pgpid As String, ByRef list As List(Of List(Of String)))
            sSQL = "SELECT DISTINCT itemid,itemname FROM transactiontbl WHERE (pgpid='" & pgpid & "' AND timeordered >= " & dtpfrom.Value.ToOADate.ToString & " AND timeordered <" & dtpto.Value.AddDays(1).ToOADate.ToString & " ) ORDER BY itemname ASC"
            da1 = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds1 = New DataSet
            da1.Fill(ds1, "TT")
            list.Clear()
            Dim mylist As List(Of String)
            For k1 = 0 To ds1.Tables("TT").Rows.Count - 1
                  With ds1.Tables("TT").Rows(k1)
                        mylist = New List(Of String)
                        mylist.Add(.Item("itemid"))
                        mylist.Add(.Item("itemname"))
                        list.Add(mylist)
                  End With
            Next
      End Sub

      Public Sub thismonth()
            Dim shift As Int16
            shift = DateTime.Today.Day - 1
            dtpfrom.Value = DateTime.Today.AddDays(-shift)
            shift = Date.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)
            dtpto.Value = DateTime.Today.AddDays(shift - DateTime.Today.Day)
      End Sub
      Private Sub butthismonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butthismonth.Click
            thismonth()
      End Sub
      Private Sub buttoday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttoday.Click
            dtpfrom.Value = DateTime.Today
            dtpto.Value = DateTime.Today
      End Sub

      Public Shared Sub Report(ByVal myResult As String, ByVal fromdate As Date, ByVal todate As Date)
            Dim TsSQL As String
            Dim Tda As OleDbDataAdapter
            Dim Tds As DataSet
            Try
                  Dim myexcel As Object = CreateObject("Excel.Application")
                  myexcel.Workbooks.Add()
                  myexcel.Visible = False

                  TsSQL = "SELECT pgpid,name,roomnumber FROM student"
                  Tda = New OleDbDataAdapter(TsSQL, My.MyApplication.conn)
                  Tds = New DataSet
                  Tda.Fill(Tds, "student")

                  myexcel.cells(1, 1).value = "FROM"
                  myexcel.cells(1, 2).value = fromdate
                  myexcel.cells(1, 3).value = "TO"
                  myexcel.cells(1, 4).value = todate

                  myexcel.cells(2, 1).value = "PGPID"
                  myexcel.cells(2, 2).value = "STUDENT NAME"
                  myexcel.cells(2, 3).value = "ROOM NUMBER"
                  myexcel.cells(2, 4).value = "TOTAL"

                  For k1 = 0 To Tds.Tables("student").Rows.Count - 1
                        With Tds.Tables("student").Rows(k1)
                              myexcel.cells(k1 + 3, 1).value = .Item(0).ToString.ToUpper
                              myexcel.cells(k1 + 3, 2).value = .Item(1).ToString.ToUpper
                              myexcel.cells(k1 + 3, 3).value = .Item(2).ToString.ToUpper

                              Dim sSQL1 As String = "SELECT sum(total) as TL FROM transactiontbl WHERE (pgpid='" & .Item(0).ToString & "' AND timeordered >= " & fromdate.ToOADate.ToString & " AND timeordered <" & todate.AddDays(1).ToOADate.ToString & " )"
                              Dim da1 As New OleDbDataAdapter(sSQL1, My.MyApplication.conn)
                              Dim ds1 As New DataSet
                              da1.Fill(ds1, "TT")
                              If ds1.Tables("TT").Rows.Count < 1 Or IsDBNull(ds1.Tables("TT").Rows(0).Item(0)) Then
                                    myexcel.cells(k1 + 3, 4).value = 0.0
                              Else
                                    myexcel.cells(k1 + 3, 4).value = ds1.Tables("TT").Rows(0).Item(0)
                              End If

                        End With
                  Next

                  For k1 = 7 To 12
                        myexcel.range(myexcel.cells(1, 1), myexcel.cells(Tds.Tables("student").Rows.Count + 2, 4)).Borders.LineStyle = 1 ' xlContinuous                        
                  Next

                  myexcel.Cells.Select()
                  myexcel.Cells.EntireColumn.AutoFit()
                  myexcel.Range("A1:D2").Font.Bold = True
                  myexcel.Range("A1:D2").HorizontalAlignment = -4108 ' xlCenter
                  myexcel.Columns("C:C").HorizontalAlignment = -4108 ' xlCenter                  
                  myexcel.Columns("D:D").NumberFormat = "0.00"
                  myexcel.Range("A1:D2").NumberFormat = "dd/mm/yyyy;@"
                  myexcel.Range("A1:D1").Interior.Color = 5296274
                  myexcel.Range("A2:D2").Interior.Color = 15773696
                  myexcel.Cells(1, 1).Select()
                  myexcel.Activeworkbook.SaveAs(myResult)
                  myexcel.Workbooks.Close()

                  'myexcel.Application.Visible = True
            Catch ex As Exception
                  'MsgBox("Error:There Is A Problem With Excel" & vbLf & "Check Permission Of The Selected Folder, You Should Have Write Permission")
            End Try
      End Sub
      Private Sub butexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butexport.Click
            Dim FileBrowser As New Windows.Forms.SaveFileDialog
            Dim myResult As String
            Dim flag As Boolean = True

            FileBrowser.InitialDirectory = FileIO.SpecialDirectories.Desktop
            FileBrowser.Filter = "Excel files (*.xls)|*.xls"
            FileBrowser.FilterIndex = 1
            FileBrowser.Title = "Select The Location To Save The Report"
            FileBrowser.RestoreDirectory = True
            FileBrowser.ShowDialog()
            myResult = FileBrowser.FileName

            If myResult = "" Then
                  MsgBox("Please Enter The File Name")
                  Exit Sub
            End If

            'Report(myResult, dtpfrom.Value, dtpto.Value)
            'Exit Sub
            Try
                  Dim myexcel As Object = CreateObject("Excel.Application")
                  myexcel.Workbooks.Add()
                  myexcel.Visible = True

                  sSQL = "SELECT pgpid,name,roomnumber FROM student"
                  da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
                  ds = New DataSet
                  da.Fill(ds, "student")

                  myexcel.cells(1, 1).value = "FROM"
                  myexcel.cells(1, 2).value = dtpfrom.Value.ToString("d/M/yyyy")
                  myexcel.cells(1, 3).value = "TO"
                  myexcel.cells(1, 4).value = dtpto.Value.ToString("d/M/yyyy")

                  myexcel.cells(2, 1).value = "PGPID"
                  myexcel.cells(2, 2).value = "STUDENT NAME"
                  myexcel.cells(2, 3).value = "ROOM NUMBER"
                  myexcel.cells(2, 4).value = "TOTAL"

                  For k1 = 0 To ds.Tables("student").Rows.Count - 1
                        With ds.Tables("student").Rows(k1)
                              myexcel.cells(k1 + 3, 1).value = .Item(0).ToString.ToUpper
                              myexcel.cells(k1 + 3, 2).value = .Item(1).ToString.ToUpper
                              myexcel.cells(k1 + 3, 3).value = .Item(2).ToString.ToUpper
                              myexcel.cells(k1 + 3, 4).value = getamount(.Item(0).ToString, flag)
                        End With
                  Next

                  For k1 = 7 To 12
                        myexcel.range(myexcel.cells(1, 1), myexcel.cells(ds.Tables("student").Rows.Count + 2, 4)).Borders.LineStyle = 1 ' xlContinuous                        
                  Next

                  myexcel.Cells.Select()
                  myexcel.Cells.EntireColumn.AutoFit()
                  myexcel.Range("A1:D2").Font.Bold = True
                  myexcel.Range("A1:D2").HorizontalAlignment = -4108 ' xlCenter
                  myexcel.Columns("C:C").HorizontalAlignment = -4108 ' xlCenter
                  myexcel.Columns("D:D").NumberFormat = "0.00"
                  myexcel.Range("A1:D1").Interior.Color = 5296274
                  myexcel.Range("A2:D2").Interior.Color = 15773696
                  myexcel.Cells(1, 1).Select()
                  myexcel.Activeworkbook.SaveAs(myResult)
                  myexcel.Application.Visible = True
            Catch ex As Exception
                  MsgBox("Error:There Is A Problem With Excel" & vbLf & "Check Permission Of The Selected Folder, You Should Have Write Permission")
            End Try

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
      Private Sub butindreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butindreport.Click
            If Rstudent Is Nothing Then
                  lblmsg.Text = "---> * Enter Student's PGPID"
                  lblmsg.ForeColor = Color.Red
                  txtpgpid.Focus()
                  Exit Sub
            End If
            lblmsg.Text = ""
            indreport()
      End Sub
      Private Function getitem_date(ByRef list As List(Of String), ByVal curdate As Long) As Boolean
            list.Clear()
            sSQL = "SELECT DISTINCT itemid,itemname FROM transactiontbl WHERE (pgpid='" & txtpgpid.Text & "' AND timeordered >= " & curdate.ToString & " AND timeordered <" & (curdate + 1).ToString & " ) ORDER BY itemname ASC"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            If ds.Tables("TT").Rows.Count > 0 Then
                  For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                        list.Add(ds.Tables("TT").Rows(k1).Item(0))
                  Next
                  Return True
            Else
                  Return False
            End If
      End Function
      Private Function getitem_count(ByVal itemid As String, ByVal curdate As Long) As Long
            sSQL = "SELECT SUM(qty) FROM transactiontbl WHERE (itemid='" & itemid & "' AND pgpid='" & txtpgpid.Text & "' AND timeordered >= " & curdate.ToString & " AND timeordered <" & (curdate + 1).ToString & " )"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            Return ds.Tables("TT").Rows(0).Item(0)
      End Function
      Private Sub get_date(ByRef thedate As Long, ByVal type As String)
            sSQL = "SELECT " & type & "(timeordered) as mindate FROM transactiontbl WHERE (pgpid='" & txtpgpid.Text & "' AND timeordered >= " & dtpfrom.Value.ToOADate.ToString & " AND timeordered <" & dtpto.Value.AddDays(1).ToOADate.ToString & " )"
            da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            ds = New DataSet
            da.Fill(ds, "TT")
            thedate = Math.Floor(CDate(ds.Tables("TT").Rows(0).Item(0)).ToOADate)
      End Sub
      Private Sub indreport()
            Dim FileBrowser As New Windows.Forms.SaveFileDialog
            Dim myResult As String
            Dim flag As Boolean = True

            FileBrowser.InitialDirectory = FileIO.SpecialDirectories.Desktop
            FileBrowser.Filter = "Excel files (*.xls)|*.xls"
            FileBrowser.FilterIndex = 1
            FileBrowser.Title = "Select The Location To Save The Report"
            FileBrowser.RestoreDirectory = True
            FileBrowser.ShowDialog()
            myResult = FileBrowser.FileName

            If myResult = "" Then
                  MsgBox("Please Enter The File Name")
                  Exit Sub
            End If

            Try
                  Dim myexcel As Object = CreateObject("Excel.Application")
                  myexcel.Workbooks.Add()
                  myexcel.Visible = True

                  myexcel.cells(1, 1).value = "FROM"
                  myexcel.cells(1, 2).value = dtpfrom.Value

                  myexcel.cells(2, 1).value = "TO"
                  myexcel.cells(2, 2).value = dtpto.Value

                  myexcel.cells(3, 1).value = "PGPID"
                  myexcel.cells(3, 2).value = txtpgpid.Text

                  myexcel.cells(4, 1).value = "NAME"
                  myexcel.cells(4, 2).value = lblname.Text.Replace("NAME : ", "")

                  myexcel.cells(5, 1).value = "ROOM NUMBER"
                  myexcel.cells(5, 2).value = lblroomno.Text.Replace("ROOM NO : ", "")

                  Dim IndItemList As New List(Of List(Of String))
                  getindlist(txtpgpid.Text, IndItemList)

                  Dim totalitems(IndItemList.Count - 1) As Long

                  If IndItemList.Count > 0 Then
                        'Header
                        myexcel.cells(1, 3).value = "DATE"
                        For k1 = 0 To IndItemList.Count - 1
                              myexcel.cells(1, k1 + 4).value = IndItemList(k1)(1).ToUpper
                              'myexcel.cells(3, 3 * k1 + 2).value = IndItemList(k1)(1).ToUpper
                              'myexcel.Range(myexcel.cells(3, 3 * k1 + 2), myexcel.cells(3, 3 * (k1 + 1) + 1)).Merge()
                              'myexcel.cells(4, 3 * k1 + 2).value = "QTY"
                              'myexcel.cells(4, 3 * k1 + 2 + 1).value = "PRICE"
                              'myexcel.cells(4, 3 * k1 + 2 + 2).value = "TOTAL"
                        Next

                        Dim mindate As Long
                        get_date(mindate, "min")
                        Dim maxdate As Long
                        get_date(maxdate, "max")

                        Dim listItemCurdate As New List(Of String)
                        Dim ind As Long
                        Dim curdate As Long
                        For curdate = mindate To maxdate
                              'myexcel.cells(curdate - mindate + 2, 3).value = "'" & Date.FromOADate(curdate).ToString("d/M/yyyy")
                              myexcel.cells(curdate - mindate + 2, 3).value = Date.FromOADate(curdate)
                              ind = 0
                              If getitem_date(listItemCurdate, curdate) Then
                                    For k1 = 0 To listItemCurdate.Count - 1
                                          For kk = ind To IndItemList.Count - 1
                                                If IndItemList(kk)(0) = listItemCurdate(k1) Then
                                                      Dim itemcount As Long = getitem_count(listItemCurdate(k1), curdate)
                                                      myexcel.cells(curdate - mindate + 2, kk + 4).value = itemcount
                                                      totalitems(kk) += itemcount
                                                      ind = kk + 1
                                                End If
                                          Next
                                    Next
                              End If
                        Next
                        Dim lastrow As Long = curdate - mindate + 2
                        myexcel.cells(lastrow, 3).value = "Total Items".ToUpper
                        For kk = 0 To IndItemList.Count - 1
                              myexcel.cells(lastrow, kk + 4).value = totalitems(kk)
                        Next
                        myexcel.Rows(lastrow & ":" & lastrow).Font.Bold = True
                        myexcel.range(myexcel.cells(lastrow, 3), myexcel.cells(lastrow, 3 + IndItemList.Count)).Interior.Color = 65535
                        For k1 = 7 To 12
                              myexcel.range(myexcel.cells(1, 3), myexcel.cells(lastrow, 3 + IndItemList.Count)).Borders.LineStyle = 1 ' xlContinuous
                              myexcel.range(myexcel.cells(1, 1), myexcel.cells(5, 2)).Borders.LineStyle = 1 ' xlContinuous                              
                        Next
                  End If

                  myexcel.Cells.EntireColumn.AutoFit()
                  myexcel.Cells.HorizontalAlignment = -4108 ' xlCenter
                  myexcel.Cells.VerticalAlignment = -4108 ' xlCenter

                  myexcel.Range("A1:B5").Font.Bold = True

                  myexcel.Rows("1:1").Font.Bold = True

                  myexcel.Range("A1:B2").Interior.Color = 5296274
                  myexcel.Range("A3:B5").Interior.Color = 15773696
                  myexcel.Cells(1, 1).Select()
                  myexcel.Activeworkbook.SaveAs(myResult)
                  myexcel.Application.Visible = True
            Catch ex As Exception
                  MsgBox("Error:There Is A Problem With Excel" & vbLf & "Check Permission Of The Selected Folder, You Should Have Write Permission")
            End Try

      End Sub
      Private Sub indreport_row()
            Dim FileBrowser As New Windows.Forms.SaveFileDialog
            Dim myResult As String
            Dim flag As Boolean = True

            FileBrowser.InitialDirectory = FileIO.SpecialDirectories.Desktop
            FileBrowser.Filter = "Excel files (*.xls)|*.xls"
            FileBrowser.FilterIndex = 1
            FileBrowser.Title = "Select The Location To Save The Report"
            FileBrowser.RestoreDirectory = True
            FileBrowser.ShowDialog()
            myResult = FileBrowser.FileName

            If myResult = "" Then
                  MsgBox("Please Enter The File Name")
                  Exit Sub
            End If

            Try
                  Dim myexcel As Object = CreateObject("Excel.Application")
                  myexcel.Workbooks.Add()
                  myexcel.Visible = True

                  myexcel.cells(1, 1).value = "FROM"
                  'myexcel.cells(1, 2).value = "'" & dtpfrom.Value.ToString("d/M/yyyy")
                  myexcel.cells(1, 2).value = dtpfrom.Value

                  myexcel.cells(2, 1).value = "TO"
                  'myexcel.cells(2, 2).value = "'" & dtpto.Value.ToString("d/M/yyyy")
                  myexcel.cells(2, 2).value = dtpto.Value

                  myexcel.cells(3, 1).value = "PGPID"
                  myexcel.cells(3, 2).value = txtpgpid.Text

                  myexcel.cells(4, 1).value = "NAME"
                  myexcel.cells(4, 2).value = lblname.Text.Replace("NAME : ", "")

                  myexcel.cells(5, 1).value = "ROOM NUMBER"
                  myexcel.cells(5, 2).value = lblroomno.Text.Replace("ROOM NO : ", "")

                  sSQL = "SELECT timeordered,transid,itemid,itemname,itemdes,qty,sellingprice,total FROM transactiontbl WHERE (pgpid='" & txtpgpid.Text & "' AND timeordered >= " & dtpfrom.Value.ToOADate.ToString & " AND timeordered <" & dtpto.Value.AddDays(1).ToOADate.ToString & " )"
                  da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
                  ds = New DataSet
                  da.Fill(ds, "TT")

                  If ds.Tables("TT").Rows.Count > 0 Then
                        For k1 = 0 To ds.Tables("TT").Columns.Count - 1
                              myexcel.cells(1, k1 + 3).value = ds.Tables("TT").Columns(k1).ColumnName.ToString.ToUpper
                        Next
                        For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                              For k2 = 0 To ds.Tables("TT").Columns.Count - 1
                                    myexcel.cells(k1 + 2, k2 + 3).value = ds.Tables("TT").Rows(k1).Item(k2)
                              Next
                        Next

                        Dim lastrow As Long = ds.Tables("TT").Rows.Count + 1
                        For k1 = 7 To 12
                              myexcel.range(myexcel.cells(1, 3), myexcel.cells(lastrow, 2 + ds.Tables("TT").Columns.Count)).Borders.LineStyle = 1 ' xlContinuous
                              myexcel.range(myexcel.cells(1, 1), myexcel.cells(5, 2)).Borders.LineStyle = 1 ' xlContinuous
                        Next
                        With ds.Tables("TT")
                              myexcel.cells(lastrow + 1, .Columns.Count + 2).value = "=SUM(" & myexcel.range(myexcel.cells(2, .Columns.Count + 2), myexcel.cells(lastrow, .Columns.Count + 2)).address & ")"
                              myexcel.cells(lastrow + 1, .Columns.Count + 2).Font.Bold = True

                              myexcel.range(myexcel.cells(2, .Columns.Count + 2), myexcel.cells(lastrow + 1, .Columns.Count + 2)).NumberFormat = "0.00"

                              myexcel.cells(lastrow + 1, .Columns.Count + 1).value = "TOTAL"
                              myexcel.cells(lastrow + 1, .Columns.Count + 1).Font.Bold = True
                        End With
                  End If
                  myexcel.Cells.EntireColumn.AutoFit()
                  myexcel.Cells.HorizontalAlignment = -4108 ' xlCenter
                  myexcel.Cells.VerticalAlignment = -4108 ' xlCenter
                  myexcel.Range("A1:B5").Font.Bold = True
                  myexcel.Rows("1:1").Font.Bold = True

                  myexcel.Range("A1:B2").Interior.Color = 5296274
                  myexcel.Range("A3:B5").Interior.Color = 15773696
                  myexcel.Cells(1, 1).Select()
                  myexcel.Activeworkbook.SaveAs(myResult)
                  myexcel.Application.Visible = True
            Catch ex As Exception
                  MsgBox("Error:There Is A Problem With Excel" & vbLf & "Check Permission Of The Selected Folder, You Should Have Write Permission")
            End Try

      End Sub
      Private Sub butexportindreport_row_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butexportindreport_row.Click
            If Rstudent Is Nothing Then
                  lblmsg.Text = "---> * Enter Student's PGPID"
                  lblmsg.ForeColor = Color.Red
                  txtpgpid.Focus()
                  Exit Sub
            End If
            lblmsg.Text = ""
            indreport_row()
      End Sub
End Class
