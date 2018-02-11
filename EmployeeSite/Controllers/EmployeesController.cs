using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EmployeeSite.Data.Context;
using EmployeeSite.Data.Entities;
using EmployeeSite.Business;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EmployeeSite.ViewModels;

namespace EmployeeSite.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext db;
        private readonly IChangesTrackProvider _changesTrackProvider;
        public EmployeesController()
        {
            db = new EmployeeDbContext();
            _changesTrackProvider = new ChangesTrackProvider();
        }

        public async Task<ActionResult> Index()
        {
            return View(await db.Employees.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _changesTrackProvider.LogChanges(employee);

                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Reports")]
        public async Task<ActionResult> GetReports()
        {


            var report = await (from ea in db.EmployeeActivities
                                join e in db.Employees on ea.EmployeeId equals e.Id
                                select new ReportVm
                                {
                                    ChangeType = ea.ChangeType,
                                    Date = ea.Date,
                                    EmployeeId = e.Id,
                                    EmployeeName = e.Name,
                                    NewValue = ea.NewValue,
                                    OldValue = ea.OldValue,
                                    Id = ea.Id
                                }).ToListAsync();

            return View("Reports", report);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
