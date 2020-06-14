using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class EnderecoTipoBusiness
    {
        public EnderecoTipoTransfer Validar(EnderecoTipoTransfer enderecoTipoTransfer) 
        {
            EnderecoTipoTransfer enderecoTipoValidacao;

            try  {
                enderecoTipoValidacao = new EnderecoTipoTransfer(enderecoTipoTransfer);

                //-- Descrição de Tipo de Endereço
                if (string.IsNullOrEmpty(enderecoTipoValidacao.EnderecoTipo.Descricao)) {
                    enderecoTipoValidacao.IncluirMensagem("Necessário informar a Descrição do tipo de Endereço");
                } else if ((enderecoTipoValidacao.EnderecoTipo.Descricao.Length < 3) || 
                        (enderecoTipoValidacao.EnderecoTipo.Descricao.Length > 100)) {
                    enderecoTipoValidacao.IncluirMensagem("Descrição deve ter entre 3 e 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(enderecoTipoValidacao.EnderecoTipo.Descricao)) {
                    enderecoTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    enderecoTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                } else if (!Validacao.ValidarBrancoIniFim(enderecoTipoValidacao.EnderecoTipo.Descricao)) {
                    enderecoTipoValidacao.IncluirMensagem("Descrição não deve começar ou terminar com espaço em branco");
                }

                //-- Código de Tipo de Endereço
                if (!string.IsNullOrEmpty(enderecoTipoValidacao.EnderecoTipo.Codigo)) {
                    if ((enderecoTipoValidacao.EnderecoTipo.Codigo.Length < 3) || 
                        (enderecoTipoValidacao.EnderecoTipo.Codigo.Length > 10)) {
                        enderecoTipoValidacao.IncluirMensagem("Código deve ter entre 3 e 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(enderecoTipoValidacao.EnderecoTipo.Codigo)) {
                        enderecoTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        enderecoTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                enderecoTipoValidacao.Validacao = true;

                if (enderecoTipoValidacao.Mensagens != null) {
                    if (enderecoTipoValidacao.Mensagens.Count > 0) {
                        enderecoTipoValidacao.Validacao = false;
                    }
                }

                enderecoTipoValidacao.Erro = false;
            } catch (Exception ex) {
                enderecoTipoValidacao = new EnderecoTipoTransfer();

                enderecoTipoValidacao.IncluirMensagem("Erro em EnderecoTipoBusiness Validar [" + ex.Message + "]");
                enderecoTipoValidacao.Validacao = false;
                enderecoTipoValidacao.Erro = true;
            }

            return enderecoTipoValidacao;
        }

        public EnderecoTipoTransfer ValidarConsulta(EnderecoTipoTransfer enderecoTipoTransfer) 
        {
            EnderecoTipoTransfer enderecoTipoValidacao;

            try  {
                enderecoTipoValidacao = new EnderecoTipoTransfer(enderecoTipoTransfer);

                if (enderecoTipoValidacao != null) {

                    //-- Id
                    if ((enderecoTipoValidacao.Filtro.IdDe <= 0) && (enderecoTipoValidacao.Filtro.IdAte > 0)) {
                        enderecoTipoValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((enderecoTipoValidacao.Filtro.IdDe > 0) && (enderecoTipoValidacao.Filtro.IdAte > 0)) {
                        if (enderecoTipoValidacao.Filtro.IdDe >= enderecoTipoValidacao.Filtro.IdAte) {
                            enderecoTipoValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição de Tipo de Endereço
                    if (!string.IsNullOrEmpty(enderecoTipoValidacao.Filtro.Descricao)) {
                        if (enderecoTipoValidacao.Filtro.Descricao.Length > 100) {
                            enderecoTipoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(enderecoTipoValidacao.Filtro.Descricao)) {
                            enderecoTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            enderecoTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código de Tipo de Endereço
                    if (!string.IsNullOrEmpty(enderecoTipoValidacao.Filtro.Codigo)) {
                        if (enderecoTipoValidacao.Filtro.Codigo.Length > 10) {
                            enderecoTipoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(enderecoTipoValidacao.Filtro.Codigo)) {
                            enderecoTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            enderecoTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((enderecoTipoValidacao.Filtro.CriacaoDe == DateTime.MinValue) && (enderecoTipoValidacao.Filtro.CriacaoAte != DateTime.MinValue)) {
                        enderecoTipoValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((enderecoTipoValidacao.Filtro.CriacaoDe > DateTime.MinValue) && (enderecoTipoValidacao.Filtro.CriacaoAte > DateTime.MinValue)) {
                        if (enderecoTipoValidacao.Filtro.CriacaoDe >= enderecoTipoValidacao.Filtro.CriacaoAte) {
                            enderecoTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((enderecoTipoValidacao.Filtro.AlteracaoDe == DateTime.MinValue) && (enderecoTipoValidacao.Filtro.AlteracaoAte != DateTime.MinValue)) {
                        enderecoTipoValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((enderecoTipoValidacao.Filtro.AlteracaoDe > DateTime.MinValue) && (enderecoTipoValidacao.Filtro.AlteracaoAte > DateTime.MinValue)) {
                        if (enderecoTipoValidacao.Filtro.AlteracaoDe >= enderecoTipoValidacao.Filtro.AlteracaoAte) {
                            enderecoTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    enderecoTipoValidacao = new EnderecoTipoTransfer();
                    enderecoTipoValidacao.IncluirMensagem("É necessário informar os dados do Tipo de Endereço");
                }

                enderecoTipoValidacao.Validacao = true;

                if (enderecoTipoValidacao.Mensagens != null) {
                    if (enderecoTipoValidacao.Mensagens.Count > 0) {
                        enderecoTipoValidacao.Validacao = false;
                    }
                }

                enderecoTipoValidacao.Erro = false;
            } catch (Exception ex) {
                enderecoTipoValidacao = new EnderecoTipoTransfer();

                enderecoTipoValidacao.IncluirMensagem("Erro em EnderecoTipoBusiness Validar [" + ex.Message + "]");
                enderecoTipoValidacao.Validacao = false;
                enderecoTipoValidacao.Erro = true;
            }

            return enderecoTipoValidacao;
        }
    }
}
