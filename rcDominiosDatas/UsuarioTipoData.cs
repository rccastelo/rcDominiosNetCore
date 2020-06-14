using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class UsuarioTipoData : Data<UsuarioTipoEntity>
    {
        public UsuarioTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public UsuarioTipoTransfer Consultar(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            IQueryable<UsuarioTipoEntity> query = _contexto.Set<UsuarioTipoEntity>();
            UsuarioTipoTransfer usuarioTipoLista = new UsuarioTipoTransfer(usuarioTipoTransfer);
            IList<UsuarioTipoEntity> lista = new List<UsuarioTipoEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (usuarioTipoTransfer.Filtro.IdAte <= 0) {
                if (usuarioTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id == usuarioTipoTransfer.Filtro.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (usuarioTipoTransfer.Filtro.IdDe > 0) {
                    query = query.Where(et => et.Id >= usuarioTipoTransfer.Filtro.IdDe);
                    query = query.Where(et => et.Id <= usuarioTipoTransfer.Filtro.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(usuarioTipoTransfer.Filtro.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(usuarioTipoTransfer.Filtro.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(usuarioTipoTransfer.Filtro.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(usuarioTipoTransfer.Filtro.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(usuarioTipoTransfer.Filtro.Ativo)) {
                bool ativo = true;

                if (usuarioTipoTransfer.Filtro.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (usuarioTipoTransfer.Filtro.CriacaoAte == DateTime.MinValue) {
                if (usuarioTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == usuarioTipoTransfer.Filtro.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (usuarioTipoTransfer.Filtro.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= usuarioTipoTransfer.Filtro.CriacaoDe);
                    query = query.Where(et => et.Criacao <= usuarioTipoTransfer.Filtro.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (usuarioTipoTransfer.Filtro.AlteracaoAte == DateTime.MinValue) {
                if (usuarioTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == usuarioTipoTransfer.Filtro.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (usuarioTipoTransfer.Filtro.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= usuarioTipoTransfer.Filtro.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= usuarioTipoTransfer.Filtro.AlteracaoAte);
                }
            }
            
            if (usuarioTipoTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (usuarioTipoTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = usuarioTipoTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (usuarioTipoTransfer.Paginacao.PaginaAtual < 2 ? 0 : usuarioTipoTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            usuarioTipoLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            usuarioTipoLista.Paginacao.TotalRegistros = totalRegistros;
            usuarioTipoLista.Lista = lista;

            return usuarioTipoLista;
        }
    }
}
