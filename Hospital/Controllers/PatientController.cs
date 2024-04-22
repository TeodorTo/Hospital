using Hospital.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;

public class PatientController : Controller
{
    private readonly HospitalDbContext _context;

    public PatientController(HospitalDbContext context)
    {
        this._context = context;
    }
}