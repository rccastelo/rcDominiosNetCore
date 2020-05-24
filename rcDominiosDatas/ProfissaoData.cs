using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class ProfissaoData : Data<ProfissaoEntity>
    {
        public ProfissaoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public ProfissaoTransfer Consultar(ProfissaoTransfer profissaoTransfer)
        {
            IQueryable<ProfissaoEntity> query = _contexto.Set<ProfissaoEntity>();
            ProfissaoTransfer profissaoLista = new ProfissaoTransfer(profissaoTransfer);
            IList<ProfissaoEntity> lista = new List<ProfissaoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (profissaoTransfer.IdAte <= 0) {
                if (profissaoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == profissaoTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (profissaoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= profissaoTransfer.IdDe);
                    query = query.Where(et => et.Id <= profissaoTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(profissaoTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(profissaoTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(profissaoTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(profissaoTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(profissaoTransfer.Ativo)) {
                bool ativo = true;

                if (profissaoTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (profissaoTransfer.CriacaoAte == DateTime.MinValue) {
                if (profissaoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == profissaoTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (profissaoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= profissaoTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= profissaoTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (profissaoTransfer.AlteracaoAte == DateTime.MinValue) {
                if (profissaoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == profissaoTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (profissaoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= profissaoTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= profissaoTransfer.AlteracaoAte);
                }
            }
            
            if (profissaoTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (profissaoTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = profissaoTransfer.RegistrosPorPagina;
            }

            pular = (profissaoTransfer.PaginaAtual < 2 ? 0 : profissaoTransfer.PaginaAtual - 1);
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
