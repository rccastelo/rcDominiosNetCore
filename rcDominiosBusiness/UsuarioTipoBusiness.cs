using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class UsuarioTipoBusiness
    {
        public UsuarioTipoTransfer Validar(UsuarioTipoTransfer usuarioTipoTransfer) 
        {
            UsuarioTipoTransfer usuarioTipoValidacao;

            try  {
                usuarioTipoValidacao = new UsuarioTipoTransfer(usuarioTipoTransfer);

                //-- Descrição de Tipo de Usuário
                if (string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    usuarioTipoValidacao.IncluirMensagem("Necessário informar a Descrição do tipo de Usuário");
                } else if ((usuarioTipoValidacao.UsuarioTipo.Descricao.Length < 3) || 
                        (usuarioTipoValidacao.UsuarioTipo.Descricao.Length > 100)) {
                    usuarioTipoValidacao.IncluirMensagem("Descrição deve ter entre 3 e 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    usuarioTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    usuarioTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                } else if (!Validacao.ValidarBrancoIniFim(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    usuarioTipoValidacao.IncluirMensagem("Descrição não deve começar ou terminar com espaço em branco");
                }

                //-- Código de Tipo de Usuário
                if (!string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                    if ((usuarioTipoValidacao.UsuarioTipo.Codigo.Length < 3) || 
                        (usuarioTipoValidacao.UsuarioTipo.Codigo.Length > 10)) {
                        usuarioTipoValidacao.IncluirMensagem("Código deve ter entre 3 e 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                        usuarioTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        usuarioTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                usuarioTipoValidacao.Validacao = true;

                if (usuarioTipoValidacao.Mensagens != null) {
                    if (usuarioTipoValidacao.Mensagens.Count > 0) {
                        usuarioTipoValidacao.Validacao = false;
                    }
                }

                usuarioTipoValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioTipoValidacao = new UsuarioTipoTransfer();

                usuarioTipoValidacao.IncluirMensagem("Erro em UsuarioTipoBusiness Validar [" + ex.Message + "]");
                usuarioTipoValidacao.Validacao = false;
                usuarioTipoValidacao.Erro = true;
            }

            return usuarioTipoValidacao;
        }

        public UsuarioTipoTransfer ValidarConsulta(UsuarioTipoTransfer usuarioTipoTransfer) 
        {
            UsuarioTipoTransfer usuarioTipoValidacao;

            try  {
                usuarioTipoValidacao = new UsuarioTipoTransfer(usuarioTipoTransfer);

                if (usuarioTipoValidacao != null) {

                    //-- Id
                    if ((usuarioTipoValidacao.Filtro.IdDe <= 0) && (usuarioTipoValidacao.Filtro.IdAte > 0)) {
                        usuarioTipoValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((usuarioTipoValidacao.Filtro.IdDe > 0) && (usuarioTipoValidacao.Filtro.IdAte > 0)) {
                        if (usuarioTipoValidacao.Filtro.IdDe >= usuarioTipoValidacao.Filtro.IdAte) {
                            usuarioTipoValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição de Tipo de Usuário
                    if (!string.IsNullOrEmpty(usuarioTipoValidacao.Filtro.Descricao)) {
                        if (usuarioTipoValidacao.Filtro.Descricao.Length > 100) {
                            usuarioTipoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(usuarioTipoValidacao.Filtro.Descricao)) {
                            usuarioTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            usuarioTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código de Tipo de Usuário
                    if (!string.IsNullOrEmpty(usuarioTipoValidacao.Filtro.Codigo)) {
                        if (usuarioTipoValidacao.Filtro.Codigo.Length > 10) {
                            usuarioTipoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(usuarioTipoValidacao.Filtro.Codigo)) {
                            usuarioTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            usuarioTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((usuarioTipoValidacao.Filtro.CriacaoDe == DateTime.MinValue) && (usuarioTipoValidacao.Filtro.CriacaoAte != DateTime.MinValue)) {
                        usuarioTipoValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((usuarioTipoValidacao.Filtro.CriacaoDe > DateTime.MinValue) && (usuarioTipoValidacao.Filtro.CriacaoAte > DateTime.MinValue)) {
                        if (usuarioTipoValidacao.Filtro.CriacaoDe >= usuarioTipoValidacao.Filtro.CriacaoAte) {
                            usuarioTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((usuarioTipoValidacao.Filtro.AlteracaoDe == DateTime.MinValue) && (usuarioTipoValidacao.Filtro.AlteracaoAte != DateTime.MinValue)) {
                        usuarioTipoValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((usuarioTipoValidacao.Filtro.AlteracaoDe > DateTime.MinValue) && (usuarioTipoValidacao.Filtro.AlteracaoAte > DateTime.MinValue)) {
                        if (usuarioTipoValidacao.Filtro.AlteracaoDe >= usuarioTipoValidacao.Filtro.AlteracaoAte) {
                            usuarioTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    usuarioTipoValidacao = new UsuarioTipoTransfer();
                    usuarioTipoValidacao.IncluirMensagem("É necessário informar os dados do Tipo de Usuário");
                }

                usuarioTipoValidacao.Validacao = true;

                if (usuarioTipoValidacao.Mensagens != null) {
                    if (usuarioTipoValidacao.Mensagens.Count > 0) {
                        usuarioTipoValidacao.Validacao = false;
                    }
                }

                usuarioTipoValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioTipoValidacao = new UsuarioTipoTransfer();

                usuarioTipoValidacao.IncluirMensagem("Erro em UsuarioTipoBusiness Validar [" + ex.Message + "]");
                usuarioTipoValidacao.Validacao = false;
                usuarioTipoValidacao.Erro = true;
            }

            return usuarioTipoValidacao;
        }
    }
}
