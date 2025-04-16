using System.Threading.Tasks;

namespace MauiApp1.Vistas;

public partial class vElementosVisuales : ContentPage
{
	public vElementosVisuales()
	{
		InitializeComponent();
	}


    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        if (paises.SelectedItem != null)
        {
            string paisSeleccionado = paises.SelectedItem.ToString();
            await DisplayAlert("Pa�s seleccionado", paisSeleccionado, "OK");
        }
        else
        {
            await DisplayAlert("Advertencia", "Por favor selecciona un pa�s", "OK");
        }
    }
}