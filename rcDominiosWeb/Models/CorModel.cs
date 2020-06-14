using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class CorModel
    {
        private readonly IHttpContextAccessor httpContext;

        public CorModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<CorTransfer> Incluir(CorTransfer corTransfer)
        {
            CorService corService;
            CorTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                corService = new CorService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                corTransfer.Cor.Criacao = DateTime.Today;
                corTransfer.Cor.Alteracao = DateTime.Today;

                cor = await corService.Incluir(corTransfer, autorizacao);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorModel Incluir [" + ex.Message + "]");
            } finally {
                corService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Alterar(CorTransfer corTransfer)
        {
            CorService corService;
            CorTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                corService = new CorService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                corTransfer.Cor.Alteracao = DateTime.Today;

                cor = await corService.Alterar(corTransfer, autorizacao);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorModel Alterar [" + ex.Message + "]");
            } finally {
                corService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Excluir(int id)
        {
            CorService corService;
            CorTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                corService = new CorService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                cor = await corService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorModel Excluir [" + ex.Message + "]");
            } finally {
                corService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<CorTransfer> ConsultarPorId(int id)
        {
            CorService corService;
            CorTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                corService = new CorService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                cor = await corService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                corService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Consultar(CorTransfer corListaTransfer)
        {
            CorService corService;
            CorTransfer corLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                corService = new CorService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                corLista = await corService.Consultar(corListaTransfer, autorizacao);

                if (corLista != null) {
                    if (corLista.Paginacao.TotalRegistros > 0) {
                        if (corLista.Paginacao.RegistrosPorPagina < 1) {
                            corLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (corLista.Paginacao.RegistrosPorPagina > 200) {
                            corLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        corLista.Paginacao.PaginaAtual = (corLista.Paginacao.PaginaAtual < 1 ? 1 : corLista.Paginacao.PaginaAtual);
                        corLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(corLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(corLista.Paginacao.RegistrosPorPagina)));
                        corLista.Paginacao.TotalPaginas = (corLista.Paginacao.TotalPaginas < 1 ? 1 : corLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > corLista.Paginacao.TotalPaginas ? corLista.Paginacao.TotalPaginas : qtdExibe);

                        corLista.Paginacao.PaginaInicial = corLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        corLista.Paginacao.PaginaFinal = corLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        corLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (corLista.Paginacao.PaginaFinal - 1) : corLista.Paginacao.PaginaFinal);

                        if (corLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - corLista.Paginacao.PaginaInicial;
                            corLista.Paginacao.PaginaInicial += dif;
                            corLista.Paginacao.PaginaFinal += dif;
                        }

                        if (corLista.Paginacao.PaginaFinal > corLista.Paginacao.TotalPaginas) {
                            dif = corLista.Paginacao.PaginaFinal - corLista.Paginacao.TotalPaginas;
                            corLista.Paginacao.PaginaInicial -= dif;
                            corLista.Paginacao.PaginaFinal -= dif;
                        }

                        corLista.Paginacao.PaginaInicial = (corLista.Paginacao.PaginaInicial < 1 ? 1 : corLista.Paginacao.PaginaInicial);
                        corLista.Paginacao.PaginaFinal = (corLista.Paginacao.PaginaFinal > corLista.Paginacao.TotalPaginas ? 
                            corLista.Paginacao.TotalPaginas : corLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em CorModel Consultar [" + ex.Message + "]");
            } finally {
                corService = null;
                autenticaModel = null;
            }

            return corLista;
        }
    }
}
