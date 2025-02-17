﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Sem6_CristianNavarro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Put : ContentPage
    {
        private const string Url = "http://192.168.1.60/mobiles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Sem6_CristianNavarro.Ws.Datos> _post;
        public Put(string id, string nombre, string apellido, string edad)
        {
            InitializeComponent();
            txtCodigo.Text = id.ToString();
            txtNombre.Text = nombre.ToString();
            txtApellido.Text = apellido.ToString();
            txtEdad.Text = edad.ToString();
            if (txtCodigo.Text == "")
            {
                DisplayAlert("Alerta", "Es necesario seleccionar un usuario para realizar una operacion", "ok");
            }
        }
     
        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("codigo", txtCodigo.Text);
                    parametros.Add("nombre", txtNombre.Text);
                    parametros.Add("apellido", txtApellido.Text);
                    parametros.Add("edad", txtEdad.Text);

                    cliente.UploadValues(Url, "PUT", cliente.QueryString = parametros);
                }
                await DisplayAlert("Alerta", "Actualizado correctamente", "ok");
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }
            
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("codigo", txtCodigo.Text);

                    cliente.UploadValues(Url, "DELETE", cliente.QueryString = parametros);

                }
                await DisplayAlert("Alerta", "Eliminacion correcta", "ok");
                await Navigation.PushAsync(new MainPage());



            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}