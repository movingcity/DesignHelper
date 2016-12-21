using System.ComponentModel;
using System;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Represents a MDI child window instance
    /// </summary>
    public interface IMDIChild
    {
        /// <summary>
        /// The window title of the MDI child.
        /// </summary>
        string Title
        {
            get;
        }

        /// <summary>
        /// Returns true if this child is active to the user.
        /// </summary>
        bool IsActive
        {
            get;
        }

        /// <summary>
        /// Occurs directly after IMDIControl.Close is called, and can be handled to cancel window closure. 
        /// </summary>
        event CancelEventHandler Closing;

        /// <summary>
        /// Occurs when the child window is about to close.
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        /// Occurs when the child window has been opened.
        /// </summary>
        event EventHandler Opening;
    }
}
