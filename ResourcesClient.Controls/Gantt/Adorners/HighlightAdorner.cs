using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System;

namespace ResourcesClient.Controls.Adorners
{
    /// <summary>
    /// An Adorner that displays a pulsating border over the passed control.
    /// </summary>
    public class HighlightAdorner : Adorner
    {
        private Pen pen;
        Storyboard myStoryboard;
        private AdornerLayer adornerLayer;

        /// <summary>
        /// Construct the highlight adorner,
        /// </summary>
        /// <param name="target">the UI element this highlights</param>
        /// <param name="layer">the adorner layer on which this adorner is added</param>
        public HighlightAdorner(UIElement target, AdornerLayer layer) : base(target)
        {
            pen = new Pen(Brushes.Yellow, 9);
            pen.Freeze();

            adornerLayer = layer;

            Loaded += HighlightAdorner_Loaded;
            this.IsHitTestVisible = false;
        }

        private void HighlightAdorner_Loaded(object sender, RoutedEventArgs e)
        {
            PowerEase ease = new PowerEase();
            ease.Power = 4;
            ease.EasingMode = EasingMode.EaseIn;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                EasingFunction = ease
            };

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTarget(myStoryboard, this);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(OpacityProperty));

            myStoryboard.Begin(this);
        }

        protected override void OnRender(DrawingContext dc)
        {
            // sanity check
            if (adornerLayer == null)
            {
                throw new InvalidOperationException("Cannot use HighlightAdorner after Remove()");
            }

            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            dc.DrawRectangle(null, pen, adornedElementRect);
            base.OnRender(dc);
        }

        /// <summary>
        /// Remove this highlight adorner.
        /// </summary>
        public void Remove()
        {
            // stop animation
            myStoryboard.Stop();
            // remove from layer
            adornerLayer.Remove(this);
            adornerLayer = null;
        }
    }
}
