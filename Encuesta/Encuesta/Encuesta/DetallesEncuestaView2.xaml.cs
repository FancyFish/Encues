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
    public partial class DetallesEncuestaView : ContentPage
    {
        private readonly string[] equipos = {"colombia", "Mexico", "Costa Rica" };
		public DetallesEncuestaView ()
		{
			InitializeComponent ();
            BtAgregarEq.Clicked += BtAgregarEq_Clicked;
            BtnAccept.Clicked += BtnAccept_Clicked;
		}

        private async void BtnAccept_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EnNombre.Text) || string.IsNullOrEmpty(DtNac.ToString()) || string.IsNullOrEmpty(LbEquipoFav.Text)) {
                await DisplayAlert("Datos incompletos", "pro favor complete todos los campos", "ok");
                return;
            }
            var encuesta = new Encuesta() {
                EquipoFavorito = LbEquipoFav.Text,
                Nombre = EnNombre.Text,
                FechaNacimiento=DtNac.Date
                
            };
            MessagingCenter.Send((ContentPage)this,Mensajes.EncuestaCompleta , encuesta);
            await Navigation.PopAsync();
        }

        private async void BtAgregarEq_Clicked(object sender, EventArgs e)
        {
            var equipoFav = await DisplayActionSheet(Literales.tituloEqFavorito, null, null, equipos);

            LbEquipoFav.Text = (!string.IsNullOrEmpty(equipoFav)?equipoFav:"");
        }
    }
}