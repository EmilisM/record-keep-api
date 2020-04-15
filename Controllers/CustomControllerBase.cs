using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using record_keep_api.DBO;

namespace record_keep_api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected static Expression<Func<UserData, bool>> UserIdPredicate(string subjectId)
        {
            return u => u.Id.ToString().Equals(subjectId);
        }
    }
}