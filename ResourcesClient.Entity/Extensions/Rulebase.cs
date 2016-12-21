using System.Collections.ObjectModel;
using com.unisys.rms.domain.criteria.group;

///<p>Criteria related entities</p>
namespace com.unisys.rms.domain.criteria
{
    ///<p>A grouping of the Rules. Only one Rulebase can be active at a time</p>
    public partial class Rulebase : RMSEntity
    {
        public ObservableCollection<Rule> Rules
        {
            get
            {
                return rules;
            }
            set
            {
                SetField(ref rules, value, () => Rules);
            }
        }

        public ObservableCollection<RuleGroup> Groups
        {
            get
            {
                return groups;
            }
            set
            {
                SetField(ref groups, value, () => Groups);
            }
        }
    }
}



