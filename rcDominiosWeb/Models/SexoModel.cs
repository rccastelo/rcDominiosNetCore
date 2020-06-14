using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class SexoModel
    {
        private readonly IHttpContextAccessor httpContext;

        public SexoModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<SexoTransfer> Incluir(SexoTransfer sexoTransfer)
        {
            SexoService sexoService;
            SexoTransfer sexo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                sexoService = new SexoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                sexoTransfer.Sexo.Criacao = DateTime.Today;
                sexoTransfer.Sexo.Alteracao = DateTime.Today;

                sexo = await sexoService.Incluir(sexoTransfer, autorizacao);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoModel Incluir [" + ex.Message + "]");
            } finally {
                sexoService = null;
                autenticaModel = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> Alterar(SexoTransfer sexoTransfer)
        {
            SexoService sexoService;
            SexoTransfer sexo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                sexoService = new SexoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                sexoTransfer.Sexo.Alteracao = DateTime.Today;

                sexo = await sexoService.Alterar(sexoTransfer, autorizacao);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoModel Alterar [" + ex.Message + "]");
            } finally {
                sexoService = null;
                autenticaModel = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> Excluir(int id)
        {
            SexoService sexoService;
            SexoTransfer sexo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                sexoService = new SexoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                sexo = await sexoService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoModel Excluir [" + ex.Message + "]");
            } finally {
                sexoService = null;
                autenticaModel = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> ConsultarPorId(int id)
        {
            SexoService sexoService;
            SexoTransfer sexo;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                sexoService = new SexoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                sexo = await sexoService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                sexoService = null;
                autenticaModel = null;
            }

            return sexo;
        }

        public async Task<SexoTransfer> Consultar(SexoTransfer sexoListaTransfer)
        {
            SexoService sexoService;
            SexoTransfer sexoLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                sexoService = new SexoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                sexoLista = await sexoService.Consultar(sexoListaTransfer, autorizacao);

                if (sexoLista != null) {
                    if (sexoLista.Paginacao.TotalRegistros > 0) {
                        if (sexoLista.Paginacao.RegistrosPorPagina < 1) {
                            sexoLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (sexoLista.Paginacao.RegistrosPorPagina > 200) {
                            sexoLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        sexoLista.Paginacao.PaginaAtual = (sexoLista.Paginacao.PaginaAtual < 1 ? 1 : sexoLista.Paginacao.PaginaAtual);
                        sexoLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(sexoLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(sexoLista.Paginacao.RegistrosPorPagina)));
                        sexoLista.Paginacao.TotalPaginas = (sexoLista.Paginacao.TotalPaginas < 1 ? 1 : sexoLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > sexoLista.Paginacao.TotalPaginas ? sexoLista.Paginacao.TotalPaginas : qtdExibe);

                        sexoLista.Paginacao.PaginaInicial = sexoLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        sexoLista.Paginacao.PaginaFinal = sexoLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        sexoLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (sexoLista.Paginacao.PaginaFinal - 1) : sexoLista.Paginacao.PaginaFinal);

                        if (sexoLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - sexoLista.Paginacao.PaginaInicial;
                            sexoLista.Paginacao.PaginaInicial += dif;
                            sexoLista.Paginacao.PaginaFinal += dif;
                        }

                        if (sexoLista.Paginacao.PaginaFinal > sexoLista.Paginacao.TotalPaginas) {
                            dif = sexoLista.Paginacao.PaginaFinal - sexoLista.Paginacao.TotalPaginas;
                            sexoLista.Paginacao.PaginaInicial -= dif;
                            sexoLista.Paginacao.PaginaFinal -= dif;
                        }

                        sexoLista.Paginacao.PaginaInicial = (sexoLista.Paginacao.PaginaInicial < 1 ? 1 : sexoLista.Paginacao.PaginaInicial);
                        sexoLista.Paginacao.PaginaFinal = (sexoLista.Paginacao.PaginaFinal > sexoLista.Paginacao.TotalPaginas ? 
                            sexoLista.Paginacao.TotalPaginas : sexoLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirMensagem("Erro em SexoModel Consultar [" + ex.Message + "]");
            } finally {
                sexoService = null;
                autenticaModel = null;
            }

            return sexoLista;
        }
    }
}
