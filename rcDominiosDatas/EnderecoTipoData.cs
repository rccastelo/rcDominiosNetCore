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
            if (enderecoTipoTransfer.IdAte <= 0) {
                if (enderecoTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == enderecoTipoTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (enderecoTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= enderecoTipoTransfer.IdDe);
                    query = query.Where(et => et.Id <= enderecoTipoTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(enderecoTipoTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(enderecoTipoTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(enderecoTipoTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(enderecoTipoTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(enderecoTipoTransfer.Ativo)) {
                bool ativo = true;

                if (enderecoTipoTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (enderecoTipoTransfer.CriacaoAte == DateTime.MinValue) {
                if (enderecoTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == enderecoTipoTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (enderecoTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= enderecoTipoTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= enderecoTipoTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (enderecoTipoTransfer.AlteracaoAte == DateTime.MinValue) {
                if (enderecoTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == enderecoTipoTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (enderecoTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= enderecoTipoTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= enderecoTipoTransfer.AlteracaoAte);
                }
            }
            
            if (enderecoTipoTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (enderecoTipoTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = enderecoTipoTransfer.RegistrosPorPagina;
            }

            pular = (enderecoTipoTransfer.PaginaAtual < 2 ? 0 : enderecoTipoTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            enderecoTipoLista.RegistrosPorPagina = registrosPorPagina;
            enderecoTipoLista.TotalRegistros = totalRegistros;
            enderecoTipoLista.EnderecoTipoLista = lista;

            return enderecoTipoLista;
        }
    }
}
