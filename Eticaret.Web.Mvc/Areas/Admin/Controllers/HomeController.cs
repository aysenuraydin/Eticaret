﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

