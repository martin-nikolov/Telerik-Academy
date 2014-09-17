namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : BaseController
    {
        [HttpGet]
        public IQueryable<CourseModel> All()
        {
            return this.StudentSystemData.Courses.All().Select(CourseModel.FromCourse);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var course = this.GetCourseModelById(id);
            if (course == null)
            {
                return this.NotFound();
            }

            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult AddStudent(int courseId, int studentId)
        {
            var course = this.StudentSystemData.Courses.Find(courseId);
            if (course == null)
            {
                return this.NotFound();
            }

            var student = this.StudentSystemData.Students.Find(studentId);
            if (student == null)
            {
                return this.NotFound();
            }

            student.Courses.Add(course);
            this.StudentSystemData.SaveChanges();

            return this.Ok(this.GetCourseModelById(courseId));
        }

        [HttpPut]
        public IHttpActionResult Edit(CourseModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.StudentSystemData.Courses.Find(courseModel.CourseId);
            if (course == null)
            {
                return this.NotFound();
            }

            try
            {
                course.Description = courseModel.Description;
                this.StudentSystemData.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CourseExists(courseModel.CourseId))
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
        public IHttpActionResult Create(Course course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.StudentSystemData.Courses.Add(course);
            this.StudentSystemData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = course.CourseId }, course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var course = this.StudentSystemData.Courses.Find(id);
            if (course == null)
            {
                return this.NotFound();
            }

            this.StudentSystemData.Courses.Delete(course);
            this.StudentSystemData.SaveChanges();

            return this.Ok(course);
        }

        private CourseModel GetCourseModelById(int id)
        {
            var course = this.StudentSystemData.Courses
                             .All()
                             .Select(CourseModel.FromCourse)
                             .FirstOrDefault(c => c.CourseId == id);
            return course;
        }

        private bool CourseExists(int id)
        {
            return this.StudentSystemData.Courses.All().Any(e => e.CourseId == id);
        }
    }
}