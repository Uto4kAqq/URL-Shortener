using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.Client.Data.ViewModels;
using URL_Shortener.Client.Helpers.Roles;
using URL_Shortener.Data;
using URL_Shortener.Data.Models;
using URL_Shortener.Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace URL_Shortener.Client.Controllers
{
    public class UrlController : Controller
    {
        private IUrlsService _urlsService;
        private readonly IMapper _mapper;
        public UrlController(IUrlsService urlsService, IMapper mapper)
        {
            _urlsService = urlsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Role.Admin);

            var allUrls = await _urlsService.GetUrlsAsync(loggedInUserId, isAdmin);

            var mappedAllUrls = _mapper.Map<List<Url>, List<GetUrlVM>>(allUrls);

            return View(mappedAllUrls);
        }

        public async Task<IActionResult> Create()
        {
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            await _urlsService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
