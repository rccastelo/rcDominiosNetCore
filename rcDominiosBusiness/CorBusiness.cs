using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class CorBusiness
    {
        public CorTransfer Validar(CorTransfer corTransfer) 
        {
            CorTransfer corValidacao;

            try  {
                corValidacao = new CorTransfer(corTransfer);

                //-- Descrição de Cor
                if (string.IsNullOrEmpty(corValidacao.Cor.Descricao)) {
                    corValidacao.IncluirMensagem("Necessário informar a Descrição da Cor");
                } else if ((corValidacao.Cor.Descricao.Length < 3) || 
                        (corValidacao.Cor.Descricao.Length > 100)) {
                    corValidacao.IncluirMensagem("Descrição deve ter entre 3 e 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(corValidacao.Cor.Descricao)) {
                    corValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    corValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                } else if (!Validacao.ValidarBrancoIniFim(corValidacao.Cor.Descricao)) {
                    corValidacao.IncluirMensagem("Descrição não deve começar ou terminar com espaço em branco");
                }

                //-- Código de Cor
                if (!string.IsNullOrEmpty(corValidacao.Cor.Codigo)) {
                    if ((corValidacao.Cor.Codigo.Length < 3) || 
                        (corValidacao.Cor.Codigo.Length > 10)) {
                        corValidacao.IncluirMensagem("Código deve ter entre 3 e 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(corValidacao.Cor.Codigo)) {
                        corValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        corValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                corValidacao.Validacao = true;

                if (corValidacao.Mensagens != null) {
                    if (corValidacao.Mensagens.Count > 0) {
                        corValidacao.Validacao = false;
                    }
                }

                corValidacao.Erro = false;
            } catch (Exception ex) {
                corValidacao = new CorTransfer();

                corValidacao.IncluirMensagem("Erro em CorBusiness Validar [" + ex.Message + "]");
                corValidacao.Validacao = false;
                corValidacao.Erro = true;
            }

            return corValidacao;
        }

        public CorTransfer ValidarConsulta(CorTransfer corTransfer) 
        {
            CorTransfer corValidacao;

            try  {
                corValidacao = new CorTransfer(corTransfer);

                if (corValidacao != null) {

                    //-- Id
                    if ((corValidacao.Filtro.IdDe <= 0) && (corValidacao.Filtro.IdAte > 0)) {
                        corValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((corValidacao.Filtro.IdDe > 0) && (corValidacao.Filtro.IdAte > 0)) {
                        if (corValidacao.Filtro.IdDe >= corValidacao.Filtro.IdAte) {
                            corValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição de Cor
                    if (!string.IsNullOrEmpty(corValidacao.Filtro.Descricao)) {
                        if (corValidacao.Filtro.Descricao.Length > 100) {
                            corValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(corValidacao.Filtro.Descricao)) {
                            corValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            corValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código de Cor
                    if (!string.IsNullOrEmpty(corValidacao.Filtro.Codigo)) {
                        if (corValidacao.Filtro.Codigo.Length > 10) {
                            corValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(corValidacao.Filtro.Codigo)) {
                            corValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            corValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((corValidacao.Filtro.CriacaoDe == DateTime.MinValue) && (corValidacao.Filtro.CriacaoAte != DateTime.MinValue)) {
                        corValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((corValidacao.Filtro.CriacaoDe > DateTime.MinValue) && (corValidacao.Filtro.CriacaoAte > DateTime.MinValue)) {
                        if (corValidacao.Filtro.CriacaoDe >= corValidacao.Filtro.CriacaoAte) {
                            corValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((corValidacao.Filtro.AlteracaoDe == DateTime.MinValue) && (corValidacao.Filtro.AlteracaoAte != DateTime.MinValue)) {
                        corValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((corValidacao.Filtro.AlteracaoDe > DateTime.MinValue) && (corValidacao.Filtro.AlteracaoAte > DateTime.MinValue)) {
                        if (corValidacao.Filtro.AlteracaoDe >= corValidacao.Filtro.AlteracaoAte) {
                            corValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    corValidacao = new CorTransfer();
                    corValidacao.IncluirMensagem("É necessário informar os dados da Cor");
                }

                corValidacao.Validacao = true;

                if (corValidacao.Mensagens != null) {
                    if (corValidacao.Mensagens.Count > 0) {
                        corValidacao.Validacao = false;
                    }
                }

                corValidacao.Erro = false;
            } catch (Exception ex) {
                corValidacao = new CorTransfer();

                corValidacao.IncluirMensagem("Erro em CorBusiness Validar [" + ex.Message + "]");
                corValidacao.Validacao = false;
                corValidacao.Erro = true;
            }

            return corValidacao;
        }
    }
}
