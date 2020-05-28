using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class AutenticaData : Data<UsuarioEntity>
    {
        public AutenticaData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public AutenticaTransfer Autenticar(AutenticaTransfer autenticaTransfer)
        {
            IQueryable<UsuarioEntity> query = _contexto.Set<UsuarioEntity>();
            AutenticaTransfer autentica = new AutenticaTransfer(autenticaTransfer);
            UsuarioEntity usuario = new UsuarioEntity();

            //-- Apelido
            query = query.Where(et => et.Apelido.Equals(autenticaTransfer.Apelido));
            //-- Senha
            query = query.Where(et => et.Senha.Equals(autenticaTransfer.Senha));
            
            usuario = query.SingleOrDefault();

            if ((usuario != null) 
                    && (!string.IsNullOrEmpty(usuario.Apelido))
                    && (!string.IsNullOrEmpty(usuario.Senha))) {
                autentica.Autenticado = true;
            } else {
                autentica.Autenticado = false;
            }
            autentica.Senha = null;

            return autentica;
        }
    }
}
