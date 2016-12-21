using System.Windows.Controls;
using System.Windows;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Specialized TabItem to be used within the "NotifyContent TabControl" in the NotificationControl.
    /// Includes extra dependency property for the Notification Window header
    /// </summary>
    public class NotifyTabItem : TabItem
    {
        /// <summary>
        /// Identifies the WindowHeaderProperty dependency property
        /// </summary>
        public static readonly DependencyProperty WindowHeaderProperty = DependencyProperty.Register("WindowHeader", typeof(object), 
            typeof(NotifyTabItem), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets the data used for the Notification Window Header for the control. This content displays on the
        /// Notification Window header when it is visible.
        /// </summary>
        public object WindowHeader
        {
            get { return (object)GetValue(WindowHeaderProperty); }
            set { SetValue(WindowHeaderProperty, value); }
        }
    }
}
