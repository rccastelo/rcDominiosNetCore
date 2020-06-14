using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class EstadoCivilBusiness
    {
        public EstadoCivilTransfer Validar(EstadoCivilTransfer estadoCivilTransfer) 
        {
            EstadoCivilTransfer estadoCivilValidacao;

            try  {
                estadoCivilValidacao = new EstadoCivilTransfer(estadoCivilTransfer);

                //-- Descrição de Estado Civil
                if (string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    estadoCivilValidacao.IncluirMensagem("Necessário informar a Descrição do Estado Civil");
                } else if ((estadoCivilValidacao.EstadoCivil.Descricao.Length < 3) || 
                        (estadoCivilValidacao.EstadoCivil.Descricao.Length > 100)) {
                    estadoCivilValidacao.IncluirMensagem("Descrição deve ter entre 3 e 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    estadoCivilValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    estadoCivilValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                } else if (!Validacao.ValidarBrancoIniFim(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    estadoCivilValidacao.IncluirMensagem("Descrição não deve começar ou terminar com espaço em branco");
                }

                //-- Código de Estado Civil
                if (!string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Codigo)) {
                    if ((estadoCivilValidacao.EstadoCivil.Codigo.Length < 3) || 
                        (estadoCivilValidacao.EstadoCivil.Codigo.Length > 10)) {
                        estadoCivilValidacao.IncluirMensagem("Código deve ter entre 3 e 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(estadoCivilValidacao.EstadoCivil.Codigo)) {
                        estadoCivilValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        estadoCivilValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                estadoCivilValidacao.Validacao = true;

                if (estadoCivilValidacao.Mensagens != null) {
                    if (estadoCivilValidacao.Mensagens.Count > 0) {
                        estadoCivilValidacao.Validacao = false;
                    }
                }

                estadoCivilValidacao.Erro = false;
            } catch (Exception ex) {
                estadoCivilValidacao = new EstadoCivilTransfer();

                estadoCivilValidacao.IncluirMensagem("Erro em EstadoCivilBusiness Validar [" + ex.Message + "]");
                estadoCivilValidacao.Validacao = false;
                estadoCivilValidacao.Erro = true;
            }

            return estadoCivilValidacao;
        }

        public EstadoCivilTransfer ValidarConsulta(EstadoCivilTransfer estadoCivilTransfer) 
        {
            EstadoCivilTransfer estadoCivilValidacao;

            try  {
                estadoCivilValidacao = new EstadoCivilTransfer(estadoCivilTransfer);

                if (estadoCivilValidacao != null) {

                    //-- Id
                    if ((estadoCivilValidacao.Filtro.IdDe <= 0) && (estadoCivilValidacao.Filtro.IdAte > 0)) {
                        estadoCivilValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((estadoCivilValidacao.Filtro.IdDe > 0) && (estadoCivilValidacao.Filtro.IdAte > 0)) {
                        if (estadoCivilValidacao.Filtro.IdDe >= estadoCivilValidacao.Filtro.IdAte) {
                            estadoCivilValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição de Estado Civil
                    if (!string.IsNullOrEmpty(estadoCivilValidacao.Filtro.Descricao)) {
                        if (estadoCivilValidacao.Filtro.Descricao.Length > 100) {
                            estadoCivilValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(estadoCivilValidacao.Filtro.Descricao)) {
                            estadoCivilValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            estadoCivilValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código de Estado Civil
                    if (!string.IsNullOrEmpty(estadoCivilValidacao.Filtro.Codigo)) {
                        if (estadoCivilValidacao.Filtro.Codigo.Length > 10) {
                            estadoCivilValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(estadoCivilValidacao.Filtro.Codigo)) {
                            estadoCivilValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            estadoCivilValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((estadoCivilValidacao.Filtro.CriacaoDe == DateTime.MinValue) && (estadoCivilValidacao.Filtro.CriacaoAte != DateTime.MinValue)) {
                        estadoCivilValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((estadoCivilValidacao.Filtro.CriacaoDe > DateTime.MinValue) && (estadoCivilValidacao.Filtro.CriacaoAte > DateTime.MinValue)) {
                        if (estadoCivilValidacao.Filtro.CriacaoDe >= estadoCivilValidacao.Filtro.CriacaoAte) {
                            estadoCivilValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((estadoCivilValidacao.Filtro.AlteracaoDe == DateTime.MinValue) && (estadoCivilValidacao.Filtro.AlteracaoAte != DateTime.MinValue)) {
                        estadoCivilValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((estadoCivilValidacao.Filtro.AlteracaoDe > DateTime.MinValue) && (estadoCivilValidacao.Filtro.AlteracaoAte > DateTime.MinValue)) {
                        if (estadoCivilValidacao.Filtro.AlteracaoDe >= estadoCivilValidacao.Filtro.AlteracaoAte) {
                            estadoCivilValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    estadoCivilValidacao = new EstadoCivilTransfer();
                    estadoCivilValidacao.IncluirMensagem("É necessário informar os dados do Estado Civil");
                }

                estadoCivilValidacao.Validacao = true;

                if (estadoCivilValidacao.Mensagens != null) {
                    if (estadoCivilValidacao.Mensagens.Count > 0) {
                        estadoCivilValidacao.Validacao = false;
                    }
                }

                estadoCivilValidacao.Erro = false;
            } catch (Exception ex) {
                estadoCivilValidacao = new EstadoCivilTransfer();

                estadoCivilValidacao.IncluirMensagem("Erro em EstadoCivilBusiness Validar [" + ex.Message + "]");
                estadoCivilValidacao.Validacao = false;
                estadoCivilValidacao.Erro = true;
            }

            return estadoCivilValidacao;
        }
    }
}
