using System;
using CustomerSystm.Domain.DTOModels.BaseDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerSystem.Infrastructure.Filters
{
	public class ValidationFilter:IAsyncActionFilter
	{
		public ValidationFilter()
		{
		}

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value!.Errors.Any())
                    .Select(s => new ErrorResponse(_key: s.Key, _values: s.Value!.Errors.Select(es => es.ErrorMessage).ToList()));
                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}

