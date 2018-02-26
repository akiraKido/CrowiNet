using System.Collections.Generic;
using System.Linq;

namespace CrowiNet.Models
{
    public class PagesListResult
    {
        private PagesListResult() { }

        public static PagesListResult FromJson(dynamic json)
        {
            var result = new PagesListResult
            {
                Ok = (bool)json["ok"],
                Pages = ((IEnumerable<dynamic>)json["pages"])
                            .Select(PageInfo.FromJson)
                            .ToArray()
            };
            return result;
        }

        public bool Ok { get; private set; }

        public PageInfo[] Pages { get; private set; }
    }
}