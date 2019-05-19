Imports System.IO
Imports System.IO.Compression
Module Compress

      Sub Main()
            ' Path to directory of files to compress.
            Dim dirpath As String = "C:\Users\VivekK\Desktop\New folder"
            Dim di As DirectoryInfo = New DirectoryInfo(dirpath)

            ' Compress the directory's files.
            For Each fi As FileInfo In di.GetFiles()
                  Compress(fi)
            Next

            ' Decompress all *.gz files in the directory.
            For Each fi As FileInfo In di.GetFiles("*.gz")
                  Decompress(fi)
            Next

      End Sub

      ' Method to compress.
      Public Sub Compress(ByVal fi As FileInfo)
            ' Get the stream of the source file.
            Using inFile As FileStream = fi.OpenRead()
                  ' Compressing:
                  ' Prevent compressing hidden and already compressed files.
                  If (File.GetAttributes(fi.FullName) And FileAttributes.Hidden) <> FileAttributes.Hidden And fi.Extension <> ".gz" Then
                        ' Create the compressed file.
                        Using outFile As FileStream = File.Create(fi.FullName + ".gz")
                              Using Compress As GZipStream = New GZipStream(outFile, CompressionMode.Compress)
                                    ' Copy the source file into the compression stream.
                                    inFile.CopyTo(Compress)
                                    'Console.WriteLine("Compressed {0} from {1} to {2} bytes.", fi.Name, fi.Length.ToString(), outFile.Length.ToString())
                              End Using
                        End Using
                  End If
            End Using
      End Sub

      ' Method to decompress.
      Private Sub Decompress(ByVal fi As FileInfo)
            ' Get the stream of the source file.
            Using inFile As FileStream = fi.OpenRead()
                  ' Get orignial file extension, for example "doc" from report.doc.gz.
                  Dim curFile As String = fi.FullName
                  Dim origName = curFile.Remove(curFile.Length - fi.Extension.Length)
                  ' Create the decompressed file.
                  Using outFile As FileStream = File.Create(origName)
                        Using Decompress As GZipStream = New GZipStream(inFile, CompressionMode.Decompress)
                              ' Copy the decompression stream 
                              ' into the output file.
                              Decompress.CopyTo(outFile)
                              'Console.WriteLine("Decompressed: {0}", fi.Name)
                        End Using
                  End Using
            End Using
      End Sub
End Module