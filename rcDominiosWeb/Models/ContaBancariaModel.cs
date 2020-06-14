using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class ContaBancariaModel
    {
        private readonly IHttpContextAccessor httpContext;

        public ContaBancariaModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<ContaBancariaTransfer> Incluir(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaService contaBancariaService;
            ContaBancariaTransfer contaBancaria;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                contaBancariaService = new ContaBancariaService();
                autenticaModel = new AutenticaModel(httpContext);

                contaBancariaTransfer.ContaBancaria.Criacao = DateTime.Today;
                contaBancariaTransfer.ContaBancaria.Alteracao = DateTime.Today;

                autorizacao = autenticaModel.ObterToken();

                contaBancaria = await contaBancariaService.Incluir(contaBancariaTransfer, autorizacao);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaModel Incluir [" + ex.Message + "]");
            } finally {
                contaBancariaService = null;
                autenticaModel = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> Alterar(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaService contaBancariaService;
            ContaBancariaTransfer contaBancaria;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                contaBancariaService = new ContaBancariaService();
                autenticaModel = new AutenticaModel(httpContext);

                contaBancariaTransfer.ContaBancaria.Alteracao = DateTime.Today;

                autorizacao = autenticaModel.ObterToken();

                contaBancaria = await contaBancariaService.Alterar(contaBancariaTransfer, autorizacao);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaModel Alterar [" + ex.Message + "]");
            } finally {
                contaBancariaService = null;
                autenticaModel = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> Excluir(int id)
        {
            ContaBancariaService contaBancariaService;
            ContaBancariaTransfer contaBancaria;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                contaBancariaService = new ContaBancariaService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                contaBancaria = await contaBancariaService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaModel Excluir [" + ex.Message + "]");
            } finally {
                contaBancariaService = null;
                autenticaModel = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> ConsultarPorId(int id)
        {
            ContaBancariaService contaBancariaService;
            ContaBancariaTransfer contaBancaria;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                contaBancariaService = new ContaBancariaService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                contaBancaria = await contaBancariaService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                contaBancariaService = null;
                autenticaModel = null;
            }

            return contaBancaria;
        }

        public async Task<ContaBancariaTransfer> Consultar(ContaBancariaTransfer contaBancariaListaTransfer)
        {
            ContaBancariaService contaBancariaService;
            ContaBancariaTransfer contaBancariaLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                contaBancariaService = new ContaBancariaService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                contaBancariaLista = await contaBancariaService.Consultar(contaBancariaListaTransfer, autorizacao);

                if (contaBancariaLista != null) {
                    if (contaBancariaLista.Paginacao.TotalRegistros > 0) {
                        if (contaBancariaLista.Paginacao.RegistrosPorPagina < 1) {
                            contaBancariaLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (contaBancariaLista.Paginacao.RegistrosPorPagina > 200) {
                            contaBancariaLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        contaBancariaLista.Paginacao.PaginaAtual = (contaBancariaLista.Paginacao.PaginaAtual < 1 ? 1 : contaBancariaLista.Paginacao.PaginaAtual);
                        contaBancariaLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(contaBancariaLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(contaBancariaLista.Paginacao.RegistrosPorPagina)));
                        contaBancariaLista.Paginacao.TotalPaginas = (contaBancariaLista.Paginacao.TotalPaginas < 1 ? 1 : contaBancariaLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > contaBancariaLista.Paginacao.TotalPaginas ? contaBancariaLista.Paginacao.TotalPaginas : qtdExibe);

                        contaBancariaLista.Paginacao.PaginaInicial = contaBancariaLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        contaBancariaLista.Paginacao.PaginaFinal = contaBancariaLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        contaBancariaLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (contaBancariaLista.Paginacao.PaginaFinal - 1) : contaBancariaLista.Paginacao.PaginaFinal);

                        if (contaBancariaLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - contaBancariaLista.Paginacao.PaginaInicial;
                            contaBancariaLista.Paginacao.PaginaInicial += dif;
                            contaBancariaLista.Paginacao.PaginaFinal += dif;
                        }

                        if (contaBancariaLista.Paginacao.PaginaFinal > contaBancariaLista.Paginacao.TotalPaginas) {
                            dif = contaBancariaLista.Paginacao.PaginaFinal - contaBancariaLista.Paginacao.TotalPaginas;
                            contaBancariaLista.Paginacao.PaginaInicial -= dif;
                            contaBancariaLista.Paginacao.PaginaFinal -= dif;
                        }

                        contaBancariaLista.Paginacao.PaginaInicial = (contaBancariaLista.Paginacao.PaginaInicial < 1 ? 1 : contaBancariaLista.Paginacao.PaginaInicial);
                        contaBancariaLista.Paginacao.PaginaFinal = (contaBancariaLista.Paginacao.PaginaFinal > contaBancariaLista.Paginacao.TotalPaginas ? 
                            contaBancariaLista.Paginacao.TotalPaginas : contaBancariaLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirMensagem("Erro em ContaBancariaModel Consultar [" + ex.Message + "]");
            } finally {
                contaBancariaService = null;
                autenticaModel = null;
            }

            return contaBancariaLista;
        }
    }
}
