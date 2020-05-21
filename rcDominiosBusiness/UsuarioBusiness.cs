using System;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class UsuarioBusiness
    {
        public UsuarioDataTransfer Validar(UsuarioDataTransfer usuarioDataTransfer) 
        {
            UsuarioDataTransfer usuarioValidacao;

            try  {
                usuarioValidacao = new UsuarioDataTransfer(usuarioDataTransfer);
                usuarioValidacao.Usuario.Apelido = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.Apelido);
                usuarioValidacao.Usuario.Senha = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.Senha);
                usuarioValidacao.Usuario.NomeApresentacao = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.NomeApresentacao);
                usuarioValidacao.Usuario.NomeCompleto = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.NomeCompleto);

                //-- Apelido (Nome de usuário)
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.Apelido)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Necessário informar o Nome de Usuário");
                } else if (usuarioValidacao.Usuario.Apelido.Length > 20) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(usuarioValidacao.Usuario.Apelido)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário possui caracteres inválidos");
                    usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Senha
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.Senha)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Necessário informar a Senha");
                } else if (usuarioValidacao.Usuario.Senha.Length > 20) {
                    usuarioValidacao.IncluirValidacaoMensagem("Senha deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(usuarioValidacao.Usuario.Senha)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Senha possui caracteres inválidos");
                    usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Nome de apresentação
                if (string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeApresentacao)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Necessário informar o Nome de Apresentacao");
                } else if (usuarioValidacao.Usuario.NomeApresentacao.Length > 20) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(usuarioValidacao.Usuario.NomeApresentacao)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao possui caracteres inválidos");
                    usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Nome Completo
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeCompleto)) {
                    if (usuarioValidacao.Usuario.NomeCompleto.Length > 100) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome Completo deve ter no máximo 100 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(usuarioValidacao.Usuario.NomeCompleto)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome Completo possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, números e traço");
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
                usuarioValidacao = new UsuarioDataTransfer();

                usuarioValidacao.IncluirErroMensagem("Erro em UsuarioBusiness Validar [" + ex.Message + "]");
                usuarioValidacao.Validacao = false;
                usuarioValidacao.Erro = true;
            }

            return usuarioValidacao;
        }

        public UsuarioDataTransfer ValidarConsulta(UsuarioDataTransfer usuarioDataTransfer) 
        {
            UsuarioDataTransfer usuarioValidacao;

            try  {
                usuarioValidacao = new UsuarioDataTransfer(usuarioDataTransfer);
                usuarioValidacao.Usuario.Apelido = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.Apelido);
                usuarioValidacao.Usuario.Senha = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.Senha);
                usuarioValidacao.Usuario.NomeApresentacao = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.NomeApresentacao);
                usuarioValidacao.Usuario.NomeCompleto = Tratamento.TratarStringNuloBranco(usuarioValidacao.Usuario.NomeCompleto);

                //-- Id
                if ((usuarioValidacao.IdDe <= 0) && (usuarioValidacao.IdAte > 0)) {
                    usuarioValidacao.IncluirValidacaoMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                } else if ((usuarioValidacao.IdDe > 0) && (usuarioValidacao.IdAte > 0)) {
                    if (usuarioValidacao.IdDe >= usuarioValidacao.IdAte) {
                        usuarioValidacao.IncluirValidacaoMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                    }
                }

                //-- Apelido (Nome de usuário)
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.Apelido)) {
                    if (usuarioValidacao.Usuario.Apelido.Length > 20) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário deve ter no máximo 20 caracteres");
                    } else if (!Validacao.ValidarCharAaN(usuarioValidacao.Usuario.Apelido)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Usuário possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras e números");
                    }
                }

                //-- Senha
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.Senha)) {
                    if (usuarioValidacao.Usuario.Senha.Length > 20) {
                        usuarioValidacao.IncluirValidacaoMensagem("Senha deve ter no máximo 20 caracteres");
                    } else if (!Validacao.ValidarCharAaBCcNT(usuarioValidacao.Usuario.Senha)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Senha possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                    }
                }

                //-- Nome de apresentação
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeApresentacao)) {
                    if (usuarioValidacao.Usuario.NomeApresentacao.Length > 20) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao deve ter no máximo 20 caracteres");
                    } else if (!Validacao.ValidarCharAaBCc(usuarioValidacao.Usuario.NomeApresentacao)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome de Apresentacao possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos e espaço em branco");
                    }
                }

                //-- Nome Completo
                if (!string.IsNullOrEmpty(usuarioValidacao.Usuario.NomeCompleto)) {
                    if (usuarioValidacao.Usuario.NomeCompleto.Length > 100) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome Completo deve ter no máximo 100 caracteres");
                    } else if(!Validacao.ValidarCharAaBCc(usuarioValidacao.Usuario.NomeCompleto)) {
                        usuarioValidacao.IncluirValidacaoMensagem("Nome Completo possui caracteres inválidos");
                        usuarioValidacao.IncluirValidacaoMensagem("Caracteres válidos: letras, acentos e espaço em branco");
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

                usuarioValidacao.Validacao = true;

                if (usuarioValidacao.ValidacaoMensagens != null) {
                    if (usuarioValidacao.ValidacaoMensagens.Count > 0) {
                        usuarioValidacao.Validacao = false;
                    }
                }

                usuarioValidacao.Erro = false;
            } catch (Exception ex) {
                usuarioValidacao = new UsuarioDataTransfer();

                usuarioValidacao.IncluirErroMensagem("Erro em UsuarioBusiness Validar [" + ex.Message + "]");
                usuarioValidacao.Validacao = false;
                usuarioValidacao.Erro = true;
            }

            return usuarioValidacao;
        }
    }
}
