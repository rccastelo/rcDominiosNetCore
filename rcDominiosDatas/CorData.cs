using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class CorData : Data<CorEntity>
    {
        public CorData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public CorTransfer Consultar(CorTransfer corTransfer)
        {
            IQueryable<CorEntity> query = _contexto.Set<CorEntity>();
            CorTransfer corLista = new CorTransfer(corTransfer);
            IList<CorEntity> lista = new List<CorEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (corTransfer.IdAte <= 0) {
                if (corTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == corTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (corTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= corTransfer.IdDe);
                    query = query.Where(et => et.Id <= corTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(corTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(corTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(corTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(corTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(corTransfer.Ativo)) {
                bool ativo = true;

                if (corTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (corTransfer.CriacaoAte == DateTime.MinValue) {
                if (corTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == corTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (corTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= corTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= corTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (corTransfer.AlteracaoAte == DateTime.MinValue) {
                if (corTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == corTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (corTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= corTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= corTransfer.AlteracaoAte);
                }
            }
            
            if (corTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (corTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = corTransfer.RegistrosPorPagina;
            }

            pular = (corTransfer.PaginaAtual < 2 ? 0 : corTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            corLista.RegistrosPorPagina = registrosPorPagina;
            corLista.TotalRegistros = totalRegistros;
            corLista.CorLista = lista;

            return corLista;
        }
    }
}
