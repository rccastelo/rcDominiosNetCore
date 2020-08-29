using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosWeb.Services
{
  public class CorService
    {
        private string enderecoServico = Settings.GetSetting(Dominios.servicoApiEndereco.ToString());
        private string nomeServico = "Cor";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public CorService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<CorTransfer> Incluir(CorTransfer corTransfer, string autorizacao)
        {
            CorTransfer cor = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", corTransfer);

                if (resposta.IsSuccessStatusCode) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    cor = new CorTransfer();
                    
                    cor.Validacao = false;
                    cor.Erro = true;
                    cor.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Alterar(CorTransfer corTransfer, string autorizacao)
        {
            CorTransfer cor = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", corTransfer);

                if (resposta.IsSuccessStatusCode) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    cor = new CorTransfer();
                    
                    cor.Validacao = false;
                    cor.Erro = true;
                    cor.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Excluir(int id, string autorizacao)
        {
            CorTransfer cor = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    cor = new CorTransfer();
                    
                    cor.Validacao = false;
                    cor.Erro = true;
                    cor.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return cor;
        }

        public async Task<CorTransfer> ConsultarPorId(int id, string autorizacao)
        {
            CorTransfer cor = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    cor = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    cor = new CorTransfer();
                    
                    cor.Validacao = false;
                    cor.Erro = true;
                    cor.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Consultar(CorTransfer corListaTransfer, string autorizacao)
        {
            CorTransfer corLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", corListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    corLista = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    corLista = resposta.Content.ReadAsAsync<CorTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    corLista = new CorTransfer();
                    
                    corLista.Validacao = false;
                    corLista.Erro = true;
                    corLista.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em CorService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return corLista;
        }
    }
}
