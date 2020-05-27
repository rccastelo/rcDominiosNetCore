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
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaModel Incluir [" + ex.Message + "]");
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
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaModel Alterar [" + ex.Message + "]");
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
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaModel Excluir [" + ex.Message + "]");
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
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaModel ConsultarPorId [" + ex.Message + "]");
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
                    if (contaBancariaLista.TotalRegistros > 0) {
                        if (contaBancariaLista.RegistrosPorPagina < 1) {
                            contaBancariaLista.RegistrosPorPagina = 30;
                        } else if (contaBancariaLista.RegistrosPorPagina > 200) {
                            contaBancariaLista.RegistrosPorPagina = 30;
                        }

                        contaBancariaLista.PaginaAtual = (contaBancariaLista.PaginaAtual < 1 ? 1 : contaBancariaLista.PaginaAtual);
                        contaBancariaLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(contaBancariaLista.TotalRegistros) 
                            / @Convert.ToDecimal(contaBancariaLista.RegistrosPorPagina)));
                        contaBancariaLista.TotalPaginas = (contaBancariaLista.TotalPaginas < 1 ? 1 : contaBancariaLista.TotalPaginas);

                        qtdExibe = (qtdExibe > contaBancariaLista.TotalPaginas ? contaBancariaLista.TotalPaginas : qtdExibe);

                        contaBancariaLista.PaginaInicial = contaBancariaLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        contaBancariaLista.PaginaFinal = contaBancariaLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        contaBancariaLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (contaBancariaLista.PaginaFinal - 1) : contaBancariaLista.PaginaFinal);

                        if (contaBancariaLista.PaginaInicial < 1) {
                            dif = 1 - contaBancariaLista.PaginaInicial;
                            contaBancariaLista.PaginaInicial += dif;
                            contaBancariaLista.PaginaFinal += dif;
                        }

                        if (contaBancariaLista.PaginaFinal > contaBancariaLista.TotalPaginas) {
                            dif = contaBancariaLista.PaginaFinal - contaBancariaLista.TotalPaginas;
                            contaBancariaLista.PaginaInicial -= dif;
                            contaBancariaLista.PaginaFinal -= dif;
                        }

                        contaBancariaLista.PaginaInicial = (contaBancariaLista.PaginaInicial < 1 ? 1 : contaBancariaLista.PaginaInicial);
                        contaBancariaLista.PaginaFinal = (contaBancariaLista.PaginaFinal > contaBancariaLista.TotalPaginas ? 
                            contaBancariaLista.TotalPaginas : contaBancariaLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirErroMensagem("Erro em ContaBancariaModel Consultar [" + ex.Message + "]");
            } finally {
                contaBancariaService = null;
                autenticaModel = null;
            }

            return contaBancariaLista;
        }
    }
}
