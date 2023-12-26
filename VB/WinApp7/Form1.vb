Imports DevExpress.Diagram.Core
Imports DevExpress.Diagram.Core.Native
Imports DevExpress.XtraDiagram
Imports System.Data
Imports System.Linq

Namespace WinApp7

    Public Partial Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            diagramControl1.CreateDocking()
            diagramControl1.CreateRibbon()
            diagramControl1.OptionsBehavior.SelectedStencils = New StencilCollection() From {"BasicShapes"}
            AddHandler diagramControl1.AddingNewItem, AddressOf DiagramControl1_AddingNewItem
            AddHandler diagramControl1.BeforeItemsMoving, AddressOf DiagramControl1_BeforeItemsMoving
            AddHandler diagramControl1.ItemsMoving, AddressOf DiagramControl1_ItemsMoving
        End Sub

        Private Sub DiagramControl1_AddingNewItem(ByVal sender As Object, ByVal e As DiagramAddingNewItemEventArgs)
            Dim shape As DiagramShape = Nothing
            e.Cancel =(CSharpImpl.__Assign(shape, TryCast(e.Item, DiagramShape)) IsNot Nothing AndAlso shape.Shape Is BasicShapes.Rectangle)
        End Sub

        Private Sub DiagramControl1_BeforeItemsMoving(ByVal sender As Object, ByVal e As DiagramBeforeItemsMovingEventArgs)
            Dim shape As DiagramShape = Nothing
            If e.Items.Where(Function(item)
                Dim shape As DiagramShape = Nothing
                Return CSharpImpl.__Assign(shape, TryCast(item, DiagramShape)) IsNot Nothing AndAlso shape.ParentItem IsNot Nothing AndAlso shape.Shape Is BasicShapes.Triangle
            End Function).Count() > 0 Then e.Items.Clear()
        End Sub

        Private Sub DiagramControl1_ItemsMoving(ByVal sender As Object, ByVal e As DiagramItemsMovingEventArgs)
            'condition 1: the item type
            Dim shape As DiagramShape = Nothing
            If e.Items.Where(Function(item)
                Dim shape As DiagramShape = Nothing
                Return CSharpImpl.__Assign(shape, TryCast(item.Item, DiagramShape)) IsNot Nothing AndAlso shape.Shape Is BasicShapes.Ellipse
            End Function).Count() > 0 Then
                e.Cancel = True
            'condition 2: the item parent
            ElseIf e.Items.Where(Function(item) CheckItemParent(item)).Count() > 0 Then
                e.Allow = False
            'condition 3: the item position
            ElseIf e.Items.Where(Function(item) CheckItemPosition(item)).Count() > 0 Then
                e.Allow = False
            End If
        End Sub

        Public Function CheckItemParent(ByVal item As MovingItem) As Boolean
            Dim shape As DiagramShape = Nothing
            If CSharpImpl.__Assign(shape, TryCast(item.Item, DiagramShape)) IsNot Nothing AndAlso shape.Shape Is BasicShapes.RightTriangle Then
                Dim parent = TryCast(item.NewParent, DiagramContainer)
                If parent IsNot Nothing AndAlso parent.Items.Count > 0 AndAlso parent.Items.OfType(Of DiagramShape)().Where(Function(child) child.Shape Is shape.Shape).Count() > 0 Then Return True
            End If

            Return False
        End Function

        Public Function CheckItemPosition(ByVal item As MovingItem) As Boolean
            Dim shape As DiagramShape = Nothing
            If CSharpImpl.__Assign(shape, TryCast(item.Item, DiagramShape)) IsNot Nothing AndAlso shape.Shape Is BasicShapes.Pentagon Then
                Dim itemRect = New System.Windows.Rect(New System.Windows.Point(item.NewDiagramPosition.X, item.NewDiagramPosition.Y), New System.Windows.Size(item.Item.Width, item.Item.Height))
                For Each diagramShape In diagramControl1.Items.OfType(Of DiagramShape)().Where(Function(x) x IsNot shape)
                    Dim diagramShapeRect = diagramShape.RotatedDiagramBounds().Rect
                    Dim extendedBounds = New System.Windows.Rect(diagramShapeRect.X - 100, diagramShapeRect.Y - 100, diagramShapeRect.Width + 200, diagramShapeRect.Height + 200)
                    If extendedBounds.Contains(itemRect) Then Return True
                Next
            End If

            Return False
        End Function

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
