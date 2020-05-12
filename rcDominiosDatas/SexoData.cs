using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class SexoData : Data<SexoEntity>
    {
        public SexoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<SexoEntity> Consultar(SexoDataTransfer sexoDataTransfer)
        {
            IQueryable<SexoEntity> query = _contexto.Set<SexoEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (sexoDataTransfer.IdAte <= 0) {
                if (sexoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == sexoDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (sexoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= sexoDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= sexoDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(sexoDataTransfer.Sexo.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(sexoDataTransfer.Sexo.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(sexoDataTransfer.Sexo.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(sexoDataTransfer.Sexo.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(sexoDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (sexoDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (sexoDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (sexoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == sexoDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (sexoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= sexoDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= sexoDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (sexoDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (sexoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == sexoDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (sexoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= sexoDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= sexoDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
