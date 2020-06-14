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

                //-- Descrição de Profissão
                if (string.IsNullOrEmpty(profissaoValidacao.Profissao.Descricao)) {
                    profissaoValidacao.IncluirMensagem("Necessário informar a Descrição da Profissão");
                } else if ((profissaoValidacao.Profissao.Descricao.Length < 3) || 
                        (profissaoValidacao.Profissao.Descricao.Length > 100)) {
                    profissaoValidacao.IncluirMensagem("Descrição deve ter entre 3 e 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(profissaoValidacao.Profissao.Descricao)) {
                    profissaoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    profissaoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                } else if (!Validacao.ValidarBrancoIniFim(profissaoValidacao.Profissao.Descricao)) {
                    profissaoValidacao.IncluirMensagem("Descrição não deve começar ou terminar com espaço em branco");
                }

                //-- Código de Profissão
                if (!string.IsNullOrEmpty(profissaoValidacao.Profissao.Codigo)) {
                    if ((profissaoValidacao.Profissao.Codigo.Length < 3) || 
                        (profissaoValidacao.Profissao.Codigo.Length > 10)) {
                        profissaoValidacao.IncluirMensagem("Código deve ter entre 3 e 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(profissaoValidacao.Profissao.Codigo)) {
                        profissaoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        profissaoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                profissaoValidacao.Validacao = true;

                if (profissaoValidacao.Mensagens != null) {
                    if (profissaoValidacao.Mensagens.Count > 0) {
                        profissaoValidacao.Validacao = false;
                    }
                }

                profissaoValidacao.Erro = false;
            } catch (Exception ex) {
                profissaoValidacao = new ProfissaoTransfer();

                profissaoValidacao.IncluirMensagem("Erro em ProfissaoBusiness Validar [" + ex.Message + "]");
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

                    //-- Id
                    if ((profissaoValidacao.Filtro.IdDe <= 0) && (profissaoValidacao.Filtro.IdAte > 0)) {
                        profissaoValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((profissaoValidacao.Filtro.IdDe > 0) && (profissaoValidacao.Filtro.IdAte > 0)) {
                        if (profissaoValidacao.Filtro.IdDe >= profissaoValidacao.Filtro.IdAte) {
                            profissaoValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição de Profissão
                    if (!string.IsNullOrEmpty(profissaoValidacao.Filtro.Descricao)) {
                        if (profissaoValidacao.Filtro.Descricao.Length > 100) {
                            profissaoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(profissaoValidacao.Filtro.Descricao)) {
                            profissaoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            profissaoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código de Profissão
                    if (!string.IsNullOrEmpty(profissaoValidacao.Filtro.Codigo)) {
                        if (profissaoValidacao.Filtro.Codigo.Length > 10) {
                            profissaoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(profissaoValidacao.Filtro.Codigo)) {
                            profissaoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            profissaoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((profissaoValidacao.Filtro.CriacaoDe == DateTime.MinValue) && (profissaoValidacao.Filtro.CriacaoAte != DateTime.MinValue)) {
                        profissaoValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((profissaoValidacao.Filtro.CriacaoDe > DateTime.MinValue) && (profissaoValidacao.Filtro.CriacaoAte > DateTime.MinValue)) {
                        if (profissaoValidacao.Filtro.CriacaoDe >= profissaoValidacao.Filtro.CriacaoAte) {
                            profissaoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((profissaoValidacao.Filtro.AlteracaoDe == DateTime.MinValue) && (profissaoValidacao.Filtro.AlteracaoAte != DateTime.MinValue)) {
                        profissaoValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((profissaoValidacao.Filtro.AlteracaoDe > DateTime.MinValue) && (profissaoValidacao.Filtro.AlteracaoAte > DateTime.MinValue)) {
                        if (profissaoValidacao.Filtro.AlteracaoDe >= profissaoValidacao.Filtro.AlteracaoAte) {
                            profissaoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    profissaoValidacao = new ProfissaoTransfer();
                    profissaoValidacao.IncluirMensagem("É necessário informar os dados da Profissão");
                }
                
                profissaoValidacao.Validacao = true;

                if (profissaoValidacao.Mensagens != null) {
                    if (profissaoValidacao.Mensagens.Count > 0) {
                        profissaoValidacao.Validacao = false;
                    }
                }

                profissaoValidacao.Erro = false;
            } catch (Exception ex) {
                profissaoValidacao = new ProfissaoTransfer();

                profissaoValidacao.IncluirMensagem("Erro em ProfissaoBusiness Validar [" + ex.Message + "]");
                profissaoValidacao.Validacao = false;
                profissaoValidacao.Erro = true;
            }

            return profissaoValidacao;
        }
    }
}
