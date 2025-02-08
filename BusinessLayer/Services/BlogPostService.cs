using BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using System.Diagnostics;
using DataAccessLayer.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IBlogPostTagRepository _blogPostTagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BlogPostService> _logger;


        //private readonly MapperConfiguration autoMapperConfig = new MapperConfiguration(cfg =>
        //{
        //    cfg.CreateMap<BlogPost, BlogPostResponseDto>()
        //    .ForMember(dest => dest.BlogPostTags, opt => opt.MapFrom(src => src.BlogPostTags.Select(x => x.Tag.Name)))
        //    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
        //});

        public BlogPostService(IBlogPostRepository blogPostRepository, IUserRepository userRepository, ITagRepository tagRepository, IBlogPostTagRepository blogPostTagRepository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<BlogPostService> logger)
        {
            _blogPostRepository = blogPostRepository;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
            _blogPostTagRepository = blogPostTagRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(BlogPostRequestDto blogPostRequest)
        {
            Debug.Assert(blogPostRequest != null, "BlogPost must not be null");
            Debug.Assert(!string.IsNullOrWhiteSpace(blogPostRequest.Email), "Email must not be null or empty");
            Debug.Assert(!string.IsNullOrWhiteSpace(blogPostRequest.Title), "Title must not be null or empty");
            Debug.Assert(!string.IsNullOrWhiteSpace(blogPostRequest.Content), "Content must not be null or empty");
            Debug.Assert(blogPostRequest.BlogPostTags != null, "BlogPostTags must not be null");

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var user = await _userRepository.GetByEmailAsync(blogPostRequest.Email);
                Debug.Assert(user != null, "User must not be null");

                var blogPost = new BlogPost
                {
                    Title = blogPostRequest.Title,
                    Content = blogPostRequest.Content,
                    UserId = user.Id
                };

                blogPost = await _blogPostRepository.AddAsync(blogPost);

                Debug.Assert(blogPost.Id > 0, "BlogPost Id must be greater than 0");

                blogPost.BlogPostTags = new List<BlogPostTag>();
                foreach (var tagDto in blogPostRequest.BlogPostTags)
                {
                    var tag = await _tagRepository.GetByNameAsync(tagDto.Name);
                    if (tag == null)
                    {
                        tag = _mapper.Map<Tag>(tagDto);
                        await _tagRepository.AddAsync(tag);
                        Debug.Assert(tag.Id > 0, "Tag Id must be greater than 0");
                        blogPost.BlogPostTags.Add(new BlogPostTag { PostId = blogPost.Id, TagId = tag.Id, Post = blogPost, Tag = tag });
                    }
                }

                foreach (var blogPostTag in blogPost.BlogPostTags)
                {
                    await _blogPostTagRepository.AddAsync(blogPostTag);
                    Debug.Assert(blogPostTag.Id > 0, "BlogPostTag Id must be greater than 0");
                }

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a blog post");
                Debug.Assert(false, "An error occurred while adding a blog post");
                await _unitOfWork.RollbackTransactionAsync();
            }
        }

        public async Task DeleteAsync(long id)
        {
            Debug.Assert(id > 0, "Id must be greater than 0");
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _blogPostRepository.DeleteAsync(id);
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a blog post");
                Debug.Assert(false, "An error occurred while deleting a blog post");
                await _unitOfWork.RollbackTransactionAsync();
            }
            // check if the blog post exists only in debug
        }

        public async Task<IEnumerable<BlogPostResponseDto>> GetAllAsync()
        {
            //var mapper = autoMapperConfig.CreateMapper();

            var blogPosts = await _blogPostRepository.GetAllAsync();

            var blogPostResponseDtos = _mapper.Map<IEnumerable<BlogPostResponseDto>>(blogPosts);
            return blogPostResponseDtos;
        }

        public async Task<IEnumerable<BlogPostResponseDto>> GetBlogPostByTag(string tag)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(tag), "Tag must not be null or empty");

            var blogPosts = await _blogPostRepository.GetPostByTagAsync(tag);

            var blogPostResponseDtos = _mapper.Map<IEnumerable<BlogPostResponseDto>>(blogPosts);
            return blogPostResponseDtos;
        }

        public async Task<BlogPostResponseDto?> GetByIdAsync(long id)
        {
            Debug.Assert(id > 0, "Id must be greater than 0");

            var blogPost = await _blogPostRepository.GetByIdAsync(id);

            if (blogPost == null)
            {
                return null;
            }


            var blogPostResponseDto = _mapper.Map<BlogPostResponseDto>(blogPost);
            return blogPostResponseDto;
        }

        public async Task UpdateAsync(BlogPostRequestDto blogPostRequest)
        {
            Debug.Assert(blogPostRequest != null, "BlogPost must not be null");

            if (blogPostRequest == null)
            {
                throw new ArgumentNullException(nameof(blogPostRequest));
            }
            var blogPost = await _blogPostRepository.GetByIdAsync(blogPostRequest.Id);
            if (blogPost == null)
            {
                throw new ArgumentException("BlogPost not found", nameof(blogPostRequest));
            }


            blogPost = _mapper.Map(blogPostRequest, blogPost);

            await _blogPostRepository.UpdateAsync(blogPost);
        }
    }
}
