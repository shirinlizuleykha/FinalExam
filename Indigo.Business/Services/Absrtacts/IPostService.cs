using Indigo.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo.Business.Services.Absrtacts;

public interface IPostService
{
    Task AddPost(Post post);
    void DeletePost(int id);
    void UpdatePost(Post post);
    Post GetPost(Func<Post, bool>? func = null);
    List<Post> GetAllPosts(Func<Post, bool>? func = null);
}



