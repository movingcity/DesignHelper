using System;
using System.Windows;
using System.Collections.Generic;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Represents a container for MDI child windows.
    /// All windows created belong to this parent MDI.
    /// </summary>
    public interface IMDIControl
    {
        /// <summary>
        /// Create the handle to the MDI child window.
        /// The passed Window content is used for creating
        /// the MDI child content.
        /// The passed Window object is merged to MDI child
        /// and is disposed - DO NOT USE this window instance AGAIN.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        IMDIChild Create(Window window);

        /// <summary>
        /// Show the MDI child with the passed handle.
        /// Opening event will be raised on the child.
        /// If the MDI child is already open (Show called previously),
        /// then it will be Activated.
        /// </summary>
        /// <param name="child"></param>
        void Show(IMDIChild child);

        /// <summary>
        /// Bring to front the MDI child with the passed handle.
        /// </summary>
        /// <param name="child"></param>
        void Activate(IMDIChild child);

        /// <summary>
        /// Close the MDI child with the passed handle.
        /// Closing and Closed events will be raised on child.
        /// Close can be cancelled by handling the Closing event Cancel property.
        /// </summary>
        /// <param name="child"></param>
        void Close(IMDIChild child);

        /// <summary>
        /// List the MDI child windows currently displayed to the user.
        /// MDI child which has been Create(d) will not be present in this list.
        /// </summary>
        IEnumerable<IMDIChild> Children
        {
            get;
        }
    }
}
