Imports System.Net.Mail
Module Mail
      Sub SendGMail(ByVal username As String, ByVal password As String, ByVal AttMail As List(Of String), ByVal ToMail As List(Of String), ByVal CCMail As List(Of String), ByVal subject As String, ByVal message As String)

            Dim mail As MailMessage = New MailMessage()
            mail.From = New MailAddress(username & "@gmail.com")

            For k1 = 0 To AttMail.Count - 1
                  mail.Attachments.Add(New Attachment(AttMail(k1)))
            Next

            For k1 = 0 To ToMail.Count - 1
                  mail.To.Add(ToMail(k1))
            Next

            For k1 = 0 To CCMail.Count - 1
                  mail.CC.Add(CCMail(k1))
            Next

            mail.Subject = subject
            mail.Body = message
            mail.IsBodyHtml = True

            Dim smtp As SmtpClient = New SmtpClient()
            smtp.Port = 587
            smtp.UseDefaultCredentials = False
            smtp.Host = "smtp.gmail.com"
            smtp.Credentials = New System.Net.NetworkCredential(username, password)
            smtp.EnableSsl = True
            'smtp.Port = 433
            smtp.Send(mail)
            mail.Dispose()
      End Sub
End Module
