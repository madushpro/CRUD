using CRUD_opr.Data;
using CRUD_opr.Models;
using CRUD_opr.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CRUD_opr.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public StudentController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;

        }

        //Add Data
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Add the data

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentModel viewobj)
        {

            var student = new Student
            {
                Name = viewobj.Name,
                Email = viewobj.Email,
                Phone = viewobj.Phone
            };

            await dbContext.obj.AddAsync(student);
            await dbContext.SaveChangesAsync();


            return RedirectToAction("List", "Student");
        }

        // read data

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var students = await dbContext.obj.ToListAsync();
            return View(students);
        }

        // Edit data read

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var student = await dbContext.obj.FindAsync(id);

            return View(student);


        }

        // Edit data 

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {

            var student = await dbContext.obj.FindAsync(viewmodel.Id);

            if (student is not null)
            {

                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.Phone = viewmodel.Phone;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");
        }

        //Delete data

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await dbContext.obj.FindAsync(id);

            if (student is not null)
            {
                dbContext.obj.Remove(student);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");
        }



    }
}
