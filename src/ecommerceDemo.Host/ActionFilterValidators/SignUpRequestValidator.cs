using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using static ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class SignUpRequestValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            SignUpRequest signUpRequest = RequestModelActionFilterValidatorHelper.GetRequestModel<SignUpRequest>(filterContext);

            ValidationResult validationResult = ValidateSignUpRequest(signUpRequest);

            await RequestModelActionFilterValidatorHelper.FinalizeActionFilterValidator(validationResult, filterContext, next);
        }

        private ValidationResult ValidateSignUpRequest(SignUpRequest signUpRequest)
        {
            ValidationResult validationResult = new ValidationResult();

            CheckHasDefaultValue(validationResult, signUpRequest);
            if (!validationResult.IsValid)
                return validationResult;

            CheckPasswordAvailability(validationResult, signUpRequest.Password);
            if (!validationResult.IsValid)
                return validationResult;

            return validationResult;
        }

        private void CheckHasDefaultValue(ValidationResult validationResult, SignUpRequest signUpRequest)
        {
            if (signUpRequest is null)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.ValueCanNotBeNull}: {nameof(SignUpRequest)}";
            }
            else if (string.IsNullOrEmpty(signUpRequest.Email) || string.IsNullOrWhiteSpace(signUpRequest.Email))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(SignUpRequest.Email)}";
            }
            else if (string.IsNullOrEmpty(signUpRequest.Password) || string.IsNullOrWhiteSpace(signUpRequest.Password))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(SignUpRequest.Password)}";
            }
        }

        private void CheckPasswordAvailability(ValidationResult validationResult, string password)
        {
            if (password.Length < 4)
            {
                validationResult.IsValid = false;
                validationResult.Message = ValidationMessages.PasswordMustBeMoreThanFourCharacters;
            }
        }
    }
}