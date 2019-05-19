Public Class ListItemCat
      Private _Item As String
      Private _Data As String
      Public Sub New(ByVal Item As String, ByVal Data As String)
            _Item = Item
            _Data = Data
      End Sub
      Public Property ItemName() As String
            Get
                  Return _Item
            End Get
            Set(ByVal value As String)
                  _Item = value
            End Set
      End Property
      Public Property ItemIdPrefix() As String
            Get
                  Return _Data
            End Get
            Set(ByVal value As String)
                  _Data = value
            End Set
      End Property
End Class
