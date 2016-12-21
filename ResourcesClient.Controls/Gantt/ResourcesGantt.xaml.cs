using System.Windows.Controls;
using System.Windows;
using System.Collections;
using System;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ResourcesClient.Controls.Data;
using ResourcesClient.Controls.Adorners;
using System.Windows.Documents;
using PlexityHide.GTP;
using ResourcesClient.Controls.Utility;
using System.Collections.Generic;
using System.Windows.Threading;
using System.ComponentModel;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Generic Gantt control for Resources Client.
    /// Consists of three gantt charts. Main gantt which displays task allocations to resources.
    /// Scratch gantt which displays tasks which are not allocated.
    /// Misc gantt which displays additional tasks which are not allocated.
    /// </summary>
    public partial class ResourcesGantt : UserControl
    {
        #region Fields

        /// <summary>
        /// fixed width of the resource header of the gantt row
        /// </summary>
        public static readonly GridLength RESOURCE_HEADER_WIDTH = new GridLength(60);
        /// <summary>
        /// fixed width of the scroll area of the gantt row 
        /// </summary>
        public static readonly GridLength SCROLL_WIDTH = new GridLength(25);
        /// <summary>
        /// Setting this to true allows override of the single selection behaviour.
        /// Selecting tasks will then be incremental
        /// </summary>
        public static bool IsSingleSelectOverride;

        // vertical timeline adorner, displayed when special key is pressed
        private TimelineAdorner timeline;
        // flag used to be Checked/Unchecked event handlers
        private bool checkFlag;

        // dispatcher timers for resource and task popups
        DispatcherTimer resourcePopupTimer = null;
        DispatcherTimer taskPopupTimer = null;
        EventHandler resourcePopupTimerEventHandler = null;
        EventHandler taskPopupTimerEventHandler = null;
        
        #endregion

        #region Constructor

        public ResourcesGantt()
        {
            InitializeComponent();
        }

        #endregion

        #region Region Visibility Properties

        /// <summary>
        /// Identifies the IsScratchVisibleProperty dependency property
        /// </summary>
        public static readonly DependencyProperty IsScratchVisibleProperty = DependencyProperty.Register("IsScratchVisible", typeof(bool),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(true, IsScratchVisiblePropertyChanged));
        /// <summary>
        /// Gets or sets the Visibility of the scratch gantt
        /// </summary>
        public object IsScratchVisible
        {
            get { return (object)GetValue(IsScratchVisibleProperty); }
            set { SetValue(IsScratchVisibleProperty, value); }
        }

        private static void IsScratchVisiblePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            bool oldValue = (bool)e.OldValue;
            bool newValue = (bool)e.NewValue;
            ResourcesGantt control = sender as ResourcesGantt;
            if (control != null && oldValue != newValue)
            {
                if (newValue)
                {
                    // scratch gantt added in the middle
                    control.LayoutRoot.RowDefinitions.Insert(1, control.splitterRow1);
                    control.LayoutRoot.RowDefinitions.Insert(2, control.scratchGanttRow);
                }
                else
                {
                    control.LayoutRoot.RowDefinitions.Remove(control.splitterRow1);
                    control.LayoutRoot.RowDefinitions.Remove(control.scratchGanttRow);
                }
            }
        }

        /// <summary>
        /// Identifies the IsMiscVisibleProperty dependency property
        /// </summary>
        public static readonly DependencyProperty IsMiscVisibleProperty = DependencyProperty.Register("IsMiscVisible", typeof(bool),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(true, IsMiscVisiblePropertyChanged));
        /// <summary>
        /// Gets or sets the Visibility of the registration changed gantt
        /// </summary>
        public object IsMiscVisible
        {
            get { return (object)GetValue(IsMiscVisibleProperty); }
            set { SetValue(IsMiscVisibleProperty, value); }
        }

        private static void IsMiscVisiblePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            bool oldValue = (bool)e.OldValue;
            bool newValue = (bool)e.NewValue;
            ResourcesGantt control = sender as ResourcesGantt;
            if (control != null && oldValue != newValue)
            {
                if (newValue)
                {
                    // change gantt added at the end
                    control.LayoutRoot.RowDefinitions.Add(control.splitterRow2);
                    control.LayoutRoot.RowDefinitions.Add(control.miscGanttRow);
                }
                else
                {
                    control.LayoutRoot.RowDefinitions.Remove(control.splitterRow2);
                    control.LayoutRoot.RowDefinitions.Remove(control.miscGanttRow);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Identifies the MainSourceProperty dependency property.
        /// </summary>
        public static readonly DependencyProperty MainSourceProperty = DependencyProperty.Register("MainSource", 
            typeof(IEnumerable<IResourceData>),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets a collection used to generate the content of the main gantt.
        /// This collection is the list of resources with their allocated tasks.
        /// Bind to an ObservableCollection of ResourceData objects.
        /// </summary>
        public IEnumerable<IResourceData> MainSource
        {
            get { return (IEnumerable<IResourceData>)GetValue(MainSourceProperty); }
            set { SetValue(MainSourceProperty, value); }
        }

        /// <summary>
        /// Identifies the ScratchSourceProperty dependency property
        /// </summary>
        public static readonly DependencyProperty ScratchSourceProperty = DependencyProperty.Register("ScratchSource",
            typeof(IEnumerable<ITaskData>),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets a collection used to generate the content of the scratch gantt.
        /// This collection is the list of tasks which are not allocated to resources.
        /// Bind to an ObservableCollection of TaskData objects
        /// </summary>
        public IEnumerable<ITaskData> ScratchSource
        {
            get { return (IEnumerable<ITaskData>)GetValue(ScratchSourceProperty); }
            set { SetValue(ScratchSourceProperty, value); }
        }

        /// <summary>
        /// Identifies the MiscSourceProperty dependency property
        /// </summary>
        public static readonly DependencyProperty MiscSourceProperty = DependencyProperty.Register("MiscSource",
            typeof(IEnumerable<ITaskData>),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets a collection used to generate the content of the misc gantt.
        /// This collection is the list of tasks which are to be listed as miscellaneous.
        /// Bind to an ObservableCollection of TaskData objects
        /// </summary>
        public IEnumerable<ITaskData> MiscSource
        {
            get { return (IEnumerable<ITaskData>)GetValue(MiscSourceProperty); }
            set { SetValue(MiscSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets a Date to be used as a lower bound for all gantts.
        /// This is not a dependency property and needs to be set at the time of construction of
        /// gantt control and before control is loaded visually
        /// </summary>
        // Plexity Gantt does not expose the property as Dependency Property
        public DateTime LowerBound
        {
            get { return dateScaler1.LowerBound; }
            set
            {
                dateScaler1.LowerBound = value;
                dateScaler2.LowerBound = value;
                dateScaler3.LowerBound = value;
            }
        }

        /// <summary>
        /// Gets or sets a Date to be used as a lower bound for all gantts.
        /// This is not a dependency property and needs to be set at the time of construction of
        /// gantt control and before control is loaded visually
        /// </summary>
        // Plexity Gantt does not expose the property as Dependency Property
        public DateTime UpperBound
        {
            get { return dateScaler1.UpperBound; }
            set
            {
                dateScaler1.UpperBound = value;
                dateScaler2.UpperBound = value;
                dateScaler3.UpperBound = value;
            }
        }

        /// <summary>
        /// Identifies the EvenRowColorProperty dependency property
        /// </summary>
        public static readonly DependencyProperty EvenRowColorProperty = DependencyProperty.Register("EvenRowColor", typeof(Color),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(Colors.Black));
        /// <summary>
        /// Gets or sets the color to be used as background for even index resource rows in the main gantt chart.
        /// Applies alpha channel transparency before rendering as background color
        /// </summary>
        public Color EvenRowColor
        {
            get { return (Color)GetValue(EvenRowColorProperty); }
            set { SetValue(EvenRowColorProperty, value); }
        }

        /// <summary>
        /// Identifies the OddRowColorProperty dependency property
        /// </summary>
        public static readonly DependencyProperty OddRowColorProperty = DependencyProperty.Register("OddRowColor", typeof(Color),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(Colors.White));
        /// <summary>
        /// Gets or sets the color to be used as background for odd index resource rows in the main gantt chart.
        /// Applies alpha channel transparency before rendering as background color
        /// </summary>
        public Color OddRowColor
        {
            get { return (Color)GetValue(OddRowColorProperty); }
            set { SetValue(OddRowColorProperty, value); }
        }

        /// <summary>
        /// Identifies the CmdButtonContentProperty dependency property
        /// </summary>
        public static readonly DependencyProperty CmdButtonContentProperty = DependencyProperty.Register("CmdButtonContent", typeof(object),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets the content for the Command Button on the main gantt.
        /// </summary>
        public object CmdButtonContent
        {
            get { return GetValue(CmdButtonContentProperty); }
            set { SetValue(CmdButtonContentProperty, value); }
        }

        /// <summary>
        /// Identifies the CmdButtonCommandProperty dependency property
        /// </summary>
        public static readonly DependencyProperty CmdButtonCommandProperty = DependencyProperty.Register("CmdButtonCommand", typeof(ICommand),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets the ICommand for the Command Button on the main gantt.
        /// </summary>
        public ICommand CmdButtonCommand
        {
            get { return (ICommand)GetValue(CmdButtonCommandProperty); }
            set { SetValue(CmdButtonCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the DateTimeFormatProperty dependency property
        /// </summary>
        public static readonly DependencyProperty DateTimeFormatProperty = DependencyProperty.Register("DateTimeFormat", typeof(string),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata("MMM dd, yyyy"));
        /// <summary>
        /// Gets or sets the datetime format string to be used to format date time display in the gantt header.
        /// </summary>
        public string DateTimeFormat
        {
            get { return (string)GetValue(DateTimeFormatProperty); }
            set { SetValue(DateTimeFormatProperty, value); }
        }

        /// <summary>
        /// Identifies the VerticalGridGapProperty dependency property
        /// </summary>
        public static readonly DependencyProperty VerticalGridGapProperty = DependencyProperty.Register("VerticalGridGap", typeof(int),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(1));
        /// <summary>
        /// Gets or sets the gap (in hours) between vertical grid lines in all three gantt charts.
        /// A value of zero indicates that vertical grid lines not to be drawn.
        /// </summary>
        public int VerticalGridGap
        {
            get { return (int)GetValue(VerticalGridGapProperty); }
            set { SetValue(VerticalGridGapProperty, value); }
        }

        /// <summary>
        /// Identifies the AllowedLinesProperty dependency property
        /// </summary>
        public static readonly DependencyProperty AllowedLinesProperty = DependencyProperty.Register("AllowedLines", typeof(int),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(1, AllowedLinesPropertyChanged), 
            new ValidateValueCallback(ValidateAllowedLinesProperty));
        /// <summary>
        /// Gets or sets the number of lines to be shown on task lozenges.
        /// Allowed values are 1, 2 and 3.
        /// Default value is 1
        /// </summary>
        public int AllowedLines
        {
            get { return (int)GetValue(AllowedLinesProperty); }
            set { SetValue(AllowedLinesProperty, value); }
        }

        private static bool ValidateAllowedLinesProperty(object value)
        {
            if (value is int)
            {
                int intValue = (int)value;
                if (intValue > 0 && intValue < 4)
                {
                    return true;
                }
            }
            return false;
        }

        private static void AllowedLinesPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // need to set the GanttRow
        }

        /// <summary>
        /// Identifies the SelectionBackColorProperty dependency property
        /// </summary>
        public static readonly DependencyProperty SelectionBackColorProperty = DependencyProperty.Register("SelectionBackColor", typeof(Brush),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black)));
        /// <summary>
        /// Gets or sets the Brush to be used as the selected task background color.
        /// Default background for selected tasks is black
        /// </summary>
        public Brush SelectionBackColor
        {
            get { return (Brush)GetValue(SelectionBackColorProperty); }
            set { SetValue(SelectionBackColorProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectionTextColorProperty dependency property
        /// </summary>
        public static readonly DependencyProperty SelectionTextColorProperty = DependencyProperty.Register("SelectionTextColor", typeof(Brush),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White)));
        /// <summary>
        /// Gets or sets the Brush to be used as the selected task text color.
        /// Default text color for selected tasks is white
        /// </summary>
        public Brush SelectionTextColor
        {
            get { return (Brush)GetValue(SelectionTextColorProperty); }
            set { SetValue(SelectionTextColorProperty, value); }
        }

        /// <summary>
        /// Identifies the TaskBoundKeyProperty dependency property
        /// </summary>
        public static readonly DependencyProperty TaskBoundKeyProperty = DependencyProperty.Register("TaskBoundKey", typeof(Key),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(Key.B));
        /// <summary>
        /// Gets or sets the Key to be bound to the task in the gantt.
        /// Clicking on the key while mouse is over a task will display task popup populated with TaskPopupDataTemplate.
        /// Default key bound to task is 'B'
        /// </summary>
        public Key TaskBoundKey
        {
            get { return (Key)GetValue(TaskBoundKeyProperty); }
            set { SetValue(TaskBoundKeyProperty, value); }
        }

        /// <summary>
        /// Identifies the ScratchBackColorProperty dependency property
        /// </summary>
        public static readonly DependencyProperty ScratchBackColorProperty = DependencyProperty.Register("ScratchBackColor", typeof(Color),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(Colors.Black));
        /// <summary>
        /// Gets or sets the color to be used as background for scratch gantt row.
        /// Applies alpha channel transparency before rendering as background color
        /// </summary>
        public Color ScratchBackColor
        {
            get { return (Color)GetValue(ScratchBackColorProperty); }
            set { SetValue(ScratchBackColorProperty, value); }
        }

        /// <summary>
        /// Identifies the ScratchTextProperty dependency property
        /// </summary>
        public static readonly DependencyProperty ScratchTextProperty = DependencyProperty.Register("ScratchText", typeof(string),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata("Scratch"));
        /// <summary>
        /// Gets or sets the header text for the scratch gantt.
        /// </summary>
        public string ScratchText
        {
            get { return (string)GetValue(ScratchTextProperty); }
            set { SetValue(ScratchTextProperty, value); }
        }

        /// <summary>
        /// Identifies the MiscBackColorProperty dependency property
        /// </summary>
        public static readonly DependencyProperty MiscBackColorProperty = DependencyProperty.Register("MiscBackColor", typeof(Color),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(Colors.Black));
        /// <summary>
        /// Gets or sets the color to be used as background for miscellaneous gantt row.
        /// Applies alpha channel transparency before rendering as background color
        /// </summary>
        public Color MiscBackColor
        {
            get { return (Color)GetValue(MiscBackColorProperty); }
            set { SetValue(MiscBackColorProperty, value); }
        }

        /// <summary>
        /// Identifies the MiscTextProperty dependency property
        /// </summary>
        public static readonly DependencyProperty MiscTextProperty = DependencyProperty.Register("MiscText", typeof(string),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata("Misc"));
        /// <summary>
        /// Gets or sets the header text for the miscellaneous gantt.
        /// </summary>
        public string MiscText
        {
            get { return (string)GetValue(MiscTextProperty); }
            set { SetValue(MiscTextProperty, value); }
        }

        /// <summary>
        /// Identifies the GuidelineKeyProperty dependency property
        /// </summary>
        public static readonly DependencyProperty GuidelineKeyProperty = DependencyProperty.Register("GuidelineKey", typeof(Key),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(Key.L));
        /// <summary>
        /// Gets or sets the Key to be bound show vertical timeline command.
        /// Clicking on the key while mouse is over a gantt will display the vertical timeline across all 3 gantts.
        /// Default key bound to task is 'L'
        /// </summary>
        public Key GuidelineKey
        {
            get { return (Key)GetValue(GuidelineKeyProperty); }
            set { SetValue(GuidelineKeyProperty, value); }
        }

        /// <summary>
        /// Identifies the SelectedTasksProperty dependency property
        /// </summary>
        public static readonly DependencyProperty SelectedTasksProperty = DependencyProperty.Register("SelectedTasks", typeof(IList<ITaskData>),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(new List<ITaskData>(), SelectedTasksPropertyChanged));
        /// <summary>
        /// Gets or sets the Selected Tasks in the gantt
        /// </summary>
        public IList<ITaskData> SelectedTasks
        {
            get { return (IList<ITaskData>)GetValue(SelectedTasksProperty); }
            set { SetValue(SelectedTasksProperty, value); }
        }
        private static void SelectedTasksPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // ensure that all tasks in list are selected
            if (e.NewValue != e.OldValue && e.NewValue != null)
            {

                IList<ITaskData> list = e.NewValue as IList<ITaskData>;
                if (list != null)
                {
                    foreach (ITaskData task in list)
                    {
                        task.IsSelected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Identifies the TaskPopupDataTemplateProperty dependency property
        /// </summary>
        public static readonly DependencyProperty TaskPopupDataTemplateProperty = DependencyProperty.Register("TaskPopupDataTemplate", 
            typeof(DataTemplate), typeof(ResourcesGantt), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets the DataTemplate used to visually render the task popup.
        /// This template will be bound to data provided in the TaskData.Payload property
        /// </summary>
        public DataTemplate TaskPopupDataTemplate
        {
            get { return (DataTemplate)GetValue(TaskPopupDataTemplateProperty); }
            set { SetValue(TaskPopupDataTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the ResourceBoundKeyProperty dependency property
        /// </summary>
        public static readonly DependencyProperty ResourceBoundKeyProperty = DependencyProperty.Register("ResourceBoundKey", typeof(Key),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(Key.B));
        /// <summary>
        /// Gets or sets the Key to be bound to the resource in the gantt.
        /// Clicking on the key while mouse is over a resource will display resource popup populated with ResourcePopupDataTemplate.
        /// Default key bound to task is 'B'
        /// </summary>
        public Key ResourceBoundKey
        {
            get { return (Key)GetValue(ResourceBoundKeyProperty); }
            set { SetValue(ResourceBoundKeyProperty, value); }
        }

        /// <summary>
        /// Identifies the ResourcePopupDataTemplateProperty dependency property
        /// </summary>
        public static readonly DependencyProperty ResourcePopupDataTemplateProperty = 
            DependencyProperty.Register("ResourcePopupDataTemplateProperty",
            typeof(DataTemplate), typeof(ResourcesGantt), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Gets or sets the DataTemplate used to visually render the resource popup.
        /// This template will be bound to data provided in the ResourceData.Payload property
        /// </summary>
        public DataTemplate ResourcePopupDataTemplate
        {
            get { return (DataTemplate)GetValue(ResourcePopupDataTemplateProperty); }
            set { SetValue(ResourcePopupDataTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the ResourcePopupDelayProperty dependency property
        /// </summary>
        public static readonly DependencyProperty ResourcePopupDelayProperty = DependencyProperty.Register("ResourcePopupDelay", typeof(int),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(0, ResourcePopupDelayPropertyChanged),
            new ValidateValueCallback(ValidatePopupDelayProperty));
        /// <summary>
        /// Gets or sets the time period (seconds) after which resource popup will automatically display on mouse hover on 
        /// a resource.
        /// Time period of 0 indicates popup never displays automatically.
        /// Default time period is zero and popup does not display automatically.
        /// </summary>
        public int ResourcePopupDelay
        {
            get { return (int)GetValue(ResourcePopupDelayProperty); }
            set { SetValue(ResourcePopupDelayProperty, value); }
        }

        // popup delay should be positive
        private static bool ValidatePopupDelayProperty(object value)
        {
            if (value is int)
            {
                int intValue = (int)value;
                if (intValue >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        // when resource popup delay property changes, set/unset the resource popup timer
        private static void ResourcePopupDelayPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            int oldValue = (int)e.OldValue;
            int newValue = (int)e.NewValue;
            ResourcesGantt control = sender as ResourcesGantt;
            if (control != null && oldValue != newValue)
            {
                // cleanup old timer
                if (control.resourcePopupTimer != null)
                {
                    control.resourcePopupTimer.Stop();
                    if (control.resourcePopupTimerEventHandler != null)
                    {
                        control.resourcePopupTimer.Tick -= control.resourcePopupTimerEventHandler;
                    }
                }

                // special handling for zero
                if (newValue == 0)
                {
                    // timer to be set to null
                    control.resourcePopupTimer = null;
                }
                else // create new instance of timer with new interval
                {
                    control.resourcePopupTimer = new DispatcherTimer(DispatcherPriority.Normal);
                    control.resourcePopupTimer.Interval = TimeSpan.FromSeconds(newValue); 
                }
            }
        }

        /// <summary>
        /// Identifies the TaskPopupDelayProperty dependency property
        /// </summary>
        public static readonly DependencyProperty TaskPopupDelayProperty = DependencyProperty.Register("TaskPopupDelay", typeof(int),
            typeof(ResourcesGantt), new FrameworkPropertyMetadata(0, TaskPopupDelayPropertyChanged),
            new ValidateValueCallback(ValidatePopupDelayProperty));
        /// <summary>
        /// Gets or sets the time period (seconds) after which task popup will automatically display on mouse hover on 
        /// a task.
        /// Time period of 0 indicates popup never displays automatically.
        /// Default time period is zero and popup does not display automatically.
        /// </summary>
        public int TaskPopupDelay
        {
            get { return (int)GetValue(TaskPopupDelayProperty); }
            set { SetValue(TaskPopupDelayProperty, value); }
        }

        // when resource popup delay property changes, set/unset the resource popup timer
        private static void TaskPopupDelayPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            int oldValue = (int)e.OldValue;
            int newValue = (int)e.NewValue;
            ResourcesGantt control = sender as ResourcesGantt;
            if (control != null && oldValue != newValue)
            {
                // cleanup old timer
                if (control.taskPopupTimer != null)
                {
                    control.taskPopupTimer.Stop();
                    if (control.taskPopupTimerEventHandler != null)
                    {
                        control.taskPopupTimer.Tick -= control.taskPopupTimerEventHandler;
                    }
                }

                // special handling for zero
                if (newValue == 0)
                {
                    // timer to be set to null
                    control.taskPopupTimer = null;
                }
                else // create new instance of timer with new interval
                {
                    control.taskPopupTimer = new DispatcherTimer(DispatcherPriority.Normal);
                    control.taskPopupTimer.Interval = TimeSpan.FromSeconds(newValue);
                }
            }
        }
        
        #endregion

        #region Private Event Handlers

        // handle double click event on the horizontal grid splitters
        private void GridSplitter_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender == this.splitter1)
            {
                this.scratchGanttRow.Height = new GridLength(0, GridUnitType.Star);
            }
            else if (sender == this.splitter2)
            {
                this.miscGanttRow.Height = new GridLength(0, GridUnitType.Star);
            }
        }

        // when the GanttRow height changes, ensure that enclosing canvas and associated gantt row panels follow suit
        private void GanttRow_OnGanttRowMinHeightChange(object sender, PlexityHide.GTP.OnGanttRowMinHeightChangeArgs e)
        {
            (e.GanttRow.Parent as Canvas).MinHeight = e.NewHeight;
        }

        // when zoom button is clicked
        private void zoomButton_Click(object sender, RoutedEventArgs e)
        {
            zoomPopup.IsOpen = true;
            zoomSlider.Value = ConvertDateToValue(dateScaler1.StartTime, dateScaler1.StopTime);
        }

        // when the zoom slider value is changed
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double newHours = ConvertValueToPeriod(zoomSlider.Value, zoomSlider.Maximum);
            double currentHours = (dateScaler1.StopTime - dateScaler1.StartTime).TotalHours;
            DateTime dtMiddle = dateScaler1.StartTime.AddHours(currentHours / 2);

            dateScaler1.StopTime = dtMiddle.AddHours(newHours/2);
            if (dateScaler1.StopTime > UpperBound)
            {
                dateScaler1.StopTime = UpperBound;
            }
            dateScaler1.StartTime = dtMiddle.AddHours(newHours/2 * -1);
            if (dateScaler1.StartTime < LowerBound)
            {
                dateScaler1.StartTime = LowerBound;
            }
        }

        // when the gantt is drawing the background canvas
        // draw vertical gridlines
        private void Gantt_OnDrawBackground(object sender, PlexityHide.GTP.GanttUserDrawArgs e)
        {
            e.Canvas.Children.Clear();
            PlexityHide.GTP.Gantt gantt = sender as PlexityHide.GTP.Gantt;
            if (VerticalGridGap != 0 && gantt != null)
            {
                // get date rounded to next hour
                DateTime aDate = GetHourDate(gantt.DateScaler.StartTime);
                while (aDate < gantt.DateScaler.StopTime)
                {
                    Line line = new Line();
                    e.Canvas.Children.Add(line);
                    line.X1 = gantt.DateScaler.TimeToPixel(aDate);
                    line.X2 = line.X1;
                    line.Y1 = 0;
                    line.Y2 = gantt.ActualHeight;
                    line.Stroke = LayoutRoot.Resources["SolidBorderBrush"] as SolidColorBrush;
                    line.StrokeThickness = 1;

                    // next
                    aDate = aDate.AddHours(VerticalGridGap);
                }
            }
        }

        // when scale is changed on the main gantt date scaler
        private void dateScaler1_OnScaleChangeEvent(object sender, EventArgs e)
        {
            dateScaler2.StartTime = dateScaler1.StartTime;
            dateScaler2.StopTime = dateScaler1.StopTime;
            dateScaler3.StartTime = dateScaler1.StartTime;
            dateScaler3.StopTime = dateScaler1.StopTime;
        }

        // when a key is pressed when focus is on the user control
        private void resourcesGantt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // remove highlight if any
            RemoveHighlightAdorner();

            if (e.Key == GuidelineKey)
            {
                // toggle timeline display
                timeline.IsDisplayed = !timeline.IsDisplayed;
            }
            if (e.Key == TaskBoundKey)
            {
                // show the task popup - if the mouse is over a task lozenge
                Point mouse = Mouse.GetPosition(this);
                // perform hit test
                HitTestResult result = VisualTreeHelper.HitTest(this, mouse);
                // check if result is a Lozenge
                Lozenge lozenge = Helper.FindVisualAncestor<Lozenge>(result.VisualHit);
                if (lozenge != null)
                {
                    OpenTaskPopup(lozenge);
                }
            }
            if (e.Key == ResourceBoundKey)
            {
                // show the resource popup - if the mouse is over a resource header
                Point mouse = Mouse.GetPosition(this);
                // perform hit test
                HitTestResult result = VisualTreeHelper.HitTest(this, mouse);
                // check if result is a ResourceBorder
                Border border = Helper.FindVisualAncestor<Border>(result.VisualHit);
                if (border != null && border.Name.Equals("ResourceBorder"))
                {
                    OpenResourcePopup(border);
                }
            }
        }

        // when the user control is loaded
        private void resourcesGantt_Loaded(object sender, RoutedEventArgs e)
        {
            // do nothing in design mode
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            // add the timeline adorner to the adorner layer
            // offset the timeline to allow mouse click to function
            timeline = GetTimelineAdroner(2);
            // add the rubberband adorners to the adorner layer
            CreateRubberbandAdorner(listBox1);
            CreateRubberbandAdorner(listBox2);
            CreateRubberbandAdorner(listBox3);

            // ensure that the date-scalers are in synch
            // else we may have different Start/Stop for the three scalers
            // depending on the data bound to each gantt
            dateScaler3.StartTime = dateScaler2.StartTime = dateScaler1.StartTime = LowerBound;
            dateScaler3.StopTime = dateScaler2.StopTime = dateScaler1.StopTime = UpperBound;
        }

        // when the task lozenge is selected
        private void Lozenge_Checked(object sender, RoutedEventArgs e)
        {
            Lozenge lozenge = sender as Lozenge;
            if (lozenge != null)
            {
                // check if Shift key is pressed for incremental selection
                // also allow incremental selection if single select is overriden for the control
                if (Keyboard.PrimaryDevice.IsKeyDown(Key.LeftShift) || Keyboard.PrimaryDevice.IsKeyDown(Key.RightShift) ||
                    IsSingleSelectOverride)
                {
                    // incremental selection
                    SelectedTasks.Add(lozenge.DataContext as ITaskData);
                }
                else // single selection
                {
                    // unselect old values
                    // set the flag to avoid recursive call to Unchecked handler
                    // IsSelected is bound to Lozenge.IsChecked
                    checkFlag = true; 
                    foreach (ITaskData task in SelectedTasks)
                    {
                        
                        task.IsSelected = false;
                    }
                    checkFlag = false;
                    SelectedTasks.Clear();
                    SelectedTasks.Add(lozenge.DataContext as ITaskData);
                }
            }
        }

        // when the task lozenge is unselected
        private void Lozenge_Unchecked(object sender, RoutedEventArgs e)
        {
            Lozenge lozenge = sender as Lozenge;
            // perform event handling only if  flag is clear
            if (lozenge != null && !checkFlag)
            {
                // check if Shift key is pressed for incremental de-selection
                if (Keyboard.PrimaryDevice.IsKeyDown(Key.LeftShift) || Keyboard.PrimaryDevice.IsKeyDown(Key.RightShift))
                {
                    // incremental de-selection
                    SelectedTasks.Remove(lozenge.DataContext as ITaskData);
                }
                else // single selection
                {
                    // unselect old values
                    checkFlag = true;
                    foreach (ITaskData task in SelectedTasks)
                    {
                        if (task != lozenge.DataContext as ITaskData)
                        {
                            task.IsSelected = false;
                        }
                    }
                    checkFlag = false;
                    SelectedTasks.Clear();
                }
            }
        }

        // when mouse leaves a lozenge
        private void Lozenge_MouseLeave(object sender, MouseEventArgs e)
        {
            // hide the taskPopup
            taskPopup.IsOpen = false;

            // if popup timer is present, then disable
            if (taskPopupTimer != null)
            {
                taskPopupTimer.Stop();
                taskPopupTimer.Tick -= taskPopupTimerEventHandler;
                taskPopupTimerEventHandler = null;
            }
        }

        // when mouse leaves resource header border
        private void ResourceBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            // hide the resourcePopup
            resourcePopup.IsOpen = false;

            // if popup timer is present, then disable
            if (resourcePopupTimer != null)
            {
                resourcePopupTimer.Stop();
                resourcePopupTimer.Tick -= resourcePopupTimerEventHandler;
                resourcePopupTimerEventHandler = null;
            }
        }

        // when a lozenge is loaded
        private void Lozenge_Loaded(object sender, RoutedEventArgs e)
        {
            Lozenge lozenge = sender as Lozenge;
            if (lozenge != null)
            {
                // hack to remove extra margin from the ContentPresenter parent of the lozenge
                ContentPresenter presenter = Helper.FindVisualAncestor<ContentPresenter>(lozenge);
                if (presenter != null)
                {
                    presenter.Margin = new Thickness(0);
                }
            }
        }

        // when mouse enters resource header border
        private void ResourceBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            // if the timer is present, setup timer to show popup
            Border border = sender as Border;
            if (border != null && resourcePopupTimer != null)
            {
                resourcePopupTimerEventHandler = (s, args) =>
                    {
                        OpenResourcePopup(border);
                    };
                resourcePopupTimer.Tick += resourcePopupTimerEventHandler;
                resourcePopupTimer.Start();
            }
        }

        private void Lozenge_MouseEnter(object sender, MouseEventArgs e)
        {
            // if the timer is present, setup timer to show popup
            Lozenge lozenge = sender as Lozenge;
            if (lozenge != null && taskPopupTimer != null)
            {
                taskPopupTimerEventHandler = (s, args) =>
                {
                    OpenTaskPopup(lozenge);
                };
                taskPopupTimer.Tick += taskPopupTimerEventHandler;
                taskPopupTimer.Start();
            }
        }

        private void resourcesGantt_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // remove any existing highlight for locate
            RemoveHighlightAdorner();
        }

        private void resourcesGantt_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // remove any existing highlight for locate
            RemoveHighlightAdorner();
        }

        #endregion

        #region Helper methods

        // open the resource popup on the specified target
        // and prevents MouseLeave event from being raised
        // due to popup opening
        private void OpenResourcePopup(UIElement target)
        {
            resourcePopup.PlacementTarget = target;
            // to prevent the popup display to cause mouseleave event
            // we capture the mouse before display (and release after)
            target.CaptureMouse();
            resourcePopup.IsOpen = true;
            target.ReleaseMouseCapture();
        }

        // open the task popup on the specified target
        // and prevents MouseLeave event from being raised
        // due to popup opening
        private void OpenTaskPopup(UIElement target)
        {
            taskPopup.PlacementTarget = target;
            // to prevent the popup display to cause mouseleave event
            // we capture the mouse before display (and release after)
            target.CaptureMouse();
            taskPopup.IsOpen = true;
            target.ReleaseMouseCapture();
        }

        // convert from the gantt date range to a value to display on zoom slider
        private double ConvertDateToValue(DateTime start, DateTime stop)
        {
            // the maximum allowed hours period (min zoom value)
            double maxHours = (UpperBound - LowerBound).TotalHours;
            // the minimum allowed hours period (max zoom value)
            double minHours = 1.0;
            // the current hours period
            double currentHours = (stop - start).TotalHours;

            return (((maxHours - currentHours) * 10) / (maxHours - minHours));
            
        }

        // convert from zoom slider value to an hour period between gantt start and stop
        private double ConvertValueToPeriod(double value, double maxValue)
        {
            // the maximum allowed hours period (min zoom value)
            double maxHours = (UpperBound - LowerBound).TotalHours;
            // the minimum allowed hours period (max zoom value)
            double minHours = 1.0;

            return (maxHours - ((maxHours - minHours) / maxValue) * value);
        }

        // create a timeline adorner bound to the 3 list boxes gantt task area
        private TimelineAdorner GetTimelineAdroner(double offset)
        {
            // add the timeline adorner to the adorner layer
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
            // get the timeline bounding constraints
            Point topLeft = listBox1.TranslatePoint(new Point(RESOURCE_HEADER_WIDTH.Value, 0), this);
            // offset the timeline as per requested amount
            TimelineAdorner adorner = new TimelineAdorner(this, topLeft, listBox3, SCROLL_WIDTH.Value, offset);
            adornerLayer.Add(adorner);

            return adorner;
        }

        // create a rubberband adorner
        private RubberBandAdorner CreateRubberbandAdorner(ListBox listBox)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(listBox);
            RubberBandAdorner band = new RubberBandAdorner(listBox);
            adornerLayer.Add(band);

            return band;
        }

        // refresh the desired height of gantt row.
        // the height of the gantt row is not recalculated by Plexity when we remove the task which is
        // in collision with another task. This method forces the Plexity gantt to refresh the gantt row
        // height
        private void RefreshGanttRowHeight(GanttRow row)
        {
            // changing the Start results in refresh of the gantt row
            // as a hack we change the start and set it back to ensure refresh
            // TODO: better way of doing this?
            if (sourceRow.InternalIndexOfContent.Count > 0)
            {
                DateTime aDate = sourceRow.InternalIndexOfContent[0].TimeItem.Start;
                sourceRow.InternalIndexOfContent[0].TimeItem.Start = aDate.AddSeconds(-1);
                sourceRow.InternalIndexOfContent[0].TimeItem.Start = aDate.AddSeconds(1);
            }
        }

        // return the DateTime rounded for the hour interval
        private DateTime GetHourDate(DateTime date)
        {
            int hour = date.Hour;
            int min = date.Minute;
            int day = date.Day;
            if (min > 0)
            {
                // goto next hour
                hour++;

                if (hour > 23)
                {
                    hour = 0;
                    day++;
                }
            }
            // return date with rounded hour
            return new DateTime(date.Year, date.Month, day, hour, 0, 0);
        }

        #endregion

        #region Drag Drop and Resize Handling

        // the gantt row where drag initiated
        private GanttRow sourceRow;
        // the drag start point
        Point startPoint;
        // the gantt row item which is being dragged
        GanttRowItem ganttItem;
        // width of the lozenge being dragged
        double width;
        // height of the lozenge being dragged 
        double height;
        // location of the lozenge
        Point location;
        // is this a resize
        bool isResize;
        // resize at right
        bool isResizeRight;
        // data being dragged
        object draggedData;
        // the resize timeline adorner
        TimelineAdorner resizeTimeline;
        // the offset from the mouse X for the resize
        double resizeDelta;
        // saved state of the timeline adorner
        bool isTimelineVisible;
        // flag indicating dragging in progress - to prevent recursive drag-drop initiations
        bool isDragging;
        // the adorner used to display lozenge during drag and drop
        private DragAdorner dragAdorner;
        
        // when mouse left button down on gantt row (task list box)
        private void GanttRow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // get the ItemContainer where mouse clicked
            Visual visual = e.OriginalSource as Visual;
            sourceRow = sender as GanttRow;
            ganttItem = sourceRow.ContainerFromElement(visual) as GanttRowItem;
            startPoint = e.GetPosition(sourceRow);
            // click over GanttRowItem?
            if (ganttItem != null)
            {
                // get the actual size of source from the TimeItem framework element
                width = ganttItem.TimeItem.TimeItemSizedFrameworkElement.ActualWidth;  
                height = ganttItem.TimeItem.TimeItemSizedFrameworkElement.ActualHeight; 
                // determine location of source by translating the GanttRowItem origin to GanttRow coordinates
                location = ganttItem.TranslatePoint(new Point(0, 0), sourceRow);

                // check if this is a resize
                if (ganttItem.TimeItem.Cursor == Cursors.SizeWE)
                {
                    isResize = true;
                    double middle = location.X + width / 2;
                    if (startPoint.X >= middle)
                    {
                        // resizing right
                        isResizeRight = true;
                        resizeDelta = startPoint.X - (location.X + width);
                    }
                    else
                    {
                        // resizing left
                        isResizeRight = false;
                        resizeDelta = startPoint.X - location.X;
                    }
                    // save the state of the timeline and hide if visible
                    isTimelineVisible = timeline.IsDisplayed;
                    if (isTimelineVisible)
                    {
                        timeline.IsDisplayed = false;
                    }
                    // create resize timeline adorner
                    resizeTimeline = GetTimelineAdroner(resizeDelta * -1);
                    resizeTimeline.IsDisplayed = true;
                    e.Handled = true;
                    // capture the mouse to keep mouse events on the gantt row only
                    // until the mouse button is Up
                    sourceRow.CaptureMouse();
                }
                // this is a drag drop
                else
                {
                    draggedData = ganttItem.DataContext;
                }
            }
        }

        // when mouse moved on gantt row (task list box)
        private void GanttRow_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition((GanttRow)sender);
            Vector diff = startPoint - mousePos;
            // has dragged data been saved by mouse click handler?
            // if yes, then we are to initiate dragging
            if (draggedData != null)
            {
                // initiate dragging if mouse held down and movement is beyond the tolerance
                if (e.LeftButton == MouseButtonState.Pressed && !isDragging &&
                    (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    isDragging = true;
                    // hide the source task
                    ganttItem.Visibility = Visibility.Hidden;
                    // store the dragged data for DragDrop
                    DataObject dragData = new DataObject("item", draggedData);
                    // initiate drag drop
                    DragDropEffects effects = DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                    // check the return from drag drop
                    if ((effects & DragDropEffects.Move) == 0)
                    {
                        // operation was cancelled
                        // restore gantt item visibility
                        ganttItem.Visibility = Visibility.Visible;
                    }
                    // reset state
                    isDragging = false;
                    draggedData = null;
                }
            }
            // are we resizing - if resize flag is set and mouse held down and movement is beyond tolerance
            else if (isResize && e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > 2))
            {
                DateTime aDate = dateScaler1.PixelToTime(mousePos.X - resizeDelta);
                // is resize to right
                if (isResizeRight)
                {
                    // check the current width of the timeItem - do not allow beyond minimum
                    if (Math.Abs((ganttItem.TimeItem.Start - aDate).TotalMinutes) < 10)
                    {
                        return;
                    }
                    // change the task width
                    ganttItem.TimeItem.Stop = aDate;
                }
                // is resize to left
                else
                {
                    // check the current width of the timeItem - do not allow beyond minimum
                    if (Math.Abs((aDate - ganttItem.TimeItem.Stop).TotalMinutes) < 10)
                    {
                        return;
                    }
                    // change the task width
                    ganttItem.TimeItem.Start = aDate;
                }
            }
        }

        // when mouse left button up on gantt row (task list box)
        private void GanttRow_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // is resize in progress - if yes, then operation complete
            if (isResize)
            {
                // reset state
                isResize = false;
                // remove resize timeline
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                adornerLayer.Remove(resizeTimeline);
                resizeTimeline = null;
                // restore the state of the generic timeline
                timeline.IsDisplayed = isTimelineVisible;
                // release mouse captured
                sourceRow.ReleaseMouseCapture();
            }
            // clear any dragged data
            draggedData = null;
        }

        // when drag drop initiated and drag enters a gantt row
        private void GanttRow_DragEnter(object sender, DragEventArgs e)
        {
            if (dragAdorner == null)
            {
                GanttRow row = sender as GanttRow;
                // get the dragged data
                TimeItem item = e.Data.GetData("item") as TimeItem;
                var adornerLayer = AdornerLayer.GetAdornerLayer(row);
                var template = LayoutRoot.Resources["DragTask"] as DataTemplate;
                dragAdorner = new DragAdorner(draggedData, template, row, adornerLayer, width, height, location, AllowedLines);

            }
            e.Handled = true;
        }

        // when drag drop initiated and drag leaves a gantt row
        private void GanttRow_DragLeave(object sender, DragEventArgs e)
        {
            // remove the drag adorner
            DetachDragAdorner();
            e.Handled = true;
        }

        // when drag drop initiated and drag continues over a gantt row
        private void GanttRow_DragOver(object sender, DragEventArgs e)
        {
            // no need to update position on gantt row
            // as dragged task appears in fixed position within the row

            // check if we need to auto scroll
            GanttRow row = sender as GanttRow;
            if (row != null)
            {
                // find the gantt listbox
                ListBox listBox = Helper.FindVisualAncestor<ListBox>(row.OwningContentControl);
                ScrollViewer sv = Helper.FindVisualChild<ScrollViewer>(listBox);
                double tolerance = 10;
                double offset = 3;
                double verticalPos = e.GetPosition(listBox).Y;
                if (sv != null)
                {
                    if (verticalPos < tolerance) // Top of visible list?
                    {
                        sv.ScrollToVerticalOffset(sv.VerticalOffset - offset); //Scroll up.
                    }
                    else if (verticalPos > listBox.ActualHeight - tolerance) //Bottom of visible list?
                    {
                        sv.ScrollToVerticalOffset(sv.VerticalOffset + offset); //Scroll down.    
                    }
                }
            }
            e.Handled = true;
        }

        // when drag drop initiated and drop occurs over a gantt row
        private void GanttRow_Drop(object sender, DragEventArgs e)
        {
            TimeItem item = e.Data.GetData("item") as TimeItem;
            GanttRow row = sender as GanttRow;
            
            // if drop is not on the source row
            if (row != sourceRow)
            {
                // remove the dragged data from the source ResourceData to target
                ((IResourceData)row.DataContext).Items.Add((ITaskData)draggedData);
                ((IResourceData)sourceRow.DataContext).Items.Remove((ITaskData)draggedData);
            }
            else
            {
                // drop on source row only - do nothing
                // restore gantt item visibility
                ganttItem.Visibility = Visibility.Visible;
            }
            DetachDragAdorner();
            e.Handled = true;
            // check source gantt row height is updated
            RefreshGanttRowHeight(sourceRow);
        }

        // helper
        private void DetachDragAdorner()
        {
            if (dragAdorner != null)
            {
                dragAdorner.Destroy();
                dragAdorner = null;
            }
        }

        #endregion

        #region Locate Task Public Methods

        // the one and only adorner used to highlight located tasks
        private HighlightAdorner highlightAdorner = null;

        /// <summary>
        /// Locate a specific task on the Main Gantt.
        /// </summary>
        /// <param name="resourceData">The resource data where this task resides</param>
        /// <param name="taskData">The task data which is to be located</param>
        /// <returns>true if locate succeeded</returns>
        public bool LocateMain(IResourceData resourceData, ITaskData taskData)
        {
            // remove any existing highlight for locate
            RemoveHighlightAdorner();

            // scroll the resource data into view in the main gantt list box
            listBox1.ScrollIntoView(resourceData);

            // sanity checks
            if (taskData == null)
            {
                return false;
            }
            if (taskData.Start < dateScaler1.LowerBound || taskData.Start > dateScaler1.UpperBound)
            {
                return false;
            }
            else if (taskData.Stop > dateScaler1.UpperBound)
            {
                return false;
            }

            // change the start and end time on the datescaler to center the task
            // centered task will occupy x percentage of horizontal space
            // x is set here to 30%
            double x = 0.3;
            double y = (1.0-x)/2;
            double width = ((taskData.Stop - taskData.Start).TotalSeconds)/x;

            dateScaler1.StartTime = taskData.Start.AddSeconds(y * width * -1.0);
            dateScaler1.StopTime = taskData.Stop.AddSeconds(y * width);

            // create a highlight effect on the located lozenge.
            // fails safe - if unable to get lozenge, then will not display highlight.
            // Need to do this via Dispatcher with low priority
            // so that Items visual tree is generated and ready for our search routine below.
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.ContextIdle, 
                        new Action(() =>
                        {
                            // locate the visual container for the located item
                            Lozenge uiItem = GetLozenge(resourceData, taskData);
                            // if found, then highlight - fail-safe
                            if (uiItem != null)
                            {
                                // choose top most adorner layer for highlight
                                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                                highlightAdorner = new HighlightAdorner(uiItem, adornerLayer);
                                adornerLayer.Add(highlightAdorner);
                            }
                        }));
            

            return true;
        }

        // helper method to get the visual for the passed ITaskData item
        // returns null if unable to locate
        // depends on the XAML style hierarchy *****
        private Lozenge GetLozenge(IResourceData resourceData, ITaskData taskData)
        {
            // get the listBox1 ListBoxItem
            DependencyObject dObj = listBox1.ItemContainerGenerator.ContainerFromItem(resourceData);
            if (dObj != null)
            {
                // obtain the GanttRow visual child of the ListBoxItem
                //dObj.ApplyTemplate();
                GanttRow row = Helper.FindVisualChild<GanttRow>(dObj);
                if (row != null)
                {
                    // obtain the container for the ITaskData from the GanttRow
                    // this will be a GanttRowItem
                    dObj = row.ItemContainerGenerator.ContainerFromItem(taskData);
                    if (dObj != null)
                    {
                        // get Lozenge which is the visual child of the GanttRowItem
                        return Helper.FindVisualChild<Lozenge>(dObj);
                    }
                }
            }

            return null;
        }

        private void RemoveHighlightAdorner()
        {
            if (highlightAdorner != null)
            {
                highlightAdorner.Remove();
                highlightAdorner = null;
            }
        }

        /// <summary>
        /// Locate a specific task on the Scratch Gantt.
        /// </summary>
        /// <param name="taskData">The task data which is to be located</param>
        /// <returns>true if locate succeeded</returns>
        public bool LocateScratch(ITaskData taskData)
        {
            // TODO
            return false;
        }

        /// <summary>
        /// Locate a specific task on the Misc Gantt.
        /// </summary>
        /// <param name="taskData">The task data which is to be located</param>
        /// <returns>true if locate succeeded</returns>
        public bool LocateMisc(ITaskData taskData)
        {
            // TODO
            return false;
        }

        #endregion

    }
}
