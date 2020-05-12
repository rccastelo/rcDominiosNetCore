using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class GeneroSocialBusiness
    {
        public GeneroSocialDataTransfer Validar(GeneroSocialDataTransfer generoSocialDataTransfer) 
        {
            GeneroSocialDataTransfer generoSocialValidacao;

            try  {
                generoSocialValidacao = new GeneroSocialDataTransfer(generoSocialDataTransfer);
                generoSocialValidacao.GeneroSocial.Descricao = Tratamento.TratarStringNuloBranco(generoSocialValidacao.GeneroSocial.Descricao);
                generoSocialValidacao.GeneroSocial.Codigo = Tratamento.TratarStringNuloBranco(generoSocialValidacao.GeneroSocial.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(generoSocialValidacao.GeneroSocial.Descricao)) {
                    generoSocialValidacao.ValidacaoMensagens.Add("Necessário informar a Descrição do Gênero Social");
                } else if (generoSocialValidacao.GeneroSocial.Descricao.Length > 100) {
                    generoSocialValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharDescricao(generoSocialValidacao.GeneroSocial.Descricao)) {
                    generoSocialValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                    generoSocialValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(generoSocialValidacao.GeneroSocial.Codigo)) {
                    if (generoSocialValidacao.GeneroSocial.Codigo.Length > 10) {
                        generoSocialValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharCodigoAlfanum(generoSocialValidacao.GeneroSocial.Codigo)) {
                        generoSocialValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        generoSocialValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                if (generoSocialValidacao.ValidacaoMensagens.Count > 0) {
                    generoSocialValidacao.Validacao = false;
                } else {
                    generoSocialValidacao.Validacao = true;
                }

                generoSocialValidacao.Erro = false;
            } catch (Exception ex) {
                generoSocialValidacao = new GeneroSocialDataTransfer();

                generoSocialValidacao.ErroMensagens.Add("Erro em GeneroSocialBusiness Validar [" + ex.Message + "]");
                generoSocialValidacao.Validacao = false;
                generoSocialValidacao.Erro = true;
            }

            return generoSocialValidacao;
        }

        public GeneroSocialDataTransfer ValidarConsulta(GeneroSocialDataTransfer generoSocialDataTransfer) 
        {
            GeneroSocialDataTransfer generoSocialValidacao;

            try  {
                generoSocialValidacao = new GeneroSocialDataTransfer(generoSocialDataTransfer);
                generoSocialValidacao.GeneroSocial.Descricao = Tratamento.TratarStringNuloBranco(generoSocialValidacao.GeneroSocial.Descricao);
                generoSocialValidacao.GeneroSocial.Codigo = Tratamento.TratarStringNuloBranco(generoSocialValidacao.GeneroSocial.Codigo);

                //-- Id
                if ((generoSocialValidacao.IdDe <= 0) && (generoSocialValidacao.IdAte > 0)) {
                    generoSocialValidacao.ValidacaoMensagens.Add("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((generoSocialValidacao.IdDe > 0) && (generoSocialValidacao.IdAte > 0)) {
                    if (generoSocialValidacao.IdDe >= generoSocialValidacao.IdAte) {
                        generoSocialValidacao.ValidacaoMensagens.Add("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(generoSocialValidacao.GeneroSocial.Descricao)) {
                    if (generoSocialValidacao.GeneroSocial.Descricao.Length > 100) {
                        generoSocialValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharDescricao(generoSocialValidacao.GeneroSocial.Descricao)) {
                        generoSocialValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                        generoSocialValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(generoSocialValidacao.GeneroSocial.Codigo)) {
                    if (generoSocialValidacao.GeneroSocial.Codigo.Length > 10) {
                        generoSocialValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharCodigoAlfanum(generoSocialValidacao.GeneroSocial.Codigo)) {
                        generoSocialValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        generoSocialValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((generoSocialValidacao.CriacaoDe == DateTime.MinValue) && (generoSocialValidacao.CriacaoAte != DateTime.MinValue)) {
                    generoSocialValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((generoSocialValidacao.CriacaoDe > DateTime.MinValue) && (generoSocialValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (generoSocialValidacao.CriacaoDe >= generoSocialValidacao.CriacaoAte) {
                        generoSocialValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((generoSocialValidacao.AlteracaoDe == DateTime.MinValue) && (generoSocialValidacao.AlteracaoAte != DateTime.MinValue)) {
                    generoSocialValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((generoSocialValidacao.AlteracaoDe > DateTime.MinValue) && (generoSocialValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (generoSocialValidacao.AlteracaoDe >= generoSocialValidacao.AlteracaoAte) {
                        generoSocialValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                if (generoSocialValidacao.ValidacaoMensagens.Count > 0) {
                    generoSocialValidacao.Validacao = false;
                } else {
                    generoSocialValidacao.Validacao = true;
                }

                generoSocialValidacao.Erro = false;
            } catch (Exception ex) {
                generoSocialValidacao = new GeneroSocialDataTransfer();

                generoSocialValidacao.ErroMensagens.Add("Erro em GeneroSocialBusiness Validar [" + ex.Message + "]");
                generoSocialValidacao.Validacao = false;
                generoSocialValidacao.Erro = true;
            }

            return generoSocialValidacao;
        }
    }
}
