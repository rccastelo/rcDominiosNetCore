using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class GeneroSocialService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "GeneroSocial";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;
        private string autorizacao = null;

        public GeneroSocialService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<GeneroSocialTransfer> Incluir(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialTransfer generoSocial = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", generoSocialTransfer);

                if (resposta.IsSuccessStatusCode) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    generoSocial = new GeneroSocialTransfer();
                    
                    generoSocial.Validacao = false;
                    generoSocial.Erro = true;
                    generoSocial.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Alterar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialTransfer generoSocial = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", generoSocialTransfer);

                if (resposta.IsSuccessStatusCode) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    generoSocial = new GeneroSocialTransfer();
                    
                    generoSocial.Validacao = false;
                    generoSocial.Erro = true;
                    generoSocial.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Excluir(int id)
        {
            GeneroSocialTransfer generoSocial = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    generoSocial = new GeneroSocialTransfer();
                    
                    generoSocial.Validacao = false;
                    generoSocial.Erro = true;
                    generoSocial.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> ConsultarPorId(int id)
        {
            GeneroSocialTransfer generoSocial = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    generoSocial = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    generoSocial = new GeneroSocialTransfer();
                    
                    generoSocial.Validacao = false;
                    generoSocial.Erro = true;
                    generoSocial.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Consultar(GeneroSocialTransfer generoSocialListaTransfer)
        {
            GeneroSocialTransfer generoSocialLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", generoSocialListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    generoSocialLista = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    generoSocialLista = resposta.Content.ReadAsAsync<GeneroSocialTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    generoSocialLista = new GeneroSocialTransfer();
                    
                    generoSocialLista.Validacao = false;
                    generoSocialLista.Erro = true;
                    generoSocialLista.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirErroMensagem("Erro em GeneroSocialService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return generoSocialLista;
        }
    }
}
