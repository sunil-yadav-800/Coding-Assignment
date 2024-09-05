using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public class ValueTypeComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(object obj1, object obj2)
        {
            return obj1.Equals(obj2);
        }
    }
}
