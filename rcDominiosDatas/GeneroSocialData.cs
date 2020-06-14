using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class GeneroSocialData : Data<GeneroSocialEntity>
    {
        public GeneroSocialData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public GeneroSocialTransfer Consultar(GeneroSocialTransfer generoSocialTransfer)
        {
            IQueryable<GeneroSocialEntity> query = _contexto.Set<GeneroSocialEntity>();
            GeneroSocialTransfer generoSocialLista = new GeneroSocialTransfer(generoSocialTransfer);
            IList<GeneroSocialEntity> lista = new List<GeneroSocialEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (generoSocialTransfer.Filtro.IdAte <= 0) {
                if (generoSocialTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == generoSocialTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (generoSocialTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= generoSocialTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= generoSocialTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(generoSocialTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(generoSocialTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(generoSocialTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(generoSocialTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(generoSocialTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (generoSocialTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (generoSocialTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (generoSocialTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == generoSocialTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (generoSocialTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= generoSocialTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= generoSocialTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (generoSocialTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (generoSocialTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == generoSocialTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (generoSocialTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= generoSocialTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= generoSocialTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (generoSocialTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (generoSocialTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = generoSocialTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (generoSocialTransfer.Paginacao.PaginaAtual < 2 ? 0 : generoSocialTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            generoSocialLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            generoSocialLista.Paginacao.TotalRegistros = totalRegistros;
            generoSocialLista.Lista = lista;

            return generoSocialLista;
        }
    }
}
