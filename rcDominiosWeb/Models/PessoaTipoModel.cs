using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class PessoaTipoModel
    {
        private readonly IHttpContextAccessor httpContext;

        public PessoaTipoModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<PessoaTipoTransfer> Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                pessoaTipoService = new PessoaTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                pessoaTipoTransfer.PessoaTipo.Criacao = DateTime.Today;
                pessoaTipoTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipo = await pessoaTipoService.Incluir(pessoaTipoTransfer, autorizacao);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
                autenticaModel = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                pessoaTipoService = new PessoaTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                pessoaTipoTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipo = await pessoaTipoService.Alterar(pessoaTipoTransfer, autorizacao);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoModel Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
                autenticaModel = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Excluir(int id)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                pessoaTipoService = new PessoaTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                pessoaTipo = await pessoaTipoService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoModel Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
                autenticaModel = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> ConsultarPorId(int id)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                pessoaTipoService = new PessoaTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                pessoaTipo = await pessoaTipoService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
                autenticaModel = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Consultar(PessoaTipoTransfer pessoaTipoListaTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipoLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                pessoaTipoService = new PessoaTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                pessoaTipoLista = await pessoaTipoService.Consultar(pessoaTipoListaTransfer, autorizacao);

                if (pessoaTipoLista != null) {
                    if (pessoaTipoLista.Paginacao.TotalRegistros > 0) {
                        if (pessoaTipoLista.Paginacao.RegistrosPorPagina < 1) {
                            pessoaTipoLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (pessoaTipoLista.Paginacao.RegistrosPorPagina > 200) {
                            pessoaTipoLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        pessoaTipoLista.Paginacao.PaginaAtual = (pessoaTipoLista.Paginacao.PaginaAtual < 1 ? 1 : pessoaTipoLista.Paginacao.PaginaAtual);
                        pessoaTipoLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(pessoaTipoLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(pessoaTipoLista.Paginacao.RegistrosPorPagina)));
                        pessoaTipoLista.Paginacao.TotalPaginas = (pessoaTipoLista.Paginacao.TotalPaginas < 1 ? 1 : pessoaTipoLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > pessoaTipoLista.Paginacao.TotalPaginas ? pessoaTipoLista.Paginacao.TotalPaginas : qtdExibe);

                        pessoaTipoLista.Paginacao.PaginaInicial = pessoaTipoLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        pessoaTipoLista.Paginacao.PaginaFinal = pessoaTipoLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        pessoaTipoLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (pessoaTipoLista.Paginacao.PaginaFinal - 1) : pessoaTipoLista.Paginacao.PaginaFinal);

                        if (pessoaTipoLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - pessoaTipoLista.Paginacao.PaginaInicial;
                            pessoaTipoLista.Paginacao.PaginaInicial += dif;
                            pessoaTipoLista.Paginacao.PaginaFinal += dif;
                        }

                        if (pessoaTipoLista.Paginacao.PaginaFinal > pessoaTipoLista.Paginacao.TotalPaginas) {
                            dif = pessoaTipoLista.Paginacao.PaginaFinal - pessoaTipoLista.Paginacao.TotalPaginas;
                            pessoaTipoLista.Paginacao.PaginaInicial -= dif;
                            pessoaTipoLista.Paginacao.PaginaFinal -= dif;
                        }

                        pessoaTipoLista.Paginacao.PaginaInicial = (pessoaTipoLista.Paginacao.PaginaInicial < 1 ? 1 : pessoaTipoLista.Paginacao.PaginaInicial);
                        pessoaTipoLista.Paginacao.PaginaFinal = (pessoaTipoLista.Paginacao.PaginaFinal > pessoaTipoLista.Paginacao.TotalPaginas ? 
                            pessoaTipoLista.Paginacao.TotalPaginas : pessoaTipoLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirMensagem("Erro em PessoaTipoModel Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
                autenticaModel = null;
            }

            return pessoaTipoLista;
        }
    }
}
