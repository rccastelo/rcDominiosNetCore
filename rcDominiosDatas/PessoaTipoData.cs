using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class PessoaTipoData : Data<PessoaTipoEntity>
    {
        public PessoaTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<PessoaTipoEntity> Consultar(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            IQueryable<PessoaTipoEntity> query = _contexto.Set<PessoaTipoEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (pessoaTipoDataTransfer.IdAte <= 0) {
                if (pessoaTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == pessoaTipoDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (pessoaTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= pessoaTipoDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= pessoaTipoDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(pessoaTipoDataTransfer.PessoaTipo.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(pessoaTipoDataTransfer.PessoaTipo.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(pessoaTipoDataTransfer.PessoaTipo.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(pessoaTipoDataTransfer.PessoaTipo.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(pessoaTipoDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (pessoaTipoDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (pessoaTipoDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (pessoaTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == pessoaTipoDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (pessoaTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= pessoaTipoDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= pessoaTipoDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (pessoaTipoDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (pessoaTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == pessoaTipoDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (pessoaTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= pessoaTipoDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= pessoaTipoDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
