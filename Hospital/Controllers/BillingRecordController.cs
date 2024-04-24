using Microsoft.AspNetCore.Mvc;
using Hospital.Models;
using Hospital.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class BillingRecordController : Controller
    {
        private readonly HospitalDbContext _context;

        public BillingRecordController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: BillingRecord
        public async Task<IActionResult> Index()
        {
            var billingRecords = await _context.BillingRecords.ToListAsync();
            return View(billingRecords);
        }

        // GET: BillingRecord/Edit/5
        // GET: BillingRecord/Edit/{id}
        public IActionResult Edit(int id)
        {
            var billingRecord = _context.BillingRecords.Find(id);
            if (billingRecord == null)
            {
                return NotFound();
            }

            var appointments = _context.Appointments
                .Select(a => new SelectListItem 
                { 
                    Value = a.AppointmentId.ToString(), 
                    Text = $"{a.DateTime} - Dr. {a.Doctor.Name}" 
                })
                .ToList();

            ViewBag.Appointments = new SelectList(appointments, "Value", "Text", billingRecord.AppointmentId);

            var patients = _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            ViewBag.Patients = new SelectList(patients, "Value", "Text", billingRecord.PatientId);

            var viewModel = new BillingRecordViewModel
            {
                BillingRecordId = billingRecord.BillingRecordId,
                AppointmentId = billingRecord.AppointmentId,
                PatientId = billingRecord.PatientId,
                Amount = billingRecord.Amount,
                BillingDate = billingRecord.BillingDate,
                Notes = billingRecord.Notes
            };

            return View(viewModel);
        }


        // POST: BillingRecord/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BillingRecordViewModel model)
        {
            if (id != model.BillingRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var billingRecord = new BillingRecord
                    {
                        BillingRecordId = model.BillingRecordId,
                        AppointmentId = model.AppointmentId,
                        PatientId = model.PatientId,
                        Amount = model.Amount,
                        BillingDate = model.BillingDate,
                        Notes = model.Notes
                    };
                    _context.Update(billingRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingRecordExists(model.BillingRecordId))
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
            return View(model);
        }

        // GET: BillingRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billingRecord = await _context.BillingRecords
                .FirstOrDefaultAsync(m => m.BillingRecordId == id);
            if (billingRecord == null)
            {
                return NotFound();
            }

            return View(billingRecord);
        }

        // POST: BillingRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billingRecord = await _context.BillingRecords.FindAsync(id);
            _context.BillingRecords.Remove(billingRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        // GET: BillingRecord/Create
        public IActionResult Create()
        {
            var appointments = _context.Appointments
                .Select(a => new SelectListItem 
                { 
                    Value = a.AppointmentId.ToString(), 
                    Text = $"{a.DateTime} - Dr. {a.Doctor.Name}" 
                })
                .ToList();

            ViewBag.Appointments = new SelectList(appointments, "Value", "Text");
    
            var patients = _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            ViewBag.Patients = new SelectList(patients, "Value", "Text");

            return View();
        }




        // POST: BillingRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillingRecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var billingRecord = new BillingRecord
                {
                    AppointmentId = model.AppointmentId,
                    PatientId = model.PatientId,
                    Amount = model.Amount,
                    BillingDate = model.BillingDate,
                    Notes = model.Notes
                };
                _context.Add(billingRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        private bool BillingRecordExists(int id)
        {
            return _context.BillingRecords.Any(e => e.BillingRecordId == id);
        }
    }
}
