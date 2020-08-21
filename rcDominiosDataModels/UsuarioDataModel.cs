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
            UsuarioEntity usuarioExiste;

            try {
                usuarioData = new UsuarioData(_contexto);
                usuario = new UsuarioTransfer(usuarioTransfer);

                usuarioExiste = usuarioData.ConsultarPorApelido(usuarioTransfer.Usuario.Apelido);

                if (usuarioExiste == null) {
                    usuarioData.Incluir(usuarioTransfer.Usuario);

                    _contexto.SaveChanges();

                    usuario.Usuario = new UsuarioEntity(usuarioTransfer.Usuario);
                } else {
                    usuario.Validacao = false;
                    usuario.IncluirMensagem("Nome de Usuário já cadastrado");
                }
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioDataModel Incluir [" + ex.Message + "]");
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
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioDataModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuario;
        }

        public UsuarioTransfer AlterarSenha(UsuarioTransfer usuarioTransfer)
        {
            UsuarioData usuarioData;
            UsuarioTransfer usuario;

            try {
                usuarioData = new UsuarioData(_contexto);
                usuario = new UsuarioTransfer();

                usuarioData.AlterarSenha(usuarioTransfer.Usuario);

                _contexto.SaveChanges();

                usuario.Usuario = new UsuarioEntity(usuarioTransfer.Usuario);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioDataModel Alterar [" + ex.Message + "]");
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
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioDataModel Excluir [" + ex.Message + "]");
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
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuario;
        }

        public UsuarioTransfer ConsultarPorApelido(string apelido)
        {
            UsuarioData usuarioData;
            UsuarioTransfer usuario;

            try {
                usuarioData = new UsuarioData(_contexto);
                usuario = new UsuarioTransfer();

                usuario.Usuario = usuarioData.ConsultarPorApelido(apelido);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioDataModel ConsultarPorId [" + ex.Message + "]");
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
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Erro = true;
                usuarioLista.IncluirMensagem("Erro em UsuarioDataModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return usuarioLista;
        }
    }
}
