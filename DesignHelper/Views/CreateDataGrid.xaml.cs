using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using MahApps.Metro.Controls;

namespace DesignHelper
{
    /// <summary>
    /// Interaction logic for CreateDataGrid.xaml
    /// </summary>
    public partial class CreateDataGrid : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Prefix;
        private string gridXAML;
        public ObservableCollection<GridMember> GridList { get; set; }

        public string GridXAML
        {
            get { return gridXAML; }
            set
            {
                gridXAML = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("GridXAML"));
                }
            }
        }

        public CreateDataGrid()
        {
            Prefix = "Resx ResxName=ResourcesClient.Infrastructure.Resources.StringResources, Key=ManageStands.List.";
            GridList = new ObservableCollection<GridMember>();
            GridList.Add(new GridMember("Code"));
            GridList.Add(new GridMember("Description"));
            GridList.Add(new GridMember("LocalDesc"));
            GridList.Add(new GridMember("Position"));

            GridList.Add(new GridMember("Terminal"));
            GridList.Add(new GridMember("Group"));
            GridList.Add(new GridMember("DomDefaultGate"));
            GridList.Add(new GridMember("IntDefaultGate"));
            GridList.Add(new GridMember("Width"));
            GridList.Add(new GridMember("Length"));
            GridList.Add(new GridMember("Height"));
            GridList.Add(new GridMember("Type"));
            GridList.Add(new GridMember("AllocGap"));
            GridList.Add(new GridMember("ConflictGap"));
            GridList.Add(new GridMember("Location"));
            GridList.Add(new GridMember("HasGPU"));

            GridList.Add(new GridMember("NearByStands", "NearbyList", 0, 0, true));

            DataContext = this;
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (GridMember gridMember in GridList)
            {
                if (!gridMember.IsCSV)
                {
                    // <DataGridTextColumn Header="{Resx ResxName=ResourcesClient.Infrastructure.Resources.StringResources, Key=ManageStands.List.Terminal}" 
                    // Binding="{Binding Terminal}" />
                    sb.Append("<DataGridTextColumn Header=\"{");
                    sb.Append(Prefix);
                    sb.AppendLine(gridMember.Header + "}\"");
                    sb.AppendLine("Binding=\"{Binding " + gridMember.Binding + "}\"");

                    //Width="120"
                    if (gridMember.Width != 0)
                    {
                        sb.AppendLine("Width=\"" + gridMember.Width + "\"");
                    }

                    //MaxWidth="200"
                    if (gridMember.MaxWidth != 0)
                    {
                        sb.AppendLine("MaxWidth=\"" + gridMember.MaxWidth + "\"");
                    }

                    sb.AppendLine("/>");
                }
                else
                {
                    //<DataGridTextColumn Width="*"
                    //                    Header="{Resx ResxName=ResourcesClient.Infrastructure.Resources.StringResources, Key=ManageStands.List.Stands}"
                    //                    Binding="{Binding Stands}"
                    //                    MaxWidth="200">
                    //    <DataGridTextColumn.ElementStyle>
                    //        <Style>
                    //            <Setter Property="TextBlock.TextWrapping"
                    //                    Value="Wrap" />
                    //        </Style>
                    //    </DataGridTextColumn.ElementStyle>
                    //</DataGridTextColumn>
                    sb.Append("<DataGridTextColumn Header=\"{");
                    sb.Append(Prefix);
                    sb.AppendLine(gridMember.Header + "}\"");
                    sb.AppendLine("Binding=\"{Binding " + gridMember.Binding + "}\"");
                    sb.AppendLine("Width=\"*\"");
                    sb.AppendLine("MaxWidth=\"200\">");

                    sb.AppendLine("    <DataGridTextColumn.ElementStyle>");

                    sb.AppendLine("        <Style>");
                    sb.AppendLine("            <Setter Property=\"TextBlock.TextWrapping\"");
                    sb.AppendLine("                    Value=\"Wrap\" />");
                    sb.AppendLine("        </Style>");
                    sb.AppendLine("    </DataGridTextColumn.ElementStyle>");
                    sb.AppendLine("</DataGridTextColumn>");
                }

                GridXAML = sb.ToString();
            }
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GridXAML);
            MessageBox.Show("Text copied.");
        }
    }

    public class GridMember
    {
        public GridMember(string header, string binding = "", int width = 0, int maxWidth = 0, bool isCSV = false)
        {
            Header = header;
            Binding = string.IsNullOrEmpty(binding) ? header : binding;
            Width = width;
            MaxWidth = maxWidth;
            IsCSV = isCSV;
        }
        public string Header { get; set; }
        public string Binding { get; set; }
        public int Width { get; set; }
        public int MaxWidth { get; set; }
        public bool IsCSV { get; set; }
    }
}
