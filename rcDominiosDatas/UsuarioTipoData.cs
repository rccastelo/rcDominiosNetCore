using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class UsuarioTipoData : Data<UsuarioTipoEntity>
    {
        public UsuarioTipoData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<UsuarioTipoEntity> Consultar(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            IQueryable<UsuarioTipoEntity> query = _contexto.Set<UsuarioTipoEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (usuarioTipoDataTransfer.IdAte <= 0) {
                if (usuarioTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == usuarioTipoDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (usuarioTipoDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= usuarioTipoDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= usuarioTipoDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(usuarioTipoDataTransfer.UsuarioTipo.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(usuarioTipoDataTransfer.UsuarioTipo.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(usuarioTipoDataTransfer.UsuarioTipo.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(usuarioTipoDataTransfer.UsuarioTipo.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(usuarioTipoDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (usuarioTipoDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (usuarioTipoDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (usuarioTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == usuarioTipoDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (usuarioTipoDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= usuarioTipoDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= usuarioTipoDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (usuarioTipoDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (usuarioTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == usuarioTipoDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (usuarioTipoDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= usuarioTipoDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= usuarioTipoDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
