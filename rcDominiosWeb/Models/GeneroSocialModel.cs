using System;
using System.Threading.Tasks;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class GeneroSocialModel
    {
        public async Task<GeneroSocialTransfer> Incluir(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialService = new GeneroSocialService();

                generoSocialTransfer.GeneroSocial.Criacao = DateTime.Today;
                generoSocialTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocial = await generoSocialService.Incluir(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialModel Incluir [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Alterar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialService = new GeneroSocialService();

                generoSocialTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocial = await generoSocialService.Alterar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialModel Alterar [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Excluir(int id)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialService = new GeneroSocialService();

                generoSocial = await generoSocialService.Excluir(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialModel Excluir [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> ConsultarPorId(int id)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocial;
            
            try {
                generoSocialService = new GeneroSocialService();

                generoSocial = await generoSocialService.ConsultarPorId(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
            }

            return generoSocial;
        }

        public async Task<GeneroSocialTransfer> Consultar(GeneroSocialTransfer generoSocialListaTransfer)
        {
            GeneroSocialService generoSocialService;
            GeneroSocialTransfer generoSocialLista;
            int dif = 0;
            int qtdExibe = 5;

            try {
                generoSocialService = new GeneroSocialService();

                generoSocialLista = await generoSocialService.Consultar(generoSocialListaTransfer);

                if (generoSocialLista != null) {
                    if (generoSocialLista.TotalRegistros > 1) {
                        if (generoSocialLista.RegistrosPorPagina < 1) {
                            generoSocialLista.RegistrosPorPagina = 30;
                        } else if (generoSocialLista.RegistrosPorPagina > 200) {
                            generoSocialLista.RegistrosPorPagina = 30;
                        }

                        generoSocialLista.PaginaAtual = (generoSocialLista.PaginaAtual < 1 ? 1 : generoSocialLista.PaginaAtual);
                        generoSocialLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(generoSocialLista.TotalRegistros) 
                            / @Convert.ToDecimal(generoSocialLista.RegistrosPorPagina)));
                        generoSocialLista.TotalPaginas = (generoSocialLista.TotalPaginas < 1 ? 1 : generoSocialLista.TotalPaginas);

                        qtdExibe = (qtdExibe > generoSocialLista.TotalPaginas ? generoSocialLista.TotalPaginas : qtdExibe);

                        generoSocialLista.PaginaInicial = generoSocialLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        generoSocialLista.PaginaFinal = generoSocialLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        generoSocialLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (generoSocialLista.PaginaFinal - 1) : generoSocialLista.PaginaFinal);

                        if (generoSocialLista.PaginaInicial < 1) {
                            dif = 1 - generoSocialLista.PaginaInicial;
                            generoSocialLista.PaginaInicial += dif;
                            generoSocialLista.PaginaFinal += dif;
                        }

                        if (generoSocialLista.PaginaFinal > generoSocialLista.TotalPaginas) {
                            dif = generoSocialLista.PaginaFinal - generoSocialLista.TotalPaginas;
                            generoSocialLista.PaginaInicial -= dif;
                            generoSocialLista.PaginaFinal -= dif;
                        }

                        generoSocialLista.PaginaInicial = (generoSocialLista.PaginaInicial < 1 ? 1 : generoSocialLista.PaginaInicial);
                        generoSocialLista.PaginaFinal = (generoSocialLista.PaginaFinal > generoSocialLista.TotalPaginas ? 
                            generoSocialLista.TotalPaginas : generoSocialLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirErroMensagem("Erro em GeneroSocialModel Consultar [" + ex.Message + "]");
            } finally {
                generoSocialService = null;
            }

            return generoSocialLista;
        }
    }
}
