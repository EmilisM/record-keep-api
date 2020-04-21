using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using record_keep_api.DBO;
using record_keep_api.Error;
using record_keep_api.Services;

namespace record_keep_api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected static Expression<Func<UserData, bool>> UserIdPredicate(string subjectId)
        {
            return u => u.Id.ToString().Equals(subjectId);
        }

        protected void CustomValidation(object model = null)
        {
            if (model != null && TryValidateModel(model) || model == null && ModelState.IsValid)
            {
                return;
            }

            var errorList =
                ModelState.ToDictionary(pair => pair.Key.ToCamelCase(),
                    pair => pair.Value.Errors.Select(e => e.ErrorMessage).ToArray());

            throw new HttpResponseException(errorList, HttpStatusCode.BadRequest);
        }
    }
}