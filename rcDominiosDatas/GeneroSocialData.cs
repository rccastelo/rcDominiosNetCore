using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class GeneroSocialData : Data<GeneroSocialEntity>
    {
        public GeneroSocialData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<GeneroSocialEntity> Consultar(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            IQueryable<GeneroSocialEntity> query = _contexto.Set<GeneroSocialEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (generoSocialDataTransfer.IdAte <= 0) {
                if (generoSocialDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == generoSocialDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (generoSocialDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= generoSocialDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= generoSocialDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(generoSocialDataTransfer.GeneroSocial.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(generoSocialDataTransfer.GeneroSocial.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(generoSocialDataTransfer.GeneroSocial.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(generoSocialDataTransfer.GeneroSocial.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(generoSocialDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (generoSocialDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (generoSocialDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (generoSocialDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == generoSocialDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (generoSocialDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= generoSocialDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= generoSocialDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (generoSocialDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (generoSocialDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == generoSocialDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (generoSocialDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= generoSocialDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= generoSocialDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
