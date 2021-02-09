using System.Threading.Tasks;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using static ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class SignInModelValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            SignInModel signInModel = RequestModelActionFilterValidatorHelper.GetRequestModel<SignInModel>(filterContext);

            ValidationResult validationResult = ValidateSignInModel(signInModel);

            await RequestModelActionFilterValidatorHelper.FinalizeActionFilterValidator(validationResult, filterContext, next);
        }

        private ValidationResult ValidateSignInModel(SignInModel signInModel)
        {
            ValidationResult validationResult = new ValidationResult();

            CheckHasDefaultValue(validationResult, signInModel);
            if (!validationResult.IsValid)
                return validationResult;

            CheckPasswordAvailability(validationResult, signInModel.Password);
            if (!validationResult.IsValid)
                return validationResult;

            return validationResult;
        }

        private void CheckHasDefaultValue(ValidationResult validationResult, SignInModel signInModel)
        {
            if (signInModel is null)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.ValueCanNotBeNull}: {nameof(SignInModel)}";
            }
            else if (string.IsNullOrEmpty(signInModel.Email) || string.IsNullOrWhiteSpace(signInModel.Email))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(SignInModel.Email)}";
            }
            else if (string.IsNullOrEmpty(signInModel.Password) || string.IsNullOrWhiteSpace(signInModel.Password))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(SignInModel.Password)}";
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