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
            if (usuarioTipoTransfer.IdAte <= 0) {
                if (usuarioTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == usuarioTipoTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (usuarioTipoTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= usuarioTipoTransfer.IdDe);
                    query = query.Where(et => et.Id <= usuarioTipoTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(usuarioTipoTransfer.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(usuarioTipoTransfer.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(usuarioTipoTransfer.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(usuarioTipoTransfer.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(usuarioTipoTransfer.Ativo)) {
                bool ativo = true;

                if (usuarioTipoTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (usuarioTipoTransfer.CriacaoAte == DateTime.MinValue) {
                if (usuarioTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == usuarioTipoTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (usuarioTipoTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= usuarioTipoTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= usuarioTipoTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (usuarioTipoTransfer.AlteracaoAte == DateTime.MinValue) {
                if (usuarioTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == usuarioTipoTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (usuarioTipoTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= usuarioTipoTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= usuarioTipoTransfer.AlteracaoAte);
                }
            }
            
            if (usuarioTipoTransfer.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (usuarioTipoTransfer.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = usuarioTipoTransfer.RegistrosPorPagina;
            }

            pular = (usuarioTipoTransfer.PaginaAtual < 2 ? 0 : usuarioTipoTransfer.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            usuarioTipoLista.RegistrosPorPagina = registrosPorPagina;
            usuarioTipoLista.TotalRegistros = totalRegistros;
            usuarioTipoLista.UsuarioTipoLista = lista;

            return usuarioTipoLista;
        }
    }
}
