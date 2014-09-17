namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class MaterialsController : BaseController
    {
        [HttpGet]
        public IQueryable<MaterialModel> All()
        {
            return this.StudentSystemData.Materials.All().Select(MaterialModel.FromMaterial);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var material = this.GetMaterialModelById(id);
            if (material == null)
            {
                return this.NotFound();
            }

            return this.Ok(material);
        }

        [HttpPut]
        public IHttpActionResult Change(MaterialModel materialModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var material = this.StudentSystemData.Materials.Find(materialModel.MaterialId);
            if (material == null)
            {
                return this.NotFound();
            }

            try
            {
                material.DownloadUrl = materialModel.DownloadUrl;
                material.HomeworkId = materialModel.HomeworkId;
                materialModel.Type = materialModel.Type;

                this.StudentSystemData.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.MaterialExists(materialModel.MaterialId))
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
        public IHttpActionResult Create(Material material)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.StudentSystemData.Materials.Add(material);
            this.StudentSystemData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = material.MaterialId }, material);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var material = this.StudentSystemData.Materials.Find(id);
            if (material == null)
            {
                return this.NotFound();
            }

            this.StudentSystemData.Materials.Delete(material);
            this.StudentSystemData.SaveChanges();

            return this.Ok(material);
        }

        private MaterialModel GetMaterialModelById(int id)
        {
            var material = this.StudentSystemData.Materials
                               .All()
                               .Select(MaterialModel.FromMaterial)
                               .FirstOrDefault(m => m.MaterialId == id);
            return material;
        }

        private bool MaterialExists(int id)
        {
            return this.StudentSystemData.Materials.All().Any(e => e.MaterialId == id);
        }
    }
}