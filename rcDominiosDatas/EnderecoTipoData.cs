using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class EnderecoTipoData : Data<EnderecoTipoEntity>
    {
        public EnderecoTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public EnderecoTipoTransfer Consultar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            IQueryable<EnderecoTipoEntity> query = _contexto.Set<EnderecoTipoEntity>();
            EnderecoTipoTransfer enderecoTipoLista = new EnderecoTipoTransfer(enderecoTipoTransfer);
            IList<EnderecoTipoEntity> lista = new List<EnderecoTipoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (enderecoTipoTransfer.Filtro.IdAte <= 0) {
                if (enderecoTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == enderecoTipoTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (enderecoTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= enderecoTipoTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= enderecoTipoTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(enderecoTipoTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(enderecoTipoTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(enderecoTipoTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(enderecoTipoTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(enderecoTipoTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (enderecoTipoTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (enderecoTipoTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (enderecoTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == enderecoTipoTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (enderecoTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= enderecoTipoTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= enderecoTipoTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (enderecoTipoTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (enderecoTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == enderecoTipoTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (enderecoTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= enderecoTipoTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= enderecoTipoTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (enderecoTipoTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (enderecoTipoTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = enderecoTipoTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (enderecoTipoTransfer.Paginacao.PaginaAtual < 2 ? 0 : enderecoTipoTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            enderecoTipoLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            enderecoTipoLista.Paginacao.TotalRegistros = totalRegistros;
            enderecoTipoLista.Lista = lista;

            return enderecoTipoLista;
        }
    }
}
