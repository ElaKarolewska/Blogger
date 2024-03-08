﻿
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GettAll();
        Post GetById(int id);
        Post Add(Post post);
        void Update(Post post);
        void Delete(Post post);

    }
}