using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class UsuarioBusiness
    {
        public UsuarioTransfer Validar(UsuarioTransfer usuarioTransfer) 
        {
            UsuarioTransfer usuarioValidacao;

            try  {
                usuarioValidacao = new UsuarioTransfer(usuarioTransfer);

                //-- Apelido (Nome de usuário)
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.Apelido)) {
                    usuarioValidacao.IncluirMensagem("Necessário informar o Nome de Usuário");
                } else if ((usuarioValidacao.Usuario.Apelido.StartsWith(" ")) || 
                        (usuarioValidacao.Usuario.Apelido.EndsWith(" "))) {
                    usuarioValidacao.IncluirMensagem("Nome de Usuário não deve começar ou terminar com espaço em branco");
                } else if ((usuarioValidacao.Usuario.Apelido.Length < 3) || 
                        (usuarioValidacao.Usuario.Apelido.Length > 20)) {
                    usuarioValidacao.IncluirMensagem("Nome de Usuário deve ter entre 3 e 20 caracteres");
                } else if (!Validacao.ValidarCharAaN(usuarioValidacao.Usuario.Apelido)) {
                    usuarioValidacao.IncluirMensagem("Nome de Usuário possui caracteres inválidos");
                    usuarioValidacao.IncluirMensagem("Caracteres válidos: letras e números");
                }

                //-- Senha
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.Senha)) {
                    usuarioValidacao.IncluirMensagem("Necessário informar a Senha");
                } else if ((usuarioValidacao.Usuario.Senha.StartsWith(" ")) || 
                        (usuarioValidacao.Usuario.Senha.EndsWith(" "))) {
                    usuarioValidacao.IncluirMensagem("Senha não deve começar ou terminar com espaço em branco");
                } else if ((usuarioValidacao.Usuario.Senha.Length < 3) || 
                        (usuarioValidacao.Usuario.Senha.Length > 20)) {
                    usuarioValidacao.IncluirMensagem("Senha deve ter entre 3 e 20 caracteres");
                } else if (!Validacao.ValidarCharAaBEN(usuarioValidacao.Usuario.Senha)) {
                    usuarioValidacao.IncluirMensagem("Senha possui caracteres inválidos");
                    usuarioValidacao.IncluirMensagem("Caracteres válidos: letras, números, espaço em branco e especiais");
                }

                //-- Nome de apresentação
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeApresentacao)) {
                    if (usuarioValidacao.Usuario.NomeApresentacao.Length > 20) {
                        usuarioValidacao.IncluirMensagem("Nome de Apresentacao deve ter no máximo 20 caracteres");
                    } else if ((usuarioValidacao.Usuario.NomeApresentacao.StartsWith(" ")) || 
                            (usuarioValidacao.Usuario.NomeApresentacao.EndsWith(" "))) {
                        usuarioValidacao.IncluirMensagem("Nome de Apresentacao não deve começar ou terminar com espaço em branco");
                    } else if (!Validacao.ValidarCharAaBN(usuarioValidacao.Usuario.NomeApresentacao)) {
                        usuarioValidacao.IncluirMensagem("Nome de Apresentacao possui caracteres inválidos");
                        usuarioValidacao.IncluirMensagem("Caracteres válidos: letras, números e espaço em branco");
                    }
                }

                //-- Nome Completo
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeCompleto)) {
                    if (usuarioValidacao.Usuario.NomeCompleto.Length > 100) {
                        usuarioValidacao.IncluirMensagem("Nome Completo deve ter no máximo 100 caracteres");
                    } else if ((usuarioValidacao.Usuario.NomeCompleto.StartsWith(" ")) || 
                            (usuarioValidacao.Usuario.NomeCompleto.EndsWith(" "))) {
                        usuarioValidacao.IncluirMensagem("Nome Completo não deve começar ou terminar com espaço em branco");
                    } else if(!Validacao.ValidarCharAaB(usuarioValidacao.Usuario.NomeCompleto)) {
                        usuarioValidacao.IncluirMensagem("Nome Completo possui caracteres inválidos");
                        usuarioValidacao.IncluirMensagem("Caracteres válidos: letras e espaço em branco");
                    }
                }

                usuarioValidacao.Validacao = true;

                if (usuarioValidacao.Mensagens != null) {
                    if (usuarioValidacao.Mensagens.Count > 0) {
                        usuarioValidacao.Validacao = false;
                    }
                }

                usuarioValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioValidacao = new UsuarioTransfer();

                usuarioValidacao.IncluirMensagem("Erro em UsuarioBusiness Validar [" + ex.Message + "]");
                usuarioValidacao.Validacao = false;
                usuarioValidacao.Erro = true;
            }

            return usuarioValidacao;
        }

        public UsuarioTransfer ValidarConsulta(UsuarioTransfer usuarioTransfer) 
        {
            UsuarioTransfer usuarioValidacao;

            try  {
                usuarioValidacao = new UsuarioTransfer(usuarioTransfer);

                if (usuarioValidacao != null) {
                    //-- Id
                    if ((usuarioValidacao.IdDe <= 0) && (usuarioValidacao.IdAte > 0)) {
                        usuarioValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((usuarioValidacao.IdDe > 0) && (usuarioValidacao.IdAte > 0)) {
                        if (usuarioValidacao.IdDe >= usuarioValidacao.IdAte) {
                            usuarioValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Apelido (Nome de usuário)
                    if (!string.IsNullOrEmpty(usuarioValidacao.Apelido)) {
                        if (usuarioValidacao.Apelido.Length > 20) {
                            usuarioValidacao.IncluirMensagem("Nome de Usuário deve ter no máximo 20 caracteres");
                        } else if (!Validacao.ValidarCharAaN(usuarioValidacao.Apelido)) {
                            usuarioValidacao.IncluirMensagem("Nome de Usuário possui caracteres inválidos");
                            usuarioValidacao.IncluirMensagem("Caracteres válidos: letras e números");
                        }
                    }

                    //-- Senha
                    if (!string.IsNullOrEmpty(usuarioValidacao.Senha)) {
                        if (usuarioValidacao.Senha.Length > 20) {
                            usuarioValidacao.IncluirMensagem("Senha deve ter no máximo 20 caracteres");
                        } else if (!Validacao.ValidarCharAaBEN(usuarioValidacao.Senha)) {
                            usuarioValidacao.IncluirMensagem("Senha possui caracteres inválidos");
                            usuarioValidacao.IncluirMensagem("Caracteres válidos: letras, números, espaço em branco e especiais");
                        }
                    }

                    //-- Nome de apresentação
                    if (!string.IsNullOrEmpty(usuarioValidacao.NomeApresentacao)) {
                        if (usuarioValidacao.NomeApresentacao.Length > 20) {
                            usuarioValidacao.IncluirMensagem("Nome de Apresentacao deve ter no máximo 20 caracteres");
                        } else if (!Validacao.ValidarCharAaBN(usuarioValidacao.NomeApresentacao)) {
                            usuarioValidacao.IncluirMensagem("Nome de Apresentacao possui caracteres inválidos");
                            usuarioValidacao.IncluirMensagem("Caracteres válidos: letras, números e espaço em branco");
                        }
                    }

                    //-- Nome Completo
                    if (!string.IsNullOrEmpty(usuarioValidacao.NomeCompleto)) {
                        if (usuarioValidacao.NomeCompleto.Length > 100) {
                            usuarioValidacao.IncluirMensagem("Nome Completo deve ter no máximo 100 caracteres");
                        } else if(!Validacao.ValidarCharAaB(usuarioValidacao.NomeCompleto)) {
                            usuarioValidacao.IncluirMensagem("Nome Completo possui caracteres inválidos");
                            usuarioValidacao.IncluirMensagem("Caracteres válidos: letras e espaço em branco");
                        }
                    }

                    //-- Data de Criação
                    if ((usuarioValidacao.CriacaoDe == DateTime.MinValue) && (usuarioValidacao.CriacaoAte != DateTime.MinValue)) {
                        usuarioValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((usuarioValidacao.CriacaoDe > DateTime.MinValue) && (usuarioValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (usuarioValidacao.CriacaoDe >= usuarioValidacao.CriacaoAte) {
                            usuarioValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((usuarioValidacao.AlteracaoDe == DateTime.MinValue) && (usuarioValidacao.AlteracaoAte != DateTime.MinValue)) {
                        usuarioValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((usuarioValidacao.AlteracaoDe > DateTime.MinValue) && (usuarioValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (usuarioValidacao.AlteracaoDe >= usuarioValidacao.AlteracaoAte) {
                            usuarioValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    usuarioValidacao = new UsuarioTransfer();
                    usuarioValidacao.IncluirMensagem("É necessário informar os dados do Usuário");
                }

                usuarioValidacao.Validacao = true;

                if (usuarioValidacao.Mensagens != null) {
                    if (usuarioValidacao.Mensagens.Count > 0) {
                        usuarioValidacao.Validacao = false;
                    }
                }

                usuarioValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioValidacao = new UsuarioTransfer();

                usuarioValidacao.IncluirMensagem("Erro em UsuarioBusiness Validar [" + ex.Message + "]");
                usuarioValidacao.Validacao = false;
                usuarioValidacao.Erro = true;
            }

            return usuarioValidacao;
        }
    }
}
