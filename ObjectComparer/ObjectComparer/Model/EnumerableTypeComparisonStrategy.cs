using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public class EnumerableTypeComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(object obj1, object obj2)
        {

            IEnumerable enum1 = (IEnumerable)obj1;
            IEnumerable enum2 = (IEnumerable)obj2;

            Dictionary<object, int> dict1 = new Dictionary<object, int>();
            Dictionary<object, int> dict2 = new Dictionary<object, int>();
            foreach (object item in enum1)
            {
                if (dict1.ContainsKey(item))
                {
                    dict1[item]++;
                }
                else
                {
                    dict1.Add(item, 1);
                }
            }
            foreach (object item in enum2)
            {
                if (dict2.ContainsKey(item))
                {
                    dict2[item]++;
                }
                else
                {
                    dict2.Add(item, 1);
                }
            }

            if (dict1.Count != dict2.Count)
                return false;

            foreach (var key in dict1.Keys)
            {
                if (!dict2.ContainsKey(key) || dict1[key] != dict2[key])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
