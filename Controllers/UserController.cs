using JPT.Models;
using JPT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourApp.Models;
using YourApp.Services;

namespace JPT.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User/Index
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users); // Views/User/Index.cshtml
        }

        // GET: User/Create
        public IActionResult Create()
        {
            var model = new AddUserModel
            {
                Branch = "001",
                Counter = "001-001-B1",
                Role = "admin",
                Gender = "male",
                PasswordOption = "manual",
                Active = true
            };

            PopulateDropdowns();
            return View(model); // Views/User/Create.cshtml
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUserAsync(model);
                return RedirectToAction("Index");
            }

            PopulateDropdowns();
            return View(model);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var userFromDb = await _userService.GetUserByIdAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            var userviewModel = new EditUserModel
            {
                Id = userFromDb.Id,
                Branch = userFromDb.Branch,
                Counter = userFromDb.Counter,
                Role = userFromDb.Role,
                Username = userFromDb.Username,
                FullName = userFromDb.FullName,
                NepaliName = userFromDb.NepaliName,
                Address = userFromDb.Address,
                Gender = userFromDb.Gender,
                Contact = userFromDb.Contact,
                OtherContact = userFromDb.OtherContact,
                Email = userFromDb.Email,
                PasswordOption = userFromDb.PasswordOption,
                Active = userFromDb.Active,
                Remarks = userFromDb.Remarks
            };

            PopulateDropdowns();
            return View(userviewModel); // Views/User/Edit.cshtml
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditUserModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateUserAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) here if needed
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the user.");
                }
            }

            // If we got this far, something failed, redisplay form
            PopulateDropdowns();
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        private void PopulateDropdowns()
        {
            ViewBag.Branches = UserFormOptions.Branches;
            ViewBag.Counters = UserFormOptions.Counters;
            ViewBag.Roles = UserFormOptions.Roles;
            ViewBag.Genders = UserFormOptions.Genders;
            ViewBag.PasswordOptions = UserFormOptions.PasswordOptions;
        }
    }
}
