using System;
using System.Threading.Tasks;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class PessoaTipoModel
    {
        public async Task<PessoaTipoTransfer> Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoTransfer.PessoaTipo.Criacao = DateTime.Today;
                pessoaTipoTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipo = await pessoaTipoService.Incluir(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipo = await pessoaTipoService.Alterar(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoModel Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Excluir(int id)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipo = await pessoaTipoService.Excluir(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoModel Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> ConsultarPorId(int id)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;
            
            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipo = await pessoaTipoService.ConsultarPorId(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return pessoaTipo;
        }

        public async Task<PessoaTipoTransfer> Consultar(PessoaTipoTransfer pessoaTipoListaTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipoLista;
            int dif = 0;
            int qtdExibe = 5;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoLista = await pessoaTipoService.Consultar(pessoaTipoListaTransfer);

                if (pessoaTipoLista != null) {
                    if (pessoaTipoLista.TotalRegistros > 1) {
                        if (pessoaTipoLista.RegistrosPorPagina < 1) {
                            pessoaTipoLista.RegistrosPorPagina = 30;
                        } else if (pessoaTipoLista.RegistrosPorPagina > 200) {
                            pessoaTipoLista.RegistrosPorPagina = 30;
                        }

                        pessoaTipoLista.PaginaAtual = (pessoaTipoLista.PaginaAtual < 1 ? 1 : pessoaTipoLista.PaginaAtual);
                        pessoaTipoLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(pessoaTipoLista.TotalRegistros) 
                            / @Convert.ToDecimal(pessoaTipoLista.RegistrosPorPagina)));
                        pessoaTipoLista.TotalPaginas = (pessoaTipoLista.TotalPaginas < 1 ? 1 : pessoaTipoLista.TotalPaginas);

                        qtdExibe = (qtdExibe > pessoaTipoLista.TotalPaginas ? pessoaTipoLista.TotalPaginas : qtdExibe);

                        pessoaTipoLista.PaginaInicial = pessoaTipoLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        pessoaTipoLista.PaginaFinal = pessoaTipoLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        pessoaTipoLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (pessoaTipoLista.PaginaFinal - 1) : pessoaTipoLista.PaginaFinal);

                        if (pessoaTipoLista.PaginaInicial < 1) {
                            dif = 1 - pessoaTipoLista.PaginaInicial;
                            pessoaTipoLista.PaginaInicial += dif;
                            pessoaTipoLista.PaginaFinal += dif;
                        }

                        if (pessoaTipoLista.PaginaFinal > pessoaTipoLista.TotalPaginas) {
                            dif = pessoaTipoLista.PaginaFinal - pessoaTipoLista.TotalPaginas;
                            pessoaTipoLista.PaginaInicial -= dif;
                            pessoaTipoLista.PaginaFinal -= dif;
                        }

                        pessoaTipoLista.PaginaInicial = (pessoaTipoLista.PaginaInicial < 1 ? 1 : pessoaTipoLista.PaginaInicial);
                        pessoaTipoLista.PaginaFinal = (pessoaTipoLista.PaginaFinal > pessoaTipoLista.TotalPaginas ? 
                            pessoaTipoLista.TotalPaginas : pessoaTipoLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoModel Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return pessoaTipoLista;
        }
    }
}
