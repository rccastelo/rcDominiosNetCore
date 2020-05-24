using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosTransfers;

namespace rcDominiosWeb.Services
{
  public class ContaBancariaService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "ContaBancaria";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;
        private string autorizacao = null;

        public ContaBancariaService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<ContaBancariaTransfer> Incluir(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaTransfer contaBancaria = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", contaBancariaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    contaBancaria = new ContaBancariaTransfer();
                    
                    contaBancaria.Validacao = false;
                    contaBancaria.Erro = true;
                    contaBancaria.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> Alterar(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaTransfer contaBancaria = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", contaBancariaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    contaBancaria = new ContaBancariaTransfer();
                    
                    contaBancaria.Validacao = false;
                    contaBancaria.Erro = true;
                    contaBancaria.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> Excluir(int id)
        {
            ContaBancariaTransfer contaBancaria = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    contaBancaria = new ContaBancariaTransfer();
                    
                    contaBancaria.Validacao = false;
                    contaBancaria.Erro = true;
                    contaBancaria.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> ConsultarPorId(int id)
        {
            ContaBancariaTransfer contaBancaria = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    contaBancaria = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    contaBancaria = new ContaBancariaTransfer();
                    
                    contaBancaria.Validacao = false;
                    contaBancaria.Erro = true;
                    contaBancaria.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> Consultar(ContaBancariaTransfer contaBancariaListaTransfer)
        {
            ContaBancariaTransfer contaBancariaLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/lista", contaBancariaListaTransfer);

                if (resposta.IsSuccessStatusCode) {
                    contaBancariaLista = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    contaBancariaLista = resposta.Content.ReadAsAsync<ContaBancariaTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    contaBancariaLista = new ContaBancariaTransfer();
                    
                    contaBancariaLista.Validacao = false;
                    contaBancariaLista.Erro = true;
                    contaBancariaLista.IncluirErroMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirErroMensagem("Erro em ContaBancariaService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return contaBancariaLista;
        }
    }
}
