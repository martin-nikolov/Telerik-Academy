namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Data.UnitOfWork;
    using TicketingSystem.Web.Controllers.Base;
    using TicketingSystem.Web.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Tickets;

    public class TicketsController : BaseController
    {
        private readonly ITicketsService ticketsService;
        private readonly ICategoriesService categoriesService;

        public TicketsController(ITicketingSystemData data, ITicketsService ticketsService, ICategoriesService categoriesService)
            : base(data)
        {
            this.ticketsService = ticketsService;
            this.categoriesService = categoriesService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult All(int? category)
        {
            return this.View(category);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ReadTickets([DataSourceRequest]
                                        DataSourceRequest request, int? category)
        {
            var tickets = this.ticketsService.GetTicketsByCategoryId(category);
            return this.Json(tickets.ToDataSourceResult(request));
        }
 
        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var model = new CreateTicketViewModel()
            {
                Categories = this.categoriesService.GetTicketCategories()
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CreateTicketViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var ticket = Mapper.Map<Ticket>(model);
                ticket.AuthorId = this.CurrentUser.Id;

                if (model.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        model.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();
                        ticket.Image = this.CreateImageModel(model.UploadedImage.FileName, content);
                    }
                }

                this.CurrentUser.Points++;
                this.Data.Tickets.Add(ticket);
                this.Data.SaveChanges();

                return this.RedirectToAction("All", "Tickets");
            }

            model.Categories = this.categoriesService.GetTicketCategories();
            return this.View(model);
        }
 
        public ActionResult Details(int id)
        {
            var ticket = this.ticketsService.GetTicketById(id);

            if (ticket == null)
            {
                throw new HttpException(404, "Ticket not found");
            }

            ticket.Comments = this.ticketsService.GetTicketCommentsById(id);

            return this.View(ticket);
        }
 
        public ActionResult Image(int id)
        {
            var image = this.Data.Images.Find(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }

        public ActionResult GetCategories()
        {
            return this.Json(this.categoriesService.GetTicketCategories(), JsonRequestBehavior.AllowGet);
        }
      
        private Image CreateImageModel(string fileName, byte[] content)
        {
            var image = new Image
            {
                Content = content,
                FileExtension = fileName.Split(new[] { '.' }).Last()
            };

            return image;
        }
    }
}