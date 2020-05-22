using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class ProfissaoData : Data<ProfissaoEntity>
    {
        public ProfissaoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public ProfissaoListaTransfer Consultar(ProfissaoListaTransfer profissaoListaTransfer)
        {
            IQueryable<ProfissaoEntity> query = _contexto.Set<ProfissaoEntity>();
            ProfissaoListaTransfer profissaoLista = new ProfissaoListaTransfer(profissaoListaTransfer);
            IList<ProfissaoEntity> lista = new List<ProfissaoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (profissaoListaTransfer.IdAte <= 0) {
                if (profissaoListaTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == profissaoListaTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (profissaoListaTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= profissaoListaTransfer.IdDe);
                    query = query.Where(et => et.Id <= profissaoListaTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(profissaoListaTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(profissaoListaTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(profissaoListaTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(profissaoListaTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(profissaoListaTransfer.Ativo)) {
                bool ativo = true;

                if (profissaoListaTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (profissaoListaTransfer.CriacaoAte == DateTime.MinValue) {
                if (profissaoListaTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == profissaoListaTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (profissaoListaTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= profissaoListaTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= profissaoListaTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (profissaoListaTransfer.AlteracaoAte == DateTime.MinValue) {
                if (profissaoListaTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == profissaoListaTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (profissaoListaTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= profissaoListaTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= profissaoListaTransfer.AlteracaoAte);
                }
            }
            
            if (profissaoListaTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (profissaoListaTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = profissaoListaTransfer.RegistrosPorPagina;
            }

            pular = (profissaoListaTransfer.PaginaAtual < 2 ? 0 : profissaoListaTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            profissaoLista.RegistrosPorPagina = registrosPorPagina;
            profissaoLista.TotalRegistros = totalRegistros;
            profissaoLista.ProfissaoLista = lista;

            return profissaoLista;
        }
    }
}
