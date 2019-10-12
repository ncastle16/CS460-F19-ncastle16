const dollarType = ["USD", "Euro", "Yuan", "Peso"];

function tipTable(amount, tip, split){
    "use strict";
    
    var tabl = $("<table>", {
        "class": "tipTable" 
    });

    var tcaption = $("<caption>").html("$" + amount);
    tcaption.appendTo(tabl);

    var thead = $("<thead>\
			      <tr>\
                     <th>USD</th>\
                     <th>Euro</th>\
                     <th>Yuan</th>\
                     <th>Peso</th>\
			      </tr>\
				</thead>");
    thead.appendTo(tabl);

    var tbody = $("<tbody>");
    var tdat = $("<td>");
    var trow = $("<tr>");
    var n = null;
    n = amount * (tip / 100) / split;
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);
    
    n = (1.1 * amount) * (tip / 100) / split;
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    n = (0.14 * amount) * (tip / 100) / split;
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    n = ( .052 * amount) * (tip / 100) / split;
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    trow.appendTo(tabl);
    
    return tabl;
}

$("#gen").submit(function (event) {
    event.preventDefault();
    var amount = $("#id1").val();
    var tip = $("#id2").val();
    var split = $("#id3").val();
    console.log(amount, tip, split);
        $("#theNums").empty();
        $("#theNums").append(tipTable(amount, tip, split));
        $("#dataEntry").html("");
});