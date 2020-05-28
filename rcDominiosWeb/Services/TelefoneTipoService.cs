using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class TelefoneTipoService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "TelefoneTipo";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public TelefoneTipoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<TelefoneTipoTransfer> Incluir(TelefoneTipoTransfer telefoneTipoTransfer, string autorizacao)
        {
            TelefoneTipoTransfer telefoneTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", telefoneTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    telefoneTipo = new TelefoneTipoTransfer();
                    
                    telefoneTipo.Validacao = false;
                    telefoneTipo.Erro = true;
                    telefoneTipo.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Alterar(TelefoneTipoTransfer telefoneTipoTransfer, string autorizacao)
        {
            TelefoneTipoTransfer telefoneTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", telefoneTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    telefoneTipo = new TelefoneTipoTransfer();
                    
                    telefoneTipo.Validacao = false;
                    telefoneTipo.Erro = true;
                    telefoneTipo.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Excluir(int id, string autorizacao)
        {
            TelefoneTipoTransfer telefoneTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    telefoneTipo = new TelefoneTipoTransfer();
                    
                    telefoneTipo.Validacao = false;
                    telefoneTipo.Erro = true;
                    telefoneTipo.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> ConsultarPorId(int id, string autorizacao)
        {
            TelefoneTipoTransfer telefoneTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    telefoneTipo = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    telefoneTipo = new TelefoneTipoTransfer();
                    
                    telefoneTipo.Validacao = false;
                    telefoneTipo.Erro = true;
                    telefoneTipo.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Consultar(TelefoneTipoTransfer telefoneTipoListaTransfer, string autorizacao)
        {
            TelefoneTipoTransfer telefoneTipoLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", telefoneTipoListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    telefoneTipoLista = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    telefoneTipoLista = resposta.Content.ReadAsAsync<TelefoneTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    telefoneTipoLista = new TelefoneTipoTransfer();
                    
                    telefoneTipoLista.Validacao = false;
                    telefoneTipoLista.Erro = true;
                    telefoneTipoLista.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirMensagem("Erro em TelefoneTipoService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return telefoneTipoLista;
        }
    }
}
