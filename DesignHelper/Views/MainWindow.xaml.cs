using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace DesignHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private int? _paxCount;
        private long? _paxCountLong;

        public MainWindow()
        {
            PaxCountLong = 100;
            PaxCount = 100;
            FlightNumber = "CA1234";
            DataContext = this;
            InitializeComponent();
            //#if (DEBUG)
            //            {
            //                EntityToAdapter EntityToAdapter = new EntityToAdapter();
            //                EntityToAdapter.Show();
            //            }
            //#endif
        }

        public int? PaxCount
        {
            get { return _paxCount; }
            set { _paxCount = value; }
        }
        public long? PaxCountLong
        {
            get { return _paxCountLong; }
            set { _paxCountLong = value; }
        }

        public String FlightNumber { get; set; }

        private void XamlToResx_Click(object sender, RoutedEventArgs e)
        {
            XamlToResx xamlToResx = new XamlToResx();
            xamlToResx.Show();
        }

        private void XamlBindings_Click(object sender, RoutedEventArgs e)
        {
            XamlBindings XamlBindings = new XamlBindings();
            XamlBindings.Show();
        }

        private void CreateDataGrid_Click(object sender, RoutedEventArgs e)
        {
            CreateDataGrid CreateDataGrid = new CreateDataGrid();
            CreateDataGrid.Show();
        }

        private void RemoveResx_Click(object sender, RoutedEventArgs e)
        {
            RemoveResx RemoveResx = new RemoveResx();
            RemoveResx.Show();

        }

        private void TestEntities_Click(object sender, RoutedEventArgs e)
        {
            //TestEntities TestEntities = new TestEntities();
            //TestEntities.Show();
        }

        private void EntityToAdapter_Click(object sender, RoutedEventArgs e)
        {
            EntityToAdapter EntityToAdapter = new EntityToAdapter();
            EntityToAdapter.Show();
        }

        private void ListProps_Click(object sender, RoutedEventArgs e)
        {
            ListProps listProps = new ListProps();
            listProps.Show();
        }
    }
}
