
using Indigo.Business.Services.Absrtacts;
using Microsoft.AspNetCore.Mvc;


namespace Indigo.Controllers;

public class HomeController : Controller
{
    IPostService _postService;
    public HomeController(IPostService service)
    {
      _postService = service;
    }

    public IActionResult Index()
    {
        var data = _postService.GetAllPosts();

        return View(data);
    }

  
}
