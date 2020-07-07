function VerMensagens() {
    $('#modalMessages').modal('show');
}

function VerCaracs() {
    $('#modalCaracs').modal('show');
}

$('[data-toggle="popover"]').popover(
    {
        html : true,
        content: function() {
            var objContent = $(this).attr("data-object-content");
            return $(objContent).html();
        }
    }
);

$('#Filtro_CriacaoDe').click(function() { $(this).val(""); });
$('#Filtro_CriacaoAte').click(function() { $(this).val(""); });
$('#Filtro_AlteracaoDe').click(function() { $(this).val(""); });
$('#Filtro_AlteracaoAte').click(function() { $(this).val(""); });

var cfgCalendar = {
    dateFormat: "dd/mm/yy",
    dayNames: ['Domingo','Segunda','Terça','Quarta','Quinta','Sexta','Sábado','Domingo'],
    dayNamesMin: ['D','S','T','Q','Q','S','S','D'],
    dayNamesShort: ['Dom','Seg','Ter','Qua','Qui','Sex','Sáb','Dom'],
    monthNames: ['Janeiro','Fevereiro','Março','Abril','Maio','Junho','Julho','Agosto','Setembro','Outubro','Novembro','Dezembro'],
    monthNamesShort: ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set','Out','Nov','Dez']
};

$('#Filtro_CriacaoDe').datepicker(cfgCalendar);
$('#Filtro_CriacaoAte').datepicker(cfgCalendar);
$('#Filtro_AlteracaoDe').datepicker(cfgCalendar);
$('#Filtro_AlteracaoAte').datepicker(cfgCalendar);

function paginar(pagina) {
    var form = document.getElementById("form");
    var paginaAtual = document.getElementById("Paginacao_PaginaAtual");

    paginaAtual.value = pagina;
    
    form.submit();
}
