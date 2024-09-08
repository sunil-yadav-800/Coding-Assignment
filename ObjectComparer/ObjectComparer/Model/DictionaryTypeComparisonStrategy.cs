using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public class DictionaryTypeComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(object obj1, object obj2)
        {
            var dict1 = obj1 as IDictionary;
            var dict2 = obj2 as IDictionary;

            if(dict1.Count != dict2.Count)
                return false;

            foreach(object key in dict1.Keys)
            {
                if(!dict2.Contains(key))
                    return false;

                var comparitorStrategy = ComparisonStrategyFactory.GetComparitorObject(dict1[key], dict2[key]);
                var result = comparitorStrategy.Compare(dict1[key], dict2[key]);
                if(!result)
                    return false;
            }

            return true;
        }
    }
}
