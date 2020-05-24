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
            if (generoSocialTransfer.IdAte <= 0) {
                if (generoSocialTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == generoSocialTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (generoSocialTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= generoSocialTransfer.IdDe);
                    query = query.Where(et => et.Id <= generoSocialTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(generoSocialTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(generoSocialTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(generoSocialTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(generoSocialTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(generoSocialTransfer.Ativo)) {
                bool ativo = true;

                if (generoSocialTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (generoSocialTransfer.CriacaoAte == DateTime.MinValue) {
                if (generoSocialTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == generoSocialTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (generoSocialTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= generoSocialTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= generoSocialTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (generoSocialTransfer.AlteracaoAte == DateTime.MinValue) {
                if (generoSocialTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == generoSocialTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (generoSocialTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= generoSocialTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= generoSocialTransfer.AlteracaoAte);
                }
            }
            
            if (generoSocialTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (generoSocialTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = generoSocialTransfer.RegistrosPorPagina;
            }

            pular = (generoSocialTransfer.PaginaAtual < 2 ? 0 : generoSocialTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            generoSocialLista.RegistrosPorPagina = registrosPorPagina;
            generoSocialLista.TotalRegistros = totalRegistros;
            generoSocialLista.GeneroSocialLista = lista;

            return generoSocialLista;
        }
    }
}
