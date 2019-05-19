Imports System.Data.OleDb
Imports System.Threading
Imports System.IO
Module MEvents
      Dim sSQL As String
      Dim da As OleDbDataAdapter
      Dim ds As DataSet
      Dim cmd As OleDbCommand
      Dim Thread_Mail As Thread
      Dim Thread_Archive As Thread
      Dim Thread_ScheduleArchive As Thread

      Private Sub ThreadTask_ScheduleArchive()
            Try
                  If ISOKArchive() Then
                        Dim type As String = "email"
                        Dim subject As String = "Night Mess Archive (" & Now.ToString("F") & ")"
                        Dim message As String = ""

                        Dim attpath As String = "backup\" & Now.ToString("MMM dd yyyy hh-mm-ss tt")
                        Dim filepath As String = attpath & "\NMS.accdb"

                        Directory.CreateDirectory(attpath)
                        FileCopy("NMS.accdb", filepath)

                        Dim fi As New FileInfo(filepath)
                        Compress.Compress(fi)
                        File.Delete(filepath)

                        Dim TsSQL As String = "INSERT INTO adminevent (type,subject,message,attpath) VALUES" & _
                        "('" & type & "','" & subject & "','" & message & "','" & attpath & "')"
                        Dim cmd1 As New OleDbCommand(TsSQL, My.MyApplication.connEvent)
                        cmd1.ExecuteNonQuery()

                        Start_Archive()
                        Update_lastarchived()
                  End If

                  Dim lastreported As Date
                  If ISOKSendReport(lastreported) Then
                        Dim shift As Int16
                        Dim dateto As Date
                        Dim datefrom As Date

                        shift = lastreported.Day
                        With lastreported.AddDays(-shift + 1)
                              datefrom = New Date(.Year, .Month, .Day)
                        End With

                        shift = Date.DaysInMonth(datefrom.Year, datefrom.Month) - 1
                        With datefrom.AddDays(shift)
                              dateto = New Date(.Year, .Month, .Day)
                        End With

                        Dim type As String = "email"
                        Dim subject As String = "Night Mess Report (" & datefrom.ToString("MMMM dd yyyy") & " to " & dateto.ToString("MMMM dd yyyy") & ")"
                        Dim message As String = ""

                        Dim attpath As String = "backup\Report " & Now.ToString("MMM dd yyyy hh-mm-ss tt")
                        Directory.CreateDirectory(attpath)
                        Dim filepath As String = attpath & "\NMSReport(" & datefrom.ToString("MMMM dd yyyy") & " to " & dateto.ToString("MMMM dd yyyy") & ").xls"

                        usrreport.Report(New FileInfo(filepath).FullName, datefrom, dateto)

                        Dim TsSQL As String = "INSERT INTO adminevent (type,subject,message,attpath) VALUES" & _
                        "('" & type & "','" & subject & "','" & message & "','" & attpath & "')"
                        Dim cmd1 As New OleDbCommand(TsSQL, My.MyApplication.connEvent)
                        cmd1.ExecuteNonQuery()

                        Start_Archive()
                        Update_lastreported()
                  End If

                  Dim lastcleaned As Date
                  If ISOKClean(lastcleaned) Then
                        lastcleaned = New Date(lastcleaned.Year, lastcleaned.Month, 1)
                        Dim TsSQL As String = "DELETE FROM transactiontbl WHERE(timeordered < " & lastcleaned.ToOADate.ToString & ")"
                        Dim cmd1 As New OleDbCommand(TsSQL, My.MyApplication.conn)
                        cmd1.ExecuteNonQuery()

                        lastcleaned = lastcleaned.AddMonths(1)
                        Dim lastupdated As String = Now.ToOADate().ToString
                        TsSQL = "UPDATE datetrack SET  lastcleaned = " & lastcleaned.ToOADate.ToString & ""
                        cmd1 = New OleDbCommand(TsSQL, My.MyApplication.connEvent)
                        cmd1.ExecuteNonQuery()
                  End If
            Catch ex As Exception

            End Try
      End Sub
      Public Sub Start_ScheduleArchive()
            'Thread.Sleep(5000)
            If Thread_ScheduleArchive Is Nothing Then
                  Thread_ScheduleArchive = New Thread(AddressOf ThreadTask_ScheduleArchive)
                  Thread_ScheduleArchive.IsBackground = True
                  Thread_ScheduleArchive.Start()
            End If
            If Thread_ScheduleArchive.ThreadState = ThreadState.Stopped Then
                  Thread_ScheduleArchive = New Thread(AddressOf ThreadTask_ScheduleArchive)
                  Thread_ScheduleArchive.IsBackground = True
                  Thread_ScheduleArchive.Start()
            End If
      End Sub

      Private Sub ThreadTask_Archive()
            Dim TsSQL As String
            Dim Tda As OleDbDataAdapter
            Dim Tds As DataSet

            While True
                  Try
                        Dim AttMail As New List(Of String)
                        Dim ToMail As New List(Of String)
                        Dim CCMail As New List(Of String)

                        TsSQL = "SELECT TOP 1 * FROM adminevent"
                        Tda = New OleDbDataAdapter(TsSQL, My.MyApplication.connEvent)
                        Tds = New DataSet
                        Tda.Fill(Tds, "TT")

                        If Tds.Tables("TT").Rows.Count = 1 Then
                              With Tds.Tables("TT").Rows(0)
                                    If .Item("type").ToString = "email" Then
                                          Dim folderpath As String = .Item("attpath").ToString
                                          If Directory.Exists(folderpath) = False Then
                                                DeleteTopRow_adminevent()
                                          End If
                                          ToMail.Add(NMS.Gmail_Username & "@gmail.com")
                                          Dim di As DirectoryInfo = New DirectoryInfo(folderpath)
                                          For Each fi As FileInfo In di.GetFiles()
                                                AttMail.Add(fi.FullName)
                                          Next
                                          Mail.SendGMail(NMS.Gmail_Username, NMS.Gmail_Password, AttMail, ToMail, CCMail, .Item("subject").ToString, .Item("message").ToString)
                                          DeleteTopRow_adminevent()
                                          'Delete Folder
                                          Directory.Delete(folderpath, True)
                                    ElseIf .Item("type").ToString = "clean" Then
                                    ElseIf .Item("type").ToString = "report" Then
                                    ElseIf .Item("type").ToString = "indreport" Then
                                    End If

                              End With
                        Else
                              Exit While
                        End If
                  Catch ex As Exception

                  End Try
            End While
      End Sub
      Public Sub Start_Archive()
            If Thread_Archive Is Nothing Then
                  Thread_Archive = New Thread(AddressOf ThreadTask_Archive)
                  Thread_Archive.IsBackground = True
                  Thread_Archive.Start()
            End If
            If Thread_Archive.ThreadState = ThreadState.Stopped Then
                  Thread_Archive = New Thread(AddressOf ThreadTask_Archive)
                  Thread_Archive.IsBackground = True
                  Thread_Archive.Start()
            End If
      End Sub

      Private Sub ThreadTask_Mail()
            Dim TsSQL As String
            Dim Tda As OleDbDataAdapter
            Dim Tds As DataSet
            Dim Tcmd As OleDbCommand

            While True
                  Try
                        Dim AttMail As New List(Of String)
                        Dim ToMail As New List(Of String)
                        Dim CCMail As New List(Of String)

                        TsSQL = "SELECT TOP 1 * FROM transactionevent"
                        Tda = New OleDbDataAdapter(TsSQL, My.MyApplication.connEvent)
                        Tds = New DataSet
                        Tda.Fill(Tds, "TT")

                        If Tds.Tables("TT").Rows.Count = 1 Then
                              With Tds.Tables("TT").Rows(0)
                                    'ToMail.AddRange(.Item("mailid").ToString.TrimEnd(";").Split(";"))
                                    ToMail.Add(.Item("mailid").ToString)
                                    Mail.SendGMail(NMS.Gmail_Username, NMS.Gmail_Password, AttMail, ToMail, CCMail, .Item("subject").ToString, .Item("message").ToString)
                              End With

                              TsSQL = "DELETE TBL FROM (SELECT TOP 1 * FROM transactionevent) TBL"
                              Tcmd = New OleDbCommand(TsSQL, My.MyApplication.connEvent)
                              Tcmd.ExecuteNonQuery()
                        Else
                              Exit While
                        End If
                  Catch ex As Exception

                  End Try
            End While
      End Sub
      Public Sub Start_Mail()
            If Thread_Mail Is Nothing Then
                  Thread_Mail = New Thread(AddressOf ThreadTask_Mail)
                  Thread_Mail.IsBackground = True
                  Thread_Mail.Start()
            End If
            If Thread_Mail.ThreadState = ThreadState.Stopped Then
                  Thread_Mail = New Thread(AddressOf ThreadTask_Mail)
                  Thread_Mail.IsBackground = True
                  Thread_Mail.Start()
            End If
      End Sub

      Private Function GetMailID(ByVal pgpid As String)
            Dim TsSQL As String
            Dim Tda As OleDbDataAdapter
            Dim Tds As DataSet
            TsSQL = "SELECT email FROM student WHERE(pgpid='" & pgpid & "')"
            Tda = New OleDbDataAdapter(TsSQL, My.MyApplication.conn)
            Tds = New DataSet
            Tda.Fill(Tds, "TT")

            If IsDBNull(Tds.Tables("TT").Rows(0).Item(0)) Then
                  Return pgpid & "@iiml.ac.in"
            Else
                  Dim eid As String = Tds.Tables("TT").Rows(0).Item(0).ToString
                  If eid.Length > 0 Then
                        If eid.Contains("@") Then
                              Return eid
                        Else
                              Return eid & "@iiml.ac.in"
                        End If
                  Else
                        Return NMS.Gmail_Username & "@gmail.com"
                  End If
            End If

      End Function
      Public Sub SendMail(ByVal pgpid As String, ByVal transid As String)
            Try
                  Dim mailid As String = GetMailID(pgpid)
                  Dim subject As String = "Night Mess"
                  Dim message As String = ""

                  sSQL = "SELECT itemname,qty,sellingprice,total,timeordered FROM transactiontbl WHERE(transid='" & transid & "')"
                  da = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
                  ds = New DataSet
                  da.Fill(ds, "TT")

                  Dim date1 As Date = ds.Tables("TT").Rows(0).Item("timeordered")

                  message &= "<div>"
                  'message &= "<h1>Transaction ID:" & transid & "(" & date1.ToString("d/m/yyyy h:mm:ss tt") & ")</h1><br/>"
                  message &= "<h3>Transaction ID:" & transid & "    (" & date1.ToString("F") & ")</h3><br/>"
                  message &= "<table style=""text-align:center"">"
                  message &= "<tr>"
                  message &= "<th>ITEM</th>"
                  message &= "<th>PRICE</th>"
                  message &= "<th>QTY</th>"
                  message &= "<th>TOTAL</th>"
                  message &= "</tr>"
                  Dim total As Double = 0
                  For k1 = 0 To ds.Tables("TT").Rows.Count - 1
                        With ds.Tables("TT").Rows(k1)
                              message &= "<tr>"
                              message &= "<td  style=""text-align:left"">" & .Item("itemname") & "</td>"
                              message &= "<td>" & .Item("sellingprice") & "</td>"
                              message &= "<td>" & .Item("qty") & "</td>"
                              message &= "<td  style=""text-align:right"">" & .Item("total") & "</td>"
                              message &= "</tr>"
                              total += .Item("total")
                        End With
                  Next
                  message &= "<tr style=""text-align:right;font-weight:bold;color:Red"">"
                  message &= "<td colspan=""3"" > TOTAL </td>"
                  message &= "<td>" & total & "</td>"
                  message &= "</tr>"
                  message &= "</table>"
                  message &= "</div>"

                  sSQL = "INSERT INTO transactionevent (mailid,subject,message) VALUES ( '" & mailid & "','" & subject & "','" & message & "')"
                  cmd = New OleDbCommand(sSQL, My.MyApplication.connEvent)
                  cmd.ExecuteNonQuery()
                  Start_Mail()
            Catch ex As Exception
            End Try
      End Sub

      Private Sub DeleteTopRow_adminevent()
            Dim TsSQL As String
            Dim Tcmd As OleDbCommand
            TsSQL = "DELETE TBL FROM (SELECT TOP 1 * FROM adminevent) TBL"
            Tcmd = New OleDbCommand(TsSQL, My.MyApplication.connEvent)
            Tcmd.ExecuteNonQuery()
      End Sub

      Public Sub Update_lastupdated()
            Try
                  Dim lastupdated As String = Now.ToOADate().ToString
                  Dim TsSQL As String = "UPDATE datetrack SET  lastupdated = " & lastupdated & ""
                  Dim cmd1 As New OleDbCommand(TsSQL, My.MyApplication.connEvent)
                  cmd1.ExecuteNonQuery()
            Catch ex As Exception
            End Try
      End Sub
      Private Sub Update_lastarchived()
            Dim lastarchived As String = Now.ToOADate().ToString
            Dim TsSQL As String = "UPDATE datetrack SET  lastarchived = " & lastarchived & ",lastupdated = " & lastarchived
            Dim cmd1 As New OleDbCommand(TsSQL, My.MyApplication.connEvent)
            cmd1.ExecuteNonQuery()
      End Sub
      Private Sub Update_lastreported()
            Dim lastarchived As String = Now.ToOADate().ToString
            Dim TsSQL As String = "UPDATE datetrack SET  lastreported = " & lastarchived & ""
            Dim cmd1 As New OleDbCommand(TsSQL, My.MyApplication.connEvent)
            cmd1.ExecuteNonQuery()
      End Sub
      Private Function ISOKSendReport(ByRef lastreported As Date) As Boolean
            Dim TsSQL As String
            Dim Tda As OleDbDataAdapter
            Dim Tds As DataSet

            TsSQL = "SELECT lastreported FROM datetrack"
            Tda = New OleDbDataAdapter(TsSQL, My.MyApplication.connEvent)
            Tds = New DataSet
            Tda.Fill(Tds, "TT")

            If IsDBNull(Tds.Tables("TT").Rows(0).Item("lastreported")) Then
                  lastreported = DateTime.Today.AddDays(-DateTime.Today.Day)
                  Return True
            End If

            lastreported = Tds.Tables("TT").Rows(0).Item("lastreported")
            If CInt(lastreported.ToString("%M")) <> CInt(Now.ToString("%M")) Then
                  Return True
            Else
                  Return False
            End If
      End Function
      Private Function ISOKArchive()
            Dim TsSQL As String
            Dim Tda As OleDbDataAdapter
            Dim Tds As DataSet

            TsSQL = "SELECT * FROM datetrack"
            Tda = New OleDbDataAdapter(TsSQL, My.MyApplication.connEvent)
            Tds = New DataSet
            Tda.Fill(Tds, "TT")

            If Tds.Tables("TT").Rows.Count < 1 Or IsDBNull(Tds.Tables("TT").Rows(0).Item("lastarchived")) Or IsDBNull(Tds.Tables("TT").Rows(0).Item("lastupdated")) Then
                  Return True
            End If

            If Tds.Tables("TT").Rows(0).Item("lastarchived") = Tds.Tables("TT").Rows(0).Item("lastupdated") Then
                  Return False
            Else
                  Return True
            End If
      End Function
      Private Function ISOKClean(ByRef lastcleaned As Date)
            Try
                  Dim TsSQL As String
                  Dim Tda As OleDbDataAdapter
                  Dim Tds As DataSet

                  TsSQL = "SELECT lastcleaned,cleanmonth FROM datetrack"
                  Tda = New OleDbDataAdapter(TsSQL, My.MyApplication.connEvent)
                  Tds = New DataSet
                  Tda.Fill(Tds, "TT")

                  lastcleaned = Tds.Tables("TT").Rows(0).Item("lastcleaned")
                  Dim cm As Integer = Tds.Tables("TT").Rows(0).Item("cleanmonth")

                  'Dim ts As TimeSpan = Now.Subtract(lastcleaned)
                  If 12 * (Now.Year - lastcleaned.Year) + Now.Month - lastcleaned.Month >= cm Then
                        Return True
                  Else
                        Return False
                  End If
            Catch ex As Exception
                  Return False
            End Try

      End Function
End Module
