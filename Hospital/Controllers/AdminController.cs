using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// Import your data models here

 // Restrict access to users with the "Admin" role
 namespace Hospital.Controllers;

 public class AdminController : Controller
 {
     private readonly UserManager<IdentityUser> _userManager;
     private readonly RoleManager<IdentityRole> _roleManager;

     public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
     {
         _userManager = userManager;
         _roleManager = roleManager;
     }

     // Action method for managing admin users
     
     
     public IActionResult Index()
     {
         return View();
     }
     
     
     public IActionResult ManageUsers()
     {
         var users = _userManager.Users;
         return View(users);
     }

     // Action method for managing roles
     public IActionResult ManageRoles()
     {
         var roles = _roleManager.Roles;
         return View(roles);
     }

    
    
     public IActionResult CreateRole()
     {
         return View();
     }
    
     // Action method for creating a new role
     [HttpPost]
     public async Task<IActionResult> CreateRole(string roleName)
     {
         if (!string.IsNullOrEmpty(roleName))
         {
             var role = new IdentityRole(roleName);
             var result = await _roleManager.CreateAsync(role);
             if (result.Succeeded)
             {
                 return RedirectToAction("ManageRoles");
             }
             foreach (var error in result.Errors)
             {
                 ModelState.AddModelError("", error.Description);
             }
         }
         return View();
     }
     
     
     
     public IActionResult AssignRoles()
     {
         var viewModel = new AssignRolesViewModel
         {
             Users = _userManager.Users.ToList(),
             Roles = _roleManager.Roles.ToList()
         };

         return View(viewModel);
     }


     [HttpPost]
     public async Task<IActionResult> AssignRoles(string userId, string roleId)
     {
         if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleId))
         {
             // Handle invalid input
             return RedirectToAction("AssignRoles");
         }

         var user = await _userManager.FindByIdAsync(userId);
         var role = await _roleManager.FindByIdAsync(roleId);

         if (user == null || role == null)
         {
             // Handle invalid user or role
             return RedirectToAction("AssignRoles");
         }

         var result = await _userManager.AddToRoleAsync(user, role.Name);

         if (result.Succeeded)
         {
             // Role assignment successful
             return RedirectToAction("AssignRoles");
         }
         else
         {
             // Handle error
             // You may want to display error messages to the user
             return RedirectToAction("AssignRoles");
         }
     }




     // Other action methods for CRUD operations on users, roles, content management, etc.
 }