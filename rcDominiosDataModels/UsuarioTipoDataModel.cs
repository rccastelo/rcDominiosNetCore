using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class UsuarioTipoDataModel : DataModel
    {
        public UsuarioTipoTransfer Incluir(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                usuarioTipo = new UsuarioTipoTransfer(usuarioTipoTransfer);

                usuarioTipoData.Incluir(usuarioTipoTransfer.UsuarioTipo);

                _contexto.SaveChanges();

                usuarioTipo.UsuarioTipo = new UsuarioTipoEntity(usuarioTipoTransfer.UsuarioTipo);
                usuarioTipo.Validacao = true;
                usuarioTipo.Erro = false;
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return usuarioTipo;
        }

        public UsuarioTipoTransfer Alterar(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipoData.Alterar(usuarioTipoTransfer.UsuarioTipo);

                _contexto.SaveChanges();

                usuarioTipo.UsuarioTipo = new UsuarioTipoEntity(usuarioTipoTransfer.UsuarioTipo);
                usuarioTipo.Validacao = true;
                usuarioTipo.Erro = false;
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return usuarioTipo;
        }

        public UsuarioTipoTransfer Excluir(int id)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.UsuarioTipo = usuarioTipoData.ConsultarPorId(id);
                usuarioTipoData.Excluir(usuarioTipo.UsuarioTipo);

                _contexto.SaveChanges();

                usuarioTipo.Validacao = true;
                usuarioTipo.Erro = false;
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return usuarioTipo;
        }

        public UsuarioTipoTransfer ConsultarPorId(int id)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.UsuarioTipo = usuarioTipoData.ConsultarPorId(id);
                usuarioTipo.Validacao = true;
                usuarioTipo.Erro = false;
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return usuarioTipo;
        }

        public UsuarioTipoTransfer Consultar(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoData usuarioTipoData;
            UsuarioTipoTransfer usuarioTipoLista;

            try {
                usuarioTipoData = new UsuarioTipoData(_contexto);

                usuarioTipoLista = usuarioTipoData.Consultar(usuarioTipoTransfer);
                usuarioTipoLista.Validacao = true;
                usuarioTipoLista.Erro = false;
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirMensagem("Erro em UsuarioTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioTipoData = null;
            }

            return usuarioTipoLista;
        }
    }
}
