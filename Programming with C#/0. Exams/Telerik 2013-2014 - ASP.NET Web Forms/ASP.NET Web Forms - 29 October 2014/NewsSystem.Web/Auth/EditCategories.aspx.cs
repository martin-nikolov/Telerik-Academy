namespace NewsSystem.Web.Auth
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Error_Handler_Control;
    using NewsSystem.Web.Models;

    public partial class EditCategories : Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.context.Categories.OrderBy(c => c.Name);
        }

        public void ListViewCategories_DeleteItem(int CategoryId)
        {
            var category = this.context.Categories.Find(CategoryId);
            
            var categoryArticles = category.Articles;
            foreach (var article in categoryArticles.ToList())
            {
                this.context.Articles.Remove(article);
            }

            this.context.Categories.Remove(category);
            this.TryUpdateOrShowMessage(new NotificationMessage()
            {
                Text = "Category was deleted successfully.",
                AutoHide = false,
                Type = MessageType.Success
            });
        }

        public void ListViewCategories_UpdateItem(int categoryId)
        {
            var category = this.context.Categories.Find(categoryId);
            if (category == null)
            {
                this.ModelState.AddModelError("", String.Format("Item with id {0} was not found", categoryId));
                return;
            }

            this.TryUpdateModel(category);

            if (string.IsNullOrEmpty(category.Name))
            {
                ErrorSuccessNotifier.AddMessage(new NotificationMessage()
                {
                    Text = "Cannot create category with invalid name.",
                    AutoHide = false,
                    Type = MessageType.Warning
                });
                return;
            }

            var categoryNameToLower = category.Name.ToLower();
            var hasCategoryAlready = this.context.Categories.Any(c => c.Name.ToLower() == categoryNameToLower);
            if (hasCategoryAlready)
            {
                ErrorSuccessNotifier.AddMessage(new NotificationMessage()
                {
                    Text = string.Format(@"Category with name ""{0}"" already exists!", category.Name),
                    AutoHide = false,
                    Type = MessageType.Warning
                });
                return;
            }

            if (this.ModelState.IsValid)
            {
                this.TryUpdateOrShowMessage(new NotificationMessage()
                {
                    Text = "Category was updated successfully.",
                    AutoHide = false,
                    Type = MessageType.Success
                });
            }
        }

        public void ListViewCategories_InsertItem()
        {
            var category = new Category();
            this.TryUpdateModel(category);

            if (string.IsNullOrEmpty(category.Name))
            {
                ErrorSuccessNotifier.AddMessage(new NotificationMessage()
                {
                    Text = "Cannot create category with invalid name.",
                    AutoHide = false,
                    Type = MessageType.Warning
                });
                return;
            }

            var categoryNameToLower = category.Name.ToLower();
            var hasCategoryAlready = this.context.Categories.Any(c => c.Name.ToLower() == categoryNameToLower);
            if (hasCategoryAlready)
            {
                ErrorSuccessNotifier.AddMessage(new NotificationMessage()
                {
                    Text = string.Format(@"Category with name ""{0}"" already exists!", category.Name),
                    AutoHide = false,
                    Type = MessageType.Warning
                });
                return;
            }

            if (this.ModelState.IsValid)
            {
                this.context.Categories.Add(category);
                this.TryUpdateOrShowMessage(new NotificationMessage()
                {
                    Text = "Category was created successfully.",
                    AutoHide = false,
                    Type = MessageType.Success
                });
            }
        }

        private void TryUpdateOrShowMessage(NotificationMessage msg)
        {
            try
            {
                this.context.SaveChanges();
                ErrorSuccessNotifier.AddMessage(msg);
            }
            catch (Exception)
            {
                ErrorSuccessNotifier.AddMessage(new NotificationMessage()
                {
                    Text = "Unhandled exception: something bad happened.",
                    AutoHide = false,
                    Type = MessageType.Error
                });
            }
        }
    }
}