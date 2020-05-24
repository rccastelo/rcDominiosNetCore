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
                usuarioValidacao.Usuario.Apelido = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.Apelido);
                usuarioValidacao.Usuario.Senha = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.Senha);
                usuarioValidacao.Usuario.NomeApresentacao = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.NomeApresentacao);
                usuarioValidacao.Usuario.NomeCompleto = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.NomeCompleto);

                //-- Apelido (Nome de usuário)
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.Apelido)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Necessário informar o Nome de Usuário");
                } else if (usuarioValidacao.Usuario.Apelido.Length > 20) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaN(usuarioValidacao.Usuario.Apelido)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário possui caracteres inválidos");
                    usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras e números");
                }

                //-- Senha
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.Senha)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Necessário informar a Senha");
                } else if (usuarioValidacao.Usuario.Senha.Length > 20) {
                    usuarioValidacao.IncluirValidacaoMensagem("Senha deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaBEN(usuarioValidacao.Usuario.Senha)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Senha possui caracteres inválidos");
                    usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números, espaço em branco e especiais");
                }

                //-- Nome de apresentação
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeApresentacao)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Necessário informar o Nome de Apresentacao");
                } else if (usuarioValidacao.Usuario.NomeApresentacao.Length > 20) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaBN(usuarioValidacao.Usuario.NomeApresentacao)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao possui caracteres inválidos");
                    usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e espaço em branco");
                }

                //-- Nome Completo
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeCompleto)) {
                    if (usuarioValidacao.Usuario.NomeCompleto.Length > 100) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome Completo deve ter no máximo 100 caracteres");
                    } else if(!Validacao.ValidarCharAaB(usuarioValidacao.Usuario.NomeCompleto)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome Completo possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras e espaço em branco");
                    }
                }

                usuarioValidacao.Validacao = true;

                if (usuarioValidacao.ValidacaoMensagens != null) {
                    if (usuarioValidacao.ValidacaoMensagens.Count > 0) {
                        usuarioValidacao.Validacao = false;
                    }
                }

                usuarioValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioValidacao = new UsuarioTransfer();

                usuarioValidacao.IncluirErroMensagem("Erro em UsuarioBusiness Validar [" + ex.Message + "]");
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
                    usuarioValidacao.Apelido = Tratamento.TratarStringNuloBranco(usuarioValidacao.Apelido);
                    usuarioValidacao.Senha = Tratamento.TratarStringNuloBranco(usuarioValidacao.Senha);
                    usuarioValidacao.NomeApresentacao = Tratamento.TratarStringNuloBranco(usuarioValidacao.NomeApresentacao);
                    usuarioValidacao.NomeCompleto = Tratamento.TratarStringNuloBranco(usuarioValidacao.NomeCompleto);

                    //-- Id
                    if ((usuarioValidacao.IdDe <= 0) && (usuarioValidacao.IdAte > 0)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((usuarioValidacao.IdDe > 0) && (usuarioValidacao.IdAte > 0)) {
                        if (usuarioValidacao.IdDe >= usuarioValidacao.IdAte) {
                            usuarioValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Apelido (Nome de usuário)
                    if (string.IsNullOrEmpty(usuarioValidacao.Apelido)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Necessário informar o Nome de Usuário");
                    } else if (usuarioValidacao.Apelido.Length > 20) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário deve ter no máximo 20 caracteres");
                    } else if (!Validacao.ValidarCharAaN(usuarioValidacao.Apelido)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras e números");
                    }

                    //-- Senha
                    if (string.IsNullOrEmpty(usuarioValidacao.Senha)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Necessário informar a Senha");
                    } else if (usuarioValidacao.Senha.Length > 20) {
                        usuarioValidacao.IncluirValidacaoMensagem("Senha deve ter no máximo 20 caracteres");
                    } else if (!Validacao.ValidarCharAaBEN(usuarioValidacao.Senha)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Senha possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números, espaço em branco e especiais");
                    }

                    //-- Nome de apresentação
                    if (string.IsNullOrEmpty(usuarioValidacao.NomeApresentacao)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Necessário informar o Nome de Apresentacao");
                    } else if (usuarioValidacao.NomeApresentacao.Length > 20) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao deve ter no máximo 20 caracteres");
                    } else if (!Validacao.ValidarCharAaBN(usuarioValidacao.NomeApresentacao)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e espaço em branco");
                    }

                    //-- Nome Completo
                    if (!string.IsNullOrEmpty(usuarioValidacao.NomeCompleto)) {
                        if (usuarioValidacao.NomeCompleto.Length > 100) {
                            usuarioValidacao.IncluirValidacaoMensagem("Nome Completo deve ter no máximo 100 caracteres");
                        } else if(!Validacao.ValidarCharAaB(usuarioValidacao.NomeCompleto)) {
                            usuarioValidacao.IncluirValidacaoMensagem("Nome Completo possui caracteres inválidos");
                            usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras e espaço em branco");
                        }
                    }

                    //-- Data de Criação
                    if ((usuarioValidacao.CriacaoDe == DateTime.MinValue) && (usuarioValidacao.CriacaoAte != DateTime.MinValue)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((usuarioValidacao.CriacaoDe > DateTime.MinValue) && (usuarioValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (usuarioValidacao.CriacaoDe >= usuarioValidacao.CriacaoAte) {
                            usuarioValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((usuarioValidacao.AlteracaoDe == DateTime.MinValue) && (usuarioValidacao.AlteracaoAte != DateTime.MinValue)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((usuarioValidacao.AlteracaoDe > DateTime.MinValue) && (usuarioValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (usuarioValidacao.AlteracaoDe >= usuarioValidacao.AlteracaoAte) {
                            usuarioValidacao.IncluirValidacaoMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    usuarioValidacao = new UsuarioTransfer();
                    usuarioValidacao.IncluirValidacaoMensagem("É necessário informar os dados do Usuário");
                }

                usuarioValidacao.Validacao = true;

                if (usuarioValidacao.ValidacaoMensagens != null) {
                    if (usuarioValidacao.ValidacaoMensagens.Count > 0) {
                        usuarioValidacao.Validacao = false;
                    }
                }

                usuarioValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioValidacao = new UsuarioTransfer();

                usuarioValidacao.IncluirErroMensagem("Erro em UsuarioBusiness Validar [" + ex.Message + "]");
                usuarioValidacao.Validacao = false;
                usuarioValidacao.Erro = true;
            }

            return usuarioValidacao;
        }
    }
}
