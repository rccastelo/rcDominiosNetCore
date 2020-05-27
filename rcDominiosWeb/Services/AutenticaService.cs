using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class AutenticaService
    {
        private string enderecoServico = "http://localhost:5500/";
        private string nomeServico = "Autentica";
        private readonly HttpClient httpClient;

        public AutenticaService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
        }
        
        public async Task<AutenticaTransfer> Autenticar(AutenticaTransfer autenticaTransfer)
        {
            HttpResponseMessage resposta = null;
            AutenticaTransfer autentica = null;
            string mensagemRetono = null;
            
            try {
                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", autenticaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    autentica = resposta.Content.ReadAsAsync<AutenticaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    autentica = resposta.Content.ReadAsAsync<AutenticaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    autentica = resposta.Content.ReadAsAsync<AutenticaTransfer>().Result;
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Autenticar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    autentica = new AutenticaTransfer();
                    
                    autentica.Autenticado = false;
                    autentica.Validacao = false;
                    autentica.Erro = true;
                    autentica.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                autentica = new AutenticaTransfer();

                autentica.Autenticado = false;
                autentica.Validacao = false;
                autentica.Erro = true;
                autentica.IncluirErroMensagem("Erro em AutenticaService Autenticar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return autentica;
        }
    }
}
