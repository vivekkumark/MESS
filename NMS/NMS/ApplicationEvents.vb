Imports System.Data.OleDb

Namespace My

      ' The following events are available for MyApplication:
      ' 
      ' Startup: Raised when the application starts, before the startup form is created.
      ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
      ' UnhandledException: Raised if the application encounters an unhandled exception.
      ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
      ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
      Partial Friend Class MyApplication
            Public Shared connStr As String
            Public Shared conn As OleDbConnection

            Public Shared connEventStr As String
            Public Shared connEvent As OleDbConnection
            Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged

            End Sub
            Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
                  Try
                        conn.Close()
                        connEvent.Close()
                  Catch ex As Exception
                  End Try

                  Try
                        NMS.ETimer.Stop()
                  Catch ex As Exception
                  End Try
            End Sub

            Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

                  'Compact.CompactDB("pNMS", "11mlm3$$i")
                  'connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=pNMS.accdb;Jet OLEDB:Database Password=11mlm3$$i;"
                  Dim dbase As String
                  Dim password As String

                  dbase = "NMS.accdb"
                  password = "11mlm3$$i"
                  'password = ""
                  connStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password={1};", dbase, password)
                  conn = New OleDbConnection(connStr)
                  Try
                        Compact.CompactDB("NMS", password)
                  Catch ex As Exception
                  End Try
                  Try
                        conn.Open()
                  Catch ex As Exception
                        MsgBox("Application Could Not Found Database File")
                        End
                  End Try


                  dbase = "Events.accdb"
                  password = "11mlm3$$i"
                  'password = ""
                  connEventStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password={1};", dbase, password)
                  connEvent = New OleDbConnection(connEventStr)
                  Try
                        Compact.CompactDB("EVENTS", password)
                  Catch ex As Exception
                  End Try
                  Try
                        connEvent.Open()
                  Catch ex As Exception
                  End Try
                  MEvents.Start_ScheduleArchive()
                  MEvents.Start_Archive()
                  MEvents.Start_Mail()
            End Sub
      End Class
End Namespace

