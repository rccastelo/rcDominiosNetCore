using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class GeneroSocialModel
    {
        private readonly IHttpContextAccessor httpContext;

        public GeneroSocialModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<GeneroSocialTransfer> Incluir(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                generoSocialService = new GeneroSocialService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                generoSocialTransfer.GeneroSocial.Criacao = DateTime.Today;
                generoSocialTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocial = await generoSocialService.Incluir(generoSocialTransfer, autorizacao);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialModel Incluir [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
                autenticaModel = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Alterar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                generoSocialService = new GeneroSocialService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                generoSocialTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocial = await generoSocialService.Alterar(generoSocialTransfer, autorizacao);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialModel Alterar [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
                autenticaModel = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Excluir(int id)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                generoSocialService = new GeneroSocialService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                generoSocial = await generoSocialService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialModel Excluir [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
                autenticaModel = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> ConsultarPorId(int id)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                generoSocialService = new GeneroSocialService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                generoSocial = await generoSocialService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
                autenticaModel = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Consultar(GeneroSocialTransfer generoSocialListaTransfer)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocialLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                generoSocialService = new GeneroSocialService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                generoSocialLista = await generoSocialService.Consultar(generoSocialListaTransfer, autorizacao);

                if (generoSocialLista != null) {
                    if (generoSocialLista.Paginacao.TotalRegistros > 0) {
                        if (generoSocialLista.Paginacao.RegistrosPorPagina < 1) {
                            generoSocialLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (generoSocialLista.Paginacao.RegistrosPorPagina > 200) {
                            generoSocialLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        generoSocialLista.Paginacao.PaginaAtual = (generoSocialLista.Paginacao.PaginaAtual < 1 ? 1 : generoSocialLista.Paginacao.PaginaAtual);
                        generoSocialLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(generoSocialLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(generoSocialLista.Paginacao.RegistrosPorPagina)));
                        generoSocialLista.Paginacao.TotalPaginas = (generoSocialLista.Paginacao.TotalPaginas < 1 ? 1 : generoSocialLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > generoSocialLista.Paginacao.TotalPaginas ? generoSocialLista.Paginacao.TotalPaginas : qtdExibe);

                        generoSocialLista.Paginacao.PaginaInicial = generoSocialLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        generoSocialLista.Paginacao.PaginaFinal = generoSocialLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        generoSocialLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (generoSocialLista.Paginacao.PaginaFinal - 1) : generoSocialLista.Paginacao.PaginaFinal);

                        if (generoSocialLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - generoSocialLista.Paginacao.PaginaInicial;
                            generoSocialLista.Paginacao.PaginaInicial += dif;
                            generoSocialLista.Paginacao.PaginaFinal += dif;
                        }

                        if (generoSocialLista.Paginacao.PaginaFinal > generoSocialLista.Paginacao.TotalPaginas) {
                            dif = generoSocialLista.Paginacao.PaginaFinal - generoSocialLista.Paginacao.TotalPaginas;
                            generoSocialLista.Paginacao.PaginaInicial -= dif;
                            generoSocialLista.Paginacao.PaginaFinal -= dif;
                        }

                        generoSocialLista.Paginacao.PaginaInicial = (generoSocialLista.Paginacao.PaginaInicial < 1 ? 1 : generoSocialLista.Paginacao.PaginaInicial);
                        generoSocialLista.Paginacao.PaginaFinal = (generoSocialLista.Paginacao.PaginaFinal > generoSocialLista.Paginacao.TotalPaginas ? 
                            generoSocialLista.Paginacao.TotalPaginas : generoSocialLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirMensagem("Erro em GeneroSocialModel Consultar [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
                autenticaModel = null;
            }

            return generoSocialLista;
        }
    }
}
