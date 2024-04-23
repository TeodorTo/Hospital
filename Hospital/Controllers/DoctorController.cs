using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext _context;

        public DoctorController(HospitalDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var s = await _context.Doctors
                .AsNoTracking()
                .Select(s => new DoctorAllViewModel(
                    s.DoctorId,
                    s.Name,
                    s.Specialty,
                    s.Department.Name))
                .ToListAsync();
            return View(s);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new DoctorAddViewModel
            {
                Departments = await _context.Departments
                    .Select(d => new DepartmentsViewModel
                    {
                        Id = d.DepartmentId,
                        Name = d.Name
                    })
                    .ToListAsync()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DoctorAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Departments = await _context.Departments
                    .Select(d => new DepartmentsViewModel
                    {
                        Id = d.DepartmentId,
                        Name = d.Name
                    })
                    .ToListAsync();

                return View(model);
            }

            var doctor = new Doctor
            {
                Name = model.Name,
                Specialty = model.Specialty,
                Office = model.Office,
                WorkingHours = model.WorkingHours,
                DepartmentId = model.DepartmentId
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 
        }
        
        
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Department) // Include the department
                .FirstOrDefaultAsync(d => d.DoctorId == id);

            if (doctor == null)
            {
                return NotFound();
            }

            var viewModel = new DoctorDetailsViewModel(
                doctor.DoctorId,
                doctor.Name,
                doctor.Specialty,
                doctor.Department.Name, // Access department name
                doctor.Office,
                doctor.WorkingHours
            );

            return View(viewModel);
        }
        
         [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            var model = new DoctorEditViewModel
            {
                Id = doctor.DoctorId,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                Office = doctor.Office,
                WorkingHours = doctor.WorkingHours,
                SelectedDepartmentId = doctor.DepartmentId,
                Departments = await _context.Departments
                    .Select(d => new SelectListItem
                    {
                        Value = d.DepartmentId.ToString(),
                        Text = d.Name,
                        Selected = d.DepartmentId == doctor.DepartmentId
                    })
                    .ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DoctorEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    return NotFound();
                }

                doctor.Name = model.Name;
                doctor.Specialty = model.Specialty;
                doctor.Office = model.Office;
                doctor.WorkingHours = model.WorkingHours;
                doctor.DepartmentId = model.SelectedDepartmentId;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            model.Departments = await _context.Departments
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.Name,
                    Selected = d.DepartmentId == model.SelectedDepartmentId
                })
                .ToListAsync();

            return View(model);
        }
        
        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.Include(doctor => doctor.Department)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            var model = new DoctorDeleteViewModel
            {
                Id = doctor.DoctorId,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                Office = doctor.Office,
                WorkingHours = doctor.WorkingHours,
                Department = doctor.Department.Name 
            };

            return View(model);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
        

    }
}

