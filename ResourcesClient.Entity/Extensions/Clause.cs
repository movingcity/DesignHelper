using System.Collections.ObjectModel;

///<p>Criteria related entities</p>
namespace com.unisys.rms.domain.criteria
{
    ///<p>A clause that applies a boolean operator to a set of criteria entities</p>
    public partial class Clause : Expression
    {
        public ObservableCollection<Expression> Expressions
        {
            get
            {
                return expressions;
            }
            set
            {
                SetField(ref expressions, value, () => Expressions);
            }
        }
    }
}



