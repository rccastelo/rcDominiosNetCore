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
                    estadoCivilValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição do Estado Civil");
                } else if (estadoCivilValidacao.EstadoCivil.Descricao.Length > 100) {
                    estadoCivilValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    estadoCivilValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    estadoCivilValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Codigo)) {
                    if (estadoCivilValidacao.EstadoCivil.Codigo.Length > 10) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(estadoCivilValidacao.EstadoCivil.Codigo)) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        estadoCivilValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                estadoCivilValidacao.Validacao = true;

                if (estadoCivilValidacao.ValidacaoMensagens != null) {
                    if (estadoCivilValidacao.ValidacaoMensagens.Count > 0) {
                        estadoCivilValidacao.Validacao = false;
                    }
                }

                estadoCivilValidacao.Erro = false;
            } catch (Exception ex) {
                estadoCivilValidacao = new EstadoCivilDataTransfer();

                estadoCivilValidacao.IncluirErroMensagem("Erro em EstadoCivilBusiness Validar [" + ex.Message + "]");
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
                    estadoCivilValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((estadoCivilValidacao.IdDe > 0) && (estadoCivilValidacao.IdAte > 0)) {
                    if (estadoCivilValidacao.IdDe >= estadoCivilValidacao.IdAte) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Descricao)) {
                    if (estadoCivilValidacao.EstadoCivil.Descricao.Length > 100) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(estadoCivilValidacao.EstadoCivil.Descricao)) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                        estadoCivilValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(estadoCivilValidacao.EstadoCivil.Codigo)) {
                    if (estadoCivilValidacao.EstadoCivil.Codigo.Length > 10) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(estadoCivilValidacao.EstadoCivil.Codigo)) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        estadoCivilValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((estadoCivilValidacao.CriacaoDe == DateTime.MinValue) && (estadoCivilValidacao.CriacaoAte != DateTime.MinValue)) {
                    estadoCivilValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((estadoCivilValidacao.CriacaoDe > DateTime.MinValue) && (estadoCivilValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (estadoCivilValidacao.CriacaoDe >= estadoCivilValidacao.CriacaoAte) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((estadoCivilValidacao.AlteracaoDe == DateTime.MinValue) && (estadoCivilValidacao.AlteracaoAte != DateTime.MinValue)) {
                    estadoCivilValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((estadoCivilValidacao.AlteracaoDe > DateTime.MinValue) && (estadoCivilValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (estadoCivilValidacao.AlteracaoDe >= estadoCivilValidacao.AlteracaoAte) {
                        estadoCivilValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                estadoCivilValidacao.Validacao = true;

                if (estadoCivilValidacao.ValidacaoMensagens != null) {
                    if (estadoCivilValidacao.ValidacaoMensagens.Count > 0) {
                        estadoCivilValidacao.Validacao = false;
                    }
                }

                estadoCivilValidacao.Erro = false;
            } catch (Exception ex) {
                estadoCivilValidacao = new EstadoCivilDataTransfer();

                estadoCivilValidacao.IncluirErroMensagem("Erro em EstadoCivilBusiness Validar [" + ex.Message + "]");
                estadoCivilValidacao.Validacao = false;
                estadoCivilValidacao.Erro = true;
            }

            return estadoCivilValidacao;
        }
    }
}
