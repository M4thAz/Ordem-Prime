using Google.Protobuf;
using Microsoft.Win32.SafeHandles;
using OrderName.classfiredb;
using OrderName.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OrderName
{
    public partial class MainPage : TabbedPage
    {

        //ClassDB.DataBaseConnection conn = new ClassDB.DataBaseConnection();
        //ClassDB.NewDataBaseConnetion connectiontest = new ClassDB.NewDataBaseConnetion();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            LoadList();
        }

        public async void LoadList()
        {
            var list = new FirebaseConnection();
            var rowList = await list.ListaClientes();

            CVList.ItemsSource = rowList;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TXTNome.Text)) {

                    var acessoCliente = new FirebaseConnection();
                    bool criarAcesso = await acessoCliente.RegisterUser(TXTNome.Text);
                    if (criarAcesso)
                    {
                        await DisplayAlert("Seja bem vindo! ", "Aguarde ser chamado " + TXTNome.Text + "!", "Confirmar");
                        LoadList();
                        return;
                    }
                    else
                    {
                        await DisplayAlert("Falha!", "a conexão não está funcionando", "verifique com o administrador!");
                    }
                }
                else {

                    await DisplayAlert("Campo vazio!", "Digite seu nome por favor!", "Confirmar");
                }
            }
            catch
            {
            }

        }

        private void BTN_ROW_Clicked(object sender, EventArgs e)
        {
            //transforma o evento do botão para seguir a outra página
            Navigation.PushAsync(new Pages.Row());
            
        }

        private async void SWDelete_Invoked(object sender, EventArgs e)
        {
            var search = (sender as SwipeItem)?.BindingContext as Clients;
            var item = search.User;

            try
            {

                var DeleteService = new FirebaseConnection();
                var confirm = await DisplayAlert("Aviso", "Tem certeza que quer apagar o cliente " + search.User.ToString() + "?", "Sim", "Não");

                string result = await DisplayPromptAsync("Digite o código para apagar", "", "Confirmar");
                int code = 4560;

                if (result == code.ToString())
                {
                    if (confirm)
                    {
                        var delete = await DeleteService.DeleteClient(item);
                        if (delete)
                        {
                            await DisplayAlert("pronto", "contato apagado", "confirmar");
                            LoadList();

                            return;
                        }
                        else
                        {
                            await DisplayAlert("erro if(delete)", "try again", "Confirmar");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    await DisplayAlert("Código errado!", "Insira novamente o código", "Confirmar");
                    return;
                }
            }
            catch
            {
                await DisplayAlert("erro catch", "try again", "Confirmar");
            }
        }

    }

}