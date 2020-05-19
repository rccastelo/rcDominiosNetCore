using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class ContaBancariaBusiness
    {
        public ContaBancariaDataTransfer Validar(ContaBancariaDataTransfer contaBancariaDataTransfer) 
        {
            ContaBancariaDataTransfer contaBancariaValidacao;

            try  {
                contaBancariaValidacao = new ContaBancariaDataTransfer(contaBancariaDataTransfer);
                contaBancariaValidacao.ContaBancaria.Descricao = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.ContaBancaria.Descricao);
                contaBancariaValidacao.ContaBancaria.Codigo = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.ContaBancaria.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(contaBancariaValidacao.ContaBancaria.Descricao)) {
                    contaBancariaValidacao.ValidacaoMensagens.Add("Necessário informar a Descrição do tipo de Conta Bancária");
                } else if (contaBancariaValidacao.ContaBancaria.Descricao.Length > 100) {
                    contaBancariaValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(contaBancariaValidacao.ContaBancaria.Descricao)) {
                    contaBancariaValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                    contaBancariaValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(contaBancariaValidacao.ContaBancaria.Codigo)) {
                    if (contaBancariaValidacao.ContaBancaria.Codigo.Length > 10) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(contaBancariaValidacao.ContaBancaria.Codigo)) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        contaBancariaValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                if (contaBancariaValidacao.ValidacaoMensagens.Count > 0) {
                    contaBancariaValidacao.Validacao = false;
                } else {
                    contaBancariaValidacao.Validacao = true;
                }

                contaBancariaValidacao.Erro = false;
            } catch (Exception ex) {
                contaBancariaValidacao = new ContaBancariaDataTransfer();

                contaBancariaValidacao.ErroMensagens.Add("Erro em ContaBancariaBusiness Validar [" + ex.Message + "]");
                contaBancariaValidacao.Validacao = false;
                contaBancariaValidacao.Erro = true;
            }

            return contaBancariaValidacao;
        }

        public ContaBancariaDataTransfer ValidarConsulta(ContaBancariaDataTransfer contaBancariaDataTransfer) 
        {
            ContaBancariaDataTransfer contaBancariaValidacao;

            try  {
                contaBancariaValidacao = new ContaBancariaDataTransfer(contaBancariaDataTransfer);
                contaBancariaValidacao.ContaBancaria.Descricao = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.ContaBancaria.Descricao);
                contaBancariaValidacao.ContaBancaria.Codigo = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.ContaBancaria.Codigo);

                //-- Id
                if ((contaBancariaValidacao.IdDe <= 0) && (contaBancariaValidacao.IdAte > 0)) {
                    contaBancariaValidacao.ValidacaoMensagens.Add("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((contaBancariaValidacao.IdDe > 0) && (contaBancariaValidacao.IdAte > 0)) {
                    if (contaBancariaValidacao.IdDe >= contaBancariaValidacao.IdAte) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(contaBancariaValidacao.ContaBancaria.Descricao)) {
                    if (contaBancariaValidacao.ContaBancaria.Descricao.Length > 100) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(contaBancariaValidacao.ContaBancaria.Descricao)) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                        contaBancariaValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(contaBancariaValidacao.ContaBancaria.Codigo)) {
                    if (contaBancariaValidacao.ContaBancaria.Codigo.Length > 10) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(contaBancariaValidacao.ContaBancaria.Codigo)) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        contaBancariaValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((contaBancariaValidacao.CriacaoDe == DateTime.MinValue) && (contaBancariaValidacao.CriacaoAte != DateTime.MinValue)) {
                    contaBancariaValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((contaBancariaValidacao.CriacaoDe > DateTime.MinValue) && (contaBancariaValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (contaBancariaValidacao.CriacaoDe >= contaBancariaValidacao.CriacaoAte) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((contaBancariaValidacao.AlteracaoDe == DateTime.MinValue) && (contaBancariaValidacao.AlteracaoAte != DateTime.MinValue)) {
                    contaBancariaValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((contaBancariaValidacao.AlteracaoDe > DateTime.MinValue) && (contaBancariaValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (contaBancariaValidacao.AlteracaoDe >= contaBancariaValidacao.AlteracaoAte) {
                        contaBancariaValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                if (contaBancariaValidacao.ValidacaoMensagens.Count > 0) {
                    contaBancariaValidacao.Validacao = false;
                } else {
                    contaBancariaValidacao.Validacao = true;
                }

                contaBancariaValidacao.Erro = false;
            } catch (Exception ex) {
                contaBancariaValidacao = new ContaBancariaDataTransfer();

                contaBancariaValidacao.ErroMensagens.Add("Erro em ContaBancariaBusiness Validar [" + ex.Message + "]");
                contaBancariaValidacao.Validacao = false;
                contaBancariaValidacao.Erro = true;
            }

            return contaBancariaValidacao;
        }
    }
}
