Imports System.IO
Module Compact
      Sub Main1()
            Try
                  Dim File_Path, compact_file As String
                  'Original file path that u want to compact
                  File_Path = AppDomain.CurrentDomain.BaseDirectory & "db.mdb"
                  File_Path = "C:\Users\VivekK\Desktop\NMS.accdb"
                  'compact file path, a temp file
                  compact_file = AppDomain.CurrentDomain.BaseDirectory & "db1.mdb"
                  compact_file = "C:\Users\VivekK\Desktop\NMS1.accdb"
                  'First check the file u want to compact exists or not
                  If File.Exists(File_Path) Then
                        Dim db As New dao.DBEngine()
                        'CompactDatabase has two parameters, creates a copy of 
                        'compact DB at the Destination path
                        db.CompactDatabase(File_Path, compact_file)
                  End If
                  'restore the original file from the compacted file
                  If File.Exists(compact_file) Then
                        File.Delete(File_Path)
                        File.Move(compact_file, File_Path)
                  End If
            Catch ex As Exception
                  MsgBox(ex.Message)
            End Try
      End Sub
      Sub CompactDB(ByVal DBName As String, ByVal password As String)
            Dim sLocalFile As String = DBName & ".accdb"
            Dim sLocalOutFile As String = DBName & "1.accdb"

            If File.Exists(sLocalOutFile) Then
                  File.Delete(sLocalOutFile)
            End If

            Dim JROEng As Object
            JROEng = CreateObject("JRO.JetEngine")
            JROEng.CompactDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sLocalFile & ";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=" & password & ";", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sLocalOutFile & ";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=" & password & ";")

            If File.Exists(sLocalOutFile) Then
                  File.Delete(sLocalFile)
                  File.Move(sLocalOutFile, sLocalFile)
            End If

      End Sub
      Sub CompactDB(ByVal DBName As String)
            Dim sLocalFile As String = DBName & ".accdb"
            Dim sLocalOutFile As String = DBName & "1.accdb"

            If File.Exists(sLocalOutFile) Then
                  File.Delete(sLocalOutFile)
            End If

            Dim JROEng As Object
            JROEng = CreateObject("JRO.JetEngine")
            JROEng.CompactDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sLocalFile & ";Jet OLEDB:Engine Type=5", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & sLocalOutFile & ";Jet OLEDB:Engine Type=5")

            If File.Exists(sLocalOutFile) Then
                  File.Delete(sLocalFile)
                  File.Move(sLocalOutFile, sLocalFile)
            End If

      End Sub
End Module
