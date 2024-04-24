using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HospitalDbContext _context;

        public AppointmentController(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.AppointmentType)
                .Include(a => a.AppointmentStatus)
                .Select(a => new AppointmentViewModel
                {
                    Id = a.AppointmentId,
                    DateTime = a.DateTime,
                    PatientName = a.Patient.Name,
                    DoctorName = a.Doctor.Name,
                    AppointmentType = a.AppointmentType.Name,
                    AppointmentStatus = a.AppointmentStatus.Name,
                    Reason = a.Reason
                })
                .ToListAsync();

            return View(appointments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.AppointmentType)
                .Include(a => a.AppointmentStatus)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            var viewModel = new AppointmentViewModel
            {
                Id = appointment.AppointmentId,
                DateTime = appointment.DateTime,
                PatientName = appointment.Patient.Name,
                DoctorName = appointment.Doctor.Name,
                AppointmentType = appointment.AppointmentType.Name,
                AppointmentStatus = appointment.AppointmentStatus.Name,
                Reason = appointment.Reason
            };

            return View(viewModel);
        }

         public IActionResult Add()
        {
            var patientOptions = _context.Patients.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            var doctorOptions = _context.Doctors.Select(d => new SelectListItem { Value = d.DoctorId.ToString(), Text = d.Name }).ToList();
            var appointmentTypeOptions = _context.AppointmentTypes.Select(t => new SelectListItem { Value = t.AppointmentTypeId.ToString(), Text = t.Name }).ToList();
            var appointmentStatusOptions = _context.AppointmentStatuses.Select(s => new SelectListItem { Value = s.AppointmentStatusId.ToString(), Text = s.Name }).ToList();

            var patientList = new SelectList(patientOptions, "Value", "Text");
            var doctorList = new SelectList(doctorOptions, "Value", "Text");
            var appointmentTypeList = new SelectList(appointmentTypeOptions, "Value", "Text");
            var appointmentStatusList = new SelectList(appointmentStatusOptions, "Value", "Text");

            ViewBag.PatientList = patientList;
            ViewBag.DoctorList = doctorList;
            ViewBag.AppointmentTypeList = appointmentTypeList;
            ViewBag.AppointmentStatusList = appointmentStatusList;

            var model = new AppointmentAddViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AppointmentAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    DateTime = model.DateTime,
                    PatientId = model.PatientId,
                    DoctorId = model.DoctorId,
                    AppointmentTypeId = model.AppointmentTypeId,
                    AppointmentStatusId = model.AppointmentStatusId,
                    Reason = model.Reason
                };

                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var patientOptions = _context.Patients.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            var doctorOptions = _context.Doctors.Select(d => new SelectListItem { Value = d.DoctorId.ToString(), Text = d.Name }).ToList();
            var appointmentTypeOptions = _context.AppointmentTypes.Select(t => new SelectListItem { Value = t.AppointmentTypeId.ToString(), Text = t.Name }).ToList();
            var appointmentStatusOptions = _context.AppointmentStatuses.Select(s => new SelectListItem { Value = s.AppointmentStatusId.ToString(), Text = s.Name }).ToList();

            var patientList = new SelectList(patientOptions, "Value", "Text");
            var doctorList = new SelectList(doctorOptions, "Value", "Text");
            var appointmentTypeList = new SelectList(appointmentTypeOptions, "Value", "Text");
            var appointmentStatusList = new SelectList(appointmentStatusOptions, "Value", "Text");

            ViewBag.PatientList = patientList;
            ViewBag.DoctorList = doctorList;
            ViewBag.AppointmentTypeList = appointmentTypeList;
            ViewBag.AppointmentStatusList = appointmentStatusList;

            return View(model);
        }
        
        // AppointmentController Edit action
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var viewModel = new AppointmentEditViewModel
            {
                Id = appointment.AppointmentId,
                DateTime = appointment.DateTime,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentTypeId = appointment.AppointmentTypeId,
                AppointmentStatusId = appointment.AppointmentStatusId,
                Reason = appointment.Reason,

                // Populate dropdown lists
                Patients = await _context.Patients.ToListAsync(),
                Doctors = await _context.Doctors.ToListAsync(),
                AppointmentTypes = await _context.AppointmentTypes.ToListAsync(),
                AppointmentStatuses = await _context.AppointmentStatuses.ToListAsync()
            };

            return View(viewModel);
        }



        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppointmentEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var appointment = await _context.Appointments.FindAsync(id);
                    if (appointment == null)
                    {
                        return NotFound();
                    }

                    appointment.DateTime = viewModel.DateTime;
                    appointment.PatientId = viewModel.PatientId;
                    appointment.DoctorId = viewModel.DoctorId;
                    appointment.AppointmentTypeId = viewModel.AppointmentTypeId;
                    appointment.AppointmentStatusId = viewModel.AppointmentStatusId;
                    appointment.Reason = viewModel.Reason;

                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(viewModel.Id))
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

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.AppointmentType)
                .Include(a => a.AppointmentStatus)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            var viewModel = new AppointmentViewModel // Adjust to match your existing AppointmentViewModel structure
            {
                Id = appointment.AppointmentId,
                DateTime = appointment.DateTime,
                PatientName = appointment.Patient.Name,
                DoctorName = appointment.Doctor.Name,
                AppointmentType = appointment.AppointmentType.Name,
                AppointmentStatus = appointment.AppointmentStatus.Name,
                Reason = appointment.Reason
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        
        
        
        
        
        // Helper method to check if an appointment exists
        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }

        
        

    }
}
