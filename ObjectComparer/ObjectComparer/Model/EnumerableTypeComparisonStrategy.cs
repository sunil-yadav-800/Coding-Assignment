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

            var list1 = new List<object>();
            var list2 = new List<object>();
            foreach ( var obj in enum1)
            {
                list1.Add(obj);
            }
            foreach ( var obj in enum2)
            { 
                list2.Add(obj); 
            }
            if(list1.Count != list2.Count)
                return false;

            foreach( var listItem1 in list1)
            {
                bool isMatched = false;
                foreach ( var listItem2 in list2)
                {
                   var comparitorStrategy = ComparisonStrategyFactory.GetComparitorObject(listItem1, listItem2);
                    var result = comparitorStrategy.Compare(listItem1, listItem2);
                    if(result)
                    {
                        isMatched = true;
                        list2.Remove(listItem2);
                        break;
                    }  
                }
                if(!isMatched)
                    return false;
            }
            return true;
        }
    }
}
