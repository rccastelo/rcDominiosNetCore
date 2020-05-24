using System;
using System.Threading.Tasks;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class EstadoCivilModel
    {
        public async Task<EstadoCivilTransfer> Incluir(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilService = new EstadoCivilService();

                estadoCivilTransfer.EstadoCivil.Criacao = DateTime.Today;
                estadoCivilTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivil = await estadoCivilService.Incluir(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirErroMensagem("Erro em EstadoCivilModel Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Alterar(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilService = new EstadoCivilService();

                estadoCivilTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivil = await estadoCivilService.Alterar(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirErroMensagem("Erro em EstadoCivilModel Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Excluir(int id)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilService = new EstadoCivilService();

                estadoCivil = await estadoCivilService.Excluir(id);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirErroMensagem("Erro em EstadoCivilModel Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> ConsultarPorId(int id)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;
            
            try {
                estadoCivilService = new EstadoCivilService();

                estadoCivil = await estadoCivilService.ConsultarPorId(id);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirErroMensagem("Erro em EstadoCivilModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Consultar(EstadoCivilTransfer estadoCivilListaTransfer)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivilLista;
            int dif = 0;
            int qtdExibe = 5;

            try {
                estadoCivilService = new EstadoCivilService();

                estadoCivilLista = await estadoCivilService.Consultar(estadoCivilListaTransfer);

                if (estadoCivilLista != null) {
                    if (estadoCivilLista.TotalRegistros > 0) {
                        if (estadoCivilLista.RegistrosPorPagina < 1) {
                            estadoCivilLista.RegistrosPorPagina = 30;
                        } else if (estadoCivilLista.RegistrosPorPagina > 200) {
                            estadoCivilLista.RegistrosPorPagina = 30;
                        }

                        estadoCivilLista.PaginaAtual = (estadoCivilLista.PaginaAtual < 1 ? 1 : estadoCivilLista.PaginaAtual);
                        estadoCivilLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(estadoCivilLista.TotalRegistros) 
                            / @Convert.ToDecimal(estadoCivilLista.RegistrosPorPagina)));
                        estadoCivilLista.TotalPaginas = (estadoCivilLista.TotalPaginas < 1 ? 1 : estadoCivilLista.TotalPaginas);

                        qtdExibe = (qtdExibe > estadoCivilLista.TotalPaginas ? estadoCivilLista.TotalPaginas : qtdExibe);

                        estadoCivilLista.PaginaInicial = estadoCivilLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        estadoCivilLista.PaginaFinal = estadoCivilLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        estadoCivilLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (estadoCivilLista.PaginaFinal - 1) : estadoCivilLista.PaginaFinal);

                        if (estadoCivilLista.PaginaInicial < 1) {
                            dif = 1 - estadoCivilLista.PaginaInicial;
                            estadoCivilLista.PaginaInicial += dif;
                            estadoCivilLista.PaginaFinal += dif;
                        }

                        if (estadoCivilLista.PaginaFinal > estadoCivilLista.TotalPaginas) {
                            dif = estadoCivilLista.PaginaFinal - estadoCivilLista.TotalPaginas;
                            estadoCivilLista.PaginaInicial -= dif;
                            estadoCivilLista.PaginaFinal -= dif;
                        }

                        estadoCivilLista.PaginaInicial = (estadoCivilLista.PaginaInicial < 1 ? 1 : estadoCivilLista.PaginaInicial);
                        estadoCivilLista.PaginaFinal = (estadoCivilLista.PaginaFinal > estadoCivilLista.TotalPaginas ? 
                            estadoCivilLista.TotalPaginas : estadoCivilLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirErroMensagem("Erro em EstadoCivilModel Consultar [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
            }

            return estadoCivilLista;
        }
    }
}
