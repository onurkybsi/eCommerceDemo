using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using Constants = ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class CreateCategoryRequestValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            => await RequestModelActionFilterValidatorHelper.CompleteActionFilterValidatorProcess<CreateCategoryRequest>(
                new List<Action<CreateCategoryRequest, ValidationResult>>
            {
                CheckHasDefaultValue
            }, filterContext, next);

        private void CheckHasDefaultValue(CreateCategoryRequest createNewCategoryRequest, ValidationResult validationResult)
        {
            if (createNewCategoryRequest is null)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.ValueCanNotBeNull}: {nameof(createNewCategoryRequest)}";
            }
            else if (string.IsNullOrEmpty(createNewCategoryRequest.Name))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(createNewCategoryRequest.Name)}";
            }
        }
    }
}