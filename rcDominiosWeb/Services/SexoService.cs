using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class SexoService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "Sexo";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;
        private string autorizacao = null;

        public SexoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<SexoTransfer> Incluir(SexoTransfer sexoTransfer)
        {
            SexoTransfer sexo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", sexoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    sexo = new SexoTransfer();
                    
                    sexo.Validacao = false;
                    sexo.Erro = true;
                    sexo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> Alterar(SexoTransfer sexoTransfer)
        {
            SexoTransfer sexo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", sexoTransfer);

                if (resposta.IsSuccessStatusCode) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    sexo = new SexoTransfer();
                    
                    sexo.Validacao = false;
                    sexo.Erro = true;
                    sexo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> Excluir(int id)
        {
            SexoTransfer sexo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    sexo = new SexoTransfer();
                    
                    sexo.Validacao = false;
                    sexo.Erro = true;
                    sexo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> ConsultarPorId(int id)
        {
            SexoTransfer sexo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    sexo = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    sexo = new SexoTransfer();
                    
                    sexo.Validacao = false;
                    sexo.Erro = true;
                    sexo.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> Consultar(SexoTransfer sexoListaTransfer)
        {
            SexoTransfer sexoLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", sexoListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    sexoLista = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    sexoLista = resposta.Content.ReadAsAsync<SexoTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    sexoLista = new SexoTransfer();
                    
                    sexoLista.Validacao = false;
                    sexoLista.Erro = true;
                    sexoLista.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirErroMensagem("Erro em SexoService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return sexoLista;
        }
    }
}
