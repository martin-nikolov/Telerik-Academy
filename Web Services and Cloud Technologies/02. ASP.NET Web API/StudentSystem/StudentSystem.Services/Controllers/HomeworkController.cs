namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class HomeworkController : BaseController
    {
        [HttpGet]
        public IQueryable<HomeworkModel> All()
        {
            return this.StudentSystemData.Homeworks.All().Select(HomeworkModel.FromHomework);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var homework = this.GetHomeworkModelById(id);
            if (homework == null)
            {
                return this.NotFound();
            }

            return this.Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult Edit(HomeworkModel homeworkModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var homework = this.StudentSystemData.Homeworks.Find(homeworkModel.HomeworkId);
            if (homework == null)
            {
                return this.NotFound();
            }

            try
            {
                homework.Content = homeworkModel.Content;
                homework.CourseId = homeworkModel.CourseId;
                homework.HomeworkId = homeworkModel.HomeworkId;
                homework.Materials = homework.Materials;
                homework.StudentId = homeworkModel.StudentId;
                homework.TimeSent = homeworkModel.TimeSent;

                this.StudentSystemData.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.HomeworkExists(homeworkModel.HomeworkId))
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
        public IHttpActionResult Create(Homework homework)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.StudentSystemData.Homeworks.Add(homework);
            this.StudentSystemData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = homework.HomeworkId }, homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var homework = this.StudentSystemData.Homeworks.Find(id);
            if (homework == null)
            {
                return this.NotFound();
            }

            this.StudentSystemData.Homeworks.Delete(homework);
            this.StudentSystemData.SaveChanges();

            return this.Ok(homework);
        }

        private HomeworkModel GetHomeworkModelById(int id)
        {
            var homework = this.StudentSystemData.Homeworks
                               .All()
                               .Select(HomeworkModel.FromHomework)
                               .FirstOrDefault(h => h.HomeworkId == id);
            return homework;
        }

        private bool HomeworkExists(int id)
        {
            return this.StudentSystemData.Homeworks.All().Any(e => e.HomeworkId == id);
        }
    }
}