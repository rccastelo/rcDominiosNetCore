using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class EnderecoTipoDataModel : DataModel
    {
        public EnderecoTipoTransfer Incluir(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                enderecoTipo = new EnderecoTipoTransfer(enderecoTipoTransfer);

                enderecoTipoData.Incluir(enderecoTipoTransfer.EnderecoTipo);

                _contexto.SaveChanges();

                enderecoTipo.EnderecoTipo = new EnderecoTipoEntity(enderecoTipoTransfer.EnderecoTipo);
                enderecoTipo.Validacao = true;
                enderecoTipo.Erro = false;
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return enderecoTipo;
        }

        public EnderecoTipoTransfer Alterar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipoData.Alterar(enderecoTipoTransfer.EnderecoTipo);

                _contexto.SaveChanges();

                enderecoTipo.EnderecoTipo = new EnderecoTipoEntity(enderecoTipoTransfer.EnderecoTipo);
                enderecoTipo.Validacao = true;
                enderecoTipo.Erro = false;
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return enderecoTipo;
        }

        public EnderecoTipoTransfer Excluir(int id)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.EnderecoTipo = enderecoTipoData.ConsultarPorId(id);
                enderecoTipoData.Excluir(enderecoTipo.EnderecoTipo);

                _contexto.SaveChanges();

                enderecoTipo.Validacao = true;
                enderecoTipo.Erro = false;
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return enderecoTipo;
        }

        public EnderecoTipoTransfer ConsultarPorId(int id)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.EnderecoTipo = enderecoTipoData.ConsultarPorId(id);
                enderecoTipo.Validacao = true;
                enderecoTipo.Erro = false;
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return enderecoTipo;
        }

        public EnderecoTipoTransfer Consultar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoTransfer enderecoTipoLista;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);

                enderecoTipoLista = enderecoTipoData.Consultar(enderecoTipoTransfer);
                enderecoTipoLista.Validacao = true;
                enderecoTipoLista.Erro = false;
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirErroMensagem("Erro em EnderecoTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return enderecoTipoLista;
        }
    }
}
