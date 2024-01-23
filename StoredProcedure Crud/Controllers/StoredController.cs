using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoredProcedure_Crud.Data;
using StoredProcedure_Crud.Models;

namespace StoredProcedure_Crud.Controllers
{
    public class StoredController : Controller
    {
        private readonly StoredContext _context;

        public StoredController(StoredContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.storeds.FromSqlRaw("exec spGetProcedureList").ToList();
            return View(result);
        }

        public IActionResult Create(StoredModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Use parameterized query or stored procedure to prevent SQL injection
                    //_context.Database.ExecuteSqlRaw("EXEC spInsert_procedure {0}, {1}, {2}, {3}",
                    //    model.Name, model.City, model.Gender, model.PinCode);

                    _context.Database.ExecuteSqlRaw("EXEC spInsert_procedure {0},{1},{2},{3}", model.Name, model.City, model.Gender, model.PinCode);
                    TempData["Success"] = "Record is successfully inserted";
                    return RedirectToAction("Index");
                }
                else
                {
                    // If the model is not valid, return the view with validation errors
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // Example: _logger.LogError(ex, "An error occurred while creating a record");
                return View(model); // You might want to return the view with the model to preserve user input
            }
        }
    }
}
