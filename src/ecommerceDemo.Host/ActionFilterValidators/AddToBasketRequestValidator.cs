using System.Threading.Tasks;
using Infrastructure.Service;
using Infrastructure.Service.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using static ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class AddToBasketRequestValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            
        }
    }
}