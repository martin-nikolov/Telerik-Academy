namespace EasyPTC.Web.Infrastructure.ModelBinders
{
    using EasyPTC.Data.Contracts;
    using System;
    using System.Web.Mvc;

    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (!typeof(IEntity).IsAssignableFrom(modelType))
            {
                return null;
            }

            var modelBinderType = typeof(EntityModelBinder<>).MakeGenericType(modelType);

            var modelBinder = ObjectFactory.GetInstance(modelBinderType);

            return (IModelBinder)modelBinder;
        }
    }
}