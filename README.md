<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/735928450/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1208174)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WinForms Diagram Control - How to track and restrict the drag action

This example demonstrates how to restrict items dragging actions in the Diagram Control.

The DiagramControl allows you to use several events that are raised at different moments of time to customize or prohibit items dragging actions:
1) `AddingNewItem` - this event is raised when a user drags a new item to the canvas.
2) `BeforeItemsMoving` - this event is raised when a user initiates the items drag/move action. It allows you to customize the dragged items.
3) `ItemsMoving` - this event is raised during the items drag/move action and allows you to restrict this action based on the stage, an item's new/old position and new/old parent.

This example demonstrates how to handle these events to implement similar restrictions:


1) You cannot drop the “Rectangle” and “Ellipse” shapes to the canvas;
2) You cannot move the “Triangle” shape after you dropped it to the canvas;
3) You cannot move the “RightTriangle” shape to a container if it contains at least one “RightTriangle” shape;
4) You cannot drop the “Pentagon” shape near another shape.

## Files to Review

- [Form1.cs](./CS/WinApp7/Form1.cs) (VB: [Form1.vb](./VB/WinApp7/Form1.vb))

## Documentation

- [DiagramControl.AddingNewItem](https://docs.devexpress.com/WindowsForms/DevExpress.XtraDiagram.DiagramControl.AddingNewItem)
- [DiagramControl.BeforeItemsMoving](https://docs.devexpress.com/WindowsForms/DevExpress.XtraDiagram.DiagramControl.BeforeItemsMoving)
- [DiagramControl.ItemsMoving](https://docs.devexpress.com/WindowsForms/DevExpress.XtraDiagram.DiagramControl.ItemsMoving)
