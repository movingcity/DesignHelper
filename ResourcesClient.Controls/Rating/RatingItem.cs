using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// An item that represents a Star in the Rating control
    /// </summary>
    [ContentProperty("Content")]
    public class RatingItem : ComboBoxItem
    {
        static RatingItem()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
                typeof(RatingItem), new FrameworkPropertyMetadata(typeof(RatingItem))
            );
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            e.Handled = true;
            var rating = ItemsControl.ItemsControlFromItemContainer(this) as Rating;
            if (rating != null)
                rating.HighlightItems(this);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            e.Handled = true;
            var rating = ItemsControl.ItemsControlFromItemContainer(this) as Rating;
            if (rating != null)
                rating.SelectItems(this);
            base.OnMouseLeftButtonDown(e);
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            e.Handled = true;
            var rating = ItemsControl.ItemsControlFromItemContainer(this) as Rating;
            if (rating != null)
                rating.DeselectItems(this);
            base.OnMouseDoubleClick(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.None) {
                var select = e.Key == Key.Space || e.Key == Key.Enter || e.Key == Key.Return;
                var deselect = e.Key == Key.Escape;

                e.Handled = select || deselect;

                if (e.Handled) {
                    var rating = ItemsControl.ItemsControlFromItemContainer(this) as Rating;
                    if (rating != null) {
                        if (select)
                            rating.SelectItems(this);
                        else
                            rating.DeselectItems(this);
                    }
                }
            }

            base.OnKeyDown(e);
        }

        internal void Highlight(bool p)
        {
            IsHighlighted = p;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var rating = ItemsControl.ItemsControlFromItemContainer(this) as Rating;
            ClearCommand = new ClearCommandImpl(rating);
        }

        public ICommand ClearCommand
        {
            get;
            private set;
        }

        class ClearCommandImpl : ICommand
        {
            private Rating rating;

            public ClearCommandImpl(Rating rating)
            {
                this.rating = rating;
            }

            public bool CanExecute(object parameter)
            {
                if (rating != null)
                {
                    return rating.Value != 0;
                }
                return false;
            }

            public event System.EventHandler CanExecuteChanged
            {
                add { }
                remove { }
            }

            public void Execute(object parameter)
            {
                rating.Value = 0;
            }
        }
    }
}
