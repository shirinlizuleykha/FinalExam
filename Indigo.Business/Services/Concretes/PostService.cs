
using Indigo.Business.Exceptions;
using Indigo.Business.Exentions;
using Indigo.Business.Services.Absrtacts;
using Indigo.Core.Models;
using Indigo.Core.Models.RepositoryAbstarcts;
using Indigo.Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes;
public class PostService : IPostService 
{ 
    private readonly IPostRepository _postRepository;
    private readonly IWebHostEnvironment _env;

        public PostService(IPostRepository postRepository, IWebHostEnvironment env)
        {
             _postRepository = postRepository;
            _env = env;

        }



    public async Task AddPost(Post post)
    {
        if (post.ImageFile == null) throw new FileRequiredException("Image is required");

        post.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/posts", post.ImageFile);

        await _postRepository.AddIdentityAsync(post);
        await _postRepository.CommitAsync();
    }


    public void DeletePost(int id)
    {
        var existPost = _postRepository.GetEntity(x => x.Id == id);
        if (existPost == null) throw new EntityNotFoundException("Post tapilmadi");

        Helper.DeleteFile(_env.WebRootPath, @"uploads/posts", existPost.ImageUrl);

        _postRepository.DeleteEntity(existPost);
        _postRepository.commit();
    }



    public List<Post> GetAllPosts(Func<Post, bool>? func = null)
    {
        return _postRepository.GetAllEntities(func);
    }


    public Post Get(Func<Post, bool>? func = null)
    {
        return _postRepository.GetEntity(func);
    }

    public void UpdateEvent(Post post)
    {
        var oldPost = _postRepository.GetEntity(x => x.Id == post.Id);
        if (oldPost == null) throw new EntityNotFoundException("Post tapilmadi");

        if (post.ImageFile != null)
        {
            post.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/posts", post.ImageFile);
            Helper.DeleteFile(_env.WebRootPath, @"uploads/posts", oldPost.ImageUrl);

            oldPost.ImageUrl = post.ImageUrl;

        }

        oldPost.Name = post.Name;
        oldPost.Description = post.Description;

        _postRepository.commit();

    }

    public void UpdatePost(Post post)
    {
        throw new NotImplementedException();
    }

    public Post GetPost(Func<Post, bool>? func = null)
    {
        throw new NotImplementedException();
    }
}



