using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class EnderecoTipoDataModel : DataModel
    {
        public EnderecoTipoDataTransfer Incluir(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoDataTransfer EnderecoTipoRetorno;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer(enderecoTipoDataTransfer);

                enderecoTipoData.Incluir(enderecoTipoDataTransfer.EnderecoTipo);

                _contexto.SaveChanges();

                EnderecoTipoRetorno.EnderecoTipo = new EnderecoTipoEntity(enderecoTipoDataTransfer.EnderecoTipo);
                EnderecoTipoRetorno.Validacao = true;
                EnderecoTipoRetorno.Erro = false;
            } catch (Exception ex) {
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.Validacao = false;
                EnderecoTipoRetorno.Erro = true;
                EnderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return EnderecoTipoRetorno;
        }

        public EnderecoTipoDataTransfer Alterar(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoDataTransfer EnderecoTipoRetorno;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                enderecoTipoData.Alterar(enderecoTipoDataTransfer.EnderecoTipo);

                _contexto.SaveChanges();

                EnderecoTipoRetorno.EnderecoTipo = new EnderecoTipoEntity(enderecoTipoDataTransfer.EnderecoTipo);
                EnderecoTipoRetorno.Validacao = true;
                EnderecoTipoRetorno.Erro = false;
            } catch (Exception ex) {
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.Validacao = false;
                EnderecoTipoRetorno.Erro = true;
                EnderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return EnderecoTipoRetorno;
        }

        public EnderecoTipoDataTransfer Excluir(int id)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoDataTransfer EnderecoTipoRetorno;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.EnderecoTipo = enderecoTipoData.ConsultarPorId(id);
                enderecoTipoData.Excluir(EnderecoTipoRetorno.EnderecoTipo);

                _contexto.SaveChanges();

                EnderecoTipoRetorno.Validacao = true;
                EnderecoTipoRetorno.Erro = false;
            } catch (Exception ex) {
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.Validacao = false;
                EnderecoTipoRetorno.Erro = true;
                EnderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return EnderecoTipoRetorno;
        }

        public EnderecoTipoDataTransfer Listar()
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoDataTransfer EnderecoTipoRetorno;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.EnderecoTipoLista = enderecoTipoData.Listar();
                EnderecoTipoRetorno.Validacao = true;
                EnderecoTipoRetorno.Erro = false;
            } catch (Exception ex) {
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.Validacao = false;
                EnderecoTipoRetorno.Erro = true;
                EnderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoDataModel Listar [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return EnderecoTipoRetorno;
        }

        public EnderecoTipoDataTransfer ConsultarPorId(int id)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoDataTransfer EnderecoTipoRetorno;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.EnderecoTipo = enderecoTipoData.ConsultarPorId(id);
                EnderecoTipoRetorno.Validacao = true;
                EnderecoTipoRetorno.Erro = false;
            } catch (Exception ex) {
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.Validacao = false;
                EnderecoTipoRetorno.Erro = true;
                EnderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return EnderecoTipoRetorno;
        }

        public EnderecoTipoDataTransfer Consultar(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoData enderecoTipoData;
            EnderecoTipoDataTransfer EnderecoTipoRetorno;

            try {
                enderecoTipoData = new EnderecoTipoData(_contexto);
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.EnderecoTipoLista = enderecoTipoData.Consultar(enderecoTipoDataTransfer);
                EnderecoTipoRetorno.Validacao = true;
                EnderecoTipoRetorno.Erro = false;
            } catch (Exception ex) {
                EnderecoTipoRetorno = new EnderecoTipoDataTransfer();

                EnderecoTipoRetorno.Validacao = false;
                EnderecoTipoRetorno.Erro = true;
                EnderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                enderecoTipoData = null;
            }

            return EnderecoTipoRetorno;
        }
    }
}
