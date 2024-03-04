using System.Diagnostics;
using Aurum.Application;
using Aurum.Application.Services;
using EFCoreTest.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EFCoreTest.Controllers;

[ApiController]
[Route("api/[controller]")]
/*
[Authorize]
*/
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PondanService _pondanService;
    
    public HomeController(ILogger<HomeController> logger,PondanService pondanService)
    {
        _logger = logger;
        _pondanService = pondanService;
    }
   
    [Route("hello")]
    [HttpGet]
    public async  Task<IActionResult> HelloWorld()
    {
        var res = await _pondanService.GetPondans(1, 10);
        res = res.ToList();
        return this.OkWithDetails($"{res.Count()} Pondans has been fetched successfully", res);
    }
}