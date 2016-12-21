using System.ComponentModel;
using System;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ResourcesClient.Controls.Data
{
    /// <summary>
    /// Defines the interface an object needs to implement to be shown
    /// as a task lozenge in the ResourcesGantt gantts.
    /// This is the ViewModel requirements for the Gantt control.
    /// </summary>
    public interface ITaskData : INotifyPropertyChanged
    {
        /// <summary>
        /// The task unique identifier
        /// </summary>
        object Id { get; }
        /// <summary>
        /// The task start date time
        /// </summary>
        DateTime Start { get; set; }
        /// <summary>
        /// The task stop date time
        /// </summary>
        DateTime Stop { get; set; }
        /// <summary>
        /// The task text color
        /// </summary>
        Brush TextColor { get; set; }
        /// <summary>
        /// The task background color
        /// </summary>
        Brush BackColor { get; set; }
        /// <summary>
        /// The task border brush
        /// </summary>
        Brush BorderBrush { get; set; }
        /// <summary>
        /// The task border thickness
        /// </summary>
        double BorderThickness { get; set; }
        /// <summary>
        /// The task highlight color
        /// </summary>
        Brush HighlightColor { get; set; }
        /// <summary>
        /// The task lozenge left end shape
        /// </summary>
        LozengeEnd LeftShape { get; set; }
        /// <summary>
        /// The task lozenge right end shape
        /// </summary>
        LozengeEnd RightShape { get; set; }
        /// <summary>
        /// The task left text row 1
        /// </summary>
        string TextR1C1 { get; set; }
        /// <summary>
        /// The task middle text row 1
        /// </summary>
        string TextR1C2 { get; set; }
        /// <summary>
        /// The task right text row 1
        /// </summary>
        string TextR1C3 { get; set; }
        /// <summary>
        /// The task left text row 2
        /// </summary>
        string TextR2C1 { get; set; }
        /// <summary>
        /// The task middle text row 2
        /// </summary>
        string TextR2C2 { get; set; }
        /// <summary>
        /// The task right text row 2
        /// </summary>
        string TextR2C3 { get; set; }
        /// <summary>
        /// The task left text row 3
        /// </summary>
        string TextR3C1 { get; set; }
        /// <summary>
        /// The task middle text row 3
        /// </summary>
        string TextR3C2 { get; set; }
        /// <summary>
        /// The task right text row 3
        /// </summary>
        string TextR3C3 { get; set; }
        /// <summary>
        /// The task left top text 1
        /// </summary>
        string TextLT1 { get; set; }
        /// <summary>
        /// The task left top text 2
        /// </summary>
        string TextLT2 { get; set; }
        /// <summary>
        /// The task right top text 1
        /// </summary>
        string TextRT1 { get; set; }
        /// <summary>
        /// The task right top text 2
        /// </summary>
        string TextRT2 { get; set; }
        /// <summary>
        /// The task left bottom icon 1
        /// </summary>
        Uri IconSourceL1 { get; set; }
        /// <summary>
        /// The task left bottom icon 2
        /// </summary>
        Uri IconSourceL2 { get; set; }
        /// <summary>
        /// The task left bottom icon 3
        /// </summary>
        Uri IconSourceL3 { get; set; }
        /// <summary>
        /// The task right bottom icon 1
        /// </summary>
        Uri IconSourceR1 { get; set; }
        /// <summary>
        /// The task right bottom icon 2
        /// </summary>
        Uri IconSourceR2 { get; set; }
        /// <summary>
        /// The task right bottom icon 3
        /// </summary>
        Uri IconSourceR3 { get; set; }
        /// <summary>
        /// Is this task selected by user
        /// </summary>
        bool IsSelected { get; set; }
        /// <summary>
        /// Payload for this task. Actual domain object for this task.
        /// </summary>
        object Payload { get; }
        /// <summary>
        /// Context menu item content for this task
        /// </summary>
        ObservableCollection<IContextMenuItemData> ContextMenuItems { get; set; }
    }
}
