using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class EstadoCivilDataModel : DataModel
    {
        public EstadoCivilTransfer Incluir(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                estadoCivil = new EstadoCivilTransfer(estadoCivilTransfer);

                estadoCivilData.Incluir(estadoCivilTransfer.EstadoCivil);

                _contexto.SaveChanges();

                estadoCivil.EstadoCivil = new EstadoCivilEntity(estadoCivilTransfer.EstadoCivil);
                estadoCivil.Validacao = true;
                estadoCivil.Erro = false;
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilDataModel Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return estadoCivil;
        }

        public EstadoCivilTransfer Alterar(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                estadoCivil = new EstadoCivilTransfer();

                estadoCivilData.Alterar(estadoCivilTransfer.EstadoCivil);

                _contexto.SaveChanges();

                estadoCivil.EstadoCivil = new EstadoCivilEntity(estadoCivilTransfer.EstadoCivil);
                estadoCivil.Validacao = true;
                estadoCivil.Erro = false;
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilDataModel Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return estadoCivil;
        }

        public EstadoCivilTransfer Excluir(int id)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.EstadoCivil = estadoCivilData.ConsultarPorId(id);
                estadoCivilData.Excluir(estadoCivil.EstadoCivil);

                _contexto.SaveChanges();

                estadoCivil.Validacao = true;
                estadoCivil.Erro = false;
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilDataModel Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return estadoCivil;
        }

        public EstadoCivilTransfer ConsultarPorId(int id)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.EstadoCivil = estadoCivilData.ConsultarPorId(id);
                estadoCivil.Validacao = true;
                estadoCivil.Erro = false;
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return estadoCivil;
        }

        public EstadoCivilTransfer Consultar(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilData estadoCivilData;
            EstadoCivilTransfer estadoCivilLista;

            try {
                estadoCivilData = new EstadoCivilData(_contexto);

                estadoCivilLista = estadoCivilData.Consultar(estadoCivilTransfer);
                estadoCivilLista.Validacao = true;
                estadoCivilLista.Erro = false;
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirMensagem("Erro em EstadoCivilDataModel Consultar [" + ex.Message + "]");
            } finally {
                estadoCivilData = null;
            }

            return estadoCivilLista;
        }
    }
}
