using CRUD_opr.Data;
using CRUD_opr.Models.Entities;
using CRUD_opr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_opr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        public StudentAPIController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;

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



            return Ok(student); 
        }

        // read data

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var students = await dbContext.obj.ToListAsync();
            RedirectToAction("List", "Student");
            return Ok(students);
        }



        // Edit data read
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var student = await dbContext.obj.FindAsync(id);

            return Ok(student);


        }

        // Edit data 

        [HttpPut]
        [Route ("{id:guid}")]
        public IActionResult Edit(Guid id , Edit ob)
        {
            var student = dbContext.obj.Find(id);

            if (student is null)
            {
                return NotFound();

            }
            student.Name = ob.Name;
            student.Email = ob.Email;
            student.Phone = ob.Phone;

            dbContext.SaveChanges();
            return Ok(student);
        }

        //Delete data

        [HttpPut]
        [Route("{id:guid}")]
        public  IActionResult Delete(Guid id)
        {
            var student =  dbContext.obj.Find(id);

            if (student is  null)
            {
                return NotFound();
            }
            dbContext.obj.Remove(student);
             dbContext.SaveChangesAsync();

            return Ok();;
        }
    }
}
