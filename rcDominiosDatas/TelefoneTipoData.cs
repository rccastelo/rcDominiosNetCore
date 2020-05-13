using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class TelefoneTipoData : Data<TelefoneTipoEntity>
    {
        public TelefoneTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<TelefoneTipoEntity> Consultar(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            IQueryable<TelefoneTipoEntity> query = _contexto.Set<TelefoneTipoEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (telefoneTipoDataTransfer.IdAte <= 0) {
                if (telefoneTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == telefoneTipoDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (telefoneTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= telefoneTipoDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= telefoneTipoDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(telefoneTipoDataTransfer.TelefoneTipo.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(telefoneTipoDataTransfer.TelefoneTipo.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(telefoneTipoDataTransfer.TelefoneTipo.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(telefoneTipoDataTransfer.TelefoneTipo.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(telefoneTipoDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (telefoneTipoDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (telefoneTipoDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (telefoneTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == telefoneTipoDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (telefoneTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= telefoneTipoDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= telefoneTipoDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (telefoneTipoDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (telefoneTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == telefoneTipoDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (telefoneTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= telefoneTipoDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= telefoneTipoDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
