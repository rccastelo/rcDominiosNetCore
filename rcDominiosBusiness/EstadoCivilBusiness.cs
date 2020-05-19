using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class EstadoCivilBusiness
    {
        public EstadoCivilDataTransfer Validar(EstadoCivilDataTransfer estadoCivilDataTransfer) 
        {
            EstadoCivilDataTransfer estadoCivilValidacao;

            try  {
                estadoCivilValidacao = new EstadoCivilDataTransfer(estadoCivilDataTransfer);
                estadoCivilValidacao.EstadoCivil.Descricao = Tratamento.TratarStringNuloBranco(estadoCivilValidacao.EstadoCivil.Descricao);
                estadoCivilValidacao.EstadoCivil.Codigo = Tratamento.TratarStringNuloBranco(estadoCivilValidacao.EstadoCivil.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    estadoCivilValidacao.ValidacaoMensagens.Add("Necessário informar a Descrição do Estado Civil");
                } else if (estadoCivilValidacao.EstadoCivil.Descricao.Length > 100) {
                    estadoCivilValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    estadoCivilValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                    estadoCivilValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Codigo)) {
                    if (estadoCivilValidacao.EstadoCivil.Codigo.Length > 10) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(estadoCivilValidacao.EstadoCivil.Codigo)) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        estadoCivilValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                if (estadoCivilValidacao.ValidacaoMensagens.Count > 0) {
                    estadoCivilValidacao.Validacao = false;
                } else {
                    estadoCivilValidacao.Validacao = true;
                }

                estadoCivilValidacao.Erro = false;
            } catch (Exception ex) {
                estadoCivilValidacao = new EstadoCivilDataTransfer();

                estadoCivilValidacao.ErroMensagens.Add("Erro em EstadoCivilBusiness Validar [" + ex.Message + "]");
                estadoCivilValidacao.Validacao = false;
                estadoCivilValidacao.Erro = true;
            }

            return estadoCivilValidacao;
        }

        public EstadoCivilDataTransfer ValidarConsulta(EstadoCivilDataTransfer estadoCivilDataTransfer) 
        {
            EstadoCivilDataTransfer estadoCivilValidacao;

            try  {
                estadoCivilValidacao = new EstadoCivilDataTransfer(estadoCivilDataTransfer);
                estadoCivilValidacao.EstadoCivil.Descricao = Tratamento.TratarStringNuloBranco(estadoCivilValidacao.EstadoCivil.Descricao);
                estadoCivilValidacao.EstadoCivil.Codigo = Tratamento.TratarStringNuloBranco(estadoCivilValidacao.EstadoCivil.Codigo);

                //-- Id
                if ((estadoCivilValidacao.IdDe <= 0) && (estadoCivilValidacao.IdAte > 0)) {
                    estadoCivilValidacao.ValidacaoMensagens.Add("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((estadoCivilValidacao.IdDe > 0) && (estadoCivilValidacao.IdAte > 0)) {
                    if (estadoCivilValidacao.IdDe >= estadoCivilValidacao.IdAte) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    if (estadoCivilValidacao.EstadoCivil.Descricao.Length > 100) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(estadoCivilValidacao.EstadoCivil.Descricao)) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                        estadoCivilValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Codigo)) {
                    if (estadoCivilValidacao.EstadoCivil.Codigo.Length > 10) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(estadoCivilValidacao.EstadoCivil.Codigo)) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        estadoCivilValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((estadoCivilValidacao.CriacaoDe == DateTime.MinValue) && (estadoCivilValidacao.CriacaoAte != DateTime.MinValue)) {
                    estadoCivilValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((estadoCivilValidacao.CriacaoDe > DateTime.MinValue) && (estadoCivilValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (estadoCivilValidacao.CriacaoDe >= estadoCivilValidacao.CriacaoAte) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((estadoCivilValidacao.AlteracaoDe == DateTime.MinValue) && (estadoCivilValidacao.AlteracaoAte != DateTime.MinValue)) {
                    estadoCivilValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((estadoCivilValidacao.AlteracaoDe > DateTime.MinValue) && (estadoCivilValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (estadoCivilValidacao.AlteracaoDe >= estadoCivilValidacao.AlteracaoAte) {
                        estadoCivilValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                if (estadoCivilValidacao.ValidacaoMensagens.Count > 0) {
                    estadoCivilValidacao.Validacao = false;
                } else {
                    estadoCivilValidacao.Validacao = true;
                }

                estadoCivilValidacao.Erro = false;
            } catch (Exception ex) {
                estadoCivilValidacao = new EstadoCivilDataTransfer();

                estadoCivilValidacao.ErroMensagens.Add("Erro em EstadoCivilBusiness Validar [" + ex.Message + "]");
                estadoCivilValidacao.Validacao = false;
                estadoCivilValidacao.Erro = true;
            }

            return estadoCivilValidacao;
        }
    }
}
