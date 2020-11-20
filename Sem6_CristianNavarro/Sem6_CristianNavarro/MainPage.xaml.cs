using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sem6_CristianNavarro
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.60/mobiles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Sem6_CristianNavarro.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }
        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Sem6_CristianNavarro.Ws.Datos> posts = JsonConvert.DeserializeObject<List<Sem6_CristianNavarro.Ws.Datos>>(content);
                _post = new ObservableCollection<Sem6_CristianNavarro.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
               await DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }
        }


        private async void btnGet_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new InsertarDato());
            //  await Navigation.PopAsync();


        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Delete());


        }

        
        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Sem6_CristianNavarro.Ws.Datos)e.SelectedItem;
            var id = Convert.ToString(item.codigo);
            var nombre = item.nombre;
            var apellido = item.apellido;
            var edad = Convert.ToString(item.edad);

            await Navigation.PushAsync(new Put(id, nombre, apellido, edad));
        }
    }
}
