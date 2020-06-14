using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class PessoaTipoData : Data<PessoaTipoEntity>
    {
        public PessoaTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public PessoaTipoTransfer Consultar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            IQueryable<PessoaTipoEntity> query = _contexto.Set<PessoaTipoEntity>();
            PessoaTipoTransfer pessoaTipoLista = new PessoaTipoTransfer(pessoaTipoTransfer);
            IList<PessoaTipoEntity> lista = new List<PessoaTipoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (pessoaTipoTransfer.Filtro.IdAte <= 0) {
                if (pessoaTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == pessoaTipoTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (pessoaTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= pessoaTipoTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= pessoaTipoTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(pessoaTipoTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(pessoaTipoTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(pessoaTipoTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(pessoaTipoTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(pessoaTipoTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (pessoaTipoTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (pessoaTipoTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (pessoaTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == pessoaTipoTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (pessoaTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= pessoaTipoTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= pessoaTipoTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (pessoaTipoTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (pessoaTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == pessoaTipoTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (pessoaTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= pessoaTipoTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= pessoaTipoTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (pessoaTipoTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (pessoaTipoTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = pessoaTipoTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (pessoaTipoTransfer.Paginacao.PaginaAtual < 2 ? 0 : pessoaTipoTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            pessoaTipoLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            pessoaTipoLista.Paginacao.TotalRegistros = totalRegistros;
            pessoaTipoLista.Lista = lista;

            return pessoaTipoLista;
        }
    }
}
