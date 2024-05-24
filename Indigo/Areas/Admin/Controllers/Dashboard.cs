﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles ="Super Admin")]
public class Dashboard : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
