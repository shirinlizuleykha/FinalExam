using Indigo.Business.Exceptions;
using Indigo.Business.Services.Absrtacts;
using Indigo.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "SuperAdmin")]
public class EventController : Controller
{
    private readonly IPostService _postService;

    public EventController(IPostService posttService)
    {
        _postService = posttService;
    }

    public IActionResult Index()
    {
        var events = _postService.GetAllPosts();
        return View(events);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Post evn)
    {
        if (!ModelState.IsValid)
            return View();

        try
        {
            await _postService.AddPost(evn);
        }
        catch (FileRequiredException ex)
        {

            ModelState.AddModelError("ImageFile", ex.Message);
            return View();
        }
        catch (FileContentTypeException ex)
        {

            ModelState.AddModelError("ImageFile", ex.Message);
            return View();
        }
        catch (FileSizeNotException ex)
        {

            ModelState.AddModelError("ImageFile", ex.Message);
            return View();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return RedirectToAction("Index");

    }
    public IActionResult Update(int id)
    {
        var existPost = _postService.GetPost(x => x.Id == id);
        if (existPost == null) return NotFound();


        return View(existPost);

    }
    [HttpPost]
    public IActionResult Update(Post evn)
    {

        if (!ModelState.IsValid)
            return View();

        try
        {
            _postService.UpdatePost(evn);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound();
        }
        //catch (EntityNotFoundException ex)
        //{
        //    return NotFound();
        //}
        catch (FileContentTypeException ex)
        {

            ModelState.AddModelError("ImageFile", ex.Message);
            return View();
        }
        catch (FileSizeNotException ex)
        {

            ModelState.AddModelError("ImageFile", ex.Message);
            return View();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return RedirectToAction("Index");

    }
    public IActionResult Delete(int id)
    {
        var existPost = _postService.GetPost(x => x.Id == id);
        if (existPost == null) return NotFound();


        return View(existPost);

    }
    [HttpPost]
    public IActionResult DeletePost(int id)
    {
        var existPost = _postService.GetPost(x => x.Id == id);
        if (existPost == null) return NotFound();

        try
        {
            _postService.DeletePost(id);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound();
        }
        //catch (EntityNotFoundException ex)
        //{
        //    return NotFound();
        //}
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

        return RedirectToAction("Index");
    }
}