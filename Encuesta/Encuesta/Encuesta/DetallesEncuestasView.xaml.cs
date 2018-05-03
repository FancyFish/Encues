using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encuesta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesEncuestasView : ContentPage
    {
        private readonly string[] equipos = { "Colombia", "Perú", "Brasil", "Rusia", "Alemania", "Argentina" };
		public DetallesEncuestasView ()
		{
			InitializeComponent ();
            BtnAgregarEqu.Clicked += BtnAgregarEqu_Clicked;
            BtnAceptar.Clicked += BtnAceptar_Clicked;
		}

        private async void BtnAceptar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNombre.Text) || string.IsNullOrEmpty(LbEquipoFav.Text))
            {
                await DisplayAlert("Datos incompletos", "Por favor diligencie todos los campos", "Aceptar");
                return;
            }
            var quiz = new Encuesta()
            {
                Nombre = EntNombre.Text,
                EquipoFavorito = LbEquipoFav.Text,
                FechaNacimiento= DtNacim.Date
            };
            MessagingCenter.Send((ContentPage)this, 
                Mensajes.EncuestaCompleta,
                quiz);
            await Navigation.PopAsync();
        }

        private async void BtnAgregarEqu_Clicked(object sender, EventArgs e)
        {
            var equipoFav = await DisplayActionSheet(Literales.tituloEqFavorito, null, null, equipos);
            if (!string.IsNullOrEmpty(equipoFav))
            {
                LbEquipoFav.Text = equipoFav;
            }
            
        }
    }
}