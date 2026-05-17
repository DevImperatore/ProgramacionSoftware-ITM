using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionITM.AppMovil.Models;
using GestionITM.AppMovil.Services;
using System.Collections.ObjectModel;
using System.Net;

namespace GestionITM.AppMovil.ViewModels
{
    public partial class CatalogoViewModel : ObservableObject
    {
        private readonly ApiService _api;
        private int _paginaActual = 1;
        private int _totalItems = 0;
        private const int PageSize = 10;

        [ObservableProperty]
        private ObservableCollection<CursoDto> cursos = new();

        [ObservableProperty]
        private bool isBusy = false;

        public CatalogoViewModel(ApiService api)
        {
            _api = api;
        }

        [RelayCommand]
        public async Task CargarCursosAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            _paginaActual = 1;
            Cursos.Clear();
            await CargarPaginaAsync();

            IsBusy = false;
        }

        [RelayCommand]
        public async Task CargarMasAsync()
        {
            if (IsBusy || Cursos.Count >= _totalItems) return;
            IsBusy = true;

            _paginaActual++;
            await CargarPaginaAsync();

            IsBusy = false;
        }

        private async Task CargarPaginaAsync()
        {
            var resultado = await _api.GetCursosPaginadoAsync(_paginaActual, PageSize);
            if (resultado is null) return;

            _totalItems = resultado.TotalItems;
            foreach (var curso in resultado.Items)
                Cursos.Add(curso);
        }

        [RelayCommand]
        public async Task MatricularseAsync(CursoDto curso)
        {
            // estudianteId hardcodeado en 1 para demo — en produccion vendria del token
            var response = await _api.MatricularAsync(1, curso.Id);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                await Shell.Current.DisplayAlert("Sin cupos", "No hay cupos disponibles en este curso.", "OK");
                return;
            }

            if (response.IsSuccessStatusCode)
                await Shell.Current.DisplayAlert("Listo", $"Te matriculaste en {curso.Nombre}.", "OK");
        }
    }
}
