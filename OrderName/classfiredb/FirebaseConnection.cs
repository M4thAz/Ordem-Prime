using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Protobuf;
using Org.BouncyCastle.Crypto;

namespace OrderName.classfiredb
{
    public class FirebaseConnection
    {
        public static string passFirebase = "TdZfDbN7JPOUpsHEiE4M3JtTXdA0JnF17m4oHTHv";
        FirebaseClient Client = new FirebaseClient("https://ordername-2e429-default-rtdb.europe-west1.firebasedatabase.app/",
        new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(passFirebase) });

        public async Task<bool> RegisterUser(string username)
        {
            try
            {
                //client.Child serve para fazer a localização da tabela na base de dados que foi linkada ao Client;
                await Client.Child("Clients").PostAsync(new Clients()
                {
                    User = username
                });

                return true;

            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Clients>> ListaClientes()
        {
            //código que buscar os dados da DB e manda para a fila da aplicação
            //client.child = conexão da base de dados dessa pastaa que busca a classe Clients da classfiredb
            //onceasync em diante puxa os dados da tabela "user" e o transforma em lista.
            var listagemClientes = (await Client.Child("Clients").OnceAsync<Clients>()).Select(receptor => new Clients()
            {
                User = receptor.Object.User
            }).ToList();
            return listagemClientes;
        }


        public async Task<bool> DeleteClient(string nomeC)
        {

            try
            {
                var locate = (await Client.Child("Clients").OnceAsync<Clients>()).Where(location => location.Object.User == nomeC).FirstOrDefault();

                await Client.Child("Clients").Child(locate.Key).DeleteAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAllClients()
        {
            try
            {
                var locateClients = (await Client.Child("Clients").OnceAsync<Clients>());

                await Client.Child("Clients").DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        }

    }

