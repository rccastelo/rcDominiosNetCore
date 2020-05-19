using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Services
{
  public class AutenticaService
    {
        private string enderecoServico = "http://localhost:5500/";
        private string nomeServico = "Autentica";
        private HttpClient httpClient;

        public AutenticaService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
        }
        
        public async Task<string> Autorizar()
        {
            string autorizacao = null;
            HttpResponseMessage resposta = null;
            UsuarioRequest usuarioRequest = new UsuarioRequest() { Apelido = "admin", Senha = "senha" };
            
            try {
                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", usuarioRequest);

                if (resposta.IsSuccessStatusCode) {
                    autorizacao = await resposta.Content.ReadAsStringAsync();
                }
            } catch {
                autorizacao = null;
            } finally {
                resposta = null;
            }

            return autorizacao;
        }
    }
}
