using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class ContaBancariaBusiness
    {
        public ContaBancariaTransfer Validar(ContaBancariaTransfer contaBancariaTransfer) 
        {
            ContaBancariaTransfer contaBancariaValidacao;

            try  {
                contaBancariaValidacao = new ContaBancariaTransfer(contaBancariaTransfer);
                contaBancariaValidacao.ContaBancaria.Descricao = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.ContaBancaria.Descricao);
                contaBancariaValidacao.ContaBancaria.Codigo = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.ContaBancaria.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(contaBancariaValidacao.ContaBancaria.Descricao)) {
                    contaBancariaValidacao.IncluirMensagem("Necessário informar a Descrição do tipo de Conta Bancária");
                } else if (contaBancariaValidacao.ContaBancaria.Descricao.Length > 100) {
                    contaBancariaValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(contaBancariaValidacao.ContaBancaria.Descricao)) {
                    contaBancariaValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    contaBancariaValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(contaBancariaValidacao.ContaBancaria.Codigo)) {
                    if (contaBancariaValidacao.ContaBancaria.Codigo.Length > 10) {
                        contaBancariaValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(contaBancariaValidacao.ContaBancaria.Codigo)) {
                        contaBancariaValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        contaBancariaValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                contaBancariaValidacao.Validacao = true;

                if (contaBancariaValidacao.Mensagens != null) {
                    if (contaBancariaValidacao.Mensagens.Count > 0) {
                        contaBancariaValidacao.Validacao = false;
                    }
                }

                contaBancariaValidacao.Erro = false;
            } catch (Exception ex) {
                contaBancariaValidacao = new ContaBancariaTransfer();

                contaBancariaValidacao.IncluirMensagem("Erro em ContaBancariaBusiness Validar [" + ex.Message + "]");
                contaBancariaValidacao.Validacao = false;
                contaBancariaValidacao.Erro = true;
            }

            return contaBancariaValidacao;
        }

        public ContaBancariaTransfer ValidarConsulta(ContaBancariaTransfer contaBancariaTransfer) 
        {
            ContaBancariaTransfer contaBancariaValidacao;

            try  {
                contaBancariaValidacao = new ContaBancariaTransfer(contaBancariaTransfer);

                if (contaBancariaValidacao != null) {
                    contaBancariaValidacao.Descricao = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.Descricao);
                    contaBancariaValidacao.Codigo = Tratamento.TratarStringNuloBranco(contaBancariaValidacao.Codigo);

                    //-- Id
                    if ((contaBancariaValidacao.IdDe <= 0) && (contaBancariaValidacao.IdAte > 0)) {
                        contaBancariaValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((contaBancariaValidacao.IdDe > 0) && (contaBancariaValidacao.IdAte > 0)) {
                        if (contaBancariaValidacao.IdDe >= contaBancariaValidacao.IdAte) {
                            contaBancariaValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(contaBancariaValidacao.Descricao)) {
                        if (contaBancariaValidacao.Descricao.Length > 100) {
                            contaBancariaValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(contaBancariaValidacao.Descricao)) {
                            contaBancariaValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            contaBancariaValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(contaBancariaValidacao.Codigo)) {
                        if (contaBancariaValidacao.Codigo.Length > 10) {
                            contaBancariaValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(contaBancariaValidacao.Codigo)) {
                            contaBancariaValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            contaBancariaValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((contaBancariaValidacao.CriacaoDe == DateTime.MinValue) && (contaBancariaValidacao.CriacaoAte != DateTime.MinValue)) {
                        contaBancariaValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((contaBancariaValidacao.CriacaoDe > DateTime.MinValue) && (contaBancariaValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (contaBancariaValidacao.CriacaoDe >= contaBancariaValidacao.CriacaoAte) {
                            contaBancariaValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((contaBancariaValidacao.AlteracaoDe == DateTime.MinValue) && (contaBancariaValidacao.AlteracaoAte != DateTime.MinValue)) {
                        contaBancariaValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((contaBancariaValidacao.AlteracaoDe > DateTime.MinValue) && (contaBancariaValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (contaBancariaValidacao.AlteracaoDe >= contaBancariaValidacao.AlteracaoAte) {
                            contaBancariaValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    contaBancariaValidacao = new ContaBancariaTransfer();
                    contaBancariaValidacao.IncluirMensagem("É necessário informar os dados do Tipo de Conta Bancária");
                }

                contaBancariaValidacao.Validacao = true;

                if (contaBancariaValidacao.Mensagens != null) {
                    if (contaBancariaValidacao.Mensagens.Count > 0) {
                        contaBancariaValidacao.Validacao = false;
                    }
                }

                contaBancariaValidacao.Erro = false;
            } catch (Exception ex) {
                contaBancariaValidacao = new ContaBancariaTransfer();

                contaBancariaValidacao.IncluirMensagem("Erro em ContaBancariaBusiness Validar [" + ex.Message + "]");
                contaBancariaValidacao.Validacao = false;
                contaBancariaValidacao.Erro = true;
            }

            return contaBancariaValidacao;
        }
    }
}
