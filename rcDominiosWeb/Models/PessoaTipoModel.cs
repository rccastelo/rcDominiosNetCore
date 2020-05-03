using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class PessoaTipoModel
    {
        public PessoaTipoDataTransfer Incluir(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoDataTransfer pessoaTipoDataTransferValidacao;
            PessoaTipoDataTransfer pessoaTipoDataTransferInclusao;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDataTransferValidacao = pessoaTipoBusiness.Validar(pessoaTipoDataTransfer);

                if (!pessoaTipoDataTransferValidacao.Erro) {
                    if (pessoaTipoDataTransferValidacao.Validacao) {
                        pessoaTipoDataTransferInclusao = pessoaTipoDataModel.Incluir(pessoaTipoDataTransfer);
                    } else {
                        pessoaTipoDataTransferInclusao = new PessoaTipoDataTransfer(pessoaTipoDataTransferValidacao);
                    }
                } else {
                    pessoaTipoDataTransferInclusao = new PessoaTipoDataTransfer(pessoaTipoDataTransferValidacao);
                }
            } catch {
                pessoaTipoDataTransferInclusao = new PessoaTipoDataTransfer();

                pessoaTipoDataTransferInclusao.Validacao = false;
                pessoaTipoDataTransferInclusao.Erro = true;
                pessoaTipoDataTransferInclusao.ErroMensagens.Add("Erro em PessoaTipoModel Incluir");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoDataTransferValidacao = null;
            }

            return pessoaTipoDataTransferInclusao;
        }
    }
}
