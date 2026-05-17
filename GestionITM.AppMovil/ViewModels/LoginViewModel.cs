using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionITM.AppMovil.Services;

namespace GestionITM.AppMovil.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly ApiService _api;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        public LoginViewModel(ApiService api)
        {
            _api = api;
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            ErrorMessage = string.Empty;
            var token = await _api.LoginAsync(Username, Password);

            if (token is null)
            {
                ErrorMessage = "Usuario o contraseña incorrectos.";
                return;
            }

            await SecureStorage.SetAsync("jwt_token", token);
            await Shell.Current.GoToAsync("//CatalogoPage");
        }
    }
}
