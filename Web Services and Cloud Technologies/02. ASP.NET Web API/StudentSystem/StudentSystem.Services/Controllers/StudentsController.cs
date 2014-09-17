namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class StudentsController : BaseController
    {
        [HttpGet]
        public IQueryable<StudentModel> All()
        {
            return this.StudentSystemData.Students.All().Select(StudentModel.FromStudent);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var student = this.GetStudentModelById(id);
            if (student == null)
            {
                return this.NotFound();
            }

            return this.Ok(student);
        }
 
        [HttpPut]
        public IHttpActionResult Edit(StudentModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.StudentSystemData.Students.Find(studentModel.StudentId);
            if (student == null)
            {
                return this.NotFound();
            }

            try
            {
                student.Name = studentModel.Name;
                this.StudentSystemData.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.StudentExists(studentModel.StudentId))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IHttpActionResult Create(Student student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.StudentSystemData.Students.Add(student);
            this.StudentSystemData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var student = this.StudentSystemData.Students.Find(id);
            if (student == null)
            {
                return this.NotFound();
            }

            this.StudentSystemData.Students.Delete(student);
            this.StudentSystemData.SaveChanges();

            return this.Ok(student);
        }

        private StudentModel GetStudentModelById(int id)
        {
            var student = this.StudentSystemData.Students
                              .All()
                              .Select(StudentModel.FromStudent)
                              .FirstOrDefault(s => s.StudentId == id);
            return student;
        }

        private bool StudentExists(int id)
        {
            return this.StudentSystemData.Students.All().Any(e => e.StudentId == id);
        }
    }
}