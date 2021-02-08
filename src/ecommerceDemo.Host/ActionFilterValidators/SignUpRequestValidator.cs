using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using Infrastructure.Service;
using Infrastructure.Service.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using static ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class SignUpRequestValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            SignUpRequest signUpRequest = RequestModelActionFilterValidatorHelper.GetRequestModel<SignUpRequest>(filterContext);

            ValidationResult validationResult = await ValidateSignUpRequest(signUpRequest);

            await RequestModelActionFilterValidatorHelper.FinalizeActionFilterValidator(validationResult, filterContext, next);
        }

        private async Task<ValidationResult> ValidateSignUpRequest(SignUpRequest signUpRequest)
        {
            ValidationResult validationResult = new ValidationResult();

            CheckHasDefaultValue(validationResult, signUpRequest);
            if (!validationResult.IsValid)
                return validationResult;

            CheckPasswordAvailability(validationResult, signUpRequest.Password);
            if (!validationResult.IsValid)
                return validationResult;

            await CheckWhetherUserExist(validationResult, signUpRequest.Email);
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

        private async Task CheckWhetherUserExist(ValidationResult validationResult, string email)
        {
            validationResult.IsValid = (await Startup.GetInstance<Service.IUserService>().GetUser(u => u.Email == email)) is null;
            validationResult.Message = validationResult.IsValid ? string.Empty : ValidationMessages.UserAlreadyExists;
        }
    }
}