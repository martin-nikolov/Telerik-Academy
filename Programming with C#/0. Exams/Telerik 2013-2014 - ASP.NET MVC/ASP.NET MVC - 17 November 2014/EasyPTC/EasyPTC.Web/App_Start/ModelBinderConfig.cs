namespace EasyPTC.Web
{
    using EasyPTC.Web.Infrastructure.ModelBinders;
    using System.Web.Mvc;

    public class ModelBinderConfig
    {
        internal static void RegisterModelBinders(ModelBinderProviderCollection modelBinderProviderCollection)
        {
            modelBinderProviderCollection.Add(new EntityModelBinderProvider());
        }
    }
}