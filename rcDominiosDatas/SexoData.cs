using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class SexoData : Data<SexoEntity>
    {
        public SexoData(DominiosDbContext contexto)
            : base(contexto)
        {
        }

        public SexoTransfer Consultar(SexoTransfer sexoTransfer)
        {
            IQueryable<SexoEntity> query = _contexto.Set<SexoEntity>();
            SexoTransfer sexoLista = new SexoTransfer(sexoTransfer);
            IList<SexoEntity> lista = new List<SexoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (sexoTransfer.Filtro.IdAte <= 0) {
                if (sexoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == sexoTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (sexoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= sexoTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= sexoTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(sexoTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(sexoTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(sexoTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(sexoTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(sexoTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (sexoTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (sexoTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (sexoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == sexoTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (sexoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= sexoTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= sexoTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (sexoTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (sexoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == sexoTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (sexoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= sexoTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= sexoTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (sexoTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (sexoTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = sexoTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (sexoTransfer.Paginacao.PaginaAtual < 2 ? 0 : sexoTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            sexoLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            sexoLista.Paginacao.TotalRegistros = totalRegistros;
            sexoLista.Lista = lista;

            return sexoLista;
        }
    }
}
