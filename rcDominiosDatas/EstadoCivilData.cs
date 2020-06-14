using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class EstadoCivilData : Data<EstadoCivilEntity>
    {
        public EstadoCivilData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public EstadoCivilTransfer Consultar(EstadoCivilTransfer estadoCivilTransfer)
        {
            IQueryable<EstadoCivilEntity> query = _contexto.Set<EstadoCivilEntity>();
            EstadoCivilTransfer estadoCivilLista = new EstadoCivilTransfer(estadoCivilTransfer);
            IList<EstadoCivilEntity> lista = new List<EstadoCivilEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (estadoCivilTransfer.Filtro.IdAte <= 0) {
                if (estadoCivilTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == estadoCivilTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (estadoCivilTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= estadoCivilTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= estadoCivilTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(estadoCivilTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(estadoCivilTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(estadoCivilTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(estadoCivilTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(estadoCivilTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (estadoCivilTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (estadoCivilTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (estadoCivilTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == estadoCivilTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (estadoCivilTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= estadoCivilTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= estadoCivilTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (estadoCivilTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (estadoCivilTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == estadoCivilTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (estadoCivilTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= estadoCivilTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= estadoCivilTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (estadoCivilTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (estadoCivilTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = estadoCivilTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (estadoCivilTransfer.Paginacao.PaginaAtual < 2 ? 0 : estadoCivilTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            estadoCivilLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            estadoCivilLista.Paginacao.TotalRegistros = totalRegistros;
            estadoCivilLista.Lista = lista;

            return estadoCivilLista;
        }
    }
}
