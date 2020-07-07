using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class EstadoCivilService
    {
        private string enderecoServico = "http://localhost/rcDominiosApiNetCore/";
        private string nomeServico = "EstadoCivil";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public EstadoCivilService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<EstadoCivilTransfer> Incluir(EstadoCivilTransfer estadoCivilTransfer, string autorizacao)
        {
            EstadoCivilTransfer estadoCivil = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", estadoCivilTransfer);

                if (resposta.IsSuccessStatusCode) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    estadoCivil = new EstadoCivilTransfer();
                    
                    estadoCivil.Validacao = false;
                    estadoCivil.Erro = true;
                    estadoCivil.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Alterar(EstadoCivilTransfer estadoCivilTransfer, string autorizacao)
        {
            EstadoCivilTransfer estadoCivil = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", estadoCivilTransfer);

                if (resposta.IsSuccessStatusCode) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    estadoCivil = new EstadoCivilTransfer();
                    
                    estadoCivil.Validacao = false;
                    estadoCivil.Erro = true;
                    estadoCivil.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Excluir(int id, string autorizacao)
        {
            EstadoCivilTransfer estadoCivil = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    estadoCivil = new EstadoCivilTransfer();
                    
                    estadoCivil.Validacao = false;
                    estadoCivil.Erro = true;
                    estadoCivil.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> ConsultarPorId(int id, string autorizacao)
        {
            EstadoCivilTransfer estadoCivil = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    estadoCivil = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    estadoCivil = new EstadoCivilTransfer();
                    
                    estadoCivil.Validacao = false;
                    estadoCivil.Erro = true;
                    estadoCivil.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Consultar(EstadoCivilTransfer estadoCivilListaTransfer, string autorizacao)
        {
            EstadoCivilTransfer estadoCivilLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", estadoCivilListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    estadoCivilLista = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    estadoCivilLista = resposta.Content.ReadAsAsync<EstadoCivilTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    estadoCivilLista = new EstadoCivilTransfer();
                    
                    estadoCivilLista.Validacao = false;
                    estadoCivilLista.Erro = true;
                    estadoCivilLista.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirMensagem("Erro em EstadoCivilService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return estadoCivilLista;
        }
    }
}
