using ObjectComparer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class DeepComparer
    {
        public static bool CompareObject(object obj1, object obj2)
        {
            var result = false;
            try
            {
                var comparitor = ComparisonStrategyFactory.GetComparitorObject(obj1, obj2);
                result = comparitor.Compare(obj1, obj2);
            }
            catch(Exception ex)
            {
                return false;
            }
            return result;
        }
    }
}
