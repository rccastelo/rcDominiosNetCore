using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class UsuarioDataModel : DataModel
    {
        public UsuarioDataTransfer Incluir(UsuarioDataTransfer usuarioDataTransfer)
        {
            UsuarioData usuarioData;
            UsuarioDataTransfer UsuarioRetorno;

            try {
                usuarioData = new UsuarioData(_contexto);
                UsuarioRetorno = new UsuarioDataTransfer(usuarioDataTransfer);

                usuarioData.Incluir(usuarioDataTransfer.Usuario);

                _contexto.SaveChanges();

                UsuarioRetorno.Usuario = new UsuarioEntity(usuarioDataTransfer.Usuario);
                UsuarioRetorno.Validacao = true;
                UsuarioRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Validacao = false;
                UsuarioRetorno.Erro = true;
                UsuarioRetorno.IncluirErroMensagem("Erro em UsuarioDataModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return UsuarioRetorno;
        }

        public UsuarioDataTransfer Alterar(UsuarioDataTransfer usuarioDataTransfer)
        {
            UsuarioData usuarioData;
            UsuarioDataTransfer UsuarioRetorno;

            try {
                usuarioData = new UsuarioData(_contexto);
                UsuarioRetorno = new UsuarioDataTransfer();

                usuarioData.Alterar(usuarioDataTransfer.Usuario);

                _contexto.SaveChanges();

                UsuarioRetorno.Usuario = new UsuarioEntity(usuarioDataTransfer.Usuario);
                UsuarioRetorno.Validacao = true;
                UsuarioRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Validacao = false;
                UsuarioRetorno.Erro = true;
                UsuarioRetorno.IncluirErroMensagem("Erro em UsuarioDataModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return UsuarioRetorno;
        }

        public UsuarioDataTransfer Excluir(int id)
        {
            UsuarioData usuarioData;
            UsuarioDataTransfer UsuarioRetorno;

            try {
                usuarioData = new UsuarioData(_contexto);
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Usuario = usuarioData.ConsultarPorId(id);
                usuarioData.Excluir(UsuarioRetorno.Usuario);

                _contexto.SaveChanges();

                UsuarioRetorno.Validacao = true;
                UsuarioRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Validacao = false;
                UsuarioRetorno.Erro = true;
                UsuarioRetorno.IncluirErroMensagem("Erro em UsuarioDataModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return UsuarioRetorno;
        }

        public UsuarioDataTransfer Listar()
        {
            UsuarioData usuarioData;
            UsuarioDataTransfer UsuarioRetorno;

            try {
                usuarioData = new UsuarioData(_contexto);
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.UsuarioLista = usuarioData.Listar();
                UsuarioRetorno.Validacao = true;
                UsuarioRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Validacao = false;
                UsuarioRetorno.Erro = true;
                UsuarioRetorno.IncluirErroMensagem("Erro em UsuarioDataModel Listar [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return UsuarioRetorno;
        }

        public UsuarioDataTransfer ConsultarPorId(int id)
        {
            UsuarioData usuarioData;
            UsuarioDataTransfer UsuarioRetorno;

            try {
                usuarioData = new UsuarioData(_contexto);
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Usuario = usuarioData.ConsultarPorId(id);
                UsuarioRetorno.Validacao = true;
                UsuarioRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Validacao = false;
                UsuarioRetorno.Erro = true;
                UsuarioRetorno.IncluirErroMensagem("Erro em UsuarioDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return UsuarioRetorno;
        }

        public UsuarioDataTransfer Consultar(UsuarioDataTransfer usuarioDataTransfer)
        {
            UsuarioData usuarioData;
            UsuarioDataTransfer UsuarioRetorno;

            try {
                usuarioData = new UsuarioData(_contexto);
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.UsuarioLista = usuarioData.Consultar(usuarioDataTransfer);
                UsuarioRetorno.Validacao = true;
                UsuarioRetorno.Erro = false;
            } catch (Exception ex) {
                UsuarioRetorno = new UsuarioDataTransfer();

                UsuarioRetorno.Validacao = false;
                UsuarioRetorno.Erro = true;
                UsuarioRetorno.IncluirErroMensagem("Erro em UsuarioDataModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioData = null;
            }

            return UsuarioRetorno;
        }
    }
}
