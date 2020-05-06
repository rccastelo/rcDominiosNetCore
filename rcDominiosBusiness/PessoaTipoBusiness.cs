using System;
using System.Collections.Generic;
using rcDominiosDataTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class PessoaTipoBusiness
    {
        public PessoaTipoDataTransfer Validar(PessoaTipoDataTransfer pessoaTipoDataTransfer) 
        {
            PessoaTipoDataTransfer pessoaTipoValidacao;

            try  {
                pessoaTipoValidacao = new PessoaTipoDataTransfer(pessoaTipoDataTransfer);
                pessoaTipoValidacao.PessoaTipo.Descricao = Tratamento.TratarStringNuloBranco(pessoaTipoValidacao.PessoaTipo.Descricao);
                pessoaTipoValidacao.PessoaTipo.Codigo = Tratamento.TratarStringNuloBranco(pessoaTipoValidacao.PessoaTipo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(pessoaTipoValidacao.PessoaTipo.Descricao)) {
                    pessoaTipoValidacao.ValidacaoMensagens.Add("Necessário informar a Descrição do Tipo de Pessoa");
                } else if (pessoaTipoValidacao.PessoaTipo.Descricao.Length > 100) {
                    pessoaTipoValidacao.ValidacaoMensagens.Add("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharDescricao(pessoaTipoValidacao.PessoaTipo.Descricao)) {
                    pessoaTipoValidacao.ValidacaoMensagens.Add("Descrição possui caracteres inválidos");
                    pessoaTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(pessoaTipoValidacao.PessoaTipo.Codigo)) {
                    if (pessoaTipoValidacao.PessoaTipo.Codigo.Length > 10) {
                        pessoaTipoValidacao.ValidacaoMensagens.Add("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharCodigoAlfanum(pessoaTipoValidacao.PessoaTipo.Codigo)) {
                        pessoaTipoValidacao.ValidacaoMensagens.Add("Código possui caracteres inválidos");
                        pessoaTipoValidacao.ValidacaoMensagens.Add("Caracteres válidos: letras, números e traço");
                    }
                }

                //-- Data de Criação do Tipo de Pessoa


                //-- Data de Alteração do Tipo de Pessoa


                if (pessoaTipoValidacao.ValidacaoMensagens.Count > 0) {
                    pessoaTipoValidacao.Validacao = false;
                } else {
                    pessoaTipoValidacao.Validacao = true;
                }

                pessoaTipoValidacao.Erro = false;
            } catch (Exception ex) {
                pessoaTipoValidacao = new PessoaTipoDataTransfer();

                pessoaTipoValidacao.ErroMensagens.Add("Erro em PessoaTipoBusiness Validar [" + ex.Message + "]");
                pessoaTipoValidacao.Validacao = false;
                pessoaTipoValidacao.Erro = true;
            }

            return pessoaTipoValidacao;
        }
    }
}
