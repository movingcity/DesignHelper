using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Collections.Specialized;
using System.Reflection;
using System.ComponentModel;
using System;
using System.Windows;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Specialized combobox that by default is IsReadOnly=false and IsEditable=true.
    /// Extends the standard combobox to disallow user entering invalid entries in the
    /// controls editable textbox.
    /// NOTE: This does not function correctly unless ItemsSource property is bound to
    /// a Collection (Items property not supported)
    /// </summary>
    public class AutoCompleteCombo : ComboBox
    {
        // caches the currently displayed strings (from DisplayMemberPath
        private List<string> items = new List<string>();
        // The editable TextBox for this control
        private TextBox textBox;
        // The combo dropdown button for this control
        private Control toggleButton;

        /// <summary>
        /// Construct the control
        /// </summary>
        public AutoCompleteCombo()
        {
            // set default values
            this.IsReadOnly = false;
            this.IsEditable = true;
            this.PreviewKeyDown += new KeyEventHandler(AutoCompleteCombo_PreviewKeyDown);
            this.PreviewTextInput += new TextCompositionEventHandler(AutoCompleteCombo_PreviewTextInput);
            this.Loaded += new RoutedEventHandler(AutoCompleteCombo_Loaded);
            // register command handler to prevent edit commands execution
            CommandManager.AddPreviewCanExecuteHandler(this, CannotExecute);
            // listen to changes to the ItemsSource property
            DependencyPropertyDescriptor descriptor = DependencyPropertyDescriptor.FromProperty(ComboBox.ItemsSourceProperty, typeof(ComboBox));
            descriptor.AddValueChanged(this, OnItemsSourceChanged);
            // listen to changes to the IsReadOnly property
            descriptor = DependencyPropertyDescriptor.FromProperty(ComboBox.IsReadOnlyProperty, typeof(ComboBox));
            descriptor.AddValueChanged(this, OnIsReadOnlyChanged);

            // also listen to keyboard focus recieved on this control
            this.GotKeyboardFocus += AutoCompleteCombo_GotKeyboardFocus;
        }

        // special handling for any label key accelerators associated with this user control
        private void AutoCompleteCombo_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            // if this event originates from AutoCompleteCombo
            // which means that this control has recieved keyboard focus.
            // This will happen when a label associated with this control has invoked key accelerator tagret
            if (sender == e.OriginalSource)
            {
                // transfer focus to Edit text box within this user control
                Keyboard.Focus(textBox);
            }
        }

        // store a handle to the editable TextBox of the control
        void AutoCompleteCombo_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            textBox = this.Template.FindName("PART_EditableTextBox", this) as TextBox;
            toggleButton = this.Template.FindName("ToggleButton", this) as Control;
            // if read-only, then disable toggle button
            if (IsReadOnly)
            {
                toggleButton.IsEnabled = false;
            }
        }

        // Invoked when the ItemsSource property is changed
        private void OnItemsSourceChanged(object source, EventArgs args)
        {
            if (this.ItemsSource != null)
            {
                // add listener to the ItemsSource bound CollectionView
                CollectionViewSource.GetDefaultView(this.ItemsSource).CollectionChanged +=
                    new NotifyCollectionChangedEventHandler(AutoCompleteCombo_CollectionChanged);
            }
        }

        // Invoked when the IsReadOnly property is changed
        private void OnIsReadOnlyChanged(object source, EventArgs args)
        {
            // sanity check
            if (toggleButton == null)
            {
                return;
            }

            // if read-only
            if (IsReadOnly)
            {
                // disable the drop down toggle button
                toggleButton.IsEnabled = false;
            }
            else
            {
                // disable the drop down toggle button
                toggleButton.IsEnabled = true;
            }
        }

        // handle changes to the ItemsSource CollectionView by updating the cached display string list
        private void AutoCompleteCombo_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (object o in e.NewItems)
                {
                    // add to display strings list
                    items.Add(GetString(o).ToLower());
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (object o in e.OldItems)
                {
                    // remove from display strings list
                    items.Remove(GetString(o).ToLower());
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (object o in e.OldItems)
                {
                    // remove old item from display strings list
                    items.Remove(GetString(o).ToLower());
                }
                foreach (object o in e.NewItems)
                {
                    // add new item to display strings list
                    items.Add(GetString(o).ToLower());
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                // reset the display string list, which will be refreshed in the TextInputHandler
                items.Clear();
            }
        }

        // prevent Cut and Paste command execution
        private void CannotExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
            {
                e.CanExecute = false;
                e.Handled = true;
            }
        }

        // special handling for Backspace and Delete key
        private void AutoCompleteCombo_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                // special handling for backspace
                if (textBox.Text.Equals(textBox.SelectedText))
                {
                    // default behavior
                    return;
                }
                if (textBox.CaretIndex < 1)
                {
                    // backspace when caret at start of text box
                    // select all
                    textBox.SelectAll();
                    e.Handled = true;
                    return;
                }
                // move the selection back instead of delete
                textBox.Select(textBox.CaretIndex - 1, textBox.Text.Length - textBox.CaretIndex + 1);
                e.Handled = true;
            }
            else if (e.Key == Key.Delete)
            {
                // special handling for delete
                if (textBox.Text.Equals(textBox.SelectedText))
                {
                    // default behavior
                    return;
                }
                // do not allow delete as it will change the allowed text in the editable text box
                e.Handled = true;
            }
        }

        // handle the text input in the editable TextBox
        private void AutoCompleteCombo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string keyPressed = e.Text;
            if (keyPressed == null)
            {
                return;
            }

            
            // indicates whether the new character added should be removed 
            bool shouldRemove = true;

            // if cached list of display strings do not exist
            if (items.Count <= 0)
            {
                // create cached list
                foreach (object o in this.Items)
                {
                    // display strings stored in LOWER CASE for case insensitive comparision
                    items.Add(GetString(o).ToLower());
                }
            }

            // handle selection
            StringBuilder textBuilder = new StringBuilder(textBox.Text);
            if (textBox.SelectedText.Length > 0)
            {
                // text selected, will be removed by new text
                textBuilder.Remove(textBox.CaretIndex, textBox.SelectedText.Length);
            }
            // add new text to reflect user key presses
            textBuilder.Insert(textBox.CaretIndex, keyPressed);
            // search string
            string text = textBuilder.ToString().ToLower(); ;

            // then look in the cached list
            foreach (string item in items)
            {
                // legal character input 
                if (text != "" && item.StartsWith(text))
                {
                    shouldRemove = false;
                    break;
                }
            }

            // illegal character input 
            if (text != "" && shouldRemove)
            {
                e.Handled = true;
            } 
        }

        // helper method to get display string representation for passed object
        // uses TextSearch Path if set,
        // else uses DisplayMemberPath if set, 
        // else uses ToString()
        private string GetString(object item)
        {
            string path = TextSearch.GetTextPath(this);
            if (string.IsNullOrEmpty(path))
            {
                path = DisplayMemberPath;
            }
            if (string.IsNullOrEmpty(path))
            {
                return item.ToString();
            }
            // use reflection
            object value = GetPropertyValue(item, path, BindingFlags.Public);
            if (value != null)
            {
                return value.ToString();
            }

            return null;
        }

        // helper method to use reflection to determine value of passed property
        private object GetPropertyValue(object source, string propertyName, BindingFlags flags)
        {
            object value = null;
            // Get the specific field info
            PropertyInfo pInfo = source.GetType().GetProperty(propertyName, flags | BindingFlags.Instance);

            // Make sure the property info is not null
            if (pInfo != null)
            {
                // Retrieve the value from the field.
                value = pInfo.GetValue(source, null);
            }
            return value;
        }

        // override base class handling for keydown when read-only
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // if combo is set to readonly
            // do not process keydown handling in the parent class
            // as that will process keyboard accelerators for drop down
            // which should not be allowed
            if (!IsReadOnly)
            {
                base.OnKeyDown(e);
            }
        }

        // override base class handling for keydown when read-only
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            // if combo is set to readonly
            // do not process keydown handling in the parent class
            // as that will process keyboard accelerators for drop down
            // which should not be allowed
            if (!IsReadOnly)
            {
                base.OnPreviewKeyDown(e);
            }
        }
    }
}
