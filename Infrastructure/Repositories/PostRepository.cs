﻿

using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post (1,"Treść 1","Treść 1"),
            new Post (2,"Treść 2","Treść 2"),
            new Post (3,"Treść 3","Treść 3"),
        };
        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(x => x.Id == id);
        }

        public Post Add(Post post)
        {
            post.Id = _posts.Count() + 1;
            post.Created = DateTime.Now;
            _posts.Add(post);
            return post;
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.Now;
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }

    }
}
