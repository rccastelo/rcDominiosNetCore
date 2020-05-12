using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class EnderecoTipoData : Data<EnderecoTipoEntity>
    {
        public EnderecoTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<EnderecoTipoEntity> Consultar(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            IQueryable<EnderecoTipoEntity> query = _contexto.Set<EnderecoTipoEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (enderecoTipoDataTransfer.IdAte <= 0) {
                if (enderecoTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == enderecoTipoDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (enderecoTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= enderecoTipoDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= enderecoTipoDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(enderecoTipoDataTransfer.EnderecoTipo.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(enderecoTipoDataTransfer.EnderecoTipo.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(enderecoTipoDataTransfer.EnderecoTipo.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(enderecoTipoDataTransfer.EnderecoTipo.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(enderecoTipoDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (enderecoTipoDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (enderecoTipoDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (enderecoTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == enderecoTipoDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (enderecoTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= enderecoTipoDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= enderecoTipoDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (enderecoTipoDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (enderecoTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == enderecoTipoDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (enderecoTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= enderecoTipoDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= enderecoTipoDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
