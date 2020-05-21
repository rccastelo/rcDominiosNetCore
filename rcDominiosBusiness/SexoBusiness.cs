using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class SexoBusiness
    {
        public SexoDataTransfer Validar(SexoDataTransfer sexoDataTransfer) 
        {
            SexoDataTransfer sexoValidacao;

            try  {
                sexoValidacao = new SexoDataTransfer(sexoDataTransfer);
                sexoValidacao.Sexo.Descricao = Tratamento.TratarStringNuloBranco(sexoValidacao.Sexo.Descricao);
                sexoValidacao.Sexo.Codigo = Tratamento.TratarStringNuloBranco(sexoValidacao.Sexo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(sexoValidacao.Sexo.Descricao)) {
                    sexoValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição do Sexo");
                } else if (sexoValidacao.Sexo.Descricao.Length > 100) {
                    sexoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(sexoValidacao.Sexo.Descricao)) {
                    sexoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    sexoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(sexoValidacao.Sexo.Codigo)) {
                    if (sexoValidacao.Sexo.Codigo.Length > 10) {
                        sexoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(sexoValidacao.Sexo.Codigo)) {
                        sexoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        sexoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                sexoValidacao.Validacao = true;

                if (sexoValidacao.ValidacaoMensagens != null) {
                    if (sexoValidacao.ValidacaoMensagens.Count > 0) {
                        sexoValidacao.Validacao = false;
                    }
                }

                sexoValidacao.Erro = false;
            } catch (Exception ex) {
                sexoValidacao = new SexoDataTransfer();

                sexoValidacao.IncluirErroMensagem("Erro em SexoBusiness Validar [" + ex.Message + "]");
                sexoValidacao.Validacao = false;
                sexoValidacao.Erro = true;
            }

            return sexoValidacao;
        }

        public SexoDataTransfer ValidarConsulta(SexoDataTransfer sexoDataTransfer) 
        {
            SexoDataTransfer sexoValidacao;

            try  {
                sexoValidacao = new SexoDataTransfer(sexoDataTransfer);
                sexoValidacao.Sexo.Descricao = Tratamento.TratarStringNuloBranco(sexoValidacao.Sexo.Descricao);
                sexoValidacao.Sexo.Codigo = Tratamento.TratarStringNuloBranco(sexoValidacao.Sexo.Codigo);

                //-- Id
                if ((sexoValidacao.IdDe <= 0) && (sexoValidacao.IdAte > 0)) {
                    sexoValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((sexoValidacao.IdDe > 0) && (sexoValidacao.IdAte > 0)) {
                    if (sexoValidacao.IdDe >= sexoValidacao.IdAte) {
                        sexoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(sexoValidacao.Sexo.Descricao)) {
                    if (sexoValidacao.Sexo.Descricao.Length > 100) {
                        sexoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(sexoValidacao.Sexo.Descricao)) {
                        sexoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                        sexoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(sexoValidacao.Sexo.Codigo)) {
                    if (sexoValidacao.Sexo.Codigo.Length > 10) {
                        sexoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(sexoValidacao.Sexo.Codigo)) {
                        sexoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        sexoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((sexoValidacao.CriacaoDe == DateTime.MinValue) && (sexoValidacao.CriacaoAte != DateTime.MinValue)) {
                    sexoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((sexoValidacao.CriacaoDe > DateTime.MinValue) && (sexoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (sexoValidacao.CriacaoDe >= sexoValidacao.CriacaoAte) {
                        sexoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((sexoValidacao.AlteracaoDe == DateTime.MinValue) && (sexoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    sexoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((sexoValidacao.AlteracaoDe > DateTime.MinValue) && (sexoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (sexoValidacao.AlteracaoDe >= sexoValidacao.AlteracaoAte) {
                        sexoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                sexoValidacao.Validacao = true;

                if (sexoValidacao.ValidacaoMensagens != null) {
                    if (sexoValidacao.ValidacaoMensagens.Count > 0) {
                        sexoValidacao.Validacao = false;
                    }
                }

                sexoValidacao.Erro = false;
            } catch (Exception ex) {
                sexoValidacao = new SexoDataTransfer();

                sexoValidacao.IncluirErroMensagem("Erro em SexoBusiness Validar [" + ex.Message + "]");
                sexoValidacao.Validacao = false;
                sexoValidacao.Erro = true;
            }

            return sexoValidacao;
        }
    }
}
