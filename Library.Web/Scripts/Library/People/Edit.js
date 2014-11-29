function PersonView() {
    var closeHandlers = new Array();

    this.create = function (url) {
        $('#person-window').kendoWindow({
            modal: true,
            content: url
        }).data('kendoWindow').center().open();
    };

    this.edit = function (url, id) {
        $('#person-window').kendoWindow({
            modal: true,
            content: url + '/' + id
        }).data('kendoWindow').center().open();
    };

    this.operations = function (url, id) {
        $('#person-operations-window').kendoWindow({
            modal: true,
            content: url + '/' + id
        }).data('kendoWindow').center().open();
    };

    this.remove = function (url, id, confirmMessage) {
        if (confirm(confirmMessage))
            $.post(url, { id: id }, reload);
    };

    this.addCloseHandler = function (handler) {
        closeHandlers.push(handler);
    };

    this.close = function () {
        $('#person-window').data('kendoWindow').close();
        onClose();
    };

    function onClose() {
        closeHandlers.forEach(function (handler) {
            handler(this);
        });
    }
}