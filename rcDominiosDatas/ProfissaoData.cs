using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class ProfissaoData : Data<ProfissaoEntity>
    {
        public ProfissaoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<ProfissaoEntity> Consultar(ProfissaoDataTransfer profissaoDataTransfer)
        {
            IQueryable<ProfissaoEntity> query = _contexto.Set<ProfissaoEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (profissaoDataTransfer.IdAte <= 0) {
                if (profissaoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == profissaoDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (profissaoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= profissaoDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= profissaoDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(profissaoDataTransfer.Profissao.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(profissaoDataTransfer.Profissao.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(profissaoDataTransfer.Profissao.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(profissaoDataTransfer.Profissao.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(profissaoDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (profissaoDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (profissaoDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (profissaoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == profissaoDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (profissaoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= profissaoDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= profissaoDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (profissaoDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (profissaoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == profissaoDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (profissaoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= profissaoDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= profissaoDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
