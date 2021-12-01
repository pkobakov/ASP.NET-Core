using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyFirstWeb.ModelBinders
{
    //!!!!!every BinderProvider must be inserted in the services container (StartUp)!!!!!
    public class ExtractYearModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context?.Metadata?.Name?.ToLower() == "year"
                && context?.Metadata?.ModelType == typeof(int)) 
            { 
               return new ExtractYearModelBinder();
            
            }
            return null;
        }
    }
}
