using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class EstadoCivilData : Data<EstadoCivilEntity>
    {
        public EstadoCivilData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<EstadoCivilEntity> Consultar(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            IQueryable<EstadoCivilEntity> query = _contexto.Set<EstadoCivilEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (estadoCivilDataTransfer.IdAte <= 0) {
                if (estadoCivilDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == estadoCivilDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (estadoCivilDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= estadoCivilDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= estadoCivilDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(estadoCivilDataTransfer.EstadoCivil.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(estadoCivilDataTransfer.EstadoCivil.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(estadoCivilDataTransfer.EstadoCivil.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(estadoCivilDataTransfer.EstadoCivil.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(estadoCivilDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (estadoCivilDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (estadoCivilDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (estadoCivilDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == estadoCivilDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (estadoCivilDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= estadoCivilDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= estadoCivilDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (estadoCivilDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (estadoCivilDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == estadoCivilDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (estadoCivilDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= estadoCivilDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= estadoCivilDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
