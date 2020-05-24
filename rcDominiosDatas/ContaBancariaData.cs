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
            if (contaBancariaTransfer.IdAte <= 0) {
                if (contaBancariaTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == contaBancariaTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (contaBancariaTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= contaBancariaTransfer.IdDe);
                    query = query.Where(et => et.Id <= contaBancariaTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(contaBancariaTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(contaBancariaTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(contaBancariaTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(contaBancariaTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(contaBancariaTransfer.Ativo)) {
                bool ativo = true;

                if (contaBancariaTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (contaBancariaTransfer.CriacaoAte == DateTime.MinValue) {
                if (contaBancariaTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == contaBancariaTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (contaBancariaTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= contaBancariaTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= contaBancariaTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (contaBancariaTransfer.AlteracaoAte == DateTime.MinValue) {
                if (contaBancariaTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == contaBancariaTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (contaBancariaTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= contaBancariaTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= contaBancariaTransfer.AlteracaoAte);
                }
            }
            
            if (contaBancariaTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (contaBancariaTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = contaBancariaTransfer.RegistrosPorPagina;
            }

            pular = (contaBancariaTransfer.PaginaAtual < 2 ? 0 : contaBancariaTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            contaBancariaLista.RegistrosPorPagina = registrosPorPagina;
            contaBancariaLista.TotalRegistros = totalRegistros;
            contaBancariaLista.ContaBancariaLista = lista;

            return contaBancariaLista;
        }
    }
}
