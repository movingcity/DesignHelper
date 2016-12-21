using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Reflection;
using Xceed.Wpf.Toolkit;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Control for showing available and selected items, in two listboxes. User can add items
    /// from the available list to the selected list, and remove items from the selected
    /// list. In the available list only items that are not in the selected list are shown.
    /// </summary>
    public partial class MultiSelectControl : UserControl
    {
        // default titles for the two list boxes
        private static readonly string AVAILABLE_TITLE = "Available Items:";
        private static readonly string SELECTED_TITLE = "Selected Items:";

        // store the default views for the two list boxes
        private ICollectionView availableItemsCollectionView;
        private ICollectionView selectedItemsCollectionView;

        /// <summary>
        /// Construct the MultiselectControl
        /// </summary>
        public MultiSelectControl()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Identifies the ItemsSource dependency property
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(MultiSelectControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(ItemsSourcePropertyChanged)));
        /// <summary>
        /// Gets or sets a collection of all items that are available for selection. This collection includes the selected items also.
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty);  }
            set { SetValue(ItemsSourceProperty, value);  }
        }

        /// <summary>
        /// Identifies the SelectedItems dependency property
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(IList), typeof(MultiSelectControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedItemsPropertyChanged)));
        /// <summary>
        /// Gets the currently selected items.
        /// </summary>
        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        /// <summary>
        /// Identifies the AvailableTitle dependency property
        /// </summary>
        public static readonly DependencyProperty AvailableTitleProperty = DependencyProperty.Register("AvailableTitle", typeof(string), typeof(MultiSelectControl), new FrameworkPropertyMetadata(AVAILABLE_TITLE));
        /// <summary>
        /// Set the title to be displayed on the Available items list box. Defaults to "Available items:"
        /// </summary>
        public string AvailableTitle
        {
            get { return (string)GetValue(AvailableTitleProperty); }
            set { SetValue(AvailableTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectedTitle dependency property
        /// </summary>
        public static readonly DependencyProperty SelectedTitleProperty = DependencyProperty.Register("SelectedTitle", typeof(string), typeof(MultiSelectControl), new FrameworkPropertyMetadata(SELECTED_TITLE));
        /// <summary>
        /// Set the title to be displayed on the Selected items list box. Defaults to "Selected items:"
        /// </summary>
        public string SelectedTitle
        {
            get { return (string)GetValue(SelectedTitleProperty); }
            set { SetValue(SelectedTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the DisplayMemberPath dependency property
        /// </summary>
        public static readonly DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(MultiSelectControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(DisplayMemberPathPropertyChanged)));
        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the visual representation of the object.
        /// This visual representation is displayed in the two list boxes.
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        /// <summary>
        /// Identifies the FilterMemberPath dependency property
        /// </summary>
        public static readonly DependencyProperty FilterMemberPathProperty = DependencyProperty.Register("FilterMemberPath", typeof(string), typeof(MultiSelectControl), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the check for filtering.
        /// The filter text is compared with this property ToString() value.
        /// Usually set the same as DisplayMemberPath.
        /// </summary>
        public string FilterMemberPath
        {
            get { return (string)GetValue(FilterMemberPathProperty); }
            set { SetValue(FilterMemberPathProperty, value); }
        }

        // bind the DisplayMemberPath to DisplayMemberPath of the two list boxes
        private static void DisplayMemberPathPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectControl control = sender as MultiSelectControl;
            if (control == null)
            {
                return;
            }
            control.AvailableListBox.DisplayMemberPath = control.DisplayMemberPath;
            control.SelectedListBox.DisplayMemberPath = control.DisplayMemberPath;
        }

        // get a handle on the default view for Available list box and set filter
        private static void ItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            IEnumerable source = e.NewValue as IEnumerable;
            MultiSelectControl control = sender as MultiSelectControl;
            if (source == null || control == null)
            {
                return;
            }

            control.availableItemsCollectionView = CollectionViewSource.GetDefaultView(source);
            control.availableItemsCollectionView.Filter = new Predicate<object>(control.FilterOutItems);
        }

        // get a handle on the default view for Selected list box and set filter
        private static void SelectedItemsPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            IList source = e.NewValue as IList;
            MultiSelectControl control = sender as MultiSelectControl;
            if (source == null || control == null)
            {
                return;
            }
            control.selectedItemsCollectionView = CollectionViewSource.GetDefaultView(source);
            control.selectedItemsCollectionView.Filter = new Predicate<object>(control.FilterOutSelectedItems);
            // refresh the available items list to ensure that it shows correct data
            control.availableItemsCollectionView.Refresh();
        }

        // Filter for the Available items list box
        private bool FilterOutItems(object item)
        {
            if (SelectedItems != null)
            {
                // filter out selected items
                foreach (object obj in SelectedItems)
                {
                    if (obj.Equals(item))
                    {
                        return false;
                    }
                }
            }
            
            // filter out the text filter
            if (LeftFilter.Text.Length > 0)
            {
                return GetString(item).IndexOf(LeftFilter.Text, 0, StringComparison.InvariantCultureIgnoreCase) > -1;
            }
            return true;
        }

        // Filter for the Selected items list box
        private bool FilterOutSelectedItems(object item)
        {
            // filter out the text filter
            if (RightFilter.Text.Length > 0)
            {
                return GetString(item).IndexOf(RightFilter.Text, 0, StringComparison.InvariantCultureIgnoreCase) > -1;
            }
            return true;
        }

        // helper method to check the FilterMemberPath and return string representation of the item
        private string GetString(object item)
        {
            if (string.IsNullOrEmpty(FilterMemberPath))
            {
                return item.ToString();
            }
            // use reflection
            object value = GetPropertyValue(item, FilterMemberPath, BindingFlags.Public);
            if (value != null)
            {
                return value.ToString();
            }

            return null;
        }

        private void LeftFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            availableItemsCollectionView.Refresh();
            AvailableListBox.SelectedItems.Clear();
        }

        private void RightFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedItemsCollectionView.Refresh();
            SelectedListBox.SelectedItems.Clear();
        }

        // add chosen items to selected items
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItems != null)
            {
                foreach (object obj in AvailableListBox.SelectedItems)
                {
                    SelectedItems.Add(obj);
                }
                // reset the the selected items in the listbox
                AvailableListBox.SelectedItems.Clear();
                SelectedListBox.SelectedItems.Clear();
                //updates the available collection
                availableItemsCollectionView.Refresh();
                selectedItemsCollectionView.Refresh();
            }
        }

        // add all items to selected items
        private void DoubleRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItems != null)
            {
                foreach (object obj in AvailableListBox.Items)
                {
                    SelectedItems.Add(obj);
                }
                //updates the available collection
                availableItemsCollectionView.Refresh();
                // reset the the selected items in the listbox
                AvailableListBox.SelectedItems.Clear();
                SelectedListBox.SelectedItems.Clear();
            }
        }

        // remove selected items from selected items
        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItems != null)
            {
                IList currentSelectedItems =
                new List<object>((IEnumerable<object>)this.SelectedListBox.SelectedItems);
                foreach (object obj in currentSelectedItems)
                {
                    SelectedItems.Remove(obj);
                }
                
                // reset the the selected items in the listbox
                AvailableListBox.SelectedItems.Clear();
                SelectedListBox.SelectedItems.Clear();
                //updates the available collection
                availableItemsCollectionView.Refresh();
                selectedItemsCollectionView.Refresh();
            }
        }

        // remove all selected items from selected items
        private void DoubleLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItems != null)
            {
                IList currentSelectedItems = new List<object>();
                foreach (object obj in SelectedListBox.Items)
                {
                    currentSelectedItems.Add(obj);
                }
                foreach (object obj in currentSelectedItems)
                {
                    SelectedItems.Remove(obj);
                }
                //updates the available collection
                availableItemsCollectionView.Refresh();
                // reset the the selected items in the listbox
                AvailableListBox.SelectedItems.Clear();
                SelectedListBox.SelectedItems.Clear();
            }
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
    }
}
