namespace EasyPTC.Web.Infrastructure.ModelBinders
{
    using EasyPTC.Data.Contracts;
    using EasyPTC.Models;
    using System;
    using System.Web.Mvc;

    public class EntityModelBinder<TEntity> : IModelBinder
        where TEntity : class, IEntity
    {
        private IRepository<TEntity> repository;

        public EntityModelBinder(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = bindingContext.ValueProvider.GetValue("id").AttemptedValue;
                        
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            int id;
            if (int.TryParse(value.ToString(), out id))
            {
                value = id;
            }

            var model = this.repository.GetById(value);

            return model;
        }
    }
}