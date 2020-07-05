using System.Collections.Generic;
using System.Linq;
using industry9.Server.Middleware.Wrappers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace industry9.Server.Middleware.Extensions
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<ValidationError> AllErrors(this ModelStateDictionary modelState)
        {
            return modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage))).ToList();
        }
    }
}
