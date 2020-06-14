using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class ContaBancariaData : Data<ContaBancariaEntity>
    {
        public ContaBancariaData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public ContaBancariaTransfer Consultar(ContaBancariaTransfer contaBancariaTransfer)
        {
            IQueryable<ContaBancariaEntity> query = _contexto.Set<ContaBancariaEntity>();
            ContaBancariaTransfer contaBancariaLista = new ContaBancariaTransfer(contaBancariaTransfer);
            IList<ContaBancariaEntity> lista = new List<ContaBancariaEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (contaBancariaTransfer.Filtro.IdAte <= 0) {
                if (contaBancariaTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == contaBancariaTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (contaBancariaTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= contaBancariaTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= contaBancariaTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(contaBancariaTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(contaBancariaTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(contaBancariaTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(contaBancariaTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(contaBancariaTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (contaBancariaTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (contaBancariaTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (contaBancariaTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == contaBancariaTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (contaBancariaTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= contaBancariaTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= contaBancariaTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (contaBancariaTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (contaBancariaTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == contaBancariaTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (contaBancariaTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= contaBancariaTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= contaBancariaTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (contaBancariaTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (contaBancariaTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = contaBancariaTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (contaBancariaTransfer.Paginacao.PaginaAtual < 2 ? 0 : contaBancariaTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            contaBancariaLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            contaBancariaLista.Paginacao.TotalRegistros = totalRegistros;
            contaBancariaLista.Lista = lista;

            return contaBancariaLista;
        }
    }
}
