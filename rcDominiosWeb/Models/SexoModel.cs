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
                sexo.IncluirErroMensagem("Erro em SexoModel Incluir [" + ex.Message + "]");
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
                sexo.IncluirErroMensagem("Erro em SexoModel Alterar [" + ex.Message + "]");
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
                sexo.IncluirErroMensagem("Erro em SexoModel Excluir [" + ex.Message + "]");
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
                sexo.IncluirErroMensagem("Erro em SexoModel ConsultarPorId [" + ex.Message + "]");
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
                    if (sexoLista.TotalRegistros > 0) {
                        if (sexoLista.RegistrosPorPagina < 1) {
                            sexoLista.RegistrosPorPagina = 30;
                        } else if (sexoLista.RegistrosPorPagina > 200) {
                            sexoLista.RegistrosPorPagina = 30;
                        }

                        sexoLista.PaginaAtual = (sexoLista.PaginaAtual < 1 ? 1 : sexoLista.PaginaAtual);
                        sexoLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(sexoLista.TotalRegistros) 
                            / @Convert.ToDecimal(sexoLista.RegistrosPorPagina)));
                        sexoLista.TotalPaginas = (sexoLista.TotalPaginas < 1 ? 1 : sexoLista.TotalPaginas);

                        qtdExibe = (qtdExibe > sexoLista.TotalPaginas ? sexoLista.TotalPaginas : qtdExibe);

                        sexoLista.PaginaInicial = sexoLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        sexoLista.PaginaFinal = sexoLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        sexoLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (sexoLista.PaginaFinal - 1) : sexoLista.PaginaFinal);

                        if (sexoLista.PaginaInicial < 1) {
                            dif = 1 - sexoLista.PaginaInicial;
                            sexoLista.PaginaInicial += dif;
                            sexoLista.PaginaFinal += dif;
                        }

                        if (sexoLista.PaginaFinal > sexoLista.TotalPaginas) {
                            dif = sexoLista.PaginaFinal - sexoLista.TotalPaginas;
                            sexoLista.PaginaInicial -= dif;
                            sexoLista.PaginaFinal -= dif;
                        }

                        sexoLista.PaginaInicial = (sexoLista.PaginaInicial < 1 ? 1 : sexoLista.PaginaInicial);
                        sexoLista.PaginaFinal = (sexoLista.PaginaFinal > sexoLista.TotalPaginas ? 
                            sexoLista.TotalPaginas : sexoLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirErroMensagem("Erro em SexoModel Consultar [" + ex.Message + "]");
            } finally {
                sexoService = null;
                autenticaModel = null;
            }

            return sexoLista;
        }
    }
}
