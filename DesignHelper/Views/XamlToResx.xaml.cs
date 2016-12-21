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
    /// Interaction logic for XamlToResx.xaml
    /// </summary>
    public partial class XamlToResx : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _xamlText;
        private string _resxText;

        /// <summary>
        /// Input xaml text
        /// </summary>
        public string XAMLText
        {
            get { return _xamlText; }
            set { _xamlText = value; }
        }

        public string ResxText
        {
            get { return _resxText; }
            set
            {
                _resxText = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ResxText"));
                }
            }
        }

        public bool IsCommonIncluded { get; set; }

        public ObservableCollection<ResxRow> ResxList { get; set; }

        public XamlToResx()
        {
            ResxList = new ObservableCollection<ResxRow>();
            IsCommonIncluded = true;

            DataContext = this;
            InitializeComponent();
        }

        private void XamlToGrid_Click(object sender, RoutedEventArgs e)
        {
            ResxList.Clear();
            if (!string.IsNullOrEmpty(XAMLText))
            {
                foreach (string line in XAMLText.Split('\n'))
                {
                    //find out all Resx tags
                    if (line.Contains("{Resx"))
                    {
                        if (IsCommonIncluded || !line.Contains("Common."))
                        {
                            ResxList.Add(new ResxRow(line));
                        }
                    }
                }
            }
        }

        private void GridToResx_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var resxRow in ResxList)
            {
                sb.Append("  <data name=\"");
                sb.Append(resxRow.Name);
                sb.AppendLine("\" xml:space=\"preserve\">");

                sb.Append("    <value>");
                sb.Append(resxRow.Value);
                sb.AppendLine("</value>");

                sb.AppendLine("  </data>");

            }
            ResxText = sb.ToString();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ResxText);
            MessageBox.Show("Text copied.");
        }
    }

    public class ResxRow
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string BindingString { get; set; }

        /// <summary>
        /// Create ResxRow from Xaml
        /// </summary>
        /// <param name="XamlLine">e.g. Content="{Resx Common.OK}"</param>
        public ResxRow(string XamlLine)
        {
            int startIndex, endIndex;
            endIndex = XamlLine.IndexOf("}\"");
            //GridColumn {Resx ResxName=ResourcesClient.Infrastructure.Resources.StringResources, Key=
            startIndex = XamlLine.IndexOf("{Resx ResxName=ResourcesClient.Infrastructure.Resources.StringResources, ");
            if (startIndex < 0)
            {
                startIndex = XamlLine.IndexOf("{Resx ");
                Name = XamlLine.Substring(startIndex + 6, endIndex - startIndex - 6);
            }
            else
            {
                Name = XamlLine.Substring(startIndex + 77, endIndex - startIndex - 77);
            }

            BindingString = XamlLine.Substring(startIndex, endIndex - startIndex + 1);

            Value = Name.Substring(Name.IndexOf(".") + 1);
        }
    }
}
