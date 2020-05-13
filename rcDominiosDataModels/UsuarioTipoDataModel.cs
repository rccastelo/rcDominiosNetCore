using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class UsuarioTipoDataModel : DataModel
    {
        public UsuarioTipoDataTransfer Incluir(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoDataTransfer UsuarioTipoRetorno;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer(usuarioTipoDataTransfer);

                usuarioTipoData.Incluir(usuarioTipoDataTransfer.UsuarioTipo);

                _contexto.SaveChanges();

                UsuarioTipoRetorno.UsuarioTipo = new UsuarioTipoEntity(usuarioTipoDataTransfer.UsuarioTipo);
                UsuarioTipoRetorno.Validacao = true;
                UsuarioTipoRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.Validacao = false;
                UsuarioTipoRetorno.Erro = true;
                UsuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return UsuarioTipoRetorno;
        }

        public UsuarioTipoDataTransfer Alterar(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoDataTransfer UsuarioTipoRetorno;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                usuarioTipoData.Alterar(usuarioTipoDataTransfer.UsuarioTipo);

                _contexto.SaveChanges();

                UsuarioTipoRetorno.UsuarioTipo = new UsuarioTipoEntity(usuarioTipoDataTransfer.UsuarioTipo);
                UsuarioTipoRetorno.Validacao = true;
                UsuarioTipoRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.Validacao = false;
                UsuarioTipoRetorno.Erro = true;
                UsuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return UsuarioTipoRetorno;
        }

        public UsuarioTipoDataTransfer Excluir(int id)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoDataTransfer UsuarioTipoRetorno;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.UsuarioTipo = usuarioTipoData.ConsultarPorId(id);
                usuarioTipoData.Excluir(UsuarioTipoRetorno.UsuarioTipo);

                _contexto.SaveChanges();

                UsuarioTipoRetorno.Validacao = true;
                UsuarioTipoRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.Validacao = false;
                UsuarioTipoRetorno.Erro = true;
                UsuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return UsuarioTipoRetorno;
        }

        public UsuarioTipoDataTransfer Listar()
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoDataTransfer UsuarioTipoRetorno;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.UsuarioTipoLista = usuarioTipoData.Listar();
                UsuarioTipoRetorno.Validacao = true;
                UsuarioTipoRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.Validacao = false;
                UsuarioTipoRetorno.Erro = true;
                UsuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoDataModel Listar [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return UsuarioTipoRetorno;
        }

        public UsuarioTipoDataTransfer ConsultarPorId(int id)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoDataTransfer UsuarioTipoRetorno;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.UsuarioTipo = usuarioTipoData.ConsultarPorId(id);
                UsuarioTipoRetorno.Validacao = true;
                UsuarioTipoRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.Validacao = false;
                UsuarioTipoRetorno.Erro = true;
                UsuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return UsuarioTipoRetorno;
        }

        public UsuarioTipoDataTransfer Consultar(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoDataTransfer UsuarioTipoRetorno;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.UsuarioTipoLista = usuarioTipoData.Consultar(usuarioTipoDataTransfer);
                UsuarioTipoRetorno.Validacao = true;
                UsuarioTipoRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioTipoRetorno = new UsuarioTipoDataTransfer();

                UsuarioTipoRetorno.Validacao = false;
                UsuarioTipoRetorno.Erro = true;
                UsuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return UsuarioTipoRetorno;
        }
    }
}
