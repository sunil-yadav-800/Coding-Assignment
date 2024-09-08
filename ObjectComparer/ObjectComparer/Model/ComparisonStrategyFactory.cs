using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public static class ComparisonStrategyFactory
    {
        public static IComparisonStrategy GetComparitorObject(object obj1, object obj2)
        {
            if(obj1 == null || obj2 == null)
                return new NullValueComparisonStrategy();
            else if(obj1.GetType() != obj2.GetType())
                return new TypeComparisonStrategy();
            else if(obj1.GetType().IsValueType || obj1 is string)
                return new ValueTypeComparisonStrategy();
            else if(obj1 is IEnumerable && obj2 is IEnumerable)
            {
                if(obj1 is IDictionary &&  obj2 is IDictionary)
                {
                    return new DictionaryTypeComparisonStrategy();
                }
                return new EnumerableTypeComparisonStrategy();
            }  
            return new ReferenceTypeComparisonStrategy();
        }
    }
}
