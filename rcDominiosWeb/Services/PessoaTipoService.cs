using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Services
{
    public class PessoaTipoService
    {
        private string enderecoServico = "http://localhost:5600/";
        private string nomeServico = "PessoaTipo";
        private HttpClient httpClient;

        public PessoaTipoService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
        }

        public async Task<PessoaTipoDataTransfer> Incluir(PessoaTipoDataTransfer pessoaTipoForm)
        {
            PessoaTipoDataTransfer pessoaTipoInclusao = null;
            HttpResponseMessage resposta = null;
            HttpContent conteudoHttp = null;
            
            try {
                conteudoHttp = new StringContent(JsonConvert.SerializeObject(pessoaTipoForm), Encoding.UTF8, "text/json");

                resposta = await httpClient.PostAsync($"{nomeServico}", conteudoHttp);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipoInclusao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipoInclusao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else {
                    pessoaTipoInclusao = new PessoaTipoDataTransfer();
                    
                    pessoaTipoInclusao.Validacao = false;
                    pessoaTipoInclusao.Erro = true;
                    pessoaTipoInclusao.ErroMensagens.Add($"Não foi possível acessar o serviço {nomeServico} Incluir");
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
            PessoaTipoDataTransfer pessoaTipoInclusao = null;
            HttpResponseMessage resposta = null;
            HttpContent conteudoHttp = null;
            
            try {
                conteudoHttp = new StringContent(JsonConvert.SerializeObject(pessoaTipoForm), Encoding.UTF8, "text/json");

                resposta = await httpClient.PutAsync($"{nomeServico}", conteudoHttp);

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipoInclusao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    pessoaTipoInclusao = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else {
                    pessoaTipoInclusao = new PessoaTipoDataTransfer();
                    
                    pessoaTipoInclusao.Validacao = false;
                    pessoaTipoInclusao.Erro = true;
                    pessoaTipoInclusao.ErroMensagens.Add($"Não foi possível acessar o serviço {nomeServico} Alterar");
                }
                
            } catch (Exception ex) {
                pessoaTipoInclusao = new PessoaTipoDataTransfer();

                pessoaTipoInclusao.Validacao = false;
                pessoaTipoInclusao.Erro = true;
                pessoaTipoInclusao.ErroMensagens.Add("Erro em PessoaTipoService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return pessoaTipoInclusao;
        }

        public async Task<PessoaTipoDataTransfer> Excluir(int id)
        {
            PessoaTipoDataTransfer pessoaTipo = null;
            HttpResponseMessage resposta = null;
            
            try {
                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else {
                    pessoaTipo = new PessoaTipoDataTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.ErroMensagens.Add($"Não foi possível acessar o serviço {nomeServico} Excluir");
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
            
            try {
                resposta = await httpClient.GetAsync($"{nomeServico}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else {
                    pessoaTipo = new PessoaTipoDataTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.ErroMensagens.Add($"Não foi possível acessar o serviço {nomeServico} Listar");
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
            
            try {
                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
                } else {
                    pessoaTipo = new PessoaTipoDataTransfer();
                    
                    pessoaTipo.Validacao = false;
                    pessoaTipo.Erro = true;
                    pessoaTipo.ErroMensagens.Add($"Não foi possível acessar o serviço {nomeServico} ConsultarPorId");
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

        // public async Task<PessoaTipoDataTransfer> Consultar(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        // {
        //     PessoaTipoDataTransfer pessoaTipo = null;
        //     HttpResponseMessage resposta = null;
            
        //     try {
        //         resposta = await httpClient.GetAsync($"{nomeServico}");

        //         if (resposta.IsSuccessStatusCode) {
        //             pessoaTipo = resposta.Content.ReadAsAsync<PessoaTipoDataTransfer>().Result;
        //         } else {
        //             pessoaTipo = new PessoaTipoDataTransfer();
                    
        //             pessoaTipo.Validacao = false;
        //             pessoaTipo.Erro = true;
        //             pessoaTipo.ErroMensagens.Add($"Não foi possível acessar o serviço {nomeServico} ConsultarPorId");
        //         }
        //     } catch (Exception ex) {
        //         pessoaTipo = new PessoaTipoDataTransfer();

        //         pessoaTipo.Validacao = false;
        //         pessoaTipo.Erro = true;
        //         pessoaTipo.ErroMensagens.Add("Erro em PessoaTipoService ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         resposta = null;
        //     }

        //     return pessoaTipo;
        // }
    }
}
