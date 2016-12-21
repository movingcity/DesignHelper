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
    /// Interaction logic for EntityToAdapter.xaml
    /// </summary>
    public partial class EntityToAdapter : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _entityText;
        private string _adapterText;

        /// <summary>
        /// Input xaml text
        /// </summary>
        public string EntityText
        {
            get { return _entityText; }
            set
            {
                _entityText = value;
                GetEntityName();
            }
        }

        public string CopyText { get; set; }
        public string MaintainText { get; set; }
        public string PropertyChangedText { get; set; }
        public string AdapterText
        {
            get { return _adapterText; }
            set
            {
                _adapterText = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AdapterText"));
                }
            }
        }

        public string EntityName { get; set; }

        public EntityToAdapter()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(AdapterText);
            MessageBox.Show("Text copied.");
        }

        private void GetEntityName()
        {
            if (!string.IsNullOrEmpty(EntityText))
            {
                foreach (string line in EntityText.Split('\n'))
                {
                    if (line.TrimStart().StartsWith("public") && line.Contains("class"))
                    {
                        string[] stats = line.Trim().Split(' ');
                        for (int i = 0; i < stats.Length - 1; i++)
                        {
                            if (stats[i] == "class")
                            {
                                EntityName = stats[i + 1];
                                OnPropertyChanged("EntityName");
                            }
                        }

                    }
                }
            }
        }

        private void GenerateAdapter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EntityText))
            {
                StringBuilder sbAdapterFinal = new StringBuilder();
                sbAdapterFinal.AppendLine();
                sbAdapterFinal.AppendLine("#region Entity properties");
                sbAdapterFinal.AppendLine();
                StringBuilder sbAdapter;

                StringBuilder sbDeepCopy = new StringBuilder();

                StringBuilder sbMaintain = new StringBuilder();

                StringBuilder sbPropertyChanged = new StringBuilder();

                foreach (string line in EntityText.Split('\n'))
                {
                    //find out all Resx tags
                    if (line.TrimStart().StartsWith("public") && !line.Contains(" class "))
                    {
                        string[] stats = line.Trim().Split(' ');
                        if (stats.Length == 3)
                        {
                            sbAdapter = new StringBuilder();
                            //public string FlightNumber
                            sbAdapter.Append(stats[0] + " ");
                            if (stats[1] == "String ")
                            {
                                sbAdapter.Append("string ");
                            }
                            else
                            {
                                sbAdapter.Append(stats[1] + " ");
                            }
                            sbAdapter.Append(stats[2]);
                            sbAdapter.AppendLine();

                            //{
                            sbAdapter.AppendLine("{");
                            //    get { return Flight.FlightNumber; }
                            sbAdapter.AppendLine("    get { return " + EntityName + "." + stats[2] + ";}");

                            //}
                            sbAdapterFinal.AppendLine("}");
                            sbAdapterFinal.AppendLine();

                            // Deep copy
                            // target.Code = source.Code;
                            sbDeepCopy.AppendLine("target." + stats[2] + " = " + "source." + stats[2] + ";");

                            sbAdapterFinal.Append(sbAdapter);

                            //set
                            //{
                            //    if (value != group.Name)
                            //    {
                            //        group.Name = value;
                            //        RaisePropertyChangedEvent("Name");
                            //    }
                            //}
                            sbAdapter.AppendLine("    set {");
                            sbAdapter.AppendLine("        if (value != "+ EntityName + "." + stats[2] + ")");
                            sbAdapter.AppendLine("        {");
                            sbAdapter.AppendLine("            " + EntityName + "." + stats[2] + " = value;");
                            sbAdapter.AppendLine("            RaisePropertyChangedEvent(\"" +  stats[2] + "\");");
                            sbAdapter.AppendLine("        }}");
                            sbAdapter.AppendLine("    }");

                            sbMaintain.Append(sbAdapter);

                            // case "Resource":
                            // RaisePropertyChangedEvent("Stand");
                            // break;
                            sbPropertyChanged.AppendLine("case \"" + stats[2] + "\" :");
                            sbPropertyChanged.AppendLine("  RaisePropertyChangedEvent(\"" + stats[2] + "\" );");
                            sbPropertyChanged.AppendLine("  break;");
                        }
                    }
                }

                sbAdapterFinal.AppendLine();
                sbAdapterFinal.AppendLine("#endregion");


                AdapterText = sbAdapterFinal.ToString();
                OnPropertyChanged("AdapterText");

                CopyText = sbDeepCopy.ToString();
                OnPropertyChanged("CopyText");

                MaintainText = sbMaintain.ToString();
                OnPropertyChanged("MaintainText");

                PropertyChangedText = sbPropertyChanged.ToString();
                OnPropertyChanged("PropertyChangedText");
            }

        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
