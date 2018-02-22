using System.Collections.Generic;

namespace CrowiNet.Models
{
    public class PageList
    {
        private PageList() { }

        public static PageList FromJson(dynamic json)
        {
            var pages = new List<PageInfo>();
            foreach (var item in json["pages"])
            {
                pages.Add(PageInfo.FromJson(item));
            }

            var result = new PageList
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