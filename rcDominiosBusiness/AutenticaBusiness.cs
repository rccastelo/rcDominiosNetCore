using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class AutenticaBusiness
    {
        public AutenticaTransfer Validar(AutenticaTransfer autenticaTransfer) 
        {
            AutenticaTransfer autenticaValidacao;

            try  {
                autenticaValidacao = new AutenticaTransfer(autenticaTransfer);
                autenticaValidacao.Apelido = Tratamento.TratarStringNuloBranco(autenticaValidacao.Apelido);
                autenticaValidacao.Senha = Tratamento.TratarStringNuloBranco(autenticaValidacao.Senha);

                //-- Apelido (Nome de usuário)
                if (string.IsNullOrEmpty(autenticaValidacao.Apelido)) {
                    autenticaValidacao.IncluirMensagem("Necessário informar o Nome de Usuário");
                } else if (autenticaValidacao.Apelido.Length > 20) {
                    autenticaValidacao.IncluirMensagem("Nome de Usuário deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaN(autenticaValidacao.Apelido)) {
                    autenticaValidacao.IncluirMensagem("Nome de Usuário possui caracteres inválidos");
                    autenticaValidacao.IncluirMensagem("Caracteres válidos: letras e números");
                }

                //-- Senha
                if (string.IsNullOrEmpty(autenticaValidacao.Senha)) {
                    autenticaValidacao.IncluirMensagem("Necessário informar a Senha");
                } else if (autenticaValidacao.Senha.Length > 20) {
                    autenticaValidacao.IncluirMensagem("Senha deve ter no máximo 20 caracteres");
                } else if (!Validacao.ValidarCharAaBEN(autenticaValidacao.Senha)) {
                    autenticaValidacao.IncluirMensagem("Senha possui caracteres inválidos");
                    autenticaValidacao.IncluirMensagem("Caracteres válidos: letras, números, espaço em branco e especiais");
                }

                autenticaValidacao.Validacao = true;

                if (autenticaValidacao.Mensagens != null) {
                    if (autenticaValidacao.Mensagens.Count > 0) {
                        autenticaValidacao.Validacao = false;
                    }
                }
            } catch (Exception ex) {
                autenticaValidacao = new AutenticaTransfer();

                autenticaValidacao.IncluirMensagem("Erro em AutenticaBusiness Validar [" + ex.Message + "]");
                autenticaValidacao.Erro = true;
            }

            return autenticaValidacao;
        }
    }
}
