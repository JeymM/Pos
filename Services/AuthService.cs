using Pos.Auth.Api.Models.Command;
using Pos.Auth.Api.Models.ViewModels;
using Pos.Auth.Api.Repository;
using System.Text.RegularExpressions;

namespace Pos.Auth.Api.Service
{
    public class AuthService
    {
        public async Task <AuthViewModel> CreatedUserServiceAsync(RegisterCommand registerCommand) 
        {
            bool hasEmptyFields = IsNullOrEmpty(registerCommand.FirstName) ||
                IsNullOrEmpty(registerCommand.LastName) ||
                IsNullOrEmpty(registerCommand.Email) ||
                IsNullOrEmpty(registerCommand.Identification) ||
                IsNullOrEmpty(registerCommand.Password);
            bool IsLegalAge = registerCommand.Age < 18 || registerCommand.Age > 120;
            bool IsValidEmail = Regex.Match(registerCommand.Email, "^[a-z0-9]+[@]{1}[a-z0-9.]+$").Success;

            //Validaciones
            if (hasEmptyFields)
            {
                throw new Exception("Hay campos obligatorios sin diligenciar");
            }

            if(IsLegalAge)
            {
                throw new Exception("El campo debe estar entre el rango de 18 a 120 ");
            }
            if(IsValidEmail is false)
            {
                throw new Exception("El email debe cumplir con los criterios establecidos");
            }
            UserRepository authRepository = new UserRepository();
            bool isCreatedUser=await authRepository.CreatedAsync(registerCommand);
            if(isCreatedUser is false) 
            {
                throw new Exception("Ha ocurrido un error para crear el usuario");
            }
            return new AuthViewModel
            {
                AccessToken = "",
                ExpireAt=""
            };
        }


        public bool IsNullOrEmpty(string text)
        {
            return text == null || text.Trim().Length == 0;
        }

    }
}
