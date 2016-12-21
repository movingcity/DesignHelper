using System;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace ResourcesClient.Controls.Adorners
{
    /// <summary>
    /// Adorner that displays a dragged lozenge
    /// </summary>
    public class DragAdorner : Adorner
    {
        // the adorner layer that the adorner is attached to 
        private AdornerLayer adornerLayer;
        // location of the adorner - left offset
        private double leftOffset;
        // location of the adorner - top offset
        private double topOffset;
        // the adorner render canvas
        Canvas canvas;
        // the allowed lines for the lozenge
        int allowedLines;
        bool flag;

        /// <summary>
        /// Create the drag drop adorner
        /// </summary>
        /// <param name="dragDropData">the data context for the lozenge. Will be the data being dragged</param>
        /// <param name="dragDropTemplate">the visual display template for the data being dragged</param>
        /// <param name="adornedElement">the element being adorned. GanttRow</param>
        /// <param name="adornerLayer">the adorner layer</param>
        /// <param name="width">the width of the lozenge</param>
        /// <param name="height">the height of the lozenge</param>
        /// <param name="location">the location of the lozenge</param>
        public DragAdorner(object dragDropData, DataTemplate dragDropTemplate, UIElement adornedElement, AdornerLayer adornerLayer,
            double width, double height, Point location, int allowedLines)
            : base(adornedElement)
        {
            this.adornerLayer = adornerLayer;
            this.allowedLines = allowedLines;
            
            // create the visual control for the dragging data
            ContentPresenter presenter = new ContentPresenter();
            presenter.Content = dragDropData;
            presenter.ContentTemplate = dragDropTemplate;
            presenter.Opacity = 0.7;
            // height is set to Auto - to match the gantt control lozenge
            presenter.Height = Double.NaN; 
            presenter.Width = width;
            leftOffset = location.X;
            // offset for taking care of the margin
            topOffset = 1;
            
            // wrap the dragging data visual in a canvas in order to size as per gantt lozenge
            canvas = new Canvas();
            canvas.Width = width;
            canvas.Height = height;
            canvas.Children.Add(presenter);

            adornerLayer.Add(this);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            canvas.Measure(constraint);
            return canvas.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            canvas.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return canvas;
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        // translate the lozenge to desired offset location
        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(leftOffset, topOffset));
            return result;
        }

        /// <summary>
        /// Remove the drag adorner
        /// </summary>
        public void Destroy()
        {
            adornerLayer.Remove(this);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            // need to set the allowed lines for the dragging lozenge
            // only do this once
            if (!flag)
            {
                Lozenge lozenge = ResourcesClient.Controls.Utility.Helper.FindVisualChild<Lozenge>(canvas);
                lozenge.AllowedLines = allowedLines;
                flag = true;
            }
            base.OnRender(drawingContext);
        }
    }
}
