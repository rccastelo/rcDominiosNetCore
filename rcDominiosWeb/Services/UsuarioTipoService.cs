using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class UsuarioTipoService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "UsuarioTipo";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public UsuarioTipoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<UsuarioTipoTransfer> Incluir(UsuarioTipoTransfer usuarioTipoTransfer, string autorizacao)
        {
            UsuarioTipoTransfer usuarioTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", usuarioTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuarioTipo = new UsuarioTipoTransfer();
                    
                    usuarioTipo.Validacao = false;
                    usuarioTipo.Erro = true;
                    usuarioTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> Alterar(UsuarioTipoTransfer usuarioTipoTransfer, string autorizacao)
        {
            UsuarioTipoTransfer usuarioTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", usuarioTipoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuarioTipo = new UsuarioTipoTransfer();
                    
                    usuarioTipo.Validacao = false;
                    usuarioTipo.Erro = true;
                    usuarioTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> Excluir(int id, string autorizacao)
        {
            UsuarioTipoTransfer usuarioTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuarioTipo = new UsuarioTipoTransfer();
                    
                    usuarioTipo.Validacao = false;
                    usuarioTipo.Erro = true;
                    usuarioTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> ConsultarPorId(int id, string autorizacao)
        {
            UsuarioTipoTransfer usuarioTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuarioTipo = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuarioTipo = new UsuarioTipoTransfer();
                    
                    usuarioTipo.Validacao = false;
                    usuarioTipo.Erro = true;
                    usuarioTipo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> Consultar(UsuarioTipoTransfer usuarioTipoListaTransfer, string autorizacao)
        {
            UsuarioTipoTransfer usuarioTipoLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", usuarioTipoListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    usuarioTipoLista = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuarioTipoLista = resposta.Content.ReadAsAsync<UsuarioTipoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuarioTipoLista = new UsuarioTipoTransfer();
                    
                    usuarioTipoLista.Validacao = false;
                    usuarioTipoLista.Erro = true;
                    usuarioTipoLista.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirErroMensagem("Erro em UsuarioTipoService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuarioTipoLista;
        }
    }
}
