Imports System.Data.OleDb
Public Class ListItemcombo

      Private _comboname As String
      Private _menu As List(Of List(Of String))
      Public Sub New(ByVal comboname As String)
            _comboname = comboname
            _menu = New List(Of List(Of String))
            Dim mylist As List(Of String)
            Dim sSQL As String
            Dim da1 As OleDbDataAdapter
            Dim ds1 As New DataSet

            sSQL = "SELECT itemid,itemname,discount  FROM combo WHERE(comboname='" & _comboname & "')"
            da1 = New OleDbDataAdapter(sSQL, My.MyApplication.conn)
            da1.Fill(ds1, "TT1")

            Dim sp As Double
            Dim ssp As Double
            Dim rp As Double = 0 'regular
            Dim cp As Double = 0 'combo
            Dim type As String = ""

            For k1 = 0 To ds1.Tables("TT1").Rows.Count - 1
                  mylist = New List(Of String)
                  sp = SQL.get_sellingprice(ds1.Tables("TT1").Rows(k1).Item("itemid").ToString, type)
                  rp += sp
                  mylist.Add(ds1.Tables("TT1").Rows(k1).Item("itemname").ToString.ToUpper)
                  mylist.Add(CStr(sp))
                  If ds1.Tables("TT1").Rows(k1).Item("discount") = 100 Then
                        mylist.Add("FREE")
                  Else
                        ssp = (100.0 - CDbl(ds1.Tables("TT1").Rows(k1).Item("discount").ToString)) * sp / 100.0
                        cp += ssp
                        mylist.Add(CStr(ssp))
                  End If
                  mylist.Add(ds1.Tables("TT1").Rows(k1).Item("itemid").ToString())
                  mylist.Add(type)
                  _menu.Add(mylist)
            Next

            mylist = New List(Of String)
            mylist.Add("TOTAL")
            mylist.Add(rp)
            mylist.Add(cp)
            _menu.Add(mylist)

      End Sub
      Public ReadOnly Property comboname() As String
            Get
                  Return _comboname
            End Get
      End Property
      Public ReadOnly Property menu() As List(Of List(Of String))
            Get
                  Return _menu
            End Get
      End Property
End Class
