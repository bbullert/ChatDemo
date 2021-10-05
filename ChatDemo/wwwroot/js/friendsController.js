
var onFriendAction = function (event) {
    event.preventDefault();

    var form = $(event.target);
    var submitter = $(event.submitter);
    var actionName = submitter.attr("formaction") ?? form.attr("action");
    var method = form.attr("method");
    var data = form.serializeArray();

    $.ajax({
        url: actionName,
        type: method,
        data: data
    }).done(function (result, textStatus, jqXHR) {

        if (actionName == "/Friends/Search") {
            $("#user-search-results").html(result);
        }
        else {
            var content = submitter.closest("#user-single-result");
            content.empty();

            if (actionName == "/Friends/SendFriendRequest") {
                content.append(`<label class="col col-form-label">You've sent a friend request</label>`);
            }
            else if (actionName == "/Friends/AcceptFriendRequest") {
                content.append(`<label class="col col-form-label">You are friends</label>`);
            }
            else if (actionName == "/Friends/DeclineFriendRequest") {
                content.append(`<button asp-action="SendFriendRequest"
                                type="submit"
                                class="btn btn-primary">Add friend</button>`);
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error(jqXHR, textStatus, errorThrown);
    });
}