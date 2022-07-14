using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPdotNETMVC.Models;

namespace ASPdotNETMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _db;

        public EmployeesController(EmployeeDbContext db)
        {
            _db = db;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _db.tEmployees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _db.tEmployees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Email,PhoneNumber,HireDate,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (_db.tEmployees.Where(x => x.Email == employee.Email || x.PhoneNumber == employee.PhoneNumber).Count() > 0)
                {
                    TempData["pesan"] = "Email or Phone Number Already Exist =" + employee.Email ;
                    return RedirectToAction("Create", "Employees");
                }

                _db.Add(employee);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _db.tEmployees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,Name,Email,PhoneNumber,HireDate,Salary")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (_db.tEmployees.Where(x => x.Email == employee.Email || x.PhoneNumber == x.PhoneNumber).Count() > 0)
            {
                TempData["pesan"] = "Email or Phone Number Already Exist";
                return RedirectToAction("Edit", "Employees");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(employee);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _db.tEmployees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _db.tEmployees.FindAsync(id);
            _db.tEmployees.Remove(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _db.tEmployees.Any(e => e.EmployeeId == id);
        }
    }
}
