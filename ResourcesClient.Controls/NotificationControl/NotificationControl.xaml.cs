using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using System.ComponentModel;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Specifies the state of the Notification Window area
    /// </summary>
    public enum NotifyState
    {
        /// <summary>
        /// The window is visible and floating over main content
        /// </summary>
        Visible,
        /// <summary>
        /// The window is hidden to a bar at the bottom of main content
        /// </summary>
        Collapsed,
        /// <summary>
        /// The window is docked with the main content and sharing screen space
        /// </summary>
        Docked
    }

    /// <summary>
    /// This control takes Content and a TabControl and wraps it into a Notification Window based framework.
    /// The content provided in MainContent is rendered as the central content of the control.
    /// The TabControl provided in NotifyContent is rendered as a collapsible/dockable window set at 
    /// the bottom of the main content. This is called the notification area.
    /// Each tab item is rendered as a Notification Window.
    /// The translation of the TabItem is as follows:
    /// NotifyState.Collapsed - The TabItem.Header is rendered as a horizontal panel at the bottom of the main content.
    /// NotifyState.Visible - The TabControl is visible floating over the main content. Clicking on the tabitem header
    /// or moving mouse on main content collapses the TabControl.
    /// NotifyState.Docked - The TabControl is rendered at the bottom of the main content and separated by a grid splitter.
    /// </summary>
    public partial class NotificationControl : UserControl
    {
        // stores the TabControl TabItem header panel
        private StackPanel tabPanel;
        // stores the parent of the tabPanel. Used to reattach the panel to the tabcontrol
        private Border border;
        // stores the image for docking/un-docking the notification window
        private Image pinImage;
        // stores a clone row definition for layer0. Used to dock the notification window
        private RowDefinition row1CloneForLayer0;
        // stores the current height of layer1 grid row index #1 (second row)
        private double height;

        /// <summary>
        /// Construct the Notification Control
        /// </summary>
        public NotificationControl()
        {
            Loaded +=new RoutedEventHandler(NotificationControl_Loaded);
            InitializeComponent();
            
            // create the row1 clone for layer0
            row1CloneForLayer0 = new RowDefinition();
            row1CloneForLayer0.SharedSizeGroup = "row1";
        }

        // obtain handles to the required control instances. Setup the control
        private void  NotificationControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabPanel = NotifyContent.Template.FindName("PART_TabPanel", NotifyContent) as StackPanel;
            border = NotifyContent.Template.FindName("border", NotifyContent) as Border;
            // default state is Visible so remove the tabPanel from the TabControl
            border.Child = null;
            bottomPanel.Children.Add(tabPanel);

            TextBlock textBlock = NotifyContent.Template.FindName("notifyHeader", NotifyContent) as TextBlock;
            
            // bind the notification header text to the TabControl.SelectedItem.Header
            Binding binding = new Binding();
            binding.Source = NotifyContent;
            binding.Path = new PropertyPath("SelectedItem.WindowHeader");
            binding.Mode = BindingMode.OneWay;
            textBlock.SetBinding(TextBlock.TextProperty, binding);

            // get the pinImage and rotate as the default state is Visible
            pinImage = NotifyContent.Template.FindName("panePinImage", NotifyContent) as Image;
            RotateImage(pinImage);

            // save the current height of layer1 second row
            height = layer1.RowDefinitions[1].ActualHeight;
        }

        /// <summary>
        /// Identifies the MainContentProperty dependency property
        /// </summary>
        public static readonly DependencyProperty MainContentProperty = DependencyProperty.Register("MainContent", typeof(object), typeof(NotificationControl), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets the Main content for the control. This is the actual content to be rendered.
        /// </summary>
        public object MainContent
        {
            get { return (object)GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }

        /// <summary>
        /// Identifies the NotifyContentProperty dependency property
        /// </summary>
        public static readonly DependencyProperty NotifyContentProperty = DependencyProperty.Register("NotifyContent", typeof(TabControl), typeof(NotificationControl), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets the TabControl to be used to generate the Notification windows for the Main content.
        /// </summary>
        public TabControl NotifyContent
        {
            get { return (TabControl)GetValue(NotifyContentProperty); }
            set { SetValue(NotifyContentProperty, value); }
        }

        /// <summary>
        /// Identifies the NotifyStateProperty dependency property
        /// </summary>
        public static readonly DependencyProperty NotifyStateProperty = DependencyProperty.Register("NotifyState", typeof(NotifyState), typeof(NotificationControl), new FrameworkPropertyMetadata(NotifyState.Visible, NotifyStatePropertyChanged));
        /// <summary>
        /// Gets or sets the current state of the Notification Window. Default state is Visible.
        /// </summary>
        public NotifyState NotifyState
        {
            get { return (NotifyState)GetValue(NotifyStateProperty); }
            set { SetValue(NotifyStateProperty, value); }
        }

        /// <summary>
        /// Identifies the SplitterHeightProperty dependency property
        /// </summary>
        public static readonly DependencyProperty SplitterHeightProperty = DependencyProperty.Register("SplitterHeight", typeof(double), typeof(NotificationControl), new FrameworkPropertyMetadata(10.0));
        /// <summary>
        /// Gets or sets the height of the splitter between the main content and the notification window. Default height is 10.
        /// </summary>
        [TypeConverterAttribute(typeof(LengthConverter))]
        public double SplitterHeight
        {
            get { return (double)GetValue(SplitterHeightProperty); }
            set { SetValue(SplitterHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the MainContentMinHeightProperty dependency property
        /// </summary>
        public static readonly DependencyProperty MainContentMinHeightProperty = DependencyProperty.Register("MainContentMinHeight", typeof(double), typeof(NotificationControl), new FrameworkPropertyMetadata(40.0));
        /// <summary>
        /// Gets or sets the min height of the main content. Default height is 40.
        /// Grid splitter not allowed to reduce main content below this.
        /// </summary>
        [TypeConverterAttribute(typeof(LengthConverter))]
        public double MainContentMinHeight
        {
            get { return (double)GetValue(MainContentMinHeightProperty); }
            set { SetValue(MainContentMinHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the NotifyContentMinHeightProperty dependency property
        /// </summary>
        public static readonly DependencyProperty NotifyContentMinHeightProperty = DependencyProperty.Register("NotifyContentMinHeight", typeof(double), typeof(NotificationControl), new FrameworkPropertyMetadata(60.0));
        /// <summary>
        /// Gets or sets the min height of the notify content window. Default height is 60.
        /// Grid splitter not allowed to reduce notify content below this.
        /// </summary>
        [TypeConverterAttribute(typeof(LengthConverter))]
        public double NotifyContentMinHeight
        {
            get { return (double)GetValue(NotifyContentMinHeightProperty); }
            set { SetValue(NotifyContentMinHeightProperty, value); }
        }

        // When the NotifyState property changes, perform the relevant logic on the notification TabControl
        private static void NotifyStatePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            NotifyState oldState = (NotifyState)e.OldValue;
            NotifyState state = (NotifyState)e.NewValue;
            NotificationControl control = sender as NotificationControl;
            if (control == null)
            {
                return;
            }
            switch(state)
            {
                case NotifyState.Collapsed:
                    control.NotifyCollapse(oldState);
                    break;
                case NotifyState.Docked:
                    control.NotifyDock(oldState);
                    break;
                case NotifyState.Visible:
                    control.NotifyVisible(oldState);
                    break;
            }
        }

        // Called when the dock/undock button is clicked on the notification window
        private void panePin_Click(object sender, RoutedEventArgs e)
        {
            // toggle the Docked<-->Visible states
            if (NotifyState == NotifyState.Docked)
            {
                NotifyState = NotifyState.Visible;
            }
            else
            {
                NotifyState = NotifyState.Docked;
            }
        }

        // click performed on the tab item header (ContentPresenter)
        private void buttonText_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ContentPresenter presenter = sender as ContentPresenter;
            if (presenter == null)
            {
                return;
            }
            // TabItem header will be the presenters Content
            object header = presenter.Content;

            // currently selected tab item
            TabItem itemSelected = NotifyContent.SelectedItem as TabItem;

            if (NotifyState == NotifyState.Collapsed)
            {
                NotifyState = NotifyState.Visible;
            }
            else if (NotifyState == NotifyState.Visible)
            {
                // click on same header will collapse
                if (itemSelected.Header == header)
                {
                    NotifyState = NotifyState.Collapsed;
                }
            }

            // select the corresponding TabItem
            foreach (TabItem item in NotifyContent.Items)
            {
                if (item.Header == header)
                {
                    NotifyContent.SelectedItem = item;
                }
            }
        }

        // helper method to collapse the notification window
        private void NotifyCollapse(NotifyState oldValue)
        {
            if (oldValue == NotifyState.Visible)
            {
                layer1.Visibility = Visibility.Collapsed;
            }
            else if (oldValue == NotifyState.Docked)
            {
                NotifyVisible(oldValue);
                layer1.Visibility = Visibility.Collapsed;
            }
        }

        // helper method to make visible the notification window
        private void NotifyVisible(NotifyState oldValue)
        {
            if (oldValue == NotifyState.Docked)
            {
                layer0.RowDefinitions.Remove(row1CloneForLayer0);
                layer0.Margin = new Thickness(0, 0, 0, 2);
                border.Child = null;
                bottomPanel.Children.Add(tabPanel);
                RotateImage(pinImage);
                // remove Tag from gridSplitter so that style trigger displays the splitter
                gridSplitter.Tag = null;
            }
            else if (oldValue == NotifyState.Collapsed)
            {
                layer1.Visibility = Visibility.Visible;
            }
        }

        // helper method to dock the notification window
        private void NotifyDock(NotifyState oldValue)
        {
            if (oldValue == NotifyState.Collapsed)
            {
                NotifyVisible(oldValue);

            }
            layer0.RowDefinitions.Add(row1CloneForLayer0);
            layer0.Margin = new Thickness(0, 0, 0, -1);
            bottomPanel.Children.Remove(tabPanel);
            border.Child = tabPanel;
            // remove the rotation in the image
            pinImage.RenderTransform = null;
            // add (arbitrary not null) Tag to gridSplitter so that style trigger displays the splitter
            gridSplitter.Tag = gridSplitter;
        }

        // helper method to rotate the pin image (pin prick downwards) by 90 degrees
        private void RotateImage(Image image)
        {
            image.RenderTransformOrigin = new Point(0.5, 0.5);
            RotateTransform transform = new RotateTransform();
            transform.Angle = 90;
            image.RenderTransform = transform;
        }

        // When mouse click on main content, then collapse the notification window
        private void layer0_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (NotifyState == NotifyState.Visible)
            {
                NotifyState = NotifyState.Collapsed;
            }
        }

        // hack to prevent the grid splitter from expanding the * row in the tabcontrol controltemplate from 
        // expanding beyond the size of the window (hence obscuring the tab header buttons in docked mode)
        private void GridSplitter_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            // when the layer1 row0 height has reached the minimum allowed height
            if (layer1.RowDefinitions[0].ActualHeight <= MainContentMinHeight)
            {
                e.Handled = true; // does not work
                if (e.VerticalChange < 0)
                {
                    // splitter moving upwards, cancel drag
                    ((GridSplitter)sender).CancelDrag();
                    // restore the height of row1
                    layer1.RowDefinitions[1].Height = new GridLength(height);
                }
            }
            else
            {
                // store the current height of layer1 row1 for restore use above
                height = layer1.RowDefinitions[1].ActualHeight;
            }
        }

        /// <summary>
        /// Helper method to get height based on the current state of the notification window.
        /// When state is Docked, then use SplitterHeight, else use smaller 5.0
        /// </summary>
        /// <param name="height"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        internal static double GetHeight(double height, NotifyState state)
        {
            if (state == NotifyState.Docked)
            {
                return height;
            }
            else
            {
                // reduce the splitter height
                return 5.0;
            }
        }
    }

    /// <summary>
    /// Converter to bind the splitter height with the margin for the notification window grid cell.
    /// Needs to match otherwise there will be over or underlap.
    /// </summary>
    internal class MarginConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert from a double to a Margin that uses that double in the Top property
        /// </summary>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2 || !(values[0] is double) || !(values[1] is NotifyState))
            {
                return new Thickness(0);
            }
            double height = (double)values[0];
            NotifyState state = (NotifyState)values[1];

            return new Thickness(0, NotificationControl.GetHeight(height, state), 0, 0);
        }

        /// <summary>
        /// Not supported
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converter to bind the SplitterHeight with the gridSplitter height.
    /// Special processing on the notification state.
    /// </summary>
    internal class HeightMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// Depending on NotifyState, translate the passed height
        /// </summary>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2 || !(values[0] is double) || !(values[1] is NotifyState))
            {
                return 0;
            }
            double height = (double)values[0];
            NotifyState state = (NotifyState)values[1];

            return NotificationControl.GetHeight(height, state);
        }

        /// <summary>
        /// Not supported
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
