using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class EnderecoTipoBusiness
    {
        public EnderecoTipoDataTransfer Validar(EnderecoTipoDataTransfer enderecoTipoDataTransfer) 
        {
            EnderecoTipoDataTransfer enderecoTipoValidacao;

            try  {
                enderecoTipoValidacao = new EnderecoTipoDataTransfer(enderecoTipoDataTransfer);
                enderecoTipoValidacao.EnderecoTipo.Descricao = Tratamento.TratarStringNuloBranco(enderecoTipoValidacao.EnderecoTipo.Descricao);
                enderecoTipoValidacao.EnderecoTipo.Codigo = Tratamento.TratarStringNuloBranco(enderecoTipoValidacao.EnderecoTipo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(enderecoTipoValidacao.EnderecoTipo.Descricao)) {
                    enderecoTipoValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição do tipo de Endereço");
                } else if (enderecoTipoValidacao.EnderecoTipo.Descricao.Length > 100) {
                    enderecoTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(enderecoTipoValidacao.EnderecoTipo.Descricao)) {
                    enderecoTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    enderecoTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(enderecoTipoValidacao.EnderecoTipo.Codigo)) {
                    if (enderecoTipoValidacao.EnderecoTipo.Codigo.Length > 10) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(enderecoTipoValidacao.EnderecoTipo.Codigo)) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                enderecoTipoValidacao.Validacao = true;

                if (enderecoTipoValidacao.ValidacaoMensagens != null) {
                    if (enderecoTipoValidacao.ValidacaoMensagens.Count > 0) {
                        enderecoTipoValidacao.Validacao = false;
                    }
                }

                enderecoTipoValidacao.Erro = false;
            } catch (Exception ex) {
                enderecoTipoValidacao = new EnderecoTipoDataTransfer();

                enderecoTipoValidacao.IncluirErroMensagem("Erro em EnderecoTipoBusiness Validar [" + ex.Message + "]");
                enderecoTipoValidacao.Validacao = false;
                enderecoTipoValidacao.Erro = true;
            }

            return enderecoTipoValidacao;
        }

        public EnderecoTipoDataTransfer ValidarConsulta(EnderecoTipoDataTransfer enderecoTipoDataTransfer) 
        {
            EnderecoTipoDataTransfer enderecoTipoValidacao;

            try  {
                enderecoTipoValidacao = new EnderecoTipoDataTransfer(enderecoTipoDataTransfer);
                enderecoTipoValidacao.EnderecoTipo.Descricao = Tratamento.TratarStringNuloBranco(enderecoTipoValidacao.EnderecoTipo.Descricao);
                enderecoTipoValidacao.EnderecoTipo.Codigo = Tratamento.TratarStringNuloBranco(enderecoTipoValidacao.EnderecoTipo.Codigo);

                //-- Id
                if ((enderecoTipoValidacao.IdDe <= 0) && (enderecoTipoValidacao.IdAte > 0)) {
                    enderecoTipoValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((enderecoTipoValidacao.IdDe > 0) && (enderecoTipoValidacao.IdAte > 0)) {
                    if (enderecoTipoValidacao.IdDe >= enderecoTipoValidacao.IdAte) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(enderecoTipoValidacao.EnderecoTipo.Descricao)) {
                    if (enderecoTipoValidacao.EnderecoTipo.Descricao.Length > 100) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(enderecoTipoValidacao.EnderecoTipo.Descricao)) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(enderecoTipoValidacao.EnderecoTipo.Codigo)) {
                    if (enderecoTipoValidacao.EnderecoTipo.Codigo.Length > 10) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(enderecoTipoValidacao.EnderecoTipo.Codigo)) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        enderecoTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((enderecoTipoValidacao.CriacaoDe == DateTime.MinValue) && (enderecoTipoValidacao.CriacaoAte != DateTime.MinValue)) {
                    enderecoTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((enderecoTipoValidacao.CriacaoDe > DateTime.MinValue) && (enderecoTipoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (enderecoTipoValidacao.CriacaoDe >= enderecoTipoValidacao.CriacaoAte) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((enderecoTipoValidacao.AlteracaoDe == DateTime.MinValue) && (enderecoTipoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    enderecoTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((enderecoTipoValidacao.AlteracaoDe > DateTime.MinValue) && (enderecoTipoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (enderecoTipoValidacao.AlteracaoDe >= enderecoTipoValidacao.AlteracaoAte) {
                        enderecoTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                enderecoTipoValidacao.Validacao = true;

                if (enderecoTipoValidacao.ValidacaoMensagens != null) {
                    if (enderecoTipoValidacao.ValidacaoMensagens.Count > 0) {
                        enderecoTipoValidacao.Validacao = false;
                    }
                }

                enderecoTipoValidacao.Erro = false;
            } catch (Exception ex) {
                enderecoTipoValidacao = new EnderecoTipoDataTransfer();

                enderecoTipoValidacao.IncluirErroMensagem("Erro em EnderecoTipoBusiness Validar [" + ex.Message + "]");
                enderecoTipoValidacao.Validacao = false;
                enderecoTipoValidacao.Erro = true;
            }

            return enderecoTipoValidacao;
        }
    }
}
