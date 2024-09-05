using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public class NullValueComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(object obj1, object obj2)
        {
            if(obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;

            return true;
        }
    }
}
