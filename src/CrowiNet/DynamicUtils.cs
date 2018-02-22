using System.Collections.Generic;

namespace CrowiNet
{
    internal static class DynamicUtils
    {
        internal static string[] ToStringArray(dynamic json)
        {
            var list = new List<string>();
            foreach (var item in json)
            {
                list.Add((string)item);
            }
            return list.ToArray();
        }
    }
}