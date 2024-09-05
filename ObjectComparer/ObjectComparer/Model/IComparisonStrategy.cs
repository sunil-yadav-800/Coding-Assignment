using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public interface IComparisonStrategy
    {
        public bool Compare(object obj1, object obj2);
    }
}
