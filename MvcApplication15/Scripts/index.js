$(function () {
    $("#addGame").on('click', function () {
        $(".addGameModal").modal();
    });

    $("#submit").on('click', function () {
        $.post("/home/addgame", {
            developer: $("#developer").val(),
            title: $("#title").val(),
            year: $("#year").val()
        }, function (game) {
            window.location.reload();
        });
    });

    function updateGame(row, cb) {
        var game = {
            id: row.find(".editButton").data('gameid'),
            developer: row.find('input.developer').val(),
            title: row.find('input.title').val(),
            year: row.find('input.year').val()
        }
        $.post("/home/update", game, cb);
    }

    $(".editButton").on('click', function () {
        var isEditMode = $(this).data('editMode');
        var row = $(this).closest('tr');
        var button = $(this);
        if (isEditMode) {
            updateGame(row, function() {
                row.find("span.edit").show();
                row.find("input.edit").hide();
                console.log(this);
                button.data('editMode', false);
                button.text("Edit");
                button.removeClass('btn-primary');
                button.addClass('btn-warning');

                row.find("span.developer").text(row.find("input.developer").val());
                row.find("span.title").text(row.find("input.title").val());
                row.find("span.year").text(row.find("input.year").val());

            });
        } else {
            row.find("span.edit").hide();
            row.find("input.edit").show();

            $(this).data('editMode', true);
            $(this).text("Save");
            $(this).removeClass('btn-warning');
            $(this).addClass('btn-primary');
        }
    });

    $(".deleteButton").on('click', function() {
        var gameId = $(this).data('gameid');
        $.post("/home/delete", { gameId: gameId }, function() {
            window.location.reload();
        });
    });
});