Public Class ListItemItem
      Private _itemid As String
      Private _itemname As String
      Private _qty As Int32
      Private _rop As Int32
      Private _sellingprice As Double
      Private _type As Boolean 'True=stockitem; False=menuitem
      Public Sub New(ByVal itemid As String, ByVal itemname As String, ByVal qty As Int32, ByVal rop As Int32, ByVal sellingprice As Double, ByVal type As Boolean)
            _itemid = itemid
            _itemname = itemname
            _qty = qty
            _rop = rop
            _sellingprice = sellingprice
            _type = type
      End Sub
      Public ReadOnly Property itemid() As String
            Get
                  Return _itemid
            End Get
      End Property
      Public ReadOnly Property itemname() As String
            Get
                  Return _itemname
            End Get
      End Property
      Public ReadOnly Property qty() As String
            Get
                  Return _qty
            End Get
      End Property
      Public ReadOnly Property rop() As String
            Get
                  Return _rop
            End Get
      End Property
      Public ReadOnly Property sellingprice() As String
            Get
                  Return _sellingprice
            End Get
      End Property
End Class
