using System.Collections.ObjectModel;

///<p>Task generation entities</p>
namespace com.unisys.rms.domain.task.generate
{
    ///<p>A list of items used to generate tasks. </p><p>Absolute time list items will specify absolute time for the task to be generated. Flight time list items will specify time relative to flight operation time.<br></br>Absolute list - Time will be specified in minutes from 0000 hours for the day in question.<br></br>Flight relative list - Time will be specified in minutes relative to flight operation time.</p>
    public partial class GenerateTaskList : RMSEntity
    {
        public ObservableCollection<GenerateTaskItem> Items
        {
            get
            {
                return items;
            }
            set
            {
                SetField(ref items, value, () => Items);
            }
        }
    }
}



