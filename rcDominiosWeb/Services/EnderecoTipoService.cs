using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class EnderecoTipoService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "EnderecoTipo";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;
        private string autorizacao = null;

        public EnderecoTipoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<EnderecoTipoTransfer> Incluir(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoTransfer enderecoTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", enderecoTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    enderecoTipo = new EnderecoTipoTransfer();
                    
                    enderecoTipo.Validacao = false;
                    enderecoTipo.Erro = true;
                    enderecoTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> Alterar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoTransfer enderecoTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", enderecoTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    enderecoTipo = new EnderecoTipoTransfer();
                    
                    enderecoTipo.Validacao = false;
                    enderecoTipo.Erro = true;
                    enderecoTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> Excluir(int id)
        {
            EnderecoTipoTransfer enderecoTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    enderecoTipo = new EnderecoTipoTransfer();
                    
                    enderecoTipo.Validacao = false;
                    enderecoTipo.Erro = true;
                    enderecoTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> ConsultarPorId(int id)
        {
            EnderecoTipoTransfer enderecoTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    enderecoTipo = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    enderecoTipo = new EnderecoTipoTransfer();
                    
                    enderecoTipo.Validacao = false;
                    enderecoTipo.Erro = true;
                    enderecoTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> Consultar(EnderecoTipoTransfer enderecoTipoListaTransfer)
        {
            EnderecoTipoTransfer enderecoTipoLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", enderecoTipoListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    enderecoTipoLista = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    enderecoTipoLista = resposta.Content.ReadAsAsync<EnderecoTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    enderecoTipoLista = new EnderecoTipoTransfer();
                    
                    enderecoTipoLista.Validacao = false;
                    enderecoTipoLista.Erro = true;
                    enderecoTipoLista.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirErroMensagem("Erro em EnderecoTipoService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return enderecoTipoLista;
        }
    }
}
