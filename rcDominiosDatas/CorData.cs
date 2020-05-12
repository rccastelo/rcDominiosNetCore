using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class CorData : Data<CorEntity>
    {
        public CorData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<CorEntity> Consultar(CorDataTransfer corDataTransfer)
        {
            IQueryable<CorEntity> query = _contexto.Set<CorEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (corDataTransfer.IdAte <= 0) {
                if (corDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == corDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (corDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= corDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= corDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(corDataTransfer.Cor.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(corDataTransfer.Cor.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(corDataTransfer.Cor.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(corDataTransfer.Cor.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(corDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (corDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (corDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (corDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == corDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (corDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= corDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= corDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (corDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (corDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == corDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (corDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= corDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= corDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
