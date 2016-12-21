using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace ResourcesClient.Controls.Adorners
{
    /// <summary>
    /// An adoner that acts as a vertical timeline.
    /// The vertical timeline appears over the passed UIElement and is constrained
    /// to appear within the Rect dimensions passed.
    /// Line appears only within the Rect dimensions.
    /// </summary>
    public class TimelineAdorner : Adorner
    {
        private readonly static string LINE_COLOR = "#32FF0000";
        private double x;
        private Pen renderPen;
        private bool isVisible;
        private FrameworkElement bottomRight;
        private Point origin;
        double extra;
        double offset;

        /// <summary>
        /// Construct a timeline adorner
        /// Timeline appears within the bounds of origin and ActualWidth/Height of bottomRight UI element.
        /// If extra is present, it is reduced from the bounding rectangle width.
        /// If offset is present, the timeline is offset from the mouse X position by that amount
        /// </summary>
        /// <param name="adornedElement"></param>
        /// <param name="constraintRect"></param>
        /// <param name="bottomRight"></param>
        public TimelineAdorner(UIElement adornedElement, Point origin, FrameworkElement bottomRight, double extra, double offset)
            : base(adornedElement)
        {
            this.bottomRight = bottomRight as FrameworkElement;
            this.x = -1;
            this.origin = origin;
            this.extra = extra;
            this.offset = offset;

            renderPen = new Pen(new SolidColorBrush((Color)ColorConverter.ConvertFromString(LINE_COLOR)), 1);
            renderPen.Freeze();

            adornedElement.PreviewMouseMove += new MouseEventHandler(adornedElement_PreviewMouseMove);
        }

        public void UpdatePosition(double x)
        {
            this.x = x;
            InvalidateVisual();
        }

        public bool IsDisplayed
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (IsDisplayed)
            {
                double startY = origin.Y;
                double stopY = GetBottomRight(AdornedElement, bottomRight).Y;
                double halfPenWidth = renderPen.Thickness / 2;

                // Create a guidelines set for snapping to pixels
                GuidelineSet guidelines = new GuidelineSet();
                guidelines.GuidelinesX.Add(x + halfPenWidth);
                guidelines.GuidelinesY.Add(startY + halfPenWidth);
                guidelines.GuidelinesY.Add(stopY + halfPenWidth);

                drawingContext.PushGuidelineSet(guidelines);
                drawingContext.DrawLine(renderPen, new Point(x, startY), new Point(x, stopY));
                drawingContext.Pop();
            }
        }

        private void adornedElement_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(AdornedElement);
            double value = -1;
            Point point = GetBottomRight(AdornedElement, bottomRight);
            point.X -= extra;
            Rect constraintRect = new Rect(origin, point);
            // show line only if mouse is within the constraint
            if (constraintRect.Contains(mousePos))
            {
                // offset the line from mouse in order to allow mouse click to function
                value = mousePos.X + offset;
            }
            UpdatePosition(value);
        }

        private Point GetBottomRight(UIElement parent, FrameworkElement child)
        {
            // translate coordinates of bottom right of child to parent coordinate space
            return child.TranslatePoint(new Point(child.ActualWidth, child.ActualHeight), parent);
        }
    }
}
