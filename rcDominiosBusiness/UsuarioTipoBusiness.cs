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
                    usuarioTipoValidacao.ValidacaoMensagens.Add("Necessário informar a Descrição do tipo de Usuário");
                } else if (usuarioTipoValidacao.UsuarioTipo.Descricao.Length > 100) {
                    usuarioTipoValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    usuarioTipoValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                    usuarioTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                    if (usuarioTipoValidacao.UsuarioTipo.Codigo.Length > 10) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                if (usuarioTipoValidacao.ValidacaoMensagens.Count > 0) {
                    usuarioTipoValidacao.Validacao = false;
                } else {
                    usuarioTipoValidacao.Validacao = true;
                }

                usuarioTipoValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioTipoValidacao = new UsuarioTipoDataTransfer();

                usuarioTipoValidacao.ErroMensagens.Add("Erro em UsuarioTipoBusiness Validar [" + ex.Message + "]");
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
                    usuarioTipoValidacao.ValidacaoMensagens.Add("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((usuarioTipoValidacao.IdDe > 0) && (usuarioTipoValidacao.IdAte > 0)) {
                    if (usuarioTipoValidacao.IdDe >= usuarioTipoValidacao.IdAte) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Descrição do Tipo de Pessoa
                if (!string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                    if (usuarioTipoValidacao.UsuarioTipo.Descricao.Length > 100) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(usuarioTipoValidacao.UsuarioTipo.Descricao)) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                    if (usuarioTipoValidacao.UsuarioTipo.Codigo.Length > 10) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(usuarioTipoValidacao.UsuarioTipo.Codigo)) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        usuarioTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação
                if ((usuarioTipoValidacao.CriacaoDe == DateTime.MinValue) && (usuarioTipoValidacao.CriacaoAte != DateTime.MinValue)) {
                    usuarioTipoValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((usuarioTipoValidacao.CriacaoDe > DateTime.MinValue) && (usuarioTipoValidacao.CriacaoAte > DateTime.MinValue)) {
                    if (usuarioTipoValidacao.CriacaoDe >= usuarioTipoValidacao.CriacaoAte) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Data de Alteração
                if ((usuarioTipoValidacao.AlteracaoDe == DateTime.MinValue) && (usuarioTipoValidacao.AlteracaoAte != DateTime.MinValue)) {
                    usuarioTipoValidacao.ValidacaoMensagens.Add("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                } else if ((usuarioTipoValidacao.AlteracaoDe > DateTime.MinValue) && (usuarioTipoValidacao.AlteracaoAte > DateTime.MinValue)) {
                    if (usuarioTipoValidacao.AlteracaoDe >= usuarioTipoValidacao.AlteracaoAte) {
                        usuarioTipoValidacao.ValidacaoMensagens.Add("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                    }
                }

                if (usuarioTipoValidacao.ValidacaoMensagens.Count > 0) {
                    usuarioTipoValidacao.Validacao = false;
                } else {
                    usuarioTipoValidacao.Validacao = true;
                }

                usuarioTipoValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioTipoValidacao = new UsuarioTipoDataTransfer();

                usuarioTipoValidacao.ErroMensagens.Add("Erro em UsuarioTipoBusiness Validar [" + ex.Message + "]");
                usuarioTipoValidacao.Validacao = false;
                usuarioTipoValidacao.Erro = true;
            }

            return usuarioTipoValidacao;
        }
    }
}
