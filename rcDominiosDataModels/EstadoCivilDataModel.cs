using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class EstadoCivilDataModel : DataModel
    {
        public EstadoCivilDataTransfer Incluir(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilDataTransfer EstadoCivilRetorno;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                EstadoCivilRetorno = new EstadoCivilDataTransfer(estadoCivilDataTransfer);

                estadoCivilData.Incluir(estadoCivilDataTransfer.EstadoCivil);

                _contexto.SaveChanges();

                EstadoCivilRetorno.EstadoCivil = new EstadoCivilEntity(estadoCivilDataTransfer.EstadoCivil);
                EstadoCivilRetorno.Validacao = true;
                EstadoCivilRetorno.Erro = false;
            } catch (Exception ex) {
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.Validacao = false;
                EstadoCivilRetorno.Erro = true;
                EstadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilDataModel Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return EstadoCivilRetorno;
        }

        public EstadoCivilDataTransfer Alterar(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilDataTransfer EstadoCivilRetorno;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                estadoCivilData.Alterar(estadoCivilDataTransfer.EstadoCivil);

                _contexto.SaveChanges();

                EstadoCivilRetorno.EstadoCivil = new EstadoCivilEntity(estadoCivilDataTransfer.EstadoCivil);
                EstadoCivilRetorno.Validacao = true;
                EstadoCivilRetorno.Erro = false;
            } catch (Exception ex) {
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.Validacao = false;
                EstadoCivilRetorno.Erro = true;
                EstadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilDataModel Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return EstadoCivilRetorno;
        }

        public EstadoCivilDataTransfer Excluir(int id)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilDataTransfer EstadoCivilRetorno;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.EstadoCivil = estadoCivilData.ConsultarPorId(id);
                estadoCivilData.Excluir(EstadoCivilRetorno.EstadoCivil);

                _contexto.SaveChanges();

                EstadoCivilRetorno.Validacao = true;
                EstadoCivilRetorno.Erro = false;
            } catch (Exception ex) {
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.Validacao = false;
                EstadoCivilRetorno.Erro = true;
                EstadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilDataModel Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return EstadoCivilRetorno;
        }

        public EstadoCivilDataTransfer Listar()
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilDataTransfer EstadoCivilRetorno;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.EstadoCivilLista = estadoCivilData.Listar();
                EstadoCivilRetorno.Validacao = true;
                EstadoCivilRetorno.Erro = false;
            } catch (Exception ex) {
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.Validacao = false;
                EstadoCivilRetorno.Erro = true;
                EstadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilDataModel Listar [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return EstadoCivilRetorno;
        }

        public EstadoCivilDataTransfer ConsultarPorId(int id)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilDataTransfer EstadoCivilRetorno;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.EstadoCivil = estadoCivilData.ConsultarPorId(id);
                EstadoCivilRetorno.Validacao = true;
                EstadoCivilRetorno.Erro = false;
            } catch (Exception ex) {
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.Validacao = false;
                EstadoCivilRetorno.Erro = true;
                EstadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return EstadoCivilRetorno;
        }

        public EstadoCivilDataTransfer Consultar(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilDataTransfer EstadoCivilRetorno;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.EstadoCivilLista = estadoCivilData.Consultar(estadoCivilDataTransfer);
                EstadoCivilRetorno.Validacao = true;
                EstadoCivilRetorno.Erro = false;
            } catch (Exception ex) {
                EstadoCivilRetorno = new EstadoCivilDataTransfer();

                EstadoCivilRetorno.Validacao = false;
                EstadoCivilRetorno.Erro = true;
                EstadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilDataModel Consultar [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return EstadoCivilRetorno;
        }
    }
}
