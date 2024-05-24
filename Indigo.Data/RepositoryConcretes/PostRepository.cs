using Indigo.Core.Models;
using Indigo.Core.Models.RepositoryAbstarcts;
using Indigo.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo.Data.RepositoryConcretes;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
}
