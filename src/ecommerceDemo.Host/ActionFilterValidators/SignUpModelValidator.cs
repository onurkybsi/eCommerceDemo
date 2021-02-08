using System.Threading.Tasks;
using ecommerceDemo.Host.Model;
using Infrastructure.Service;
using Infrastructure.Service.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using static ecommerceDemo.Host.Common.Constants;

namespace ecommerceDemo.Host
{
    public class SignUpModelValidator : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            SignUpModel signUpModel = RequestModelActionFilterValidatorHelper.GetRequestModel<SignUpModel>(filterContext);

            ValidationResult validationResult = await ValidateSignUpModel(signUpModel);

            await RequestModelActionFilterValidatorHelper.FinalizeActionFilterValidator(validationResult, filterContext, next);
        }

        private async Task<ValidationResult> ValidateSignUpModel(SignUpModel signUpModel)
        {
            ValidationResult validationResult = new ValidationResult();

            CheckHasDefaultValue(validationResult, signUpModel);
            if (!validationResult.IsValid)
                return validationResult;

            CheckPasswordAvailability(validationResult, signUpModel.Password);
            if (!validationResult.IsValid)
                return validationResult;

            await CheckWhetherUserExist(validationResult, signUpModel.Email);
            if (!validationResult.IsValid)
                return validationResult;

            return validationResult;
        }

        private void CheckHasDefaultValue(ValidationResult validationResult, SignUpModel signUpModel)
        {
            if (signUpModel is null)
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.ValueCanNotBeNull}: {nameof(SignUpModel)}";
            }
            else if (string.IsNullOrEmpty(signUpModel.Email) || string.IsNullOrWhiteSpace(signUpModel.Email))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(SignUpModel.Email)}";
            }
            else if (string.IsNullOrEmpty(signUpModel.Password) || string.IsNullOrWhiteSpace(signUpModel.Password))
            {
                validationResult.IsValid = false;
                validationResult.Message = $"{ValidationMessages.StringCanNotBeNullEmptyOrWhiteSpace}: {nameof(SignUpModel.Password)}";
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