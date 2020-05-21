using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class UsuarioTipoBusiness
    {
        public UsuarioTipoDataTransfer Validar(UsuarioTipoDataTransfer usuarioTipoDataTransfer) 
        {
            UsuarioTipoDataTransfer usuarioTipoValidacao;

            try  {
                usuarioTipoValidacao = new UsuarioTipoDataTransfer(usuarioTipoDataTransfer);
                usuarioTipoValidacao.UsuarioTipo.Descricao = Tratamento.TratarStringNuloBranco(usuarioTipoValidacao.UsuarioTipo.Descricao);
                usuarioTipoValidacao.UsuarioTipo.Codigo = Tratamento.TratarStringNuloBranco(usuarioTipoValidacao.UsuarioTipo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    usuarioTipoValidacao.IncluirValidacaoMensagem("Necessário informar a Descrição do tipo de Usuário");
                } else if (usuarioTipoValidacao.UsuarioTipo.Descricao.Length > 100) {
                    usuarioTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    usuarioTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                    usuarioTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                    if (usuarioTipoValidacao.UsuarioTipo.Codigo.Length > 10) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                usuarioTipoValidacao.Validacao = true;

                if (usuarioTipoValidacao.ValidacaoMensagens != null) {
                    if (usuarioTipoValidacao.ValidacaoMensagens.Count > 0) {
                        usuarioTipoValidacao.Validacao = false;
                    }
                }

                usuarioTipoValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioTipoValidacao = new UsuarioTipoDataTransfer();

                usuarioTipoValidacao.IncluirErroMensagem("Erro em UsuarioTipoBusiness Validar [" + ex.Message + "]");
                usuarioTipoValidacao.Validacao = false;
                usuarioTipoValidacao.Erro = true;
            }

            return usuarioTipoValidacao;
        }

        public UsuarioTipoDataTransfer ValidarConsulta(UsuarioTipoDataTransfer usuarioTipoDataTransfer) 
        {
            UsuarioTipoDataTransfer usuarioTipoValidacao;

            try  {
                usuarioTipoValidacao = new UsuarioTipoDataTransfer(usuarioTipoDataTransfer);
                usuarioTipoValidacao.UsuarioTipo.Descricao = Tratamento.TratarStringNuloBranco(usuarioTipoValidacao.UsuarioTipo.Descricao);
                usuarioTipoValidacao.UsuarioTipo.Codigo = Tratamento.TratarStringNuloBranco(usuarioTipoValidacao.UsuarioTipo.Codigo);

                //-- Id
                if ((usuarioTipoValidacao.IdDe <= 0) && (usuarioTipoValidacao.IdAte > 0)) {
                    usuarioTipoValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((usuarioTipoValidacao.IdDe > 0) && (usuarioTipoValidacao.IdAte > 0)) {
                    if (usuarioTipoValidacao.IdDe >= usuarioTipoValidacao.IdAte) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    if (usuarioTipoValidacao.UsuarioTipo.Descricao.Length > 100) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Descrição possui caracteres inválidos");
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                    if (usuarioTipoValidacao.UsuarioTipo.Codigo.Length > 10) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Código possui caracteres inválidos");
                        usuarioTipoValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((usuarioTipoValidacao.CriacaoDe == DateTime.MinValue) && (usuarioTipoValidacao.CriacaoAte != DateTime.MinValue)) {
                    usuarioTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((usuarioTipoValidacao.CriacaoDe > DateTime.MinValue) && (usuarioTipoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (usuarioTipoValidacao.CriacaoDe >= usuarioTipoValidacao.CriacaoAte) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((usuarioTipoValidacao.AlteracaoDe == DateTime.MinValue) && (usuarioTipoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    usuarioTipoValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((usuarioTipoValidacao.AlteracaoDe > DateTime.MinValue) && (usuarioTipoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (usuarioTipoValidacao.AlteracaoDe >= usuarioTipoValidacao.AlteracaoAte) {
                        usuarioTipoValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                usuarioTipoValidacao.Validacao = true;

                if (usuarioTipoValidacao.ValidacaoMensagens != null) {
                    if (usuarioTipoValidacao.ValidacaoMensagens.Count > 0) {
                        usuarioTipoValidacao.Validacao = false;
                    }
                }

                usuarioTipoValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioTipoValidacao = new UsuarioTipoDataTransfer();

                usuarioTipoValidacao.IncluirErroMensagem("Erro em UsuarioTipoBusiness Validar [" + ex.Message + "]");
                usuarioTipoValidacao.Validacao = false;
                usuarioTipoValidacao.Erro = true;
            }

            return usuarioTipoValidacao;
        }
    }
}
