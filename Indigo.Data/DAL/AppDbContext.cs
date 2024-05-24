using Indigo.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo.Data.DAL;

public class AppDbContext: IdentityDbContext
{
    public AppDbContext(DbContextOptions option) : base(option) { }


    public DbSet<Post> Posts { get; set; }

    public DbSet<AppUser> Users { get; set; }


}