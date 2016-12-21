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

namespace ResourcesClient.Controls
{
    public class DataGridHeaderFilterControl : Control
    {
        static DataGridHeaderFilterControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridHeaderFilterControl), new FrameworkPropertyMetadata(typeof(DataGridHeaderFilterControl)));
        }
    }
}
