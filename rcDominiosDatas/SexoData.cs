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
            if (sexoTransfer.IdAte <= 0) {
                if (sexoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == sexoTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (sexoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= sexoTransfer.IdDe);
                    query = query.Where(et => et.Id <= sexoTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(sexoTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(sexoTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(sexoTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(sexoTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(sexoTransfer.Ativo)) {
                bool ativo = true;

                if (sexoTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (sexoTransfer.CriacaoAte == DateTime.MinValue) {
                if (sexoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == sexoTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (sexoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= sexoTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= sexoTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (sexoTransfer.AlteracaoAte == DateTime.MinValue) {
                if (sexoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == sexoTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (sexoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= sexoTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= sexoTransfer.AlteracaoAte);
                }
            }
            
            if (sexoTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (sexoTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = sexoTransfer.RegistrosPorPagina;
            }

            pular = (sexoTransfer.PaginaAtual < 2 ? 0 : sexoTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            sexoLista.RegistrosPorPagina = registrosPorPagina;
            sexoLista.TotalRegistros = totalRegistros;
            sexoLista.SexoLista = lista;

            return sexoLista;
        }
    }
}
