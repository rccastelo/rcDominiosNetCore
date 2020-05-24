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
            if (telefoneTipoTransfer.IdAte <= 0) {
                if (telefoneTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == telefoneTipoTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (telefoneTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= telefoneTipoTransfer.IdDe);
                    query = query.Where(et => et.Id <= telefoneTipoTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(telefoneTipoTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(telefoneTipoTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(telefoneTipoTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(telefoneTipoTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(telefoneTipoTransfer.Ativo)) {
                bool ativo = true;

                if (telefoneTipoTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (telefoneTipoTransfer.CriacaoAte == DateTime.MinValue) {
                if (telefoneTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == telefoneTipoTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (telefoneTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= telefoneTipoTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= telefoneTipoTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (telefoneTipoTransfer.AlteracaoAte == DateTime.MinValue) {
                if (telefoneTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == telefoneTipoTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (telefoneTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= telefoneTipoTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= telefoneTipoTransfer.AlteracaoAte);
                }
            }
            
            if (telefoneTipoTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (telefoneTipoTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = telefoneTipoTransfer.RegistrosPorPagina;
            }

            pular = (telefoneTipoTransfer.PaginaAtual < 2 ? 0 : telefoneTipoTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            telefoneTipoLista.RegistrosPorPagina = registrosPorPagina;
            telefoneTipoLista.TotalRegistros = totalRegistros;
            telefoneTipoLista.TelefoneTipoLista = lista;

            return telefoneTipoLista;
        }
    }
}
