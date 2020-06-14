using System;
using rcDominiosTransfers;
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

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(pessoaTipoValidacao.PessoaTipo.Descricao)) {
                    pessoaTipoValidacao.IncluirMensagem("Necessário informar a Descrição do Tipo de Pessoa");
                } else if ((pessoaTipoValidacao.PessoaTipo.Descricao.Length < 3) || 
                        (pessoaTipoValidacao.PessoaTipo.Descricao.Length > 100)) {
                    pessoaTipoValidacao.IncluirMensagem("Descrição deve ter entre 3 e 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(pessoaTipoValidacao.PessoaTipo.Descricao)) {
                    pessoaTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    pessoaTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                } else if (!Validacao.ValidarBrancoIniFim(pessoaTipoValidacao.PessoaTipo.Descricao)) {
                    pessoaTipoValidacao.IncluirMensagem("Descrição não deve começar ou terminar com espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(pessoaTipoValidacao.PessoaTipo.Codigo)) {
                    if ((pessoaTipoValidacao.PessoaTipo.Codigo.Length < 3) || 
                        (pessoaTipoValidacao.PessoaTipo.Codigo.Length > 10)) {
                        pessoaTipoValidacao.IncluirMensagem("Código deve ter entre 3 e 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(pessoaTipoValidacao.PessoaTipo.Codigo)) {
                        pessoaTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        pessoaTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                pessoaTipoValidacao.Validacao = true;

                if (pessoaTipoValidacao.Mensagens != null) {
                    if (pessoaTipoValidacao.Mensagens.Count > 0) {
                        pessoaTipoValidacao.Validacao = false;
                    }
                }

                pessoaTipoValidacao.Erro = false;
            } catch (Exception ex) {
                pessoaTipoValidacao = new PessoaTipoTransfer();

                pessoaTipoValidacao.IncluirMensagem("Erro em PessoaTipoBusiness Validar [" + ex.Message + "]");
                pessoaTipoValidacao.Validacao = false;
                pessoaTipoValidacao.Erro = true;
            }

            return pessoaTipoValidacao;
        }

        public PessoaTipoTransfer ValidarConsulta(PessoaTipoTransfer pessoaTipoTransfer) 
        {
            PessoaTipoTransfer pessoaTipoValidacao;

            try  {
                pessoaTipoValidacao = new PessoaTipoTransfer(pessoaTipoTransfer);

                if (pessoaTipoValidacao != null) {

                    //-- Id
                    if ((pessoaTipoValidacao.Filtro.IdDe <= 0) && (pessoaTipoValidacao.Filtro.IdAte > 0)) {
                        pessoaTipoValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((pessoaTipoValidacao.Filtro.IdDe > 0) && (pessoaTipoValidacao.Filtro.IdAte > 0)) {
                        if (pessoaTipoValidacao.Filtro.IdDe >= pessoaTipoValidacao.Filtro.IdAte) {
                            pessoaTipoValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(pessoaTipoValidacao.Filtro.Descricao)) {
                        if (pessoaTipoValidacao.Filtro.Descricao.Length > 100) {
                            pessoaTipoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(pessoaTipoValidacao.Filtro.Descricao)) {
                            pessoaTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            pessoaTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(pessoaTipoValidacao.Filtro.Codigo)) {
                        if (pessoaTipoValidacao.Filtro.Codigo.Length > 10) {
                            pessoaTipoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(pessoaTipoValidacao.Filtro.Codigo)) {
                            pessoaTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            pessoaTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((pessoaTipoValidacao.Filtro.CriacaoDe == DateTime.MinValue) && (pessoaTipoValidacao.Filtro.CriacaoAte != DateTime.MinValue)) {
                        pessoaTipoValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((pessoaTipoValidacao.Filtro.CriacaoDe > DateTime.MinValue) && (pessoaTipoValidacao.Filtro.CriacaoAte > DateTime.MinValue)) {
                        if (pessoaTipoValidacao.Filtro.CriacaoDe >= pessoaTipoValidacao.Filtro.CriacaoAte) {
                            pessoaTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((pessoaTipoValidacao.Filtro.AlteracaoDe == DateTime.MinValue) && (pessoaTipoValidacao.Filtro.AlteracaoAte != DateTime.MinValue)) {
                        pessoaTipoValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((pessoaTipoValidacao.Filtro.AlteracaoDe > DateTime.MinValue) && (pessoaTipoValidacao.Filtro.AlteracaoAte > DateTime.MinValue)) {
                        if (pessoaTipoValidacao.Filtro.AlteracaoDe >= pessoaTipoValidacao.Filtro.AlteracaoAte) {
                            pessoaTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    pessoaTipoValidacao = new PessoaTipoTransfer();
                    pessoaTipoValidacao.IncluirMensagem("É necessário informar os dados do Tipo de Pessoa");
                }

                pessoaTipoValidacao.Validacao = true;

                if (pessoaTipoValidacao.Mensagens != null) {
                    if (pessoaTipoValidacao.Mensagens.Count > 0) {
                        pessoaTipoValidacao.Validacao = false;
                    }
                }

                pessoaTipoValidacao.Erro = false;
            } catch (Exception ex) {
                pessoaTipoValidacao = new PessoaTipoTransfer();

                pessoaTipoValidacao.IncluirMensagem("Erro em PessoaTipoBusiness Validar [" + ex.Message + "]");
                pessoaTipoValidacao.Validacao = false;
                pessoaTipoValidacao.Erro = true;
            }

            return pessoaTipoValidacao;
        }
    }
}
