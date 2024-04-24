using Hospital.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Hospital.Models; // Import your data models here

[Authorize(Roles = "Admin")] // Restrict access to users with the "Admin" role
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Action method for managing admin users
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

    // Other action methods for CRUD operations on users, roles, content management, etc.
}