using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Linq;
using com.unisys.rms.domain.reference;
using com.unisys.rms.domain.resource;
using MahApps.Metro.Controls;

namespace DesignHelper
{
    /// <summary>
    /// Interaction logic for TestEntities.xaml
    /// </summary>
    public partial class TestEntities : MetroWindow, INotifyPropertyChanged
    {
        private ICollectionView terminals;
        private Random r;

        public TestEntities()
        {
            r = new Random();
            DeletedColor = new SolidColorBrush(Colors.Gainsboro);
            HighlightedColor = new SolidColorBrush(Colors.YellowGreen);
            TerminalList = new ObservableCollection<Terminal>()
            {
                new Terminal{ Code = 1, Deleted = true,Description = "Terminal 1",Id=1,LocalDesc = "HZL1",Highlighted = false},
                new Terminal{ Code = 100, Deleted = false,Description = "Terminal 1",Id=1,LocalDesc = "HZL1",Highlighted = false},
                new Terminal{ Code = 99, Deleted = true,Description = "Terminal 1",Id=1,LocalDesc = "HZL1",Highlighted = false},
                new Terminal{ Code = 55555, Deleted = false,Description = "Terminal 1",Id=1,LocalDesc = "HZL1",Highlighted = false},
                new Terminal{ Code = 124, Deleted = false,Description = "Terminal 1",Id=1,LocalDesc = "HZL1",Highlighted = false},
                new Terminal{ Code = 421, Deleted = false,Description = "Terminal 1",Id=1,LocalDesc = "HZL1",Highlighted = true},
            };

            Airport = new Airport() { Location = LocationType.South };
            CollectionViewSource cvs = new CollectionViewSource();
            cvs.Source = TerminalList;
            terminals = cvs.View;
            // default sort
            DefaultSort();
            OnPropertyChanged("Terminals");

            DataContext = this;
            InitializeComponent();

        }
        private void DefaultSort()
        {
            terminals.SortDescriptions.Clear();
            SortDescription sd = new SortDescription("Code", ListSortDirection.Ascending);
            terminals.SortDescriptions.Add(sd);
        }
        public ICollectionView Terminals
        {
            get { return terminals; }
        }
        public Brush DeletedColor { get; set; }
        public Brush HighlightedColor { get; set; }
        public ObservableCollection<Terminal> TerminalList { get; set; }
        public Terminal SelectedTerminal { get; set; }
        public Airport Airport { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TestEntitiesButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedTerminal.Highlighted = !SelectedTerminal.Highlighted;
            //SelectedTerminal.Deleted = !SelectedTerminal.Deleted;
            SelectedTerminal.Code = SelectedTerminal.Code + 1;
        }

        public LocationType? Location
        {
            get { return Airport.Location; }
            set
            {
                Airport.Location = value;
                OnPropertyChanged("Location");
            }
        }

        public IEnumerable<LocationType?> Locations
        {
            get
            {
                return Enum.GetValues(typeof(LocationType))
                    .Cast<LocationType?>();
            }
        }


        private void AddRowButton_OnClick(object sender, RoutedEventArgs e)
        {
            TerminalList.Add(new Terminal()
            {
                Code = r.Next(1, 9999),
                Deleted = true,
                Description = "Terminal 1",
                Id = 1,
                LocalDesc = "HZL1",
                Highlighted = false
            });
            DefaultSort();
            OnPropertyChanged("Terminals");
        }
    }
}
