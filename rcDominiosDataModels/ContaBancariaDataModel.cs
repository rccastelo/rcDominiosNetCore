using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class ContaBancariaDataModel : DataModel
    {
        public ContaBancariaTransfer Incluir(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                contaBancaria = new ContaBancariaTransfer(contaBancariaTransfer);

                contaBancariaData.Incluir(contaBancariaTransfer.ContaBancaria);

                _contexto.SaveChanges();

                contaBancaria.ContaBancaria = new ContaBancariaEntity(contaBancariaTransfer.ContaBancaria);
                contaBancaria.Validacao = true;
                contaBancaria.Erro = false;
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaDataModel Incluir [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return contaBancaria;
        }

        public ContaBancariaTransfer Alterar(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                contaBancaria = new ContaBancariaTransfer();

                contaBancariaData.Alterar(contaBancariaTransfer.ContaBancaria);

                _contexto.SaveChanges();

                contaBancaria.ContaBancaria = new ContaBancariaEntity(contaBancariaTransfer.ContaBancaria);
                contaBancaria.Validacao = true;
                contaBancaria.Erro = false;
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaDataModel Alterar [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return contaBancaria;
        }

        public ContaBancariaTransfer Excluir(int id)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.ContaBancaria = contaBancariaData.ConsultarPorId(id);
                contaBancariaData.Excluir(contaBancaria.ContaBancaria);

                _contexto.SaveChanges();

                contaBancaria.Validacao = true;
                contaBancaria.Erro = false;
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaDataModel Excluir [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return contaBancaria;
        }

        public ContaBancariaTransfer ConsultarPorId(int id)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.ContaBancaria = contaBancariaData.ConsultarPorId(id);
                contaBancaria.Validacao = true;
                contaBancaria.Erro = false;
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return contaBancaria;
        }

        public ContaBancariaTransfer Consultar(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaData contaBancariaData;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaData = new ContaBancariaData(_contexto);

                contaBancariaLista = contaBancariaData.Consultar(contaBancariaTransfer);
                contaBancariaLista.Validacao = true;
                contaBancariaLista.Erro = false;
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirMensagem("Erro em ContaBancariaDataModel Consultar [" + ex.Message + "]");
            } finally {
                contaBancariaData = null;
            }

            return contaBancariaLista;
        }
    }
}
