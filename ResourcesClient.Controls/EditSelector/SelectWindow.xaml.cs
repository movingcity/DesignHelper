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
using System.Windows.Shapes;
using System.Collections;
using System.ComponentModel;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// The Select items window for the EditSelector.
    /// Hosts the MultiSelectControl to allow list based selection
    /// of items for the EditSelector.
    /// </summary>
    internal partial class SelectWindow : Window, INotifyPropertyChanged
    {
        private IList selectedItems;

        public SelectWindow()
        {
            InitializeComponent();
            SelectWindowResult = false;
        }

        /// <summary>
        /// Result of the Window - OK = true, else false.
        /// Used by the EditSelector to determine if user accepted or rejected selection
        /// in this window
        /// </summary>
        public bool SelectWindowResult { get; set; }

        /// <summary>
        /// Selected Items for this window.
        /// The MultiSelectControl SelectedItems DP will bind to this
        /// hence the need for INotifyPropertyChanged
        /// </summary>
        public IList SelectWindowSelectedItems 
        {
            get { return selectedItems; }
            set
            {
                if (value != selectedItems)
                {
                    selectedItems = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChangedEventArgs args = new PropertyChangedEventArgs("SelectWindowSelectedItems");
                        PropertyChanged(this, args);
                    }
                }
            }
        }

        // Click of OK Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // cannot use DialogResult as we cache this window
            // and do not close it
            // Without closing window, DialogResult always remains null
            // (see Window_Closing below)
            this.SelectWindowResult = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // prevent window from closing (cache)
            this.Hide();
            e.Cancel = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
