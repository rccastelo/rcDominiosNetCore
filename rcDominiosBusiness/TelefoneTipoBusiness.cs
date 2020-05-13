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
                    telefoneTipoValidacao.ValidacaoMensagens.Add("Necessário informar a Descrição do tipo de Telefone");
                } else if (telefoneTipoValidacao.TelefoneTipo.Descricao.Length > 100) {
                    telefoneTipoValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharDescricao(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                    telefoneTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                    if (telefoneTipoValidacao.TelefoneTipo.Codigo.Length > 10) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharCodigoAlfanum(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                if (telefoneTipoValidacao.ValidacaoMensagens.Count > 0) {
                    telefoneTipoValidacao.Validacao = false;
                } else {
                    telefoneTipoValidacao.Validacao = true;
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoDataTransfer();

                telefoneTipoValidacao.ErroMensagens.Add("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
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
                    telefoneTipoValidacao.ValidacaoMensagens.Add("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((telefoneTipoValidacao.IdDe > 0) && (telefoneTipoValidacao.IdAte > 0)) {
                    if (telefoneTipoValidacao.IdDe >= telefoneTipoValidacao.IdAte) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    if (telefoneTipoValidacao.TelefoneTipo.Descricao.Length > 100) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharDescricao(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                    if (telefoneTipoValidacao.TelefoneTipo.Codigo.Length > 10) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharCodigoAlfanum(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        telefoneTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((telefoneTipoValidacao.CriacaoDe == DateTime.MinValue) && (telefoneTipoValidacao.CriacaoAte != DateTime.MinValue)) {
                    telefoneTipoValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((telefoneTipoValidacao.CriacaoDe > DateTime.MinValue) && (telefoneTipoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (telefoneTipoValidacao.CriacaoDe >= telefoneTipoValidacao.CriacaoAte) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((telefoneTipoValidacao.AlteracaoDe == DateTime.MinValue) && (telefoneTipoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    telefoneTipoValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((telefoneTipoValidacao.AlteracaoDe > DateTime.MinValue) && (telefoneTipoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (telefoneTipoValidacao.AlteracaoDe >= telefoneTipoValidacao.AlteracaoAte) {
                        telefoneTipoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                if (telefoneTipoValidacao.ValidacaoMensagens.Count > 0) {
                    telefoneTipoValidacao.Validacao = false;
                } else {
                    telefoneTipoValidacao.Validacao = true;
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoDataTransfer();

                telefoneTipoValidacao.ErroMensagens.Add("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
                telefoneTipoValidacao.Validacao = false;
                telefoneTipoValidacao.Erro = true;
            }

            return telefoneTipoValidacao;
        }
    }
}
