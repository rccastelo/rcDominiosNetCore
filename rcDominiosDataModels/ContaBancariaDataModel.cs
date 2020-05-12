using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class ContaBancariaDataModel : DataModel
    {
        public ContaBancariaDataTransfer Incluir(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaDataTransfer ContaBancariaRetorno;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                ContaBancariaRetorno = new ContaBancariaDataTransfer(contaBancariaDataTransfer);

                contaBancariaData.Incluir(contaBancariaDataTransfer.ContaBancaria);

                _contexto.SaveChanges();

                ContaBancariaRetorno.ContaBancaria = new ContaBancariaEntity(contaBancariaDataTransfer.ContaBancaria);
                ContaBancariaRetorno.Validacao = true;
                ContaBancariaRetorno.Erro = false;
            } catch (Exception ex) {
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.Validacao = false;
                ContaBancariaRetorno.Erro = true;
                ContaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaDataModel Incluir [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return ContaBancariaRetorno;
        }

        public ContaBancariaDataTransfer Alterar(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaDataTransfer ContaBancariaRetorno;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                contaBancariaData.Alterar(contaBancariaDataTransfer.ContaBancaria);

                _contexto.SaveChanges();

                ContaBancariaRetorno.ContaBancaria = new ContaBancariaEntity(contaBancariaDataTransfer.ContaBancaria);
                ContaBancariaRetorno.Validacao = true;
                ContaBancariaRetorno.Erro = false;
            } catch (Exception ex) {
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.Validacao = false;
                ContaBancariaRetorno.Erro = true;
                ContaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaDataModel Alterar [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return ContaBancariaRetorno;
        }

        public ContaBancariaDataTransfer Excluir(int id)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaDataTransfer ContaBancariaRetorno;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.ContaBancaria = contaBancariaData.ConsultarPorId(id);
                contaBancariaData.Excluir(ContaBancariaRetorno.ContaBancaria);

                _contexto.SaveChanges();

                ContaBancariaRetorno.Validacao = true;
                ContaBancariaRetorno.Erro = false;
            } catch (Exception ex) {
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.Validacao = false;
                ContaBancariaRetorno.Erro = true;
                ContaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaDataModel Excluir [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return ContaBancariaRetorno;
        }

        public ContaBancariaDataTransfer Listar()
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaDataTransfer ContaBancariaRetorno;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.ContaBancariaLista = contaBancariaData.Listar();
                ContaBancariaRetorno.Validacao = true;
                ContaBancariaRetorno.Erro = false;
            } catch (Exception ex) {
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.Validacao = false;
                ContaBancariaRetorno.Erro = true;
                ContaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaDataModel Listar [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return ContaBancariaRetorno;
        }

        public ContaBancariaDataTransfer ConsultarPorId(int id)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaDataTransfer ContaBancariaRetorno;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.ContaBancaria = contaBancariaData.ConsultarPorId(id);
                ContaBancariaRetorno.Validacao = true;
                ContaBancariaRetorno.Erro = false;
            } catch (Exception ex) {
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.Validacao = false;
                ContaBancariaRetorno.Erro = true;
                ContaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return ContaBancariaRetorno;
        }

        public ContaBancariaDataTransfer Consultar(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaDataTransfer ContaBancariaRetorno;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.ContaBancariaLista = contaBancariaData.Consultar(contaBancariaDataTransfer);
                ContaBancariaRetorno.Validacao = true;
                ContaBancariaRetorno.Erro = false;
            } catch (Exception ex) {
                ContaBancariaRetorno = new ContaBancariaDataTransfer();

                ContaBancariaRetorno.Validacao = false;
                ContaBancariaRetorno.Erro = true;
                ContaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaDataModel Consultar [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return ContaBancariaRetorno;
        }
    }
}
