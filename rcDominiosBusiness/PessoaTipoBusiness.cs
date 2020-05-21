using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class PessoaTipoBusiness
    {
        public PessoaTipoTransfer Validar(PessoaTipoTransfer pessoaTipoTransfer) 
        {
            PessoaTipoTransfer pessoaTipoValidacao;

            try  {
                pessoaTipoValidacao = new PessoaTipoTransfer(pessoaTipoTransfer);
                pessoaTipoValidacao.PessoaTipo.Descricao = Tratamento.TratarStringNuloBranco(pessoaTipoValidacao.PessoaTipo.Descricao);
                pessoaTipoValidacao.PessoaTipo.Codigo = Tratamento.TratarStringNuloBranco(pessoaTipoValidacao.PessoaTipo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(pessoaTipoValidacao.PessoaTipo.Descricao)) {
                    pessoaTipoValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição do Tipo de Pessoa");
                } else if (pessoaTipoValidacao.PessoaTipo.Descricao.Length > 100) {
                    pessoaTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(pessoaTipoValidacao.PessoaTipo.Descricao)) {
                    pessoaTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    pessoaTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(pessoaTipoValidacao.PessoaTipo.Codigo)) {
                    if (pessoaTipoValidacao.PessoaTipo.Codigo.Length > 10) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(pessoaTipoValidacao.PessoaTipo.Codigo)) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                pessoaTipoValidacao.Validacao = true;

                if (pessoaTipoValidacao.ValidacaoMensagens != null) {
                    if (pessoaTipoValidacao.ValidacaoMensagens.Count > 0) {
                        pessoaTipoValidacao.Validacao = false;
                    }
                }

                pessoaTipoValidacao.Erro = false;
            } catch (Exception ex) {
                pessoaTipoValidacao = new PessoaTipoTransfer();

                pessoaTipoValidacao.IncluirErroMensagem("Erro em PessoaTipoBusiness Validar [" + ex.Message + "]");
                pessoaTipoValidacao.Validacao = false;
                pessoaTipoValidacao.Erro = true;
            }

            return pessoaTipoValidacao;
        }

        public PessoaTipoListaTransfer ValidarConsulta(PessoaTipoListaTransfer pessoaTipoListaTransfer) 
        {
            PessoaTipoListaTransfer pessoaTipoValidacao;

            try  {
                pessoaTipoValidacao = new PessoaTipoListaTransfer(pessoaTipoListaTransfer);
                pessoaTipoValidacao.Descricao = Tratamento.TratarStringNuloBranco(pessoaTipoValidacao.Descricao);
                pessoaTipoValidacao.Codigo = Tratamento.TratarStringNuloBranco(pessoaTipoValidacao.Codigo);

                //-- Id
                if ((pessoaTipoValidacao.IdDe <= 0) && (pessoaTipoValidacao.IdAte > 0)) {
                    pessoaTipoValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((pessoaTipoValidacao.IdDe > 0) && (pessoaTipoValidacao.IdAte > 0)) {
                    if (pessoaTipoValidacao.IdDe >= pessoaTipoValidacao.IdAte) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(pessoaTipoValidacao.Descricao)) {
                    if (pessoaTipoValidacao.Descricao.Length > 100) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(pessoaTipoValidacao.Descricao)) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(pessoaTipoValidacao.Codigo)) {
                    if (pessoaTipoValidacao.Codigo.Length > 10) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(pessoaTipoValidacao.Codigo)) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        pessoaTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((pessoaTipoValidacao.CriacaoDe == DateTime.MinValue) && (pessoaTipoValidacao.CriacaoAte != DateTime.MinValue)) {
                    pessoaTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((pessoaTipoValidacao.CriacaoDe > DateTime.MinValue) && (pessoaTipoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (pessoaTipoValidacao.CriacaoDe >= pessoaTipoValidacao.CriacaoAte) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((pessoaTipoValidacao.AlteracaoDe == DateTime.MinValue) && (pessoaTipoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    pessoaTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((pessoaTipoValidacao.AlteracaoDe > DateTime.MinValue) && (pessoaTipoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (pessoaTipoValidacao.AlteracaoDe >= pessoaTipoValidacao.AlteracaoAte) {
                        pessoaTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                pessoaTipoValidacao.Validacao = true;

                if (pessoaTipoValidacao.ValidacaoMensagens != null) {
                    if (pessoaTipoValidacao.ValidacaoMensagens.Count > 0) {
                        pessoaTipoValidacao.Validacao = false;
                    }
                }

                pessoaTipoValidacao.Erro = false;
            } catch (Exception ex) {
                pessoaTipoValidacao = new PessoaTipoListaTransfer();

                pessoaTipoValidacao.IncluirErroMensagem("Erro em PessoaTipoBusiness Validar [" + ex.Message + "]");
                pessoaTipoValidacao.Validacao = false;
                pessoaTipoValidacao.Erro = true;
            }

            return pessoaTipoValidacao;
        }
    }
}
