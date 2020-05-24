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
            if (estadoCivilTransfer.IdAte <= 0) {
                if (estadoCivilTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == estadoCivilTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (estadoCivilTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= estadoCivilTransfer.IdDe);
                    query = query.Where(et => et.Id <= estadoCivilTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(estadoCivilTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(estadoCivilTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(estadoCivilTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(estadoCivilTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(estadoCivilTransfer.Ativo)) {
                bool ativo = true;

                if (estadoCivilTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (estadoCivilTransfer.CriacaoAte == DateTime.MinValue) {
                if (estadoCivilTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == estadoCivilTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (estadoCivilTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= estadoCivilTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= estadoCivilTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (estadoCivilTransfer.AlteracaoAte == DateTime.MinValue) {
                if (estadoCivilTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == estadoCivilTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (estadoCivilTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= estadoCivilTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= estadoCivilTransfer.AlteracaoAte);
                }
            }
            
            if (estadoCivilTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (estadoCivilTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = estadoCivilTransfer.RegistrosPorPagina;
            }

            pular = (estadoCivilTransfer.PaginaAtual < 2 ? 0 : estadoCivilTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            estadoCivilLista.RegistrosPorPagina = registrosPorPagina;
            estadoCivilLista.TotalRegistros = totalRegistros;
            estadoCivilLista.EstadoCivilLista = lista;

            return estadoCivilLista;
        }
    }
}
