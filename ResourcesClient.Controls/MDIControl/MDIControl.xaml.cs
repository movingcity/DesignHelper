using System;
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
using System.Collections.ObjectModel;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Interaction logic for MDIControl.xaml
    /// </summary>
    public partial class MDIControl : UserControl, IMDIControl
    {
        // list of current open mdi child items
        // corresponds to the mdiParent TabItems collection
        private readonly ObservableCollection<MDIChild> mdiChildren;
        // style to be applied to all TabItems
        private readonly Style tabItemStyle;

        public MDIControl()
        {
            InitializeComponent();

            mdiChildren = new ObservableCollection<MDIChild>();
            // should match the resource key in XAML!
            tabItemStyle =  grid.Resources["MDITabItemStyle"] as Style;
        }

        #region IMDIControl

        /// <summary>
        /// Create the handle to the MDI child window.
        /// The passed Window content is used for creating
        /// the MDI child content.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public IMDIChild Create(Window window)
        {
            // sanity check
            if (window == null)
            {
                throw new ArgumentException("Create window cannot be null");
            }

            // remove content from window
            object content = window.Content;
            window.Content = null;
            // create TabItem
            TabItem tabItem = CreateTabItem(window.Title, content);
            // copy over the data context 
            tabItem.DataContext = window.DataContext;
            // close the passed window object so that it is disposed
            window.Close();

            // create and return new mdi child item
            // we dont add to list until we show
            return new MDIChild(tabItem);
        }

        /// <summary>
        /// Show the MDI child with the passed handle.
        /// Opening event will be raised on the child.
        /// If the MDI child is already open (Show called previously),
        /// then it will be Activated.
        /// </summary>
        /// <param name="child"></param>
        public void Show(IMDIChild childItem)
        {
            MDIChild child = childItem as MDIChild;
            // sanity check
            if (child == null)
            {
                throw new ArgumentException("Show child cannot be null");
            }

            // check if mdi child has been shown previously
            if (mdiChildren.Contains(child))
            {
                // activate it
                Activate(child);
                return;
            }

            // add to children
            mdiChildren.Add(child);
            mdiParent.Items.Add(child.TabItem);
            // bring to front
            mdiParent.SelectedItem = child.TabItem;
            // raise opening event
            child.RaiseOpening();
        }

        /// <summary>
        /// Bring to front the MDI child with the passed handle.
        /// </summary>
        /// <param name="child"></param>
        public void Activate(IMDIChild childItem)
        {
            MDIChild child = childItem as MDIChild;
            // sanity check
            if (child == null)
            {
                throw new ArgumentException("Activate child cannot be null");
            }
            if (!mdiChildren.Contains(child))
            {
                throw new InvalidOperationException("Cannot call Activate on a child which has not been Show(n)");
            }

            // activate
            mdiParent.SelectedItem = child.TabItem;
        }

        /// <summary>
        /// Close the MDI child with the passed handle.
        /// Closing and Closed events will be raised on child.
        /// Close can be cancelled by handling the Closing event Cancel property.
        /// </summary>
        /// <param name="child"></param>
        public void Close(IMDIChild childItem)
        {
            MDIChild child = childItem as MDIChild;
            // sanity check
            if (child == null)
            {
                throw new ArgumentException("Activate child cannot be null");
            }
            if (!mdiChildren.Contains(child))
            {
                throw new InvalidOperationException("Cannot call Close on a child which has not been Show(n)");
            }

            // invoke Closing event
            CancelEventArgs args = new CancelEventArgs();
            child.RaiseClosing(args);
            // check if close has been aborted
            if (args.Cancel)
            {
                return;
            }

            // close/remove
            mdiChildren.Remove(child);
            mdiParent.Items.Remove(child.TabItem);

            // raise Closed event
            child.RaiseClosed();
        }

        /// <summary>
        /// List the MDI child windows currently displayed to the user.
        /// MDI child which has been Create(d) will not be present in this list.
        /// Readonly list
        /// </summary>
        public IEnumerable<IMDIChild> Children
        {
            get
            {
                return new ReadOnlyObservableCollection<MDIChild>(mdiChildren);
            }
        }

        #endregion

        #region helper methods

        // create a TabItem for the passed title and content
        private TabItem CreateTabItem(string title, object content)
        {
            TabItem tabItem = new TabItem();
            tabItem.Content = content;
            tabItem.Header = title;
            tabItem.Style = tabItemStyle;

            return tabItem;
        }

        // invoked when TabItem header close X button is clicked
        private void cmdTabItemCloseButton_Click(object sender, RoutedEventArgs e)
        {
            // see XAML, tabitem is bound to Tag property
            TabItem tabItem = ((Button)sender).Tag as TabItem;

            MDIChild child = null;
            // find the MDIChild corresponding to this TabItem
            foreach (MDIChild c in mdiChildren)
            {
                if (c.TabItem == tabItem)
                {
                    child = c;
                    break;
                }
            }

            // sanity check
            if (child == null)
            {
                // fail-safe - we assume that this TabItem was never
                // added as a MDI child
                // so we just remove it
                mdiParent.Items.Remove(tabItem);
                return;
            }

            // invoke close on the child
            Close(child);
        }

        #endregion
    }
}
