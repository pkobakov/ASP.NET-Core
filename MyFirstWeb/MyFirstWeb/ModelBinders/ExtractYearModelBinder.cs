using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace MyFirstWeb.ModelBinders
{
    public class ExtractYearModelBinder : IModelBinder

    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("Date").FirstValue;

            if (DateTime.TryParse(value, out var valueAsDatetime))
            {
                bindingContext.Result = ModelBindingResult.Success(valueAsDatetime.Year);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask; 
              
        }
    }
}
