using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Services
{
  public class PessoaTipoService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "PessoaTipo";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;
        private string autorizacao = null;

        public PessoaTipoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<PessoaTipoDataTransfer> Incluir(PessoaTipoDataTransfer pessoaTipoForm)
        {
            PessoaTipoDataTransfer pessoaTipoInclusao = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}", pessoaTipoForm);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipoInclusao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipoInclusao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipoInclusao = new PessoaTipoDataTransfer();
                    
                    pessoaTipoInclusao.Validacao = false;
                    pessoaTipoInclusao.Erro = true;
                    pessoaTipoInclusao.ErroMensagens.Add(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipoInclusao = new PessoaTipoDataTransfer();

                pessoaTipoInclusao.Validacao = false;
                pessoaTipoInclusao.Erro = true;
                pessoaTipoInclusao.ErroMensagens.Add("Erro em PessoaTipoService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipoInclusao;
        }

        public async Task<PessoaTipoDataTransfer> Alterar(PessoaTipoDataTransfer pessoaTipoForm)
        {
            PessoaTipoDataTransfer pessoaTipoAlteracao = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsJsonAsync($"{nomeServico}", pessoaTipoForm);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipoAlteracao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipoAlteracao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipoAlteracao = new PessoaTipoDataTransfer();
                    
                    pessoaTipoAlteracao.Validacao = false;
                    pessoaTipoAlteracao.Erro = true;
                    pessoaTipoAlteracao.ErroMensagens.Add(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipoAlteracao = new PessoaTipoDataTransfer();

                pessoaTipoAlteracao.Validacao = false;
                pessoaTipoAlteracao.Erro = true;
                pessoaTipoAlteracao.ErroMensagens.Add("Erro em PessoaTipoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipoAlteracao;
        }

        public async Task<PessoaTipoDataTransfer> Excluir(int id)
        {
            PessoaTipoDataTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipo = new PessoaTipoDataTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.ErroMensagens.Add(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoDataTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.ErroMensagens.Add("Erro em PessoaTipoService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoDataTransfer> Listar()
        {
            PessoaTipoDataTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Listar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Listar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipo = new PessoaTipoDataTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.ErroMensagens.Add(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoDataTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.ErroMensagens.Add("Erro em PessoaTipoService Listar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoDataTransfer> ConsultarPorId(int id)
        {
            PessoaTipoDataTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipo = new PessoaTipoDataTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.ErroMensagens.Add(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoDataTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.ErroMensagens.Add("Erro em PessoaTipoService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoDataTransfer> Consultar(PessoaTipoDataTransfer pessoaTipoForm)
        {
            PessoaTipoDataTransfer pessoaTipoConsulta = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                autorizacao = await autenticaService.Autorizar();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsJsonAsync($"{nomeServico}/filtro", pessoaTipoForm);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipoConsulta = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipoConsulta = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    pessoaTipoConsulta = new PessoaTipoDataTransfer();
                    
                    pessoaTipoConsulta.Validacao = false;
                    pessoaTipoConsulta.Erro = true;
                    pessoaTipoConsulta.ErroMensagens.Add(mensagemRetono);
                }
            } catch (Exception ex) {
                pessoaTipoConsulta = new PessoaTipoDataTransfer();

                pessoaTipoConsulta.Validacao = false;
                pessoaTipoConsulta.Erro = true;
                pessoaTipoConsulta.ErroMensagens.Add("Erro em PessoaTipoService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipoConsulta;
        }
    }
}
