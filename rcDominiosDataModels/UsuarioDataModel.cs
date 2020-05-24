using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class UsuarioDataModel : DataModel
    {
        public UsuarioTransfer Incluir(UsuarioTransfer usuarioTransfer)
        {
            UsuarioData usuarioData;
            UsuarioTransfer usuario;

            try {
                usuarioData = new UsuarioData(_contexto);
                usuario = new UsuarioTransfer(usuarioTransfer);

                usuarioData.Incluir(usuarioTransfer.Usuario);

                _contexto.SaveChanges();

                usuario.Usuario = new UsuarioEntity(usuarioTransfer.Usuario);
                usuario.Validacao = true;
                usuario.Erro = false;
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioDataModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuario;
        }

        public UsuarioTransfer Alterar(UsuarioTransfer usuarioTransfer)
        {
            UsuarioData usuarioData;
            UsuarioTransfer usuario;

            try {
                usuarioData = new UsuarioData(_contexto);
                usuario = new UsuarioTransfer();

                usuarioData.Alterar(usuarioTransfer.Usuario);

                _contexto.SaveChanges();

                usuario.Usuario = new UsuarioEntity(usuarioTransfer.Usuario);
                usuario.Validacao = true;
                usuario.Erro = false;
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioDataModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuario;
        }

        public UsuarioTransfer Excluir(int id)
        {
            UsuarioData usuarioData;
            UsuarioTransfer usuario;

            try {
                usuarioData = new UsuarioData(_contexto);
                usuario = new UsuarioTransfer();

                usuario.Usuario = usuarioData.ConsultarPorId(id);
                usuarioData.Excluir(usuario.Usuario);

                _contexto.SaveChanges();

                usuario.Validacao = true;
                usuario.Erro = false;
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioDataModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuario;
        }

        public UsuarioTransfer ConsultarPorId(int id)
        {
            UsuarioData usuarioData;
            UsuarioTransfer usuario;

            try {
                usuarioData = new UsuarioData(_contexto);
                usuario = new UsuarioTransfer();

                usuario.Usuario = usuarioData.ConsultarPorId(id);
                usuario.Validacao = true;
                usuario.Erro = false;
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuario;
        }

        public UsuarioTransfer Consultar(UsuarioTransfer usuarioTransfer)
        {
            UsuarioData usuarioData;
            UsuarioTransfer usuarioLista;

            try {
                usuarioData = new UsuarioData(_contexto);

                usuarioLista = usuarioData.Consultar(usuarioTransfer);
                usuarioLista.Validacao = true;
                usuarioLista.Erro = false;
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirErroMensagem("Erro em UsuarioDataModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuarioLista;
        }
    }
}
