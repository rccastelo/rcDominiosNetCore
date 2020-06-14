using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;
using Microsoft.EntityFrameworkCore;

namespace rcDominiosDatas
{
    public class UsuarioData : Data<UsuarioEntity>
    {
        public UsuarioData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public override void Alterar(UsuarioEntity entidade)
        {
            _contexto.Set<UsuarioEntity>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.Entry(entidade).Property(e => e.Senha).IsModified = false;
            _contexto.SaveChanges();
        }

        public UsuarioEntity ConsultarPorApelido(string apelido)
        {
            return _contexto.Set<UsuarioEntity>().FirstOrDefault(et => et.Apelido == apelido);
        }

        public UsuarioTransfer Consultar(UsuarioTransfer usuarioTransfer)
        {
            IQueryable<UsuarioEntity> query = _contexto.Set<UsuarioEntity>();
            UsuarioTransfer usuarioLista = new UsuarioTransfer(usuarioTransfer);
            IList<UsuarioEntity> lista = new List<UsuarioEntity>();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            //-- Se IdAte não informado, procura Id específico
            if (usuarioTransfer.IdAte <= 0) {
                if (usuarioTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == usuarioTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (usuarioTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= usuarioTransfer.IdDe);
                    query = query.Where(et => et.Id <= usuarioTransfer.IdAte);
                }
            }

            //-- Apelido
            if (!string.IsNullOrEmpty(usuarioTransfer.Apelido)) {
                query = query.Where(et => et.Apelido.Contains(usuarioTransfer.Apelido));
            }

            //-- Senha
            if (!string.IsNullOrEmpty(usuarioTransfer.Senha)) {
                query = query.Where(et => et.Senha.Contains(usuarioTransfer.Senha));
            }
            
            //-- Nome de apresentação
            if (!string.IsNullOrEmpty(usuarioTransfer.NomeApresentacao)) {
                query = query.Where(et => et.NomeApresentacao.Contains(usuarioTransfer.NomeApresentacao));
            }

            //-- Nome completo
            if (!string.IsNullOrEmpty(usuarioTransfer.NomeCompleto)) {
                query = query.Where(et => et.NomeCompleto.Contains(usuarioTransfer.NomeCompleto));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(usuarioTransfer.Ativo)) {
                bool ativo = true;

                if (usuarioTransfer.Ativo == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (usuarioTransfer.CriacaoAte == DateTime.MinValue) {
                if (usuarioTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == usuarioTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (usuarioTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= usuarioTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= usuarioTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (usuarioTransfer.AlteracaoAte == DateTime.MinValue) {
                if (usuarioTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == usuarioTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (usuarioTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= usuarioTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= usuarioTransfer.AlteracaoAte);
                }
            }
            
            if (usuarioTransfer.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (usuarioTransfer.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = usuarioTransfer.Paginacao.RegistrosPorPagina;
            }

            pular = (usuarioTransfer.Paginacao.PaginaAtual < 2 ? 0 : usuarioTransfer.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;
            
            totalRegistros = query.Count();
            lista = query.Skip(pular).Take(registrosPorPagina).ToList();

            usuarioLista.Paginacao.RegistrosPorPagina = registrosPorPagina;
            usuarioLista.Paginacao.TotalRegistros = totalRegistros;
            usuarioLista.Lista = lista;

            return usuarioLista;
        }
    }
}
