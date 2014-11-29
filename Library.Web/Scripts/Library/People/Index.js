var personView = new PersonView();
personView.addCloseHandler(reload);

$(function () {
    $('#create-person').click(function () {
        personView.create($(this).data('url'));
    });

    $('#people-grid').on('click', '.edit-command', function (e) {
        e.preventDefault();
        var person = $("#people-grid").data("kendoGrid").dataItem($(this).closest("tr"));
        personView.edit($(this).data('url'), person.Id);
    });

    $('#people-grid').on('click', '.operations-command', function (e) {
        e.preventDefault();
        var person = $("#people-grid").data("kendoGrid").dataItem($(this).closest("tr"));
        personView.operations($(this).data('url'), person.Id);
    });

    $('#people-grid').on('click', '.delete-command', function (e) {
        e.preventDefault();
        var person = $("#people-grid").data("kendoGrid").dataItem($(this).closest("tr"));
        personView.remove($(this).data('url'), person.Id, $(this).data('confirm-message'));
    });
});

function successSubmitPerson(data) {
    if (data == "") {
        personView.close();
    }
}

function reload() {
    var grid = $("#people-grid").data("kendoGrid");
    grid.dataSource.page(1);
    grid.dataSource.read();
}