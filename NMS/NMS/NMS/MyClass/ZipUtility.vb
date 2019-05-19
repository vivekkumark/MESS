'kleinma 2006
'www.vbforums.com
'
'ZIP UTILITY
'
'THIS CLASS (WHICH I PLAN TO EXTEND) CAN ZIP FILES USING JAVA CLASSES THAT EXIST INSIDE'
'THE .NET FRAMEWORK. THIS MEANS YOU CAN ACCESS THEM VIA VB, AND WRITE CODE TO ZIP FILES UP
'NO NEED FOR 3rd PARTY TOOLS LIKE WINZIP OR WINRAR. WORKS ON ALL SYSTEMS THAT THE .NET FRAMEWORK
'CAN BE INSTALLED ON.
'
'PLEASE CONTACT ME ON VBFORUMS IF YOU FIND ANY PROBLEMS. THIS IS A BETA VERSION OF THIS CLASS.

Imports java.util.zip
Imports java.io

Public Class ZipUtility

    Public Shared Function CreateZip(ByVal FileNames() As String, ByVal ZipFileName As String) As Boolean

        'THIS SAMPLE WILL NOT ALLOW THE ZIP FILE TO BE CREATED IF IT ALREADY EXISTS
        'MODIFY AS NEEDED, I WILL WORK ON ADDING IN SUPPORT FOR APPENDING AND OVERWRITING
        If DoesFileExist(ZipFileName) Then
            Throw New IOException("zip file already exists")
            Return False
        End If

        Try
            'OUTPUT STREAM THAT WILL WRITE OUT THE ZIP FILE, THIS 
            Dim MyOutputStream As New ZipOutputStream(New java.io.FileOutputStream(ZipFileName))

            'FILE INPUT STEAM
            Dim MyFileStream As java.io.FileInputStream

            'OUR ZIP ENTRY, ONE FOR EACH FILE
            Dim MyZipEntry As ZipEntry
            'A BUFFER FOR THE I/O
            Dim Buffer(1023) As SByte

            'LOOP EACH FILE NAME IN OUR ARRAY
            For Each FileName As String In FileNames
                'CHECK THAT FILE EXISTS BEFORE TRYING TO INCLUDE IT IN THE ZIP
                If DoesFileExist(FileName) Then
                    'CREATE A NEW ENTRY IN THE ZIP FILE, BASED ON THE FILE NAME
                    MyZipEntry = New ZipEntry(New IO.FileInfo(FileName).Name)
                    'SET IT TO DEFLATE (COMPACT IT)
                    MyZipEntry.setMethod(ZipEntry.DEFLATED)
                    'STICK THE ENTRY IN THE ZIP FILE
                    MyOutputStream.putNextEntry(MyZipEntry)
                    'CREATE A FILE STREAM TO WRITE THE FILE TO THE ZIP
                    MyFileStream = New java.io.FileInputStream(FileName)

                    'A COUNTER WHILE WE INPUT THE BUFFER INTO THE FILE
                    Dim nCount As Integer = 0

                    'LOOP THE INPUT FILE STREAM AND WRITE IT TO THE ZIP FILE
                    nCount = MyFileStream.read(Buffer, 0, Buffer.Length)
                    While nCount > 0
                        MyOutputStream.write(Buffer, 0, nCount)
                        nCount = MyFileStream.read(Buffer, 0, Buffer.Length)
                    End While
                    'CLOSE THE FILE STREAM FOR THE FILE BEING ZIPPED
                    MyFileStream.close()
                    'CLOSE THE ENTRY IN THE ZIP FILE
                    MyOutputStream.closeEntry()
                End If
            Next

            'ALL DONE, CLOSE THE ZIP FILE
            MyOutputStream.close()

            'IF WE MADE IT THIS FAR, RETURN TRUE
            Return True
        Catch ex As Exception
            'PASS THE EXCEPTION TO THE CALLING ROUTINE
            Throw ex
            'RETURN FALSE
            Return False
        End Try

    End Function

    Private Shared Function DoesFileExist(ByVal FileName As String) As Boolean
        Return System.IO.File.Exists(FileName)
    End Function

End Class
