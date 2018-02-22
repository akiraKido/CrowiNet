using System;

namespace CrowiNet.Models
{
    public class Author
    {
        private Author() { }

        public static Author FromJson(dynamic json)
        {
            var result = new Author
            {
                _Id = json["_id"],
                Email = json["email"],
                UserName = json["username"],
                Name = json["name"],
                Image = json["image"],
                Admin = json["admin"],
                CreatedAt = DateTime.Parse( (string)json["createdAt"] ),
                Status = json["status"],
                Language = json["lang"]
            };
            return result;
        }

        public string _Id { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
        public bool Admin { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int Status { get; private set; }
        public string Language { get; private set; }
    }
}