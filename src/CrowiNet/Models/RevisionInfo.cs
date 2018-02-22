using System;

namespace CrowiNet.Models
{
    public class RevisionInfo
    {
        private RevisionInfo() { }

        public static RevisionInfo FromJson(dynamic json)
        {
            var result = new RevisionInfo
            {
                _Id = json["_id"],
                Author = UserInfo.FromJson(json["author"]),
                Body = json["body"],
                Path = json["path"],
                __V = json["__v"],
                CreatedAt = DateTime.Parse((string)json["createdAt"]),
                Format = json["format"]
            };
            return result;
        }

        public string _Id { get; private set; }
        public UserInfo Author { get; private set; }
        public string Body { get; private set; }
        public string Path { get; private set; }
        public int __V { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Format { get; private set; }
    }
}