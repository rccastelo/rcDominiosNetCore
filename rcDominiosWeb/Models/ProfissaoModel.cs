using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class ProfissaoModel
    {
        private readonly IHttpContextAccessor httpContext;

        public ProfissaoModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<ProfissaoTransfer> Incluir(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                profissaoService = new ProfissaoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                profissaoTransfer.Profissao.Criacao = DateTime.Today;
                profissaoTransfer.Profissao.Alteracao = DateTime.Today;

                profissao = await profissaoService.Incluir(profissaoTransfer, autorizacao);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoModel Incluir [" + ex.Message + "]");
            } finally {
                profissaoService = null;
                autenticaModel = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> Alterar(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                profissaoService = new ProfissaoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                profissaoTransfer.Profissao.Alteracao = DateTime.Today;

                profissao = await profissaoService.Alterar(profissaoTransfer, autorizacao);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoModel Alterar [" + ex.Message + "]");
            } finally {
                profissaoService = null;
                autenticaModel = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> Excluir(int id)
        {
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                profissaoService = new ProfissaoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                profissao = await profissaoService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoModel Excluir [" + ex.Message + "]");
            } finally {
                profissaoService = null;
                autenticaModel = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> ConsultarPorId(int id)
        {
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                profissaoService = new ProfissaoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                profissao = await profissaoService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoService = null;
                autenticaModel = null;
            }

            return profissao;
        }

        public async Task<ProfissaoTransfer> Consultar(ProfissaoTransfer profissaoListaTransfer)
        {
            ProfissaoService profissaoService;
            ProfissaoTransfer profissaoLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                profissaoService = new ProfissaoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                profissaoLista = await profissaoService.Consultar(profissaoListaTransfer, autorizacao);

                if (profissaoLista != null) {
                    if (profissaoLista.Paginacao.TotalRegistros > 0) {
                        if (profissaoLista.Paginacao.RegistrosPorPagina < 1) {
                            profissaoLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (profissaoLista.Paginacao.RegistrosPorPagina > 200) {
                            profissaoLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        profissaoLista.Paginacao.PaginaAtual = (profissaoLista.Paginacao.PaginaAtual < 1 ? 1 : profissaoLista.Paginacao.PaginaAtual);
                        profissaoLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(profissaoLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(profissaoLista.Paginacao.RegistrosPorPagina)));
                        profissaoLista.Paginacao.TotalPaginas = (profissaoLista.Paginacao.TotalPaginas < 1 ? 1 : profissaoLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > profissaoLista.Paginacao.TotalPaginas ? profissaoLista.Paginacao.TotalPaginas : qtdExibe);

                        profissaoLista.Paginacao.PaginaInicial = profissaoLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        profissaoLista.Paginacao.PaginaFinal = profissaoLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        profissaoLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (profissaoLista.Paginacao.PaginaFinal - 1) : profissaoLista.Paginacao.PaginaFinal);

                        if (profissaoLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - profissaoLista.Paginacao.PaginaInicial;
                            profissaoLista.Paginacao.PaginaInicial += dif;
                            profissaoLista.Paginacao.PaginaFinal += dif;
                        }

                        if (profissaoLista.Paginacao.PaginaFinal > profissaoLista.Paginacao.TotalPaginas) {
                            dif = profissaoLista.Paginacao.PaginaFinal - profissaoLista.Paginacao.TotalPaginas;
                            profissaoLista.Paginacao.PaginaInicial -= dif;
                            profissaoLista.Paginacao.PaginaFinal -= dif;
                        }

                        profissaoLista.Paginacao.PaginaInicial = (profissaoLista.Paginacao.PaginaInicial < 1 ? 1 : profissaoLista.Paginacao.PaginaInicial);
                        profissaoLista.Paginacao.PaginaFinal = (profissaoLista.Paginacao.PaginaFinal > profissaoLista.Paginacao.TotalPaginas ? 
                            profissaoLista.Paginacao.TotalPaginas : profissaoLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirMensagem("Erro em ProfissaoModel Consultar [" + ex.Message + "]");
            } finally {
                profissaoService = null;
                autenticaModel = null;
            }

            return profissaoLista;
        }
    }
}
