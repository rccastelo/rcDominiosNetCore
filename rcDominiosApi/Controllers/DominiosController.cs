using Microsoft.AspNetCore.Mvc;

namespace rcDominiosApi.Controllers
{
  [ApiController]
    [Route("")]
    public class DominiosController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            string info = @"{
                ""name"" : ""rcDominiosApi"",
                ""description"" : ""Gerenciar informações dos domínios"",
                ""uri"" : ""http://rcdominiosapi/"",
                ""services"" : [
                    {
                        ""name"" : ""ContaBancaria"",
                        ""description"" : ""Gerenciar informações do domínio Tipo de Conta Bancária"",
                        ""uri"" : ""http://rcdominiosapi/contabancaria/"",
                        ""methods"" : [
                            {
                                ""name"" : ""ConsultarPorId"",
                                ""description"" : ""Consultar um tipo de conta bancária específica através do id"",
                                ""uri"" : ""http://rcdominiosapi/contabancaria/{id}"",
                                ""method"" : ""GET"",
                                ""parameters"" : [
                                    {
                                        ""name"" : ""id"",
                                        ""type"" : ""integer"",
                                        ""required"" : ""yes""
                                    }
                                ],
                                ""return"" : {
                                    ""type"" : ""contabancariatransfer""
                                }
                            },
                            { 
                                ""name"" : ""Listar"",
                                ""description"" : ""Consultar a lista completa de tipos de conta bancária existentes"",
                                ""uri"" : ""http://rcdominiosapi/contabancaria/"",
                                ""method"" : ""GET"",
                                ""parameters"" : {},
                                ""return"" : {
                                    ""type"" : ""contabancariatransfer""
                                }
                            },
                            { 
                                ""name"" : ""Consultar"",
                                ""description"" : ""Consultar uma lista de tipos de conta bancária através de um filtro"",
                                ""uri"" : ""http://rcdominiosapi/contabancaria/lista"",
                                ""method"" : ""POST"",
                                ""parameters"" : [
                                    {
                                        ""type"" : ""contabancariatransfer"",
                                        ""required"" : ""yes""
                                    }
                                ],
                                ""return"" : {
                                    ""type"" : ""contabancariatransfer""
                                }
                            },
                            { 
                                ""name"" : ""Incluir"",
                                ""description"" : ""Incluir um novo tipo de conta bancária"",
                                ""uri"" : ""http://rcdominiosapi/contabancaria/"",
                                ""method"" : ""POST"",
                                ""parameters"" : [
                                    {
                                        ""type"" : ""contabancariatransfer"",
                                        ""required"" : ""yes""
                                    }
                                ],
                                ""return"" : {
                                    ""type"" : ""contabancariatransfer""
                                }
                            },
                            { 
                                ""name"" : ""Alterar"",
                                ""description"" : ""Alterar um tipo de conta bancária existente"",
                                ""uri"" : ""http://rcdominiosapi/contabancaria/"",
                                ""method"" : ""PUT"",
                                ""parameters"" : [
                                    {
                                        ""type"" : ""contabancariatransfer"",
                                        ""required"" : ""yes""
                                    }
                                ],
                                ""return"" : {
                                    ""type"" : ""contabancariatransfer""
                                }
                            },
                            { 
                                ""name"" : ""Excluir"",
                                ""description"" : ""Excluir um tipo de conta bancária existente"",
                                ""uri"" : ""http://rcdominiosapi/contabancaria/{id}"",
                                ""method"" : ""DELETE"",
                                ""parameters"" : [
                                    {
                                        ""name"" : ""id"",
                                        ""type"" : ""integer"",
                                        ""required"" : ""yes""
                                    }
                                ],
                                ""return"" : {
                                    ""type"" : ""contabancariatransfer""
                                }
                            }
                        ],
                        ""objects"" : [
                            {
                                ""type"" : ""contabancariatransfer"",
                                ""properties"" : [
                                    {
                                        ""name"" : ""ContaBancaria"",
                                        ""type"" : ""contabancaria"",
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""ContaBancariaLista"",
                                        ""type"" : ""list"",
                                        ""list"" : [
                                            ""type"" : ""contabancaria""
                                        ],
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""PaginaAtual"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""PaginaInicial"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""PaginaFinal"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""RegistrosPorPagina"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""TotalRegistros"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""TotalPaginas"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""IdDe"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""IdAte"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""Descricao"",
                                        ""type"" : ""string"",
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""Codigo"",
                                        ""type"" : ""string"",
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""Ativo"",
                                        ""type"" : ""string"",
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""CriacaoDe"",
                                        ""type"" : ""datetime"",
                                        ""default"" : ""0001-01-01T00:00:00""
                                    },
                                    {
                                        ""name"" : ""CriacaoAte"",
                                        ""type"" : ""datetime"",
                                        ""default"" : ""0001-01-01T00:00:00""
                                    },
                                    {
                                        ""name"" : ""AlteracaoDe"",
                                        ""type"" : ""datetime"",
                                        ""default"" : ""0001-01-01T00:00:00""
                                    },
                                    {
                                        ""name"" : ""AlteracaoAte"",
                                        ""type"" : ""datetime"",
                                        ""default"" : ""0001-01-01T00:00:00""
                                    },
                                    {
                                        ""name"" : ""Validacao"",
                                        ""type"" : ""boolean"",
                                        ""default"" : ""false""
                                    },
                                    {
                                        ""name"" : ""ValidacaoMensagens"",
                                        ""type"" : ""list"",
                                        ""list"" : [
                                            ""type"" : ""string""
                                        ],
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""Erro"",
                                        ""type"" : ""boolean"",
                                        ""default"" : ""false""
                                    },
                                    {
                                        ""name"" : ""ErroMensagens"",
                                        ""type"" : ""list"",
                                        ""list"" : [
                                            ""type"" : ""string""
                                        ],
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""Info"",
                                        ""type"" : ""boolean"",
                                        ""default"" : ""false""
                                    },
                                    {
                                        ""name"" : ""InfoMensagens"",
                                        ""type"" : ""list"",
                                        ""list"" : [
                                            ""type"" : ""string""
                                        ],
                                        ""default"" : ""null""
                                    }
                                ]
                            },
                            {
                                ""type"" : ""contabancaria"",
                                ""properties"" : [
                                    {
                                        ""name"" : ""Id"",
                                        ""type"" : ""integer"",
                                        ""default"" : ""0""
                                    },
                                    {
                                        ""name"" : ""Descricao"",
                                        ""type"" : ""string"",
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""Codigo"",
                                        ""type"" : ""string"",
                                        ""default"" : ""null""
                                    },
                                    {
                                        ""name"" : ""Ativo"",
                                        ""type"" : ""boolean"",
                                        ""default"" : ""false""
                                    },
                                    {
                                        ""name"" : ""Criacao"",
                                        ""type"" : ""datetime"",
                                        ""default"" : ""0001-01-01T00:00:00""
                                    },
                                    {
                                        ""name"" : ""Alteracao"",
                                        ""type"" : ""datetime"",
                                        ""default"" : ""0001-01-01T00:00:00""
                                    }
                                ]
                            }
                        ]
                    }
                ]
            }";

            return info;
        }        
    }
}
