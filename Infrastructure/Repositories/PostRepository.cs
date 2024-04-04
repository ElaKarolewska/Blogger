﻿

using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BloggerContext _context;
        public PostRepository(BloggerContext context)
        {
            _context = context;
        }
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }

        public Post Add(Post post)
        {
            post.Created = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.Now;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

    }
}
