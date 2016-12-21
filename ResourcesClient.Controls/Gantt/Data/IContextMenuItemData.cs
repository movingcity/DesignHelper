using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace ResourcesClient.Controls.Data
{
    /// <summary>
    /// Defines the interface an object needs to implement
    /// to be shown as a context menu item.
    /// This is the ViewModel requirements for the Gantt control context menu.
    /// </summary>
    public interface IContextMenuItemData
    {
        /// <summary>
        /// Menu item name
        /// </summary>
        string Header { get; }
        /// <summary>
        /// Sub menu items
        /// </summary>
        IEnumerable<IContextMenuItemData> Items { get; }
        /// <summary>
        /// Menu item icon
        /// </summary>
        Image Icon { get; }
        /// <summary>
        /// Is menu item checkable
        /// </summary>
        bool IsCheckable { get; }
        /// <summary>
        /// Menu item checked state
        /// </summary>
        bool IsChecked { get; set; }
        /// <summary>
        /// Is menu item visible
        /// </summary>
        bool Visible { get; }
        /// <summary>
        /// Is menu item a separator.
        /// For a separator, other properties are not required and are ignored
        /// </summary>
        bool IsSeparator { get; }
        /// <summary>
        /// The tooltip to show for the menu item
        /// </summary>
        string ToolTip { get; }
        /// <summary>
        /// The command associated with the menu item
        /// </summary>
        ICommand Command { get; }
    }
}
