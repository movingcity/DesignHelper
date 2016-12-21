using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using ResourcesClient.Controls.Data;
using ResourcesClient.Controls.Utility;
using PlexityHide.GTP;

namespace ResourcesClient.Controls.Adorners
{
    /// <summary>
    /// Adorner that encapsulates the rubber band selection functionality
    /// on the Gantt List Box.
    /// </summary>
    public class RubberBandAdorner : Adorner
    {
        // start point of the rubberband
        private Point startpoint;
        // current end point of the rubberband
        private Point currentpoint;
        // rubberband drawing brush
        private Brush brush;
        // rubberband drawing pen
        private Pen pen;
        // flag indicating if rubber banding in progress
        private bool flag;
        // flag indicating if mouse down on gantt row canvas
        private bool mouseDownRowCanvas;
        // the scroll viewer associated with the list box
        private ScrollViewer viewer;
        // the scroll bar associated with the list box
        private ScrollBar scrollbar;
        // list to store the results of the hit test on the rubberband rectangle
        private List<DependencyObject> hitTestResults;

        public RubberBandAdorner(UIElement adornedElement) : base(adornedElement)
        {
            IsHitTestVisible = false;
            adornedElement.MouseMove += new MouseEventHandler(adornedElement_PreviewMouseMove);
            adornedElement.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(adornedElement_PreviewMouseLeftButtonDown);
            adornedElement.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(adornedElement_PreviewMouseLeftButtonUp);
            brush = new SolidColorBrush(SystemColors.HighlightColor);
            brush.Opacity = 0.3;
            brush.Freeze();
            pen = new Pen(SystemColors.HighlightBrush, 1);
            pen.Freeze();
            hitTestResults = new List<DependencyObject>();
        }

        // when mouse left button down
        private void adornedElement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // rubber band allowed only on gantt row canvas
            if (e.OriginalSource is PlexityHide.GTP.GanttRowCanvas)
            {
                ListBox selector = AdornedElement as ListBox;
                // store start point of rubberband
                startpoint = e.GetPosition(this.AdornedElement);
                // capture mouse to keep mouse events on the listbox
                Mouse.Capture(selector);
                // mouse button down on row canvas
                mouseDownRowCanvas = true;
            }
            else
            {
                // mouse button down not on row canvas
                mouseDownRowCanvas = false;
            }
        }

        // when mouse is moved 
        private void adornedElement_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            // if mouse button down and click was on gantt row canvas
            if (e.LeftButton == MouseButtonState.Pressed && mouseDownRowCanvas)
            {
                // set rubberbanding flag
                flag = true;
                // set current point
                currentpoint = e.GetPosition(AdornedElement);

                // special handling when rubber band approaches scroll limits
                Selector selector = AdornedElement as Selector;
                if (viewer == null)
                {
                    viewer = Helper.FindVisualChild<ScrollViewer>(selector);
                }

                if (scrollbar == null)
                {
                    scrollbar = Helper.FindVisualChild<ScrollBar>(viewer);
                }

                if (selector.Items.Count > 0)
                {
                    if (currentpoint.Y > ((FrameworkElement)AdornedElement).ActualHeight && 
                        viewer.VerticalOffset < selector.ActualHeight && scrollbar.Visibility == System.Windows.Visibility.Visible)
                    {
                        startpoint.Y -= 50;
                    }
                    else if (currentpoint.Y < 0 && viewer.VerticalOffset > 0 && scrollbar.Visibility == System.Windows.Visibility.Visible)
                    {
                        startpoint.Y += 50;
                    }
                }

                // redraw the rubberband
                InvalidateVisual();
            }
        }

        // when mouse button released
        private void adornedElement_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // are we rubberbanding?
            if (flag)
            {
                // check time items contained in the rubber band rectangle
                RectangleGeometry hitTestArea = new RectangleGeometry(new Rect(startpoint, currentpoint));
                hitTestResults.Clear();
                VisualTreeHelper.HitTest(AdornedElement, new HitTestFilterCallback(HitTestFilter),
                    new HitTestResultCallback(HitTestResultCallback),
                    new GeometryHitTestParameters(hitTestArea));

                if (hitTestResults.Count > 0)
                {
                    // override single selection behavior for the gantt control
                    // to ensure all our selections are allowed
                    bool oldValue = ResourcesGantt.IsSingleSelectOverride;
                    ResourcesGantt.IsSingleSelectOverride = true;
                    foreach (DependencyObject o in hitTestResults)
                    {
                        // get the GanttRowItem for hit test result visual element
                        PlexityHide.GTP.GanttRowItem item = Helper.FindVisualAncestor<GanttRowItem>(o);
                        if (item != null)
                        {
                            // select the hit item
                            ((ITaskData)item.DataContext).IsSelected = true;
                        }
                    }
                    ResourcesGantt.IsSingleSelectOverride = oldValue;
                }
            }

            // clean up
            DisposeRubberBand();
        }

        // filter the hit test to not go beyond TimeItem in the visual tree
        private HitTestFilterBehavior HitTestFilter(DependencyObject o)
        {
            // Test for the object value you want to filter.
            if (o.GetType() == typeof(PlexityHide.GTP.TimeItem))
            {
                // Visual object's descendants are NOT part of hit test results enumeration.
                return HitTestFilterBehavior.ContinueSkipChildren;
            }
            else
            {
                // Visual object is part of hit test results enumeration.
                return HitTestFilterBehavior.Continue;
            }
        }

        // add items that are fully inside the hit test geometery to the results list
        private HitTestResultBehavior HitTestResultCallback(HitTestResult result)
        {
            IntersectionDetail intersectionDetail = ((GeometryHitTestResult)result).IntersectionDetail;

            switch (intersectionDetail)
            {
                case IntersectionDetail.FullyInside:

                    // Add the hit test result to the list that will be processed after the enumeration.
                    hitTestResults.Add(result.VisualHit);

                    return HitTestResultBehavior.Continue;

                case IntersectionDetail.Intersects:

                    // Set the behavior to return visuals at all z-order levels. 
                    return HitTestResultBehavior.Continue;

                case IntersectionDetail.FullyContains:

                    // Set the behavior to return visuals at all z-order levels. 
                    return HitTestResultBehavior.Continue;

                default:
                    return HitTestResultBehavior.Stop;
            }
        }

        // draw the rectangle
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect rect = new Rect(startpoint, currentpoint);
            drawingContext.DrawGeometry(brush, pen, new RectangleGeometry(rect));
            base.OnRender(drawingContext);
        }

        // helper method to reset the state of the rubberband adorner
        private void DisposeRubberBand()
        {
            currentpoint = new Point(0, 0);
            startpoint = new Point(0, 0);
            AdornedElement.ReleaseMouseCapture();
            InvalidateVisual();
            flag = false;
            mouseDownRowCanvas = false;
        }
    }
}
