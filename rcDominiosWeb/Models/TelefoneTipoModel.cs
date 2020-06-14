using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class TelefoneTipoModel
    {
        private readonly IHttpContextAccessor httpContext;

        public TelefoneTipoModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<TelefoneTipoTransfer> Incluir(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipoTransfer.TelefoneTipo.Criacao = DateTime.Today;
                telefoneTipoTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipo = await telefoneTipoService.Incluir(telefoneTipoTransfer, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel Incluir [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Alterar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipoTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipo = await telefoneTipoService.Alterar(telefoneTipoTransfer, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel Alterar [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Excluir(int id)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipo = await telefoneTipoService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel Excluir [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> ConsultarPorId(int id)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipo;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipo = await telefoneTipoService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipo;
        }

        public async Task<TelefoneTipoTransfer> Consultar(TelefoneTipoTransfer telefoneTipoListaTransfer)
        {
            TelefoneTipoService telefoneTipoService;
            TelefoneTipoTransfer telefoneTipoLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                telefoneTipoService = new TelefoneTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                telefoneTipoLista = await telefoneTipoService.Consultar(telefoneTipoListaTransfer, autorizacao);

                if (telefoneTipoLista != null) {
                    if (telefoneTipoLista.Paginacao.TotalRegistros > 0) {
                        if (telefoneTipoLista.Paginacao.RegistrosPorPagina < 1) {
                            telefoneTipoLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (telefoneTipoLista.Paginacao.RegistrosPorPagina > 200) {
                            telefoneTipoLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        telefoneTipoLista.Paginacao.PaginaAtual = (telefoneTipoLista.Paginacao.PaginaAtual < 1 ? 1 : telefoneTipoLista.Paginacao.PaginaAtual);
                        telefoneTipoLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(telefoneTipoLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(telefoneTipoLista.Paginacao.RegistrosPorPagina)));
                        telefoneTipoLista.Paginacao.TotalPaginas = (telefoneTipoLista.Paginacao.TotalPaginas < 1 ? 1 : telefoneTipoLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > telefoneTipoLista.Paginacao.TotalPaginas ? telefoneTipoLista.Paginacao.TotalPaginas : qtdExibe);

                        telefoneTipoLista.Paginacao.PaginaInicial = telefoneTipoLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        telefoneTipoLista.Paginacao.PaginaFinal = telefoneTipoLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        telefoneTipoLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (telefoneTipoLista.Paginacao.PaginaFinal - 1) : telefoneTipoLista.Paginacao.PaginaFinal);

                        if (telefoneTipoLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - telefoneTipoLista.Paginacao.PaginaInicial;
                            telefoneTipoLista.Paginacao.PaginaInicial += dif;
                            telefoneTipoLista.Paginacao.PaginaFinal += dif;
                        }

                        if (telefoneTipoLista.Paginacao.PaginaFinal > telefoneTipoLista.Paginacao.TotalPaginas) {
                            dif = telefoneTipoLista.Paginacao.PaginaFinal - telefoneTipoLista.Paginacao.TotalPaginas;
                            telefoneTipoLista.Paginacao.PaginaInicial -= dif;
                            telefoneTipoLista.Paginacao.PaginaFinal -= dif;
                        }

                        telefoneTipoLista.Paginacao.PaginaInicial = (telefoneTipoLista.Paginacao.PaginaInicial < 1 ? 1 : telefoneTipoLista.Paginacao.PaginaInicial);
                        telefoneTipoLista.Paginacao.PaginaFinal = (telefoneTipoLista.Paginacao.PaginaFinal > telefoneTipoLista.Paginacao.TotalPaginas ? 
                            telefoneTipoLista.Paginacao.TotalPaginas : telefoneTipoLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirMensagem("Erro em TelefoneTipoModel Consultar [" + ex.Message + "]");
            } finally {
                telefoneTipoService = null;
                autenticaModel = null;
            }

            return telefoneTipoLista;
        }
    }
}
