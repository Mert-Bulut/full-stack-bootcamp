using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Models;
using Proje.ViewModels;

namespace Proje.Controllers
{
    [Authorize]
    public class UsersController : Controller{

        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        private SignInManager<AppUser> _signInManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index (){

            return View(_userManager.Users);
        }
        
        public IActionResult Create (){

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateViewModel model){

            if(ModelState.IsValid){
                var user = new AppUser{UserName = model.UserName, Email = model.Email, FullName = model.FullName};
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded){
                    return RedirectToAction("Index");
                }
                foreach(IdentityError err in result.Errors){
                    ModelState.AddModelError("",err.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> Edit(string id){

            if(id == null){
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByIdAsync(id);

            if(user != null){
                ViewBag.Roles = await _roleManager.Roles.Select(i=>i.Name).ToListAsync();
               return View(new EditViewModel{
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user)
               });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditViewModel model){

            if(id != model.Id){
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid){
                var user = await _userManager.FindByIdAsync(model.Id);
                if(user!=null){
                    user.Email = model.Email;
                    user.FullName = model.FullName;
                    var result = await _userManager.UpdateAsync(user);
                    if(result.Succeeded && !string.IsNullOrEmpty(model.Password)){
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, model.Password);
                    }
                    if(result.Succeeded){
                        await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                        if(model.SelectedRoles != null){
                            await _userManager.AddToRolesAsync(user,model.SelectedRoles);
                        }
                        return RedirectToAction("Index");
                    }
                    foreach(IdentityError err in result.Errors){
                        ModelState.AddModelError("",err.Description);
                    }
                }
            }
            return View(model);
        }  
    
        [HttpPost]

        public async Task<IActionResult> Delete(string id){
            var user = await _userManager.FindByIdAsync(id);

            if(user != null){
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}