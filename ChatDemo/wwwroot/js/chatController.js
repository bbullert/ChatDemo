
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {

}).catch(function (error) {
    console.error(error.toString());
});

connection.on("GroupPing", function (chatId, status) {

    var indicator = $(`input#user-status[value=${chatId}]`).prev("i");
    status == 0 ? indicator.removeClass("online") : indicator.addClass("online");
    connection.invoke("GroupPingCallback", chatId, status);
});

connection.on("GroupPingCallback", function (chatId, status) {

    var indicator = $(`input#user-status[value=${chatId}]`).prev("i");
    status == 0 ? indicator.removeClass("online") : indicator.addClass("online");
});

connection.on("ReceiveMessage", function (data) {

    var chatId = $("input[name=chatId]").val();
    if (data.chatId != chatId)
        return;

    var wrapper = $("#messages-container-wrapper");
    var container = $("#messages-container");
    var isScrolledToBottom = container.height() - wrapper.height() - wrapper.scrollTop() == 0;

    $.ajax({
        url: "/Chat/GetMessages",
        type: "POST",
        data: { chatId: chatId, startIndex: 0, length: 1 }
    }).done(function (result, textStatus, jqXHR) {

        container.append(result);
        if (isScrolledToBottom) {
            wrapper.scrollTop(container.height());
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error(jqXHR, textStatus, errorThrown);
    });

});

$("#messages-container-wrapper").scrollTop($("#messages-container").height());

$("#messages-container-wrapper").bind("mousewheel DOMMouseScroll", function () {
    if ($(this).scrollTop() == 0) {
        loadMessages();
    }
});

var loadMessages = function () {
    var wrapper = $("#messages-container-wrapper");
    var container = $("#messages-container");
    var chatId = $("input[name=chatId]").val();
    var startIndex = $(".message-body").length;

    $.ajax({
        url: "/Chat/GetMessages",
        type: "POST",
        data: { chatId: chatId, startIndex: startIndex, length: 10 }
    }).done(function (result, textStatus, jqXHR) {

        var offset = 0;
        $(result).each(function (i, element) {
            container.prepend(element);
            if (element.tagName !== undefined) {
                offset += $(element).height();
            }
        });
        wrapper.scrollTop(offset);

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error(jqXHR, textStatus, errorThrown);
    });
}

var onSendMessage = function (event) {
    event.preventDefault();

    var chatId = $("input[name=chatId]").val();
    var text = $("input[name=text]").val();

    if (text.trim() != "") {
        connection.invoke("SendMessage", chatId, text);
        $("input[name=text]").val(null);
    }
}
