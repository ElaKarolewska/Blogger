using Domain.Common;

namespace Domain.Entities
{
    public class Post: AuditableEnitity
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Post() {}

        public Post(int id, string name, string content)
        {
            Id = id;
            Name = name;
            Content = content;
        }
    }
}
