using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class CorDataModel : DataModel
    {
        public CorTransfer Incluir(CorTransfer corTransfer)
        {
            CorData corData;
            CorTransfer cor;

            try {
                corData = new CorData(_contexto);
                cor = new CorTransfer(corTransfer);

                corData.Incluir(corTransfer.Cor);

                _contexto.SaveChanges();

                cor.Cor = new CorEntity(corTransfer.Cor);
                cor.Validacao = true;
                cor.Erro = false;
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorDataModel Incluir [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return cor;
        }

        public CorTransfer Alterar(CorTransfer corTransfer)
        {
            CorData corData;
            CorTransfer cor;

            try {
                corData = new CorData(_contexto);
                cor = new CorTransfer();

                corData.Alterar(corTransfer.Cor);

                _contexto.SaveChanges();

                cor.Cor = new CorEntity(corTransfer.Cor);
                cor.Validacao = true;
                cor.Erro = false;
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorDataModel Alterar [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return cor;
        }

        public CorTransfer Excluir(int id)
        {
            CorData corData;
            CorTransfer cor;

            try {
                corData = new CorData(_contexto);
                cor = new CorTransfer();

                cor.Cor = corData.ConsultarPorId(id);
                corData.Excluir(cor.Cor);

                _contexto.SaveChanges();

                cor.Validacao = true;
                cor.Erro = false;
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorDataModel Excluir [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return cor;
        }

        public CorTransfer ConsultarPorId(int id)
        {
            CorData corData;
            CorTransfer cor;

            try {
                corData = new CorData(_contexto);
                cor = new CorTransfer();

                cor.Cor = corData.ConsultarPorId(id);
                cor.Validacao = true;
                cor.Erro = false;
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return cor;
        }

        public CorTransfer Consultar(CorTransfer corTransfer)
        {
            CorData corData;
            CorTransfer corLista;

            try {
                corData = new CorData(_contexto);

                corLista = corData.Consultar(corTransfer);
                corLista.Validacao = true;
                corLista.Erro = false;
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em CorDataModel Consultar [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return corLista;
        }
    }
}
