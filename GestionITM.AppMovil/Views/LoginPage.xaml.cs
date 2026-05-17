using GestionITM.AppMovil.ViewModels;

namespace GestionITM.AppMovil.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
