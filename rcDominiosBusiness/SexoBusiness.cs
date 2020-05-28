using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class SexoBusiness
    {
        public SexoTransfer Validar(SexoTransfer sexoTransfer) 
        {
            SexoTransfer sexoValidacao;

            try  {
                sexoValidacao = new SexoTransfer(sexoTransfer);
                sexoValidacao.Sexo.Descricao = Tratamento.TratarStringNuloBranco(sexoValidacao.Sexo.Descricao);
                sexoValidacao.Sexo.Codigo = Tratamento.TratarStringNuloBranco(sexoValidacao.Sexo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(sexoValidacao.Sexo.Descricao)) {
                    sexoValidacao.IncluirMensagem("Necessário informar a Descrição do Sexo");
                } else if (sexoValidacao.Sexo.Descricao.Length > 100) {
                    sexoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(sexoValidacao.Sexo.Descricao)) {
                    sexoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    sexoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(sexoValidacao.Sexo.Codigo)) {
                    if (sexoValidacao.Sexo.Codigo.Length > 10) {
                        sexoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(sexoValidacao.Sexo.Codigo)) {
                        sexoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        sexoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                sexoValidacao.Validacao = true;

                if (sexoValidacao.Mensagens != null) {
                    if (sexoValidacao.Mensagens.Count > 0) {
                        sexoValidacao.Validacao = false;
                    }
                }

                sexoValidacao.Erro = false;
            } catch (Exception ex) {
                sexoValidacao = new SexoTransfer();

                sexoValidacao.IncluirMensagem("Erro em SexoBusiness Validar [" + ex.Message + "]");
                sexoValidacao.Validacao = false;
                sexoValidacao.Erro = true;
            }

            return sexoValidacao;
        }

        public SexoTransfer ValidarConsulta(SexoTransfer sexoTransfer) 
        {
            SexoTransfer sexoValidacao;

            try  {
                sexoValidacao = new SexoTransfer(sexoTransfer);

                if (sexoValidacao != null) {
                    sexoValidacao.Descricao = Tratamento.TratarStringNuloBranco(sexoValidacao.Descricao);
                    sexoValidacao.Codigo = Tratamento.TratarStringNuloBranco(sexoValidacao.Codigo);

                    //-- Id
                    if ((sexoValidacao.IdDe <= 0) && (sexoValidacao.IdAte > 0)) {
                        sexoValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((sexoValidacao.IdDe > 0) && (sexoValidacao.IdAte > 0)) {
                        if (sexoValidacao.IdDe >= sexoValidacao.IdAte) {
                            sexoValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(sexoValidacao.Descricao)) {
                        if (sexoValidacao.Descricao.Length > 100) {
                            sexoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(sexoValidacao.Descricao)) {
                            sexoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            sexoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(sexoValidacao.Codigo)) {
                        if (sexoValidacao.Codigo.Length > 10) {
                            sexoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(sexoValidacao.Codigo)) {
                            sexoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            sexoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((sexoValidacao.CriacaoDe == DateTime.MinValue) && (sexoValidacao.CriacaoAte != DateTime.MinValue)) {
                        sexoValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((sexoValidacao.CriacaoDe > DateTime.MinValue) && (sexoValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (sexoValidacao.CriacaoDe >= sexoValidacao.CriacaoAte) {
                            sexoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((sexoValidacao.AlteracaoDe == DateTime.MinValue) && (sexoValidacao.AlteracaoAte != DateTime.MinValue)) {
                        sexoValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((sexoValidacao.AlteracaoDe > DateTime.MinValue) && (sexoValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (sexoValidacao.AlteracaoDe >= sexoValidacao.AlteracaoAte) {
                            sexoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    sexoValidacao = new SexoTransfer();
                    sexoValidacao.IncluirMensagem("É necessário informar os dados do Sexo");
                }

                sexoValidacao.Validacao = true;

                if (sexoValidacao.Mensagens != null) {
                    if (sexoValidacao.Mensagens.Count > 0) {
                        sexoValidacao.Validacao = false;
                    }
                }

                sexoValidacao.Erro = false;
            } catch (Exception ex) {
                sexoValidacao = new SexoTransfer();

                sexoValidacao.IncluirMensagem("Erro em SexoBusiness Validar [" + ex.Message + "]");
                sexoValidacao.Validacao = false;
                sexoValidacao.Erro = true;
            }

            return sexoValidacao;
        }
    }
}
