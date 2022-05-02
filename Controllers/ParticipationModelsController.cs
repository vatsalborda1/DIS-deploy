using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FBIApplication.Data;
using FBIApplication.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace FBIApplication.Controllers
{
    public class ParticipationModelsController : Controller
    {
        HttpClient httpClient;
        //static string BASE_URL = "https://api.usa.gov/crime/fbi/sapi/api/participation/national?api_key=I1k91jYXO3w5ySMKJ9BehSjXUJdI8VOn7e6zdmEB";
        static string BASE_URL = "https://api.usa.gov/crime/fbi/sapi/api/participation/national?api_key=fdTpWbq8aD5ca3qu53RTqOVLWyliNl0paK2WBVaM";

        public readonly FBIApplicationContext _context;

        public ParticipationModelsController(FBIApplicationContext context)
        {
            _context = context;
        }

        // GET: ParticipationModels
        public async Task<IActionResult> Index()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            string NATIONAL_PARK_API_PATH = BASE_URL; //+ "/parks?limit=20";
            string pData = "";

            ParticipationModel pModel = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH)
                                                        .GetAwaiter().GetResult();
                var x = response;

                System.Diagnostics.Debug.WriteLine("** responsppp: " + response);

                if (response.IsSuccessStatusCode)
                {
                    pData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    //Debug.WriteLine("** responseData: " + parksData);

                }

                pModel = JsonConvert.DeserializeObject<ParticipationModel>(pData);
                var y = pModel.results[0].data_year;
                System.Diagnostics.Debug.WriteLine("** response: " + y);

                if (!pData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    pModel = JsonConvert.DeserializeObject<ParticipationModel>(pData);
                    var z = pModel;
                    //Debug.WriteLine("** parks: " +parks);
                }

                _context.Result.Add(pModel.results[0]);
                //await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return View(await _context.Result.ToListAsync());
        }

        // GET: ParticipationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Result = await _context.Result
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (Result == null)
            {
                return NotFound();
            }

            return View(Result);
        }

        // GET: ParticipationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParticipationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResultId,data_year,population,total_agency_count,active_agency_count")] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Result.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(result);
        }

        // GET: ParticipationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Result = await _context.Result.FindAsync(id);
            if (Result == null)
            {
                return NotFound();
            }
            return View(Result);
        }

        // POST: ParticipationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResultId,data_year,population,total_agency_count,active_agency_count")] Result Result)
        {
            if (id != Result.ResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Result);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipationModelExists(Result.ResultId))
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
            return View(Result);
        }

        // GET: ParticipationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Result = await _context.Result
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (Result == null)
            {
                return NotFound();
            }

            return View(Result);
        }

        // POST: ParticipationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Result = await _context.Result.FindAsync(id);
            _context.Result.Remove(Result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipationModelExists(int id)
        {
            return _context.Result.Any(e => e.ResultId == id);
        }
    }
}
