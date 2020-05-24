using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class ProfissaoBusiness
    {
        public ProfissaoTransfer Validar(ProfissaoTransfer profissaoTransfer) 
        {
            ProfissaoTransfer profissaoValidacao;

            try  {
                profissaoValidacao = new ProfissaoTransfer(profissaoTransfer);
                profissaoValidacao.Profissao.Descricao = Tratamento.TratarStringNuloBranco(profissaoValidacao.Profissao.Descricao);
                profissaoValidacao.Profissao.Codigo = Tratamento.TratarStringNuloBranco(profissaoValidacao.Profissao.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(profissaoValidacao.Profissao.Descricao)) {
                    profissaoValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição da Profissão");
                } else if (profissaoValidacao.Profissao.Descricao.Length > 100) {
                    profissaoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(profissaoValidacao.Profissao.Descricao)) {
                    profissaoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    profissaoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(profissaoValidacao.Profissao.Codigo)) {
                    if (profissaoValidacao.Profissao.Codigo.Length > 10) {
                        profissaoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(profissaoValidacao.Profissao.Codigo)) {
                        profissaoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        profissaoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                profissaoValidacao.Validacao = true;

                if (profissaoValidacao.ValidacaoMensagens != null) {
                    if (profissaoValidacao.ValidacaoMensagens.Count > 0) {
                        profissaoValidacao.Validacao = false;
                    }
                }

                profissaoValidacao.Erro = false;
            } catch (Exception ex) {
                profissaoValidacao = new ProfissaoTransfer();

                profissaoValidacao.IncluirErroMensagem("Erro em ProfissaoBusiness Validar [" + ex.Message + "]");
                profissaoValidacao.Validacao = false;
                profissaoValidacao.Erro = true;
            }

            return profissaoValidacao;
        }

        public ProfissaoTransfer ValidarConsulta(ProfissaoTransfer profissaoTransfer) 
        {
            ProfissaoTransfer profissaoValidacao;

            try  {
                profissaoValidacao = new ProfissaoTransfer(profissaoTransfer);

                if (profissaoValidacao != null) {
                    profissaoValidacao.Descricao = Tratamento.TratarStringNuloBranco(profissaoValidacao.Descricao);
                    profissaoValidacao.Codigo = Tratamento.TratarStringNuloBranco(profissaoValidacao.Codigo);

                    //-- Id
                    if ((profissaoValidacao.IdDe <= 0) && (profissaoValidacao.IdAte > 0)) {
                        profissaoValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((profissaoValidacao.IdDe > 0) && (profissaoValidacao.IdAte > 0)) {
                        if (profissaoValidacao.IdDe >= profissaoValidacao.IdAte) {
                            profissaoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(profissaoValidacao.Descricao)) {
                        if (profissaoValidacao.Descricao.Length > 100) {
                            profissaoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(profissaoValidacao.Descricao)) {
                            profissaoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                            profissaoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(profissaoValidacao.Codigo)) {
                        if (profissaoValidacao.Codigo.Length > 10) {
                            profissaoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(profissaoValidacao.Codigo)) {
                            profissaoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                            profissaoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((profissaoValidacao.CriacaoDe == DateTime.MinValue) && (profissaoValidacao.CriacaoAte != DateTime.MinValue)) {
                        profissaoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((profissaoValidacao.CriacaoDe > DateTime.MinValue) && (profissaoValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (profissaoValidacao.CriacaoDe >= profissaoValidacao.CriacaoAte) {
                            profissaoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((profissaoValidacao.AlteracaoDe == DateTime.MinValue) && (profissaoValidacao.AlteracaoAte != DateTime.MinValue)) {
                        profissaoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((profissaoValidacao.AlteracaoDe > DateTime.MinValue) && (profissaoValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (profissaoValidacao.AlteracaoDe >= profissaoValidacao.AlteracaoAte) {
                            profissaoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    profissaoValidacao = new ProfissaoTransfer();
                    profissaoValidacao.IncluirValidacaoMensagem("É necessário informar os dados da Profissão");
                }
                
                profissaoValidacao.Validacao = true;

                if (profissaoValidacao.ValidacaoMensagens != null) {
                    if (profissaoValidacao.ValidacaoMensagens.Count > 0) {
                        profissaoValidacao.Validacao = false;
                    }
                }

                profissaoValidacao.Erro = false;
            } catch (Exception ex) {
                profissaoValidacao = new ProfissaoTransfer();

                profissaoValidacao.IncluirErroMensagem("Erro em ProfissaoBusiness Validar [" + ex.Message + "]");
                profissaoValidacao.Validacao = false;
                profissaoValidacao.Erro = true;
            }

            return profissaoValidacao;
        }
    }
}
