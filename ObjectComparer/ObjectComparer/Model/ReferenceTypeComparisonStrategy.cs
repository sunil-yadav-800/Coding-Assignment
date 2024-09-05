using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Model
{
    public class ReferenceTypeComparisonStrategy : IComparisonStrategy
    {
        public bool Compare(object obj1, object obj2)
        {
            Type type = obj1.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                object value1 = property.GetValue(obj1);
                object value2 = property.GetValue(obj2);

                IComparisonStrategy comparitor = ComparisonStrategyFactory.GetComparitorObject(value1, value2);
                var result = comparitor.Compare(value1, value2);
                if(!result)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
