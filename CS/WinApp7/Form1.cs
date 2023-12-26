using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Native;
using DevExpress.XtraDiagram;
using System.Data;
using System.Linq;

namespace WinApp7
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            diagramControl1.CreateDocking();
            diagramControl1.CreateRibbon();
            diagramControl1.OptionsBehavior.SelectedStencils = new StencilCollection() { "BasicShapes" };

            diagramControl1.AddingNewItem += DiagramControl1_AddingNewItem;
            diagramControl1.BeforeItemsMoving += DiagramControl1_BeforeItemsMoving;
            diagramControl1.ItemsMoving += DiagramControl1_ItemsMoving;
        }
        private void DiagramControl1_AddingNewItem(object sender, DevExpress.XtraDiagram.DiagramAddingNewItemEventArgs e) {
            e.Cancel = (e.Item is DiagramShape shape && shape.Shape == BasicShapes.Rectangle);
        }

        private void DiagramControl1_BeforeItemsMoving(object sender, DevExpress.XtraDiagram.DiagramBeforeItemsMovingEventArgs e) {
            if (e.Items.Where(item => item is DiagramShape shape && shape.ParentItem != null && shape.Shape == BasicShapes.Triangle).Count() > 0)
                e.Items.Clear();
        }

        private void DiagramControl1_ItemsMoving(object sender, DevExpress.XtraDiagram.DiagramItemsMovingEventArgs e) {
            //condition 1: the item type
            if (e.Items.Where(item => item.Item is DiagramShape shape && shape.Shape == BasicShapes.Ellipse).Count() > 0)
                e.Cancel = true;

            //condition 2: the item parent
            else if (e.Items.Where(item => CheckItemParent(item)).Count() > 0)
                e.Allow = false;

            //condition 3: the item position
            else if (e.Items.Where(item => CheckItemPosition(item)).Count() > 0)
                e.Allow = false;
        }
        public bool CheckItemParent(MovingItem item) {
            if (item.Item is DiagramShape shape && shape.Shape == BasicShapes.RightTriangle) {
                var parent = item.NewParent as DiagramContainer;
                if (parent != null && parent.Items.Count > 0 && parent.Items.OfType<DiagramShape>().Where(child => child.Shape == shape.Shape).Count() > 0)
                    return true;
            }
            return false;
        }

        public bool CheckItemPosition(MovingItem item) {
            if (item.Item is DiagramShape shape && shape.Shape == BasicShapes.Pentagon) {
                var itemRect = new System.Windows.Rect(new System.Windows.Point(item.NewDiagramPosition.X, item.NewDiagramPosition.Y), new System.Windows.Size(item.Item.Width, item.Item.Height));
                foreach (var diagramShape in diagramControl1.Items.OfType<DiagramShape>().Where(x => x != shape)) {
                    var diagramShapeRect = diagramShape.RotatedDiagramBounds().Rect;
                    var extendedBounds = new System.Windows.Rect(diagramShapeRect.X - 100, diagramShapeRect.Y - 100, diagramShapeRect.Width + 200, diagramShapeRect.Height + 200);

                    if (extendedBounds.Contains(itemRect))
                        return true;
                }
            }
            return false;
        }
    }
}
