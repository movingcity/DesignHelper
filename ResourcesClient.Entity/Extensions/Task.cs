using System.Collections.ObjectModel;

///<p>Task related entities</p>
namespace com.unisys.rms.domain.task
{
    ///<p>An abstract Task that can be allocated to resources</p>
    public abstract partial class Task : RMSEntity
    {
        public ObservableCollection<Conflict> Conflicts
        {
            get
            {
                return conflicts;
            }
            set
            {
                SetField(ref conflicts, value, () => Conflicts);
            }
        }

        public ObservableCollection<Preference> Preferences
        {
            get
            {
                return preferences;
            }
            set
            {
                SetField(ref preferences, value, () => Preferences);
            }
        }

    }
}



