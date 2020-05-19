using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class ProfissaoBusiness
    {
        public ProfissaoDataTransfer Validar(ProfissaoDataTransfer profissaoDataTransfer) 
        {
            ProfissaoDataTransfer profissaoValidacao;

            try  {
                profissaoValidacao = new ProfissaoDataTransfer(profissaoDataTransfer);
                profissaoValidacao.Profissao.Descricao = Tratamento.TratarStringNuloBranco(profissaoValidacao.Profissao.Descricao);
                profissaoValidacao.Profissao.Codigo = Tratamento.TratarStringNuloBranco(profissaoValidacao.Profissao.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(profissaoValidacao.Profissao.Descricao)) {
                    profissaoValidacao.ValidacaoMensagens.Add("Necessário informar a Descrição da Profissão");
                } else if (profissaoValidacao.Profissao.Descricao.Length > 100) {
                    profissaoValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(profissaoValidacao.Profissao.Descricao)) {
                    profissaoValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                    profissaoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(profissaoValidacao.Profissao.Codigo)) {
                    if (profissaoValidacao.Profissao.Codigo.Length > 10) {
                        profissaoValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(profissaoValidacao.Profissao.Codigo)) {
                        profissaoValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        profissaoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                if (profissaoValidacao.ValidacaoMensagens.Count > 0) {
                    profissaoValidacao.Validacao = false;
                } else {
                    profissaoValidacao.Validacao = true;
                }

                profissaoValidacao.Erro = false;
            } catch (Exception ex) {
                profissaoValidacao = new ProfissaoDataTransfer();

                profissaoValidacao.ErroMensagens.Add("Erro em ProfissaoBusiness Validar [" + ex.Message + "]");
                profissaoValidacao.Validacao = false;
                profissaoValidacao.Erro = true;
            }

            return profissaoValidacao;
        }

        public ProfissaoDataTransfer ValidarConsulta(ProfissaoDataTransfer profissaoDataTransfer) 
        {
            ProfissaoDataTransfer profissaoValidacao;

            try  {
                profissaoValidacao = new ProfissaoDataTransfer(profissaoDataTransfer);
                profissaoValidacao.Profissao.Descricao = Tratamento.TratarStringNuloBranco(profissaoValidacao.Profissao.Descricao);
                profissaoValidacao.Profissao.Codigo = Tratamento.TratarStringNuloBranco(profissaoValidacao.Profissao.Codigo);

                //-- Id
                if ((profissaoValidacao.IdDe <= 0) && (profissaoValidacao.IdAte > 0)) {
                    profissaoValidacao.ValidacaoMensagens.Add("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((profissaoValidacao.IdDe > 0) && (profissaoValidacao.IdAte > 0)) {
                    if (profissaoValidacao.IdDe >= profissaoValidacao.IdAte) {
                        profissaoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(profissaoValidacao.Profissao.Descricao)) {
                    if (profissaoValidacao.Profissao.Descricao.Length > 100) {
                        profissaoValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(profissaoValidacao.Profissao.Descricao)) {
                        profissaoValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                        profissaoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(profissaoValidacao.Profissao.Codigo)) {
                    if (profissaoValidacao.Profissao.Codigo.Length > 10) {
                        profissaoValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(profissaoValidacao.Profissao.Codigo)) {
                        profissaoValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        profissaoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((profissaoValidacao.CriacaoDe == DateTime.MinValue) && (profissaoValidacao.CriacaoAte != DateTime.MinValue)) {
                    profissaoValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((profissaoValidacao.CriacaoDe > DateTime.MinValue) && (profissaoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (profissaoValidacao.CriacaoDe >= profissaoValidacao.CriacaoAte) {
                        profissaoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((profissaoValidacao.AlteracaoDe == DateTime.MinValue) && (profissaoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    profissaoValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((profissaoValidacao.AlteracaoDe > DateTime.MinValue) && (profissaoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (profissaoValidacao.AlteracaoDe >= profissaoValidacao.AlteracaoAte) {
                        profissaoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                if (profissaoValidacao.ValidacaoMensagens.Count > 0) {
                    profissaoValidacao.Validacao = false;
                } else {
                    profissaoValidacao.Validacao = true;
                }

                profissaoValidacao.Erro = false;
            } catch (Exception ex) {
                profissaoValidacao = new ProfissaoDataTransfer();

                profissaoValidacao.ErroMensagens.Add("Erro em ProfissaoBusiness Validar [" + ex.Message + "]");
                profissaoValidacao.Validacao = false;
                profissaoValidacao.Erro = true;
            }

            return profissaoValidacao;
        }
    }
}
