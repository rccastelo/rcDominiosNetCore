using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class TelefoneTipoBusiness
    {
        public TelefoneTipoDataTransfer Validar(TelefoneTipoDataTransfer telefoneTipoDataTransfer) 
        {
            TelefoneTipoDataTransfer telefoneTipoValidacao;

            try  {
                telefoneTipoValidacao = new TelefoneTipoDataTransfer(telefoneTipoDataTransfer);
                telefoneTipoValidacao.TelefoneTipo.Descricao = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.TelefoneTipo.Descricao);
                telefoneTipoValidacao.TelefoneTipo.Codigo = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.TelefoneTipo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição do tipo de Telefone");
                } else if (telefoneTipoValidacao.TelefoneTipo.Descricao.Length > 100) {
                    telefoneTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    telefoneTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                    if (telefoneTipoValidacao.TelefoneTipo.Codigo.Length > 10) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                telefoneTipoValidacao.Validacao = true;

                if (telefoneTipoValidacao.ValidacaoMensagens != null) {
                    if (telefoneTipoValidacao.ValidacaoMensagens.Count > 0) {
                        telefoneTipoValidacao.Validacao = false;
                    }
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoDataTransfer();

                telefoneTipoValidacao.IncluirErroMensagem("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
                telefoneTipoValidacao.Validacao = false;
                telefoneTipoValidacao.Erro = true;
            }

            return telefoneTipoValidacao;
        }

        public TelefoneTipoDataTransfer ValidarConsulta(TelefoneTipoDataTransfer telefoneTipoDataTransfer) 
        {
            TelefoneTipoDataTransfer telefoneTipoValidacao;

            try  {
                telefoneTipoValidacao = new TelefoneTipoDataTransfer(telefoneTipoDataTransfer);
                telefoneTipoValidacao.TelefoneTipo.Descricao = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.TelefoneTipo.Descricao);
                telefoneTipoValidacao.TelefoneTipo.Codigo = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.TelefoneTipo.Codigo);

                //-- Id
                if ((telefoneTipoValidacao.IdDe <= 0) && (telefoneTipoValidacao.IdAte > 0)) {
                    telefoneTipoValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((telefoneTipoValidacao.IdDe > 0) && (telefoneTipoValidacao.IdAte > 0)) {
                    if (telefoneTipoValidacao.IdDe >= telefoneTipoValidacao.IdAte) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    if (telefoneTipoValidacao.TelefoneTipo.Descricao.Length > 100) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                    if (telefoneTipoValidacao.TelefoneTipo.Codigo.Length > 10) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        telefoneTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((telefoneTipoValidacao.CriacaoDe == DateTime.MinValue) && (telefoneTipoValidacao.CriacaoAte != DateTime.MinValue)) {
                    telefoneTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((telefoneTipoValidacao.CriacaoDe > DateTime.MinValue) && (telefoneTipoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (telefoneTipoValidacao.CriacaoDe >= telefoneTipoValidacao.CriacaoAte) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((telefoneTipoValidacao.AlteracaoDe == DateTime.MinValue) && (telefoneTipoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    telefoneTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((telefoneTipoValidacao.AlteracaoDe > DateTime.MinValue) && (telefoneTipoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (telefoneTipoValidacao.AlteracaoDe >= telefoneTipoValidacao.AlteracaoAte) {
                        telefoneTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                telefoneTipoValidacao.Validacao = true;

                if (telefoneTipoValidacao.ValidacaoMensagens != null) {
                    if (telefoneTipoValidacao.ValidacaoMensagens.Count > 0) {
                        telefoneTipoValidacao.Validacao = false;
                    }
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoDataTransfer();

                telefoneTipoValidacao.IncluirErroMensagem("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
                telefoneTipoValidacao.Validacao = false;
                telefoneTipoValidacao.Erro = true;
            }

            return telefoneTipoValidacao;
        }
    }
}
