using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class CorBusiness
    {
        public CorTransfer Validar(CorTransfer corTransfer) 
        {
            CorTransfer corValidacao;

            try  {
                corValidacao = new CorTransfer(corTransfer);
                corValidacao.Cor.Descricao = Tratamento.TratarStringNuloBranco(corValidacao.Cor.Descricao);
                corValidacao.Cor.Codigo = Tratamento.TratarStringNuloBranco(corValidacao.Cor.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(corValidacao.Cor.Descricao)) {
                    corValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição da Cor");
                } else if (corValidacao.Cor.Descricao.Length > 100) {
                    corValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(corValidacao.Cor.Descricao)) {
                    corValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(corValidacao.Cor.Codigo)) {
                    if (corValidacao.Cor.Codigo.Length > 10) {
                        corValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(corValidacao.Cor.Codigo)) {
                        corValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                corValidacao.Validacao = true;

                if (corValidacao.ValidacaoMensagens != null) {
                    if (corValidacao.ValidacaoMensagens.Count > 0) {
                        corValidacao.Validacao = false;
                    }
                }

                corValidacao.Erro = false;
            } catch (Exception ex) {
                corValidacao = new CorTransfer();

                corValidacao.IncluirErroMensagem("Erro em CorBusiness Validar [" + ex.Message + "]");
                corValidacao.Validacao = false;
                corValidacao.Erro = true;
            }

            return corValidacao;
        }

        public CorTransfer ValidarConsulta(CorTransfer corTransfer) 
        {
            CorTransfer corValidacao;

            try  {
                corValidacao = new CorTransfer(corTransfer);

                if (corValidacao != null) {
                    corValidacao.Descricao = Tratamento.TratarStringNuloBranco(corValidacao.Descricao);
                    corValidacao.Codigo = Tratamento.TratarStringNuloBranco(corValidacao.Codigo);

                    //-- Id
                    if ((corValidacao.IdDe <= 0) && (corValidacao.IdAte > 0)) {
                        corValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((corValidacao.IdDe > 0) && (corValidacao.IdAte > 0)) {
                        if (corValidacao.IdDe >= corValidacao.IdAte) {
                            corValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(corValidacao.Descricao)) {
                        if (corValidacao.Descricao.Length > 100) {
                            corValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(corValidacao.Descricao)) {
                            corValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                            corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(corValidacao.Codigo)) {
                        if (corValidacao.Codigo.Length > 10) {
                            corValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(corValidacao.Codigo)) {
                            corValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                            corValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((corValidacao.CriacaoDe == DateTime.MinValue) && (corValidacao.CriacaoAte != DateTime.MinValue)) {
                        corValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((corValidacao.CriacaoDe > DateTime.MinValue) && (corValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (corValidacao.CriacaoDe >= corValidacao.CriacaoAte) {
                            corValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((corValidacao.AlteracaoDe == DateTime.MinValue) && (corValidacao.AlteracaoAte != DateTime.MinValue)) {
                        corValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((corValidacao.AlteracaoDe > DateTime.MinValue) && (corValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (corValidacao.AlteracaoDe >= corValidacao.AlteracaoAte) {
                            corValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    corValidacao = new CorTransfer();
                    corValidacao.IncluirValidacaoMensagem("É necessário informar os dados da Cor");
                }

                corValidacao.Validacao = true;

                if (corValidacao.ValidacaoMensagens != null) {
                    if (corValidacao.ValidacaoMensagens.Count > 0) {
                        corValidacao.Validacao = false;
                    }
                }

                corValidacao.Erro = false;
            } catch (Exception ex) {
                corValidacao = new CorTransfer();

                corValidacao.IncluirErroMensagem("Erro em CorBusiness Validar [" + ex.Message + "]");
                corValidacao.Validacao = false;
                corValidacao.Erro = true;
            }

            return corValidacao;
        }
    }
}
