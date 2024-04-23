using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers;

public class PatientController : Controller
{
    private readonly HospitalDbContext _context;

    public PatientController(HospitalDbContext context)
    {
        this._context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var patients = await _context.Patients
            .Select(p => new PatientViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Gender = p.Gender,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                MedicalHistory = p.MedicalHistory,
                AdditionalInformation = p.AdditionalInformation
            })
            .ToListAsync();

        return View(patients);
    }
    
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.Id == id);

        if (patient == null)
        {
            return NotFound();
        }

        var patientViewModel = new PatientViewModel
        {
            Id = patient.Id,
            Name = patient.Name,
            Age = patient.Age,
            Gender = patient.Gender,
            Address = patient.Address,
            PhoneNumber = patient.PhoneNumber,
            MedicalHistory = patient.MedicalHistory,
            AdditionalInformation = patient.AdditionalInformation
        };

        return View(patientViewModel);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        var model = new PatientAddViewModel();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(PatientAddViewModel model)
    {
        if (ModelState.IsValid)
        {
            var patient = new Patient
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                MedicalHistory = model.MedicalHistory,
                AdditionalInformation = model.AdditionalInformation
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        return View(model);
    }
    
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        var viewModel = new PatientEditViewModel
        {
            Id = patient.Id,
            Name = patient.Name,
            Age = patient.Age,
            Gender = patient.Gender,
            Address = patient.Address,
            PhoneNumber = patient.PhoneNumber,
            MedicalHistory = patient.MedicalHistory,
            AdditionalInformation = patient.AdditionalInformation
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PatientEditViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var patient = new Patient
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Age = viewModel.Age,
                Gender = viewModel.Gender,
                Address = viewModel.Address,
                PhoneNumber = viewModel.PhoneNumber,
                MedicalHistory = viewModel.MedicalHistory,
                AdditionalInformation = viewModel.AdditionalInformation
            };

            _context.Update(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

  
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        var model = new PatientDeleteViewModel
        {
            Id = patient.Id,
            Name = patient.Name,
            Age = patient.Age,
            Gender = patient.Gender,
            Address = patient.Address,
            PhoneNumber = patient.PhoneNumber,
            MedicalHistory = patient.MedicalHistory,
            AdditionalInformation = patient.AdditionalInformation
        };

        return View(model);
    }



    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PatientExists(int id)
    {
        return _context.Patients.Any(e => e.Id == id);
    }

    
}
    
