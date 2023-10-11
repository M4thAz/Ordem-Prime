using OrderName.ClassDB;
using OrderName.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OrderName
{
    public partial class MainPage : ContentPage
    {

        ClassDB.DataBaseConnection conn = new ClassDB.DataBaseConnection();
        ClassDB.NewDataBaseConnetion connectiontest  = new ClassDB.NewDataBaseConnetion();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            //try
            //{
            //    connectiontest.TestOnConection();
            //}
            //catch (Exception ex) {

            //}
            DisplayAlert("Seja bem vindo! ", "Aguarde ser chamado " + TXTNome.Text + "!", "Confirmar");

            try
            {
                ClassDB.DataBaseConnection.LinkDataBase();
                conn.ConnectionOn();
                LbEvent.Text = "conexão ok";
                conn.ConectionOF();
            }
            catch
            {
                LbEvent.Text = "conection of";
            }
        }

        private void BTN_ROW_Clicked(object sender, EventArgs e)
        {
            //transforma o evento do botão para seguir a outra página
            Navigation.PushAsync(new Pages.Row());
        }

        private void BTNEventTest_Pressed(object sender, EventArgs e)
        {
            //LbEvent.Text = "Conexão ok";
        }

        /*/private void BTNEventTest_Pressed(object sender, EventArgs e)
        //{
        //    //puxa o evento da label passando um texto enquanto segura o botao
        //    LbEvent.Text = "Holding!";
        //}

        private void BTNEventTest_Released(object sender, EventArgs e)
        {
            //puxa o evento da label quando o botão é solto
            LbEvent.Text = "Umpressed";
        }*/
    }
}
