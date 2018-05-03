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
	public partial class EncuestasView : ContentPage
	{
		public EncuestasView ()
		{
			InitializeComponent();
            BtnAdd.Clicked += BtnAdd_Clicked1;
            MessagingCenter.Subscribe<ContentPage, Encuesta>
                (this, Mensajes.EncuestaCompleta, (sender, args) => {
                    Stack.Children.Add(new Label() {
                        Text = args.ToString()
                    });
                }
                );

		}

        private async void BtnAdd_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetallesEncuestasView());
        }

        
    }
}