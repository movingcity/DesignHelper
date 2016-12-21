using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace ResourcesClient.Controls
{
    internal class MDIChild : IMDIChild, INotifyPropertyChanged
    {
        private readonly TabItem tabItem;

        /// <summary>
        /// Construct the class. Immutable
        /// </summary>
        /// <param name="title">Title of the child window</param>
        internal MDIChild(TabItem tabItem)
        {
            if (tabItem == null)
            {
                throw new ArgumentException("tabItem cannot be null");
            }

            this.tabItem = tabItem;

            // link notify property changed
            DependencyPropertyDescriptor dpd1 = DependencyPropertyDescriptor.FromProperty(TabItem.IsSelectedProperty, typeof(TabItem));
            dpd1.AddValueChanged(tabItem, (o, args) =>
            {
                RaisePropertyChanged("IsActive");
            });
            DependencyPropertyDescriptor dpd2 = DependencyPropertyDescriptor.FromProperty(TabItem.HeaderProperty, typeof(TabItem));
            dpd2.AddValueChanged(tabItem, (o, args) =>
            {
                RaisePropertyChanged("Title");
            });
        }

        /// <summary>
        /// For internal use only. The TabItem associated with the child screen.
        /// </summary>
        internal TabItem TabItem
        {
            get
            {
                return tabItem;
            }
        }

        /// <summary>
        /// The window title of the MDI child.
        /// </summary>
        public string Title
        {
            get
            {
                return tabItem.Header.ToString();
            }
        }

        /// <summary>
        /// Returns true if this child is active to the user.
        /// </summary>
        public bool IsActive
        {
            get
            {
                return tabItem.IsSelected;
            }
        }

        /// <summary>
        /// Occurs directly after MDIControl.Close is called, and can be handled to cancel window closure. 
        /// </summary>
        public event CancelEventHandler Closing;

        /// <summary>
        /// Occurs when the window is about to close.
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        /// Occurs when the child window has been opened.
        /// </summary>
        public event EventHandler Opening;

        internal void RaiseClosing(CancelEventArgs args)
        {
            if (Closing != null)
            {
                Closing(this, args);
            }
        }

        internal void RaiseClosed()
        {
            if (Closed != null)
            {
                Closed(this, EventArgs.Empty);
            }
        }

        internal void RaiseOpening()
        {
            if (Opening != null)
            {
                Opening(this, EventArgs.Empty);
            }
        }

        // get the TabControl that is hosting the child
        private TabControl GetTabControl()
        {
            return tabItem.Parent as TabControl;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(name);
                PropertyChanged(this, args);
            }
        }
    }
}
