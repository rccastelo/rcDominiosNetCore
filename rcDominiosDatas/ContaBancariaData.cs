using System;
using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class ContaBancariaData : Data<ContaBancariaEntity>
    {
        public ContaBancariaData(DominiosDbContext contexto) 
            : base(contexto)
        {
        }

        public IList<ContaBancariaEntity> Consultar(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            IQueryable<ContaBancariaEntity> query = _contexto.Set<ContaBancariaEntity>();

            //-- Se IdAte não informado, procura Id específico
            if (contaBancariaDataTransfer.IdAte <= 0) {
                if (contaBancariaDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id == contaBancariaDataTransfer.IdDe);
                }
            } else {
                //-- Se IdDe e IdAte informados, procura faixa de Id
                if (contaBancariaDataTransfer.IdDe > 0) {
                    query = query.Where(et => et.Id >= contaBancariaDataTransfer.IdDe);
                    query = query.Where(et => et.Id <= contaBancariaDataTransfer.IdAte);
                }
            }

            //-- Descrição
            if (!string.IsNullOrEmpty(contaBancariaDataTransfer.ContaBancaria.Descricao)) {
                query = query.Where(et => et.Descricao.Contains(contaBancariaDataTransfer.ContaBancaria.Descricao));
            }

            //-- Código
            if (!string.IsNullOrEmpty(contaBancariaDataTransfer.ContaBancaria.Codigo)) {
                query = query.Where(et => et.Codigo.Contains(contaBancariaDataTransfer.ContaBancaria.Codigo));
            }
            
            //-- Ativo
            if (!string.IsNullOrEmpty(contaBancariaDataTransfer.AtivoFiltro)) {
                bool ativo = true;

                if (contaBancariaDataTransfer.AtivoFiltro == "false") {
                    ativo = false;
                }

                query = query.Where(et => et.Ativo == ativo);
            }

            //-- Se CriacaoAte não informado, procura Data de Criação específica
            if (contaBancariaDataTransfer.CriacaoAte == DateTime.MinValue) {
                if (contaBancariaDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao == contaBancariaDataTransfer.CriacaoDe);
                }
            } else {
                //-- Se CriacaoDe e CriacaoAte informados, procura faixa de Data de Criação
                if (contaBancariaDataTransfer.CriacaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Criacao >= contaBancariaDataTransfer.CriacaoDe);
                    query = query.Where(et => et.Criacao <= contaBancariaDataTransfer.CriacaoAte);
                }
            }

            //-- Se AlteracaoAte não informado, procura Data de Alteração específica
            if (contaBancariaDataTransfer.AlteracaoAte == DateTime.MinValue) {
                if (contaBancariaDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao == contaBancariaDataTransfer.AlteracaoDe);
                }
            } else {
                //-- Se AlteracaoDe e AlteracaoAte informados, procura faixa de Data de Alteração
                if (contaBancariaDataTransfer.AlteracaoDe != DateTime.MinValue) {
                    query = query.Where(et => et.Alteracao >= contaBancariaDataTransfer.AlteracaoDe);
                    query = query.Where(et => et.Alteracao <= contaBancariaDataTransfer.AlteracaoAte);
                }
            }

            return query.ToList();
        }
    }
}
