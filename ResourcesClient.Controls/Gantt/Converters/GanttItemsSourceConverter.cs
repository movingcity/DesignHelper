using System;
using System.Windows.Data;
using ResourcesClient.Controls.Data;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.Generic;

namespace ResourcesClient.Controls.Converters
{
    /// <summary>
    /// This converter converts a ObservableCollection of TaskData objects into a
    /// ResourceData object by wrapping the tasks in a single resource row.
    /// This is used for the ItemsSource binding for Scratch and Misc gantts.
    /// </summary>
    public class GanttItemsSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ObservableCollection<ITaskData> items = value as ObservableCollection<ITaskData>;
            if (items != null )
            {
                IResourceData resource = new SingleResource();
                resource.Items = items;

                return new ObservableCollection<IResourceData>() { resource };
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Helper class
    class SingleResource : IResourceData
    {
        private ICollection<ITaskData> items;

        public string Text {get; set; }
        
        public Brush TextColor { get; set; }
        
        public Brush BackColor { get; set; }

        public object Payload
        {
            get { return null; }
        }

        // no context menu items
        public ObservableCollection<IContextMenuItemData> ContextMenuItems
        {
            get { return null; }
            set {}
        }

        public ICollection<ITaskData> Items
        {
            get { return items;  }
            set
            {
                if (value != items)
                {
                    items = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Items"));
                    }
                }
            }
        }
     
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
