function tipTable(amount, tip, split){
    "use strict";
    
    var tabl = $("<table>", {
        "class": "tipTable" 
    });


    if(split == ''){
        split = 1;
    }

    if(amount == '') {
        return "Fill in the provided boxes, it is not that hard!";
    }

    else if(split > 1){
    var title = $("<p>").html("$" + amount + " check with " + tip + "% tip split amongst " + split + " people");
    title.appendTo("#theNums");

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
    n = n.toFixed(2);

    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);
    
    n = (1.1 * amount) * (tip / 100) / split;
    n = n.toFixed(2);
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    n = (0.14 * amount) * (tip / 100) / split;
    n = n.toFixed(2);
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    n = ( .052 * amount) * (tip / 100) / split;
    n = n.toFixed(2);
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    trow.appendTo(tbody);
    tbody.appendTo(tabl);

    return tabl;
}

else{
var title = $("<p>").html("$" + amount + " check with " + tip + "% tip");
    title.appendTo("#theNums");

    var thead = $("<thead>\
			      <tr>\
                     <th>USD</th>\
                     <th>Euro</th>\
                     <th>Yuan</th>\
                     <th>Peso</th>\
			      </tr>\
				</thead>");
    thead.appendTo(tabl);
    var tbody = $("<tbody>")
    var tdat = $("<td>");
    var trow = $("<tr>");
    var n = null;
    n = amount * (tip / 100) / split;
    n = n.toFixed(2);
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);
    
    n = (1.1 * amount) * (tip / 100) / split;
    n = n.toFixed(2);
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    n = (0.14 * amount) * (tip / 100) / split;
    n = n.toFixed(2);
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    n = ( .052 * amount) * (tip / 100) / split;
    n = n.toFixed(2);
    tdat = $("<td>", {
        id: n
    }).html(n);
    tdat.appendTo(trow);

    trow.appendTo(tbody);
    tbody.appendTo(tabl);
    
    return tabl;
}
}

$("#gen").submit(function(event) {
    event.preventDefault();
    var amount = $("#id1").val();
    var tip = $("#id2").val();
    var split = $("#id3").val();
        $("#theNums").empty();
        $("#theNums").append(tipTable(amount, tip, split));
        $("#dataEntry").html("");
});