using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class UsuarioService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "Usuario";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public UsuarioService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<UsuarioTransfer> Incluir(UsuarioTransfer usuarioTransfer, string autorizacao)
        {
            UsuarioTransfer usuario = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", usuarioTransfer);

                if (resposta.IsSuccessStatusCode) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuario = new UsuarioTransfer();
                    
                    usuario.Validacao = false;
                    usuario.Erro = true;
                    usuario.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Alterar(UsuarioTransfer usuarioTransfer, string autorizacao)
        {
            UsuarioTransfer usuario = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", usuarioTransfer);

                if (resposta.IsSuccessStatusCode) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuario = new UsuarioTransfer();
                    
                    usuario.Validacao = false;
                    usuario.Erro = true;
                    usuario.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Excluir(int id, string autorizacao)
        {
            UsuarioTransfer usuario = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuario = new UsuarioTransfer();
                    
                    usuario.Validacao = false;
                    usuario.Erro = true;
                    usuario.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> ConsultarPorId(int id, string autorizacao)
        {
            UsuarioTransfer usuario = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuario = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuario = new UsuarioTransfer();
                    
                    usuario.Validacao = false;
                    usuario.Erro = true;
                    usuario.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Consultar(UsuarioTransfer usuarioListaTransfer, string autorizacao)
        {
            UsuarioTransfer usuarioLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", usuarioListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    usuarioLista = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    usuarioLista = resposta.Content.ReadAsAsync<UsuarioTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    usuarioLista = new UsuarioTransfer();
                    
                    usuarioLista.Validacao = false;
                    usuarioLista.Erro = true;
                    usuarioLista.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirErroMensagem("Erro em UsuarioService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return usuarioLista;
        }
    }
}
