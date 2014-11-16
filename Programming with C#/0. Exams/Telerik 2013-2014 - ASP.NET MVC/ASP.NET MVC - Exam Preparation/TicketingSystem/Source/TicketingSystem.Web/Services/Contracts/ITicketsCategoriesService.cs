namespace TicketingSystem.Web.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetTicketCategories();

        void RemoveCategoryById(int categoryId);
    }
}