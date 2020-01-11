using MechanicsBank.IdentityServer.Domain.Dtos.Identity;
using MechanicsBank.IdentityServer.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityAdmin.Controllers
{
    [Route("administration/users")]
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UsersController : Controller
    {
        private readonly IIdentityService _identityServices;

        public UsersController(IIdentityService identityServices)
        {
            _identityServices = identityServices;
        }

        [Route("search")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Search(string name, int page = 1, int size = 10)
        {
            ViewBag.Search = name;
            var model = await _identityServices.GetUsersAsync(name, page, size);
            return View(model);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(UserDto model)
        {
            if (ModelState.IsValid)
            {
                await _identityServices.CreateUserAsync(model);
                return RedirectToAction(nameof(Search));
            }

            return View(model);
        }

        [Route("details/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await _identityServices.GetUserAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [Route("details/{d}")]
        [HttpPost]
        public async Task<IActionResult> Details(string id, UserDto model)
        {
            if (ModelState.IsValid)
            {
                await _identityServices.UpdateUserAsync(model);
                return RedirectToAction(nameof(Search));
            }

            return View(model);
        }

        [Route("delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await _identityServices.GetUserAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [Route("delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id, UserDto model)
        {
            if (id == model.Id)
                return NotFound();

            await _identityServices.DeleteUserAsync(id);
            return RedirectToAction(nameof(Search));
        }
    }
}