using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace record_keep_api.Error
{
    public class HttpResponseActionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.Exception is HttpResponseException exception))
            {
                return;
            }

            context.Result = new JsonResult(exception.Value)
            {
                StatusCode = (int) exception.Status,
            };

            context.ExceptionHandled = true;
        }
    }
}