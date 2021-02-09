using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;
using Constants = ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class AddProductToBasketValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            => await RequestModelActionFilterValidatorHelper.CompleteActionFilterValidatorProcess<AddProductToBasketRequest>(new List<Action<AddProductToBasketRequest, ValidationResult>>
            {
                CheckHasDefaultValue, CheckStringIsObjectId
            }, filterContext, next);

        private void CheckHasDefaultValue(AddProductToBasketRequest addProductToBasketRequest, ValidationResult validationResult)
        {
            if (addProductToBasketRequest is null)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.ValueCanNotBeNull}: {nameof(addProductToBasketRequest)}";
            }
            else if (string.IsNullOrEmpty(addProductToBasketRequest.BasketId))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(addProductToBasketRequest.BasketId)}";
            }
            else if (string.IsNullOrWhiteSpace(addProductToBasketRequest.ProductId))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(addProductToBasketRequest.ProductId)}";
            }
        }

        private void CheckStringIsObjectId(AddProductToBasketRequest addProductToBasketRequest, ValidationResult validationResult)
        {
            if (!ObjectId.TryParse(addProductToBasketRequest.BasketId, out _))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.IdIsInvalid}: {nameof(addProductToBasketRequest.BasketId)}";
            }
            else if (!ObjectId.TryParse(addProductToBasketRequest.ProductId, out _))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{Constants.ValidationMessages.IdIsInvalid}: {nameof(addProductToBasketRequest.ProductId)}";
            }
        }
    }
}