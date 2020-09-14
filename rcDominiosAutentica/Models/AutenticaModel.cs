using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using rcDominiosBusiness;
using rcDominiosCriptografia;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
  public class AutenticaModel
    {
        public AutenticaTransfer Autenticar(AutenticaTransfer autenticaTransfer)
        {
            AutenticaDataModel autenticaDataModel;
            AutenticaBusiness autenticaBusiness;
            AutenticaTransfer autenticado;
            AutenticaTransfer autenticaValidacao;
            AutenticaTransfer autenticaRetorno;
            
            try {
                autenticaDataModel = new AutenticaDataModel();
                autenticaBusiness = new AutenticaBusiness();

                autenticaValidacao = autenticaBusiness.Validar(autenticaTransfer);

                if (!autenticaValidacao.Erro) {
                    if (autenticaValidacao.Validacao) {
                        //-- Criptografia da senha
                        string apelidoSenha = (autenticaTransfer.Apelido + autenticaTransfer.Senha);

                        string apelidoSenhaCripto = Criptografia.CriptravarSHA512(apelidoSenha);

                        autenticaValidacao.Senha = apelidoSenhaCripto;
                        //-------------------------

                        autenticado = autenticaDataModel.Autenticar(autenticaValidacao);
                    } else {
                        autenticado = new AutenticaTransfer(autenticaValidacao);
                    }
                } else {
                    autenticado = new AutenticaTransfer(autenticaValidacao);
                }

                if (autenticado.Validacao == true) {
                    if (autenticado.Autenticado == true) {
                        var direitos = new [] {
                            new Claim(JwtRegisteredClaimNames.Sub, autenticaTransfer.Apelido),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("rc-chave-autenticacao"));

                        var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                        var jwtSecurityToken = new JwtSecurityToken(
                            issuer: "rc-issuer",
                            audience: "rc-audience",
                            claims: direitos,
                            signingCredentials: credenciais,
                            expires: DateTime.Now.AddMinutes(30)
                        );

                        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                        autenticaRetorno = new AutenticaTransfer(autenticado);

                        autenticaRetorno.Senha = null;
                        autenticaRetorno.Token = token;
                    } else { //-- não autenticado
                        autenticaRetorno = new AutenticaTransfer(autenticado);

                        autenticaRetorno.Token = null;
                        autenticaRetorno.Senha = null;

                        autenticaRetorno.IncluirMensagem("Usuário e/ou senha informado(s) inválido(s)");
                    }
                } else { //-- inválido
                    autenticaRetorno = new AutenticaTransfer(autenticado);
                    autenticaRetorno.Senha = null;
                }
            } catch (Exception ex) {
                autenticaRetorno = new AutenticaTransfer();

                autenticaRetorno.Erro = true;
                autenticaRetorno.IncluirMensagem("Erro em AutenticaModel Autenticar [" + ex.Message + "]");
            } finally {
                autenticaDataModel = null;
                autenticaBusiness = null;
            }

            return autenticaRetorno;
        }
    }
}
