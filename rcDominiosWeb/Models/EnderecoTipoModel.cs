using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class EnderecoTipoModel
    {
        private readonly IHttpContextAccessor httpContext;

        public EnderecoTipoModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<EnderecoTipoTransfer> Incluir(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoService enderecoTipoService;
            EnderecoTipoTransfer enderecoTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                enderecoTipoService = new EnderecoTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                enderecoTipoTransfer.EnderecoTipo.Criacao = DateTime.Today;
                enderecoTipoTransfer.EnderecoTipo.Alteracao = DateTime.Today;

                enderecoTipo = await enderecoTipoService.Incluir(enderecoTipoTransfer, autorizacao);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirMensagem("Erro em EnderecoTipoModel Incluir [" + ex.Message + "]");
            } finally {
                enderecoTipoService = null;
                autenticaModel = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> Alterar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoService enderecoTipoService;
            EnderecoTipoTransfer enderecoTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                enderecoTipoService = new EnderecoTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                enderecoTipoTransfer.EnderecoTipo.Alteracao = DateTime.Today;

                enderecoTipo = await enderecoTipoService.Alterar(enderecoTipoTransfer, autorizacao);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirMensagem("Erro em EnderecoTipoModel Alterar [" + ex.Message + "]");
            } finally {
                enderecoTipoService = null;
                autenticaModel = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> Excluir(int id)
        {
            EnderecoTipoService enderecoTipoService;
            EnderecoTipoTransfer enderecoTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                enderecoTipoService = new EnderecoTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                enderecoTipo = await enderecoTipoService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirMensagem("Erro em EnderecoTipoModel Excluir [" + ex.Message + "]");
            } finally {
                enderecoTipoService = null;
                autenticaModel = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> ConsultarPorId(int id)
        {
            EnderecoTipoService enderecoTipoService;
            EnderecoTipoTransfer enderecoTipo;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                enderecoTipoService = new EnderecoTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                enderecoTipo = await enderecoTipoService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirMensagem("Erro em EnderecoTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                enderecoTipoService = null;
                autenticaModel = null;
            }

            return enderecoTipo;
        }

        public async Task<EnderecoTipoTransfer> Consultar(EnderecoTipoTransfer enderecoTipoListaTransfer)
        {
            EnderecoTipoService enderecoTipoService;
            EnderecoTipoTransfer enderecoTipoLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                enderecoTipoService = new EnderecoTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                enderecoTipoLista = await enderecoTipoService.Consultar(enderecoTipoListaTransfer, autorizacao);

                if (enderecoTipoLista != null) {
                    if (enderecoTipoLista.TotalRegistros > 0) {
                        if (enderecoTipoLista.RegistrosPorPagina < 1) {
                            enderecoTipoLista.RegistrosPorPagina = 30;
                        } else if (enderecoTipoLista.RegistrosPorPagina > 200) {
                            enderecoTipoLista.RegistrosPorPagina = 30;
                        }

                        enderecoTipoLista.PaginaAtual = (enderecoTipoLista.PaginaAtual < 1 ? 1 : enderecoTipoLista.PaginaAtual);
                        enderecoTipoLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(enderecoTipoLista.TotalRegistros) 
                            / @Convert.ToDecimal(enderecoTipoLista.RegistrosPorPagina)));
                        enderecoTipoLista.TotalPaginas = (enderecoTipoLista.TotalPaginas < 1 ? 1 : enderecoTipoLista.TotalPaginas);

                        qtdExibe = (qtdExibe > enderecoTipoLista.TotalPaginas ? enderecoTipoLista.TotalPaginas : qtdExibe);

                        enderecoTipoLista.PaginaInicial = enderecoTipoLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        enderecoTipoLista.PaginaFinal = enderecoTipoLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        enderecoTipoLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (enderecoTipoLista.PaginaFinal - 1) : enderecoTipoLista.PaginaFinal);

                        if (enderecoTipoLista.PaginaInicial < 1) {
                            dif = 1 - enderecoTipoLista.PaginaInicial;
                            enderecoTipoLista.PaginaInicial += dif;
                            enderecoTipoLista.PaginaFinal += dif;
                        }

                        if (enderecoTipoLista.PaginaFinal > enderecoTipoLista.TotalPaginas) {
                            dif = enderecoTipoLista.PaginaFinal - enderecoTipoLista.TotalPaginas;
                            enderecoTipoLista.PaginaInicial -= dif;
                            enderecoTipoLista.PaginaFinal -= dif;
                        }

                        enderecoTipoLista.PaginaInicial = (enderecoTipoLista.PaginaInicial < 1 ? 1 : enderecoTipoLista.PaginaInicial);
                        enderecoTipoLista.PaginaFinal = (enderecoTipoLista.PaginaFinal > enderecoTipoLista.TotalPaginas ? 
                            enderecoTipoLista.TotalPaginas : enderecoTipoLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirMensagem("Erro em EnderecoTipoModel Consultar [" + ex.Message + "]");
            } finally {
                enderecoTipoService = null;
                autenticaModel = null;
            }

            return enderecoTipoLista;
        }
    }
}
