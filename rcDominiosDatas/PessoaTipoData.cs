using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class PessoaTipoData : Data<PessoaTipoEntity>
    {
        public PessoaTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public PessoaTipoListaTransfer Consultar(PessoaTipoListaTransfer pessoaTipoListaTransfer)
        {
            IQueryable<PessoaTipoEntity> query = _contexto.Set<PessoaTipoEntity>();
            PessoaTipoListaTransfer pessoaTipoLista = new PessoaTipoListaTransfer(pessoaTipoListaTransfer);
            IList<PessoaTipoEntity> lista = new List<PessoaTipoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (pessoaTipoListaTransfer.IdAte <= 0) {
                if (pessoaTipoListaTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == pessoaTipoListaTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (pessoaTipoListaTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= pessoaTipoListaTransfer.IdDe);
                    query = query.Where(et => et.Id <= pessoaTipoListaTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(pessoaTipoListaTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(pessoaTipoListaTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(pessoaTipoListaTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(pessoaTipoListaTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(pessoaTipoListaTransfer.Ativo)) {
                bool ativo = true;

                if (pessoaTipoListaTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (pessoaTipoListaTransfer.CriacaoAte == DateTime.MinValue) {
                if (pessoaTipoListaTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == pessoaTipoListaTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (pessoaTipoListaTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= pessoaTipoListaTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= pessoaTipoListaTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (pessoaTipoListaTransfer.AlteracaoAte == DateTime.MinValue) {
                if (pessoaTipoListaTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == pessoaTipoListaTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (pessoaTipoListaTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= pessoaTipoListaTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= pessoaTipoListaTransfer.AlteracaoAte);
                }
            }
            
            if (pessoaTipoListaTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (pessoaTipoListaTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = pessoaTipoListaTransfer.RegistrosPorPagina;
            }

            pular = (pessoaTipoListaTransfer.PaginaAtual < 2 ? 0 : pessoaTipoListaTransfer.PaginaAtual - 1);
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
