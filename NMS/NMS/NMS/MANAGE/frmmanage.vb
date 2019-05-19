Public Class frmmanage
      Private Sub addusr(ByRef usr As UserControl)
            tbllayoutmanage.Controls.Add(usr, 1, 0)
            usr.Dock = DockStyle.Fill
      End Sub
      Private Sub butreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butreport.Click
            Dim usr As New usrreport
            addusr(usr)
      End Sub

      Private Sub butback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butback.Click
            NMS.Visible = True
            Me.Close()
      End Sub

      Private Sub frmmanage_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            NMS.Visible = True
      End Sub

      Private Sub frmmanage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim usr As New usrreport
            usr.txtpgpid.Text = NMS.txtpgpid.Text
            addusr(usr)
      End Sub
End Class