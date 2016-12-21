using System.Windows;
using System.Windows.Controls;
using System;
namespace ResourcesClient.Controls
{
    /// <summary>
    /// An extension of Extended WPF Toolkit MultilineTextEditor which allows
    /// ellipsis truncated text to display in the control (via Style in Theme.xaml).
    /// Also supports IsReadonly property to show the control in read only mode.
    /// Also supports MaxLength property to restrict number of characters allowed.
    /// </summary>
    public class MultilineTextEditor : Xceed.Wpf.Toolkit.MultiLineTextEditor
    {
        private TextBox textBox;

        // construct
        public MultilineTextEditor()
        {
            Loaded += MultilineTextEditor_Loaded;
            textBox = null;
        }

        // when control is loaded
        private void MultilineTextEditor_Loaded(object sender, RoutedEventArgs e)
        {
            // grab a handle to the textbox shown on the popup
            textBox = this.Template.FindName("PART_TextBox", this) as TextBox;
            // set DP on the text box
            if (textBox != null)
            {
                textBox.IsReadOnly = IsReadOnly;
                textBox.MaxLength = MaxLength;
            }
        }

        /// <summary>
        /// Identifies the IsReadOnly dependency property
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(MultilineTextEditor), 
            new FrameworkPropertyMetadata(new PropertyChangedCallback(IsReadOnlyPropertyChanged)));

        /// <summary>
        /// Gets or sets if control is read-only.
        /// Default value is false.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return (bool)GetValue(IsReadOnlyProperty);
            }
            set
            {
                SetValue(IsReadOnlyProperty, value);
            }
        }

        // called when read-only property is changed
        private static void IsReadOnlyPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            bool value = (bool)e.NewValue;
            MultilineTextEditor control = sender as MultilineTextEditor;
            if (control == null || control.textBox == null)
            {
                return;
            }

            // set the popup text box as readonly true/false
            control.textBox.IsReadOnly = value;
        }

        /// <summary>
        /// Identifies the IsReadOnly dependency property
        /// </summary>
        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(MultilineTextEditor),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(MaxLengthPropertyChanged)));

        /// <summary>
        /// Gets or sets the maximum number of characters that can be manually entered into the dropdown textbox.
        /// </summary>
        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }

        // called when max-length property is changed
        private static void MaxLengthPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            MultilineTextEditor control = sender as MultilineTextEditor;
            if (control == null || control.textBox == null)
            {
                return;
            }

            // set the popup text box max length
            control.textBox.MaxLength = value;
        }

        // when drop down is opened, set focus on text box
        protected override void OnIsOpenChanged(bool oldValue, bool newValue)
        {
            // invoke base functionality
            base.OnIsOpenChanged(oldValue, newValue);

            // set focus on text box, if open
            if (newValue && textBox != null)
            {
                // do in async manner on dispatcher to avoid focus shift issues
                Dispatcher.BeginInvoke(new Action(
                    () =>
                    {
                        textBox.Focus();
                        if (textBox.Text != null)
                        {
                            textBox.CaretIndex = textBox.Text.Length;
                        }
                    }));
            }
        }
    }
}
