using System;

namespace CrowiNet.Models
{
    public class PageInfo
    {
        private PageInfo() { }

        public static PageInfo FromJson(dynamic json)
        {
            var result = new PageInfo
            {
                _Id = json["_id"],
                RedirectTo = json["redirectTo"],
                UpdatedAt = DateTime.Parse((string)json["updatedAt"]),
                LastUpdateUser = json["lastUpdateUser"],
                Creator = json["creator"],
                Path = json["path"],
                __V = json["__v"],
                Revision = RevisionInfo.FromJson(json["revision"]),
                CreatedAt = DateTime.Parse((string)json["createdAt"]),
                CommentCount = json["commentCount"],
                SeenUsers = DynamicUtils.ToStringArray(json["seenUsers"]),
                Liker = DynamicUtils.ToStringArray(json["liker"]),
                GrantedUsers = DynamicUtils.ToStringArray(json["grantedUsers"]),
                Grant = json["grant"],
                Status = json["status"],
                Id = json["id"],
            };
            return result;
        }

        public string _Id { get; private set; }
        public string RedirectTo { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string LastUpdateUser { get; private set; }
        public string Creator { get; private set; }
        public string Path { get; private set; }
        public int __V { get; private set; }
        public RevisionInfo Revision { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int CommentCount { get; private set; }
        public string[] SeenUsers { get; private set; }
        public string[] Liker { get; private set; }
        public string[] GrantedUsers { get; private set; }
        public int Grant { get; private set; }
        public string Status { get; private set; }
        public string Id { get; private set; }
    }
}