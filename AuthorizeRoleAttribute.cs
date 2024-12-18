/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UM_System.Filters
{
    public class AuthorizeRoleAttribute : Attribute, IActionFilter
    {
        private readonly string _role;

        public AuthorizeRoleAttribute(string role)
        {
            _role = role;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = context.HttpContext.Session.GetString("Role");

            // Redirect if the role doesn't match or user is not authenticated
            if (string.IsNullOrEmpty(userRole) || userRole != _role)
            {
                context.Result = new RedirectToRouteResult(new { controller = "Auth", action = "AccessDenied" });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No-op
        }
    }
}
*/