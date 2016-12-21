using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Control that shows Ratings stars.
    /// </summary>
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(RatingItem))]
    public class Rating : ItemsControl
    {
        static Rating()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
                typeof(Rating), new FrameworkPropertyMetadata(typeof(Rating))
            );
        }

        #region Value Dependency Property

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(int), typeof(Rating),
                    new FrameworkPropertyMetadata(0,
                        FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        ValueValueChanged, CoerceValueValue, true, UpdateSourceTrigger.PropertyChanged));

        private static void ValueValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rating = (Rating)d;
            rating.UpdateItems(RatingItemUpdate.Rate, null);
        }

        private static object CoerceValueValue(DependencyObject d, object baseValue)
        {
            var rating = (Rating)d;
            var value = (int)baseValue;
            value = Math.Max(0, value);
            if (rating.HasItems)
                value = Math.Min(rating.Items.Count, value);
            return value;
        }

        #endregion

        internal void HighlightItems(RatingItem ratingItem)
        {
            UpdateItems(RatingItemUpdate.Highlight, ratingItem);
        }

        internal void SelectItems(RatingItem ratingItem)
        {
            UpdateItems(RatingItemUpdate.Select, ratingItem);
        }

        internal void DeselectItems(RatingItem ratingItem)
        {
            var children = LogicalChildren;
            if (children != null && children.MoveNext() && children.Current == ratingItem)
                Value = 0;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            e.Handled = true;
            UpdateItems(RatingItemUpdate.Rate, null);
            base.OnMouseLeave(e);
        }

        protected override void OnInitialized(EventArgs e)
        {
            UpdateItems(RatingItemUpdate.Rate, null);
            base.OnInitialized(e);
        }

        private void UpdateItems(RatingItemUpdate action, RatingItem keyItem)
        {
            var children = LogicalChildren;
            if (children != null) {
                var update = action;
                var curValue = Value;
                var newValue = 0;
                var index = 0;

                while (children.MoveNext()) {
                    var item = children.Current as RatingItem;
                    if (item != null) {
                        ++index;
                        if (update == RatingItemUpdate.Rate) {
                            item.Highlight(false);
                            item.IsSelected = index <= curValue;
                        }
                        else {
                            item.Highlight(update == RatingItemUpdate.Highlight);
                            item.IsSelected = update == RatingItemUpdate.Select;
                            if (update == RatingItemUpdate.Select)
                                ++newValue;
                        }
                    }
                    if (children.Current == keyItem)
                        update = RatingItemUpdate.Skip;
                }

                if (action == RatingItemUpdate.Select)
                    Value = newValue;
            }
        }

        private enum RatingItemUpdate
        {
            Highlight,
            Select,
            Rate,
            Skip
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PreviewKeyDown += new KeyEventHandler(Rating_PreviewKeyDown);
            this.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Rating_PreviewMouseLeftButtonDown);
        }

        void Rating_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // mouse click grants keyboard focus to this control
            this.Focus();
        }

        private void Rating_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // clear rating
                this.Value = 0;
            }
        }
    }
}
