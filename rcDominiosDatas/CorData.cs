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
            if (corTransfer.Filtro.IdAte <= 0) {
                if (corTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == corTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (corTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= corTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= corTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(corTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(corTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(corTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(corTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(corTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (corTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (corTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (corTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == corTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (corTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= corTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= corTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (corTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (corTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == corTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (corTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= corTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= corTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (corTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (corTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = corTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (corTransfer.Paginacao.PaginaAtual < 2 ? 0 : corTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            corLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            corLista.Paginacao.TotalRegistros = totalRegistros;
            corLista.Lista = lista;

            return corLista;
        }
    }
}
