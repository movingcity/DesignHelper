using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ResourcesClient.Controls.Data
{
    /// <summary>
    /// Defines the interface an object needs to implement to be shown
    /// as a resource row in the ResourcesGantt main gantt.
    /// This is the ViewModel requirements for the Gantt control.
    /// </summary>
    public interface IResourceData : INotifyPropertyChanged
    {
        /// <summary>
        /// The resource row header text
        /// </summary>
        string Text { get; set; }
        /// <summary>
        /// The resource row header text color
        /// </summary>
        Brush TextColor { get; set; }
        /// <summary>
        /// The resource row header background color
        /// </summary>
        Brush BackColor { get; set; }
        /// <summary>
        /// The TaskData items assigned to this resource row
        /// </summary>
        ICollection<ITaskData> Items { get; set; }
        /// <summary>
        /// Payload for this resource. Actual domain object for this resource.
        /// </summary>
        object Payload { get; }
        /// <summary>
        /// Context menu item content for this resource
        /// </summary>
        ObservableCollection<IContextMenuItemData> ContextMenuItems { get; set; }
    }
}
