using GestionITM.AppMovil.ViewModels;

namespace GestionITM.AppMovil.Views
{
    public partial class CatalogoPage : ContentPage
    {
        public CatalogoPage(CatalogoViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
