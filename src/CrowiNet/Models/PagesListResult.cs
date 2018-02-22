using System.Collections.Generic;

namespace CrowiNet.Models
{
    public class PagesListResult
    {
        private PagesListResult() { }

        public static PagesListResult FromJson(dynamic json)
        {
            var pages = new List<PageInfo>();
            foreach (var item in json["pages"])
            {
                pages.Add(PageInfo.FromJson(item));
            }

            var result = new PagesListResult
            {
                Ok = (bool)json["ok"],
                Pages = pages.ToArray()
            };
            return result;
        }

        public bool Ok { get; private set; }

        public PageInfo[] Pages { get; private set; }
    }
}