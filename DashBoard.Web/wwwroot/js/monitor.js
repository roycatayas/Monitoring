const connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:33671/monitors")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().then(function () {
    console.log("connected");
});

connection.on("BroadcastTransaction", (transaction, validAccount, notValidAccount) => {
    //console.log(transaction);
    //console.log(validAccount);
    //var result = JSON.stringify(transaction);
    //console.log(result);

    $("#ValidAccess").html(validAccount);
    $("#NotValidAccess").html(notValidAccount);
    $("#ValidAccess2").html(validAccount);
    $("#NotValidAccess2").html(notValidAccount);

    $('#transaction-table').DataTable({
        aaData: transaction,
        responsive: true,
        ordering: false,
        pageLength: 100,
        aoColumns: [
            { mDataProp: "transactionNo" },
            { mDataProp: "userID" },
            { mDataProp: "userName" },
            { mDataProp: "rfidCardNumber" },
            { mDataProp: "controllerID" },
            { mDataProp: "doorNumber" },
            { mDataProp: "eventAlarmCode" },
            { mDataProp: "transactionType" },
            { mDataProp: "cardReaderName" },
            { mDataProp: "transactionDescription" },
            { mDataProp: "transactionDate" }
        ],
        columnDefs : [
            { targets : [9],
                render : function (data, type, row) {
                    switch(data) {
                    case 'Valid card read' : return '<span class="badge badge-pill badge-success" style="font-size: 14px">'+ data +'</span>'; break;
                    default  : return '<span class="badge badge-pill badge-danger" style="font-size: 14px">'+ data +'</span>';
                    }
                }
            }]
    });

});

connection.on("UpdateTransaction", (transactions,validAccount, notValidAccount) => {
        $('#transaction-table').DataTable().clear().draw();
        $('#transaction-table').DataTable().rows.add(transactions).draw();
        $("#ValidAccess").html(validAccount);
        $("#NotValidAccess").html(notValidAccount);
        $("#ValidAccess2").html(validAccount);
        $("#NotValidAccess2").html(notValidAccount);
        console.log(validAccount);
    });

