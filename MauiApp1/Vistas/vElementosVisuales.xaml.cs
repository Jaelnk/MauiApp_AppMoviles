using System.Threading.Tasks;

namespace MauiApp1.Vistas;

public partial class vElementosVisuales : ContentPage
{
    public vElementosVisuales()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (studentPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Selecciona un estudiante.", "OK");
                return;
            }

            double seg1 = ValidarNota(notaSeg1Entry.Text, "Nota Seguimiento 1");
            double exam1 = ValidarNota(examen1Entry.Text, "Examen 1");
            double seg2 = ValidarNota(notaSeg2Entry.Text, "Nota Seguimiento 2");
            double exam2 = ValidarNota(examen2Entry.Text, "Examen 2");

            double parcial1 = (seg1 * 0.3) + (exam1 * 0.2);
            double parcial2 = (seg2 * 0.3) + (exam2 * 0.2);
            double final = parcial1 + parcial2;

            string estado = final >= 7 ? "APROBADO"
                          : final >= 5 ? "COMPLEMENTARIO"
                          : "REPROBADO";

            string mensaje = $"Nombre: {studentPicker.SelectedItem}\n" +
                             $"Fecha: {fechaPicker.Date:dd/MM/yyyy}\n" +
                             $"Nota Parcial 1: {parcial1:F2}\n" +
                             $"Nota Parcial 2: {parcial2:F2}\n" +
                             $"Nota Final: {final:F2}\n" +
                             $"Estado: {estado}";

            await DisplayAlert("Resultado", mensaje, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private double ValidarNota(string input, string campo)
    {
        if (!double.TryParse(input, out double valor) || valor < 0 || valor > 10)
        {
            throw new Exception($"El valor de {campo} debe ser un número entre 0 y 10.");
        }
        return valor;
    }
}