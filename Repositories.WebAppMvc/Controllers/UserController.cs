using Microsoft.AspNetCore.Mvc;
using Repositories.WebAppMvc.Models;
using Repositories.WebAppMvc.Repositories;

namespace Repositories.WebAppMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _userService;

        public UserController(IRepository<User> userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var models = await _userService.GetAll();
            return View(models);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var model = await _userService.GetById(id);
            if (model == null)
                return NotFound($"No user with Id {id} !");
            return View(model);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (model == null)
                    return NotFound("404 Brak roli!");

                var check = await _userService.Insert(model);
                if (check == false)
                {
                    return NotFound("404 Brak roli!");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var model = await _userService.GetById(id);
            if (model == null)
            {
                return NotFound($"Not found user with {id}");
            }
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var check = await _userService.Update(id, model);

                if (check == false)
                {
                    return NotFound("No user!");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult<User>> Delete(string id)
        {
            var model = await _userService.GetById(id);
            if (model == null)
            {
                return NotFound($"Not found user with {id}");
            }
            return View(model);
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, User model)
        {
            try
            {          
                var check = await _userService.Delete(id, model);
                if (check == false)
                {
                    return RedirectToAction("EmptyList");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
