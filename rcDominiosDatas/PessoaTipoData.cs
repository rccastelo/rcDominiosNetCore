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
            if (pessoaTipoTransfer.IdAte <= 0) {
                if (pessoaTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == pessoaTipoTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (pessoaTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= pessoaTipoTransfer.IdDe);
                    query = query.Where(et => et.Id <= pessoaTipoTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(pessoaTipoTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(pessoaTipoTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(pessoaTipoTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(pessoaTipoTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(pessoaTipoTransfer.Ativo)) {
                bool ativo = true;

                if (pessoaTipoTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (pessoaTipoTransfer.CriacaoAte == DateTime.MinValue) {
                if (pessoaTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == pessoaTipoTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (pessoaTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= pessoaTipoTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= pessoaTipoTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (pessoaTipoTransfer.AlteracaoAte == DateTime.MinValue) {
                if (pessoaTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == pessoaTipoTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (pessoaTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= pessoaTipoTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= pessoaTipoTransfer.AlteracaoAte);
                }
            }
            
            if (pessoaTipoTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (pessoaTipoTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = pessoaTipoTransfer.RegistrosPorPagina;
            }

            pular = (pessoaTipoTransfer.PaginaAtual < 2 ? 0 : pessoaTipoTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            pessoaTipoLista.RegistrosPorPagina = registrosPorPagina;
            pessoaTipoLista.TotalRegistros = totalRegistros;
            pessoaTipoLista.PessoaTipoLista = lista;

            return pessoaTipoLista;
        }
    }
}
