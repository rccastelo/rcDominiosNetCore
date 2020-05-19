using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class UsuarioData : Data<UsuarioEntity>
    {
        public UsuarioData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<UsuarioEntity> Consultar(UsuarioDataTransfer usuarioDataTransfer)
        {
            IQueryable<UsuarioEntity> query = _contexto.Set<UsuarioEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (usuarioDataTransfer.IdAte <= 0) {
                if (usuarioDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == usuarioDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (usuarioDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= usuarioDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= usuarioDataTransfer.IdAte);
                }
            }

            //-- Apelido
            if (!string.IsNullOrEmpty(usuarioDataTransfer.Usuario.Apelido)) {
                query = query.Where(et => et.Apelido.Contains(usuarioDataTransfer.Usuario.Apelido));
            }

            //-- Senha
            if (!string.IsNullOrEmpty(usuarioDataTransfer.Usuario.Senha)) {
                query = query.Where(et => et.Senha.Contains(usuarioDataTransfer.Usuario.Senha));
            }
            
            //-- Nome de apresentação
            if (!string.IsNullOrEmpty(usuarioDataTransfer.Usuario.NomeApresentacao)) {
                query = query.Where(et => et.NomeApresentacao.Contains(usuarioDataTransfer.Usuario.NomeApresentacao));
            }

            //-- Nome completo
            if (!string.IsNullOrEmpty(usuarioDataTransfer.Usuario.NomeCompleto)) {
                query = query.Where(et => et.NomeCompleto.Contains(usuarioDataTransfer.Usuario.NomeCompleto));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(usuarioDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (usuarioDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (usuarioDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (usuarioDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == usuarioDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (usuarioDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= usuarioDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= usuarioDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (usuarioDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (usuarioDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == usuarioDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (usuarioDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= usuarioDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= usuarioDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
