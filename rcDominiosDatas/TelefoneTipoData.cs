using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class TelefoneTipoData : Data<TelefoneTipoEntity>
    {
        public TelefoneTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public TelefoneTipoTransfer Consultar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            IQueryable<TelefoneTipoEntity> query = _contexto.Set<TelefoneTipoEntity>();
            TelefoneTipoTransfer telefoneTipoLista = new TelefoneTipoTransfer(telefoneTipoTransfer);
            IList<TelefoneTipoEntity> lista = new List<TelefoneTipoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (telefoneTipoTransfer.Filtro.IdAte <= 0) {
                if (telefoneTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == telefoneTipoTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (telefoneTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= telefoneTipoTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= telefoneTipoTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(telefoneTipoTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(telefoneTipoTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(telefoneTipoTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(telefoneTipoTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(telefoneTipoTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (telefoneTipoTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (telefoneTipoTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (telefoneTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == telefoneTipoTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (telefoneTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= telefoneTipoTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= telefoneTipoTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (telefoneTipoTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (telefoneTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == telefoneTipoTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (telefoneTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= telefoneTipoTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= telefoneTipoTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (telefoneTipoTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (telefoneTipoTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = telefoneTipoTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (telefoneTipoTransfer.Paginacao.PaginaAtual < 2 ? 0 : telefoneTipoTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            telefoneTipoLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            telefoneTipoLista.Paginacao.TotalRegistros = totalRegistros;
            telefoneTipoLista.Lista = lista;

            return telefoneTipoLista;
        }
    }
}
