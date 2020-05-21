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

        public IList<PessoaTipoEntity> Consultar(PessoaTipoListaTransfer transfer)
        {
            IQueryable<PessoaTipoEntity> query = _contexto.Set<PessoaTipoEntity>();
            int pular = 0;
            int quantidade = 0;

            //-- Se IdAte não informado, procura Id específico
            if (transfer.IdAte <= 0) {
                if (transfer.IdDe > 0) {
                    query = query.Where(et => et.Id == transfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (transfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= transfer.IdDe);
                    query = query.Where(et => et.Id <= transfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(transfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(transfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(transfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(transfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(transfer.Ativo)) {
                bool ativo = true;

                if (transfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (transfer.CriacaoAte == DateTime.MinValue) {
                if (transfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == transfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (transfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= transfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= transfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (transfer.AlteracaoAte == DateTime.MinValue) {
                if (transfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == transfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (transfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= transfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= transfer.AlteracaoAte);
                }
            }
            
            pular = (transfer.Pagina < 2 ? 0 : transfer.Pagina - 1);
            
            if (transfer.Quantidade < 1) {
                quantidade = 30;
            } else if (transfer.Quantidade > 1000) {
                quantidade = 30;
            }
            
            return query.Skip(pular).Take(quantidade).ToList();
        }
    }
}
