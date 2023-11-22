$(document).ready(function () {
    ActiveTable();
    //AchievedTable();
    //CanceledTable();
});

function ActiveTable() {
    $('#Active').DataTable({
        processing: true,
        serverSide: true,
        filter: true,
        ajax: {
            url: "/Duty/PartialList",
            type: "POST",
            datatype: "json"
        },
        columnDefs: [{
            targets: [0],
            visible: false,
            searchable: false
        }],
        columns: [
            { data: "title", "autoWidth": true },
            { data: "deadline", "autoWidth": true },
            {
                render: function (data, row) {
                    return `<a href='#' class='btn btn-success' onclick='details('${row.key}')'><i class="material-icons">visibility</i></a>
                            <a href='#' class='btn btn-info' onclick='edit('${row.key}')'><i class="material-icons">edit</i></a>
                            <a href='#' class='btn btn-danger' onclick='delete('${row.key}')'><i class="material-icons">cancel</i></a>`;
                }
            },
        ]
    });
}

function AchievedTable() {
    $('#Done').DataTable({
    });
}

function CanceledTable() {
    $('#Canceled').DataTable({
    });
}

function selectTab(element) {
    if (element === 'active') {
        $(`#active`).addClass('active');
        $(`#done`).removeClass('active');
        $(`#Done`).hide();
        $(`#canceled`).removeClass('active');
        $(`#Canceled`).hide();
        $(`#Active`).show();
    }
    else if (element === 'done') {
        $(`#done`).addClass('active');
        $(`#active`).removeClass('active');
        $(`#Active`).hide();
        $(`#canceled`).removeClass('active');
        $(`#Canceled`).hide();
        $(`#Done`).show();
    }
    else if (element === 'canceled') {
        $(`#canceled`).addClass('active');
        $(`#active`).removeClass('active');
        $(`#Active`).hide();
        $(`#done`).removeClass('active');
        $(`#Done`).hide();
        $(`#Canceled`).show();
    }
}