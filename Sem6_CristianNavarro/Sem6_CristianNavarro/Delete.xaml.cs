using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;

namespace Sem6_CristianNavarro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Delete : ContentPage
    {
        public Delete()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var url = "http://192.168.1.60/mobiles/post.php";
                HttpClient cliente = new HttpClient();
                var id = txtEliminar.Text;
                var uri = new Uri(string.Format(url + "?codigo=" + id));
                var response = await cliente.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("alerta", "Eliminado correctamente: ", "ok");

                }
                else
                {
                    await DisplayAlert("alerta", "ERROR:: ", "ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }
    }
}