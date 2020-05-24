using System;
using System.Threading.Tasks;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class CorModel
    {
        public async Task<CorTransfer> Incluir(CorTransfer corTransfer)
        {
            CorService corService;
            CorTransfer cor;

            try {
                corService = new CorService();

                corTransfer.Cor.Criacao = DateTime.Today;
                corTransfer.Cor.Alteracao = DateTime.Today;

                cor = await corService.Incluir(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorModel Incluir [" + ex.Message + "]");
            } finally {
                corService = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Alterar(CorTransfer corTransfer)
        {
            CorService corService;
            CorTransfer cor;

            try {
                corService = new CorService();

                corTransfer.Cor.Alteracao = DateTime.Today;

                cor = await corService.Alterar(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorModel Alterar [" + ex.Message + "]");
            } finally {
                corService = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Excluir(int id)
        {
            CorService corService;
            CorTransfer cor;

            try {
                corService = new CorService();

                cor = await corService.Excluir(id);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorModel Excluir [" + ex.Message + "]");
            } finally {
                corService = null;
            }

            return cor;
        }

        public async Task<CorTransfer> ConsultarPorId(int id)
        {
            CorService corService;
            CorTransfer cor;
            
            try {
                corService = new CorService();

                cor = await corService.ConsultarPorId(id);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                corService = null;
            }

            return cor;
        }

        public async Task<CorTransfer> Consultar(CorTransfer corListaTransfer)
        {
            CorService corService;
            CorTransfer corLista;
            int dif = 0;
            int qtdExibe = 5;

            try {
                corService = new CorService();

                corLista = await corService.Consultar(corListaTransfer);

                if (corLista != null) {
                    if (corLista.TotalRegistros > 0) {
                        if (corLista.RegistrosPorPagina < 1) {
                            corLista.RegistrosPorPagina = 30;
                        } else if (corLista.RegistrosPorPagina > 200) {
                            corLista.RegistrosPorPagina = 30;
                        }

                        corLista.PaginaAtual = (corLista.PaginaAtual < 1 ? 1 : corLista.PaginaAtual);
                        corLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(corLista.TotalRegistros) 
                            / @Convert.ToDecimal(corLista.RegistrosPorPagina)));
                        corLista.TotalPaginas = (corLista.TotalPaginas < 1 ? 1 : corLista.TotalPaginas);

                        qtdExibe = (qtdExibe > corLista.TotalPaginas ? corLista.TotalPaginas : qtdExibe);

                        corLista.PaginaInicial = corLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        corLista.PaginaFinal = corLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        corLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (corLista.PaginaFinal - 1) : corLista.PaginaFinal);

                        if (corLista.PaginaInicial < 1) {
                            dif = 1 - corLista.PaginaInicial;
                            corLista.PaginaInicial += dif;
                            corLista.PaginaFinal += dif;
                        }

                        if (corLista.PaginaFinal > corLista.TotalPaginas) {
                            dif = corLista.PaginaFinal - corLista.TotalPaginas;
                            corLista.PaginaInicial -= dif;
                            corLista.PaginaFinal -= dif;
                        }

                        corLista.PaginaInicial = (corLista.PaginaInicial < 1 ? 1 : corLista.PaginaInicial);
                        corLista.PaginaFinal = (corLista.PaginaFinal > corLista.TotalPaginas ? 
                            corLista.TotalPaginas : corLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirErroMensagem("Erro em CorModel Consultar [" + ex.Message + "]");
            } finally {
                corService = null;
            }

            return corLista;
        }
    }
}
