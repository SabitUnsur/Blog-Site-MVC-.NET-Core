using DailyBlogUI.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DailyBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _userManager=userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values=_roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = roleViewModel.RoleName
                };

                var result=await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }

            return View(roleViewModel);
        }


        [HttpGet]
        public IActionResult UpdateRole(int roleID)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == roleID);
            RoleUpdateViewModel model = new RoleUpdateViewModel()
            {
                roleId = values.Id,
                roleName = values.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel roleModelUpdate)
        {
            var values = _roleManager.Roles.Where(x => x.Id == roleModelUpdate.roleId).FirstOrDefault();
             values.Name= roleModelUpdate.roleName;
            var result = await _roleManager.UpdateAsync(values);

            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(roleModelUpdate);
        }

        public async Task<IActionResult> DeleteRole(int roleID)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == roleID);
           var result= await _roleManager.DeleteAsync(values); 
            
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int ID)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == ID);
            var roles=_roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> assignments = new List<RoleAssignViewModel>();    
            foreach (var role in roles)
            {
                RoleAssignViewModel assign = new RoleAssignViewModel();
                assign.roleID = role.Id;
                assign.Name = role.Name;
                assign.IsExist = userRoles.Contains(role.Name);
                assignments.Add(assign);
            }

            return View(assignments);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userID = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userID);
            foreach (var item in model)
            {
                if(item.IsExist)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }

                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            
            return RedirectToAction("UserRoleList");
        }


    }
}
