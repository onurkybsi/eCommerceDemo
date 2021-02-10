using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using Constants = ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class CreateNewProductRequestValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            => await RequestModelActionFilterValidatorHelper.CompleteActionFilterValidatorProcess<CreateNewProductRequest>(new List<Action<CreateNewProductRequest, ValidationResult>>
            {
                CheckHasDefaultValue
            }, filterContext, next);

        private void CheckHasDefaultValue(CreateNewProductRequest createNewProductRequest, ValidationResult validationResult)
        {
            if (createNewProductRequest is null)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.ValueCanNotBeNull}: {nameof(createNewProductRequest)}";
            }
            else if (string.IsNullOrEmpty(createNewProductRequest.Name))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(createNewProductRequest.Name)}";
            }
            else if (string.IsNullOrWhiteSpace(createNewProductRequest.CategoryName))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(createNewProductRequest.CategoryName)}";
            }
            else if (createNewProductRequest.Price <= 0)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.ValueCanNotBeLessThanZero}: {nameof(createNewProductRequest.Price)}";
            }
        }
    }
}