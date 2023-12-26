Namespace WinApp7

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.diagramControl1 = New DevExpress.XtraDiagram.DiagramControl()
            CType((Me.diagramControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' diagramControl1
            ' 
            Me.diagramControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.diagramControl1.Location = New System.Drawing.Point(0, 0)
            Me.diagramControl1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.diagramControl1.Name = "diagramControl1"
            Me.diagramControl1.OptionsBehavior.SelectedStencils = New DevExpress.Diagram.Core.StencilCollection(New String(-1) {})
            Me.diagramControl1.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter
            Me.diagramControl1.OptionsView.ShowGrid = False
            Me.diagramControl1.OptionsView.ShowPageBreaks = False
            Me.diagramControl1.OptionsView.ShowRulers = False
            Me.diagramControl1.Size = New System.Drawing.Size(1682, 1258)
            Me.diagramControl1.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(10F, 23F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1682, 1258)
            Me.Controls.Add(Me.diagramControl1)
            Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.diagramControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private diagramControl1 As DevExpress.XtraDiagram.DiagramControl
    End Class
End Namespace
