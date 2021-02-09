using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using Infrastructure.Service;
using Infrastructure.Service.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;
using Constants = ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class AddToBasketRequestValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            => await RequestModelActionFilterValidatorHelper.CompleteActionFilterValidatorProcess<AddToBasketRequest>(new List<Action<AddToBasketRequest, ValidationResult>>
            {
                CheckHasDefaultValue, CheckStringIsObjectId
            }, filterContext, next);

        private void CheckHasDefaultValue(AddToBasketRequest addToBasketRequest, ValidationResult validationResult)
        {
            if (addToBasketRequest is null)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.ValueCanNotBeNull}: {nameof(addToBasketRequest)}";
            }
            else if (string.IsNullOrEmpty(addToBasketRequest.BasketId))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(addToBasketRequest.BasketId)}";
            }
            else if (string.IsNullOrWhiteSpace(addToBasketRequest.ProductId))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(addToBasketRequest.ProductId)}";
            }
        }

        private void CheckStringIsObjectId(AddToBasketRequest addToBasketRequest, ValidationResult validationResult)
        {
            if (!ObjectId.TryParse(addToBasketRequest.BasketId, out _))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.IdIsInvalid}: {nameof(addToBasketRequest.BasketId)}";
            }
            else if (!ObjectId.TryParse(addToBasketRequest.ProductId, out _))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.IdIsInvalid}: {nameof(addToBasketRequest.ProductId)}";
            }
        }
    }
}