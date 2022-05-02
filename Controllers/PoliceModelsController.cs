using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FBIApplication.Data;
using FBIApplication.Models;

namespace FBIApplication.Controllers
{
    public class PoliceModelsController : Controller
    {
        private readonly FBIApplicationContext _context;

        public PoliceModelsController(FBIApplicationContext context)
        {
            _context = context;
        }

        // GET: PoliceModels
        public async Task<IActionResult> Index()
        {
          /*  PoliceModel PoliceData = new PoliceModel() { data_year = 2019 , population = 348812 , officer_rate_per_1000 = 0.17f,officer_count= 60 };
            PoliceModel PoliceData1 = new PoliceModel() { data_year = 2018, population = 1758559, officer_rate_per_1000 = 0.06f, officer_count = 107 };
            PoliceModel PoliceData2 = new PoliceModel() { data_year = 2017, population = 4480975, officer_rate_per_1000 = 0.89f, officer_count = 3967 };
            PoliceModel PoliceData3 = new PoliceModel() { data_year = 2016, population = 3470293, officer_rate_per_1000 = 0.16f, officer_count = 542 };
            PoliceModel PoliceData4 = new PoliceModel() { data_year = 2015, population = 458000, officer_rate_per_1000 = 0.12f, officer_count = 55 };

            _context.PoliceModel.Add(PoliceData);
            _context.PoliceModel.Add(PoliceData1);
            _context.PoliceModel.Add(PoliceData2);
            _context.PoliceModel.Add(PoliceData3);
            _context.PoliceModel.Add(PoliceData4);*/

            await _context.SaveChangesAsync();
            return View(await _context.PoliceModel.ToListAsync());
        }

        // GET: PoliceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeModel = await _context.PoliceModel
                .FirstOrDefaultAsync(m => m.PoliceModelID == id);
            if (policeModel == null)
            {
                return NotFound();
            }

            return View(policeModel);
        }

        // GET: PoliceModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoliceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoliceModelID,data_year,population,officer_count,officer_rate_per_1000")] PoliceModel policeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(policeModel);
        }

        // GET: PoliceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeModel = await _context.PoliceModel.FindAsync(id);
            if (policeModel == null)
            {
                return NotFound();
            }
            return View(policeModel);
        }

        // POST: PoliceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PoliceModelID,data_year,population,officer_count,officer_rate_per_1000")] PoliceModel policeModel)
        {
            if (id != policeModel.PoliceModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliceModelExists(policeModel.PoliceModelID))
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
            return View(policeModel);
        }

        // GET: PoliceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeModel = await _context.PoliceModel
                .FirstOrDefaultAsync(m => m.PoliceModelID == id);
            if (policeModel == null)
            {
                return NotFound();
            }

            return View(policeModel);
        }

        // POST: PoliceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policeModel = await _context.PoliceModel.FindAsync(id);
            _context.PoliceModel.Remove(policeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliceModelExists(int id)
        {
            return _context.PoliceModel.Any(e => e.PoliceModelID == id);
        }
    }
}
