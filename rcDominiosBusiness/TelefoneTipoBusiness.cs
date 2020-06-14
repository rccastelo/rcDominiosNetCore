using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class TelefoneTipoBusiness
    {
        public TelefoneTipoTransfer Validar(TelefoneTipoTransfer telefoneTipoTransfer) 
        {
            TelefoneTipoTransfer telefoneTipoValidacao;

            try  {
                telefoneTipoValidacao = new TelefoneTipoTransfer(telefoneTipoTransfer);

                //-- Descrição de Tipo de Telefone
                if (string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.IncluirMensagem("Necessário informar a Descrição do tipo de Telefone");
                } else if ((telefoneTipoValidacao.TelefoneTipo.Descricao.Length < 3) || 
                        (telefoneTipoValidacao.TelefoneTipo.Descricao.Length > 100)) {
                    telefoneTipoValidacao.IncluirMensagem("Descrição deve ter entre 3 e 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                } else if (!Validacao.ValidarBrancoIniFim(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.IncluirMensagem("Descrição não deve começar ou terminar com espaço em branco");
                }

                //-- Código de Tipo de Telefone
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                    if ((telefoneTipoValidacao.TelefoneTipo.Codigo.Length < 3) || 
                        (telefoneTipoValidacao.TelefoneTipo.Codigo.Length > 10)) {
                        telefoneTipoValidacao.IncluirMensagem("Código deve ter entre 3 e 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                        telefoneTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                telefoneTipoValidacao.Validacao = true;

                if (telefoneTipoValidacao.Mensagens != null) {
                    if (telefoneTipoValidacao.Mensagens.Count > 0) {
                        telefoneTipoValidacao.Validacao = false;
                    }
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoTransfer();

                telefoneTipoValidacao.IncluirMensagem("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
                telefoneTipoValidacao.Validacao = false;
                telefoneTipoValidacao.Erro = true;
            }

            return telefoneTipoValidacao;
        }

        public TelefoneTipoTransfer ValidarConsulta(TelefoneTipoTransfer telefoneTipoTransfer) 
        {
            TelefoneTipoTransfer telefoneTipoValidacao;

            try  {
                telefoneTipoValidacao = new TelefoneTipoTransfer(telefoneTipoTransfer);

                if (telefoneTipoValidacao != null) {

                    //-- Id
                    if ((telefoneTipoValidacao.Filtro.IdDe <= 0) && (telefoneTipoValidacao.Filtro.IdAte > 0)) {
                        telefoneTipoValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((telefoneTipoValidacao.Filtro.IdDe > 0) && (telefoneTipoValidacao.Filtro.IdAte > 0)) {
                        if (telefoneTipoValidacao.Filtro.IdDe >= telefoneTipoValidacao.Filtro.IdAte) {
                            telefoneTipoValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição de Tipo de Telefone
                    if (!string.IsNullOrEmpty(telefoneTipoValidacao.Filtro.Descricao)) {
                        if (telefoneTipoValidacao.Filtro.Descricao.Length > 100) {
                            telefoneTipoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(telefoneTipoValidacao.Filtro.Descricao)) {
                            telefoneTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código de Tipo de Telefone
                    if (!string.IsNullOrEmpty(telefoneTipoValidacao.Filtro.Codigo)) {
                        if (telefoneTipoValidacao.Filtro.Codigo.Length > 10) {
                            telefoneTipoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(telefoneTipoValidacao.Filtro.Codigo)) {
                            telefoneTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((telefoneTipoValidacao.Filtro.CriacaoDe == DateTime.MinValue) && (telefoneTipoValidacao.Filtro.CriacaoAte != DateTime.MinValue)) {
                        telefoneTipoValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((telefoneTipoValidacao.Filtro.CriacaoDe > DateTime.MinValue) && (telefoneTipoValidacao.Filtro.CriacaoAte > DateTime.MinValue)) {
                        if (telefoneTipoValidacao.Filtro.CriacaoDe >= telefoneTipoValidacao.Filtro.CriacaoAte) {
                            telefoneTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((telefoneTipoValidacao.Filtro.AlteracaoDe == DateTime.MinValue) && (telefoneTipoValidacao.Filtro.AlteracaoAte != DateTime.MinValue)) {
                        telefoneTipoValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((telefoneTipoValidacao.Filtro.AlteracaoDe > DateTime.MinValue) && (telefoneTipoValidacao.Filtro.AlteracaoAte > DateTime.MinValue)) {
                        if (telefoneTipoValidacao.Filtro.AlteracaoDe >= telefoneTipoValidacao.Filtro.AlteracaoAte) {
                            telefoneTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    telefoneTipoValidacao = new TelefoneTipoTransfer();
                    telefoneTipoValidacao.IncluirMensagem("É necessário informar os dados do Tipo de Telefone");
                }

                telefoneTipoValidacao.Validacao = true;

                if (telefoneTipoValidacao.Mensagens != null) {
                    if (telefoneTipoValidacao.Mensagens.Count > 0) {
                        telefoneTipoValidacao.Validacao = false;
                    }
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoTransfer();

                telefoneTipoValidacao.IncluirMensagem("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
                telefoneTipoValidacao.Validacao = false;
                telefoneTipoValidacao.Erro = true;
            }

            return telefoneTipoValidacao;
        }
    }
}
