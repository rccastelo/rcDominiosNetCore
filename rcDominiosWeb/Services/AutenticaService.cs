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
        
        public async Task<string> Autorizar(UsuarioRequest usuario)
        {
            string autorizacao = null;
            HttpResponseMessage resposta = null;
            HttpContent conteudoHttp = null;
            
            try {
                conteudoHttp = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "text/json");

                resposta = await httpClient.PostAsync($"{nomeServico}", conteudoHttp);

                if (resposta.IsSuccessStatusCode) {
                    autorizacao = await resposta.Content.ReadAsStringAsync();
                }
            } catch {
                autorizacao = null;
            } finally {
                resposta = null;
                conteudoHttp = null;
            }

            return autorizacao;
        }
    }
}
