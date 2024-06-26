﻿
using Application.Dto.Cosmos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Cosmos;
using Domain.Interfaces;

namespace Application.Services
{
    public class CosmosPostService : ICosmosPostService
    {
        private readonly IMapper _mapper;
        private readonly ICosmosPostRepository _postRepository;
        public CosmosPostService(ICosmosPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<CosmosPostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CosmosPostDto>>(posts);  
        }

        public async Task<CosmosPostDto> GetPostByIdAsync(string id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<CosmosPostDto>(post);
        }

        public async Task<CosmosPostDto> AddNewPostAsync(CreateCosmosPostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post can not have an empty title.");
            }

            var post = _mapper.Map<CosmosPost>(newPost);
            var result = await _postRepository.AddAsync(post);
            return _mapper.Map<CosmosPostDto>(result);
        }

        public async Task UpdatePostAsync(UpdateCosmosPostDto updatePost)
        {
            var existingPost = await _postRepository.GetByIdAsync(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            await _postRepository.UpdateAsync(post);
        }
        
        public async Task DeletePostAsync(string id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }
    }
}
