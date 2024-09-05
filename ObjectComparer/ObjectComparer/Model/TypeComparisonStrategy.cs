using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public class TypeComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(object obj1, object obj2)
        {
            if (obj1.GetType() != obj2.GetType()) return false;

            return true;
        }
    }
}
