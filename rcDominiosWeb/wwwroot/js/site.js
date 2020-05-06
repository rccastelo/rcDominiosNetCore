function VerMensagens() {
    $('#modalMessages').modal('show');
}

function VerCharDescricao() {
    $('#modalMessages').modal('show');
}

$(function(){
    $('[data-toggle="popover"]').popover(
        {
            html : true,
            content: function() {
                var objContent = $(this).attr("data-object-content");
                return $(objContent).html();
            }
        }
    );
});
