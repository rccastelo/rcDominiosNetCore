using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class EstadoCivilModel
    {
        private readonly IHttpContextAccessor httpContext;

        public EstadoCivilModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<EstadoCivilTransfer> Incluir(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                estadoCivilService = new EstadoCivilService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                estadoCivilTransfer.EstadoCivil.Criacao = DateTime.Today;
                estadoCivilTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivil = await estadoCivilService.Incluir(estadoCivilTransfer, autorizacao);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilModel Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
                autenticaModel = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Alterar(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                estadoCivilService = new EstadoCivilService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                estadoCivilTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivil = await estadoCivilService.Alterar(estadoCivilTransfer, autorizacao);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilModel Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
                autenticaModel = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Excluir(int id)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                estadoCivilService = new EstadoCivilService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                estadoCivil = await estadoCivilService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilModel Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
                autenticaModel = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> ConsultarPorId(int id)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivil;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                estadoCivilService = new EstadoCivilService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                estadoCivil = await estadoCivilService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
                autenticaModel = null;
            }

            return estadoCivil;
        }

        public async Task<EstadoCivilTransfer> Consultar(EstadoCivilTransfer estadoCivilListaTransfer)
        {
            EstadoCivilService estadoCivilService;
            EstadoCivilTransfer estadoCivilLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                estadoCivilService = new EstadoCivilService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                estadoCivilLista = await estadoCivilService.Consultar(estadoCivilListaTransfer, autorizacao);

                if (estadoCivilLista != null) {
                    if (estadoCivilLista.Paginacao.TotalRegistros > 0) {
                        if (estadoCivilLista.Paginacao.RegistrosPorPagina < 1) {
                            estadoCivilLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (estadoCivilLista.Paginacao.RegistrosPorPagina > 200) {
                            estadoCivilLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        estadoCivilLista.Paginacao.PaginaAtual = (estadoCivilLista.Paginacao.PaginaAtual < 1 ? 1 : estadoCivilLista.Paginacao.PaginaAtual);
                        estadoCivilLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(estadoCivilLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(estadoCivilLista.Paginacao.RegistrosPorPagina)));
                        estadoCivilLista.Paginacao.TotalPaginas = (estadoCivilLista.Paginacao.TotalPaginas < 1 ? 1 : estadoCivilLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > estadoCivilLista.Paginacao.TotalPaginas ? estadoCivilLista.Paginacao.TotalPaginas : qtdExibe);

                        estadoCivilLista.Paginacao.PaginaInicial = estadoCivilLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        estadoCivilLista.Paginacao.PaginaFinal = estadoCivilLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        estadoCivilLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (estadoCivilLista.Paginacao.PaginaFinal - 1) : estadoCivilLista.Paginacao.PaginaFinal);

                        if (estadoCivilLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - estadoCivilLista.Paginacao.PaginaInicial;
                            estadoCivilLista.Paginacao.PaginaInicial += dif;
                            estadoCivilLista.Paginacao.PaginaFinal += dif;
                        }

                        if (estadoCivilLista.Paginacao.PaginaFinal > estadoCivilLista.Paginacao.TotalPaginas) {
                            dif = estadoCivilLista.Paginacao.PaginaFinal - estadoCivilLista.Paginacao.TotalPaginas;
                            estadoCivilLista.Paginacao.PaginaInicial -= dif;
                            estadoCivilLista.Paginacao.PaginaFinal -= dif;
                        }

                        estadoCivilLista.Paginacao.PaginaInicial = (estadoCivilLista.Paginacao.PaginaInicial < 1 ? 1 : estadoCivilLista.Paginacao.PaginaInicial);
                        estadoCivilLista.Paginacao.PaginaFinal = (estadoCivilLista.Paginacao.PaginaFinal > estadoCivilLista.Paginacao.TotalPaginas ? 
                            estadoCivilLista.Paginacao.TotalPaginas : estadoCivilLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirMensagem("Erro em EstadoCivilModel Consultar [" + ex.Message + "]");
            } finally {
                estadoCivilService = null;
                autenticaModel = null;
            }

            return estadoCivilLista;
        }
    }
}
