
$(document).ready(function () {
    var source = '/api/user';

    $.ajax({
        type: 'get',
        url: source,
        datatype: 'json',
        success: test,
        error: errorOnAjax
    });

    var RepoSource = '/api/repositories';
    $.ajax({
        type: 'GET',
        url: RepoSource,
        dataType: 'json',
        success: RepoTest,
        error: errorOnAjax
    });

});


function commits(data, owner) {
    var source = '/api/commits';
    $.ajax({
        type: 'GET',
        url: '/api/commits?user=' + owner + '&repo=' + data,
        dataType: 'json',
        success: showCommits,
        error: errorOnAjax
    });
}

function showCommits(data) {
    console.log(data);
    $('#commits').empty();
    $('#commits').append(`
    <table style="border: 1px solid black">
            <tr>
                <td style="width: 250px; display: table-cell; border:1px solid black">commit message</td>
                <td style="width: 250px; display: table-cell; border:1px solid black">owner name</td>
                <td style="width: 250px; display: table-cell; border:1px solid black">date</td>
            </tr>
        <table>
`);
    for (var i = 0; i < data.counter; i++) {
        $('#commits').append(`
        <table style="border: 1px solid black">
            <tr>
                <td style="width: 250px; display: table-cell; background-color:lightblue; border:1px solid black">${data.message[i]}</td>
                <td style="width: 250px; display: table-cell; background-color:lightblue; border:1px solid black">${data.name[i]}</td>
                <td style="width: 250px; display: table-cell; background-color:lightblue; border:1px solid black">${data.date[i]}</td>
            </tr>
        <table>
`);
    }
}

function errorOnAjax() {
    console.log('Error on AJAX return');
}

function test(data) {
    
    $('#profile').html(`
        <div class="panel panel-default" style="background-color:lightblue; height: 170px">
            <img class="thumbnail avatar" src="${data.avatar}" width="150" height="170" align="left">
            <div class="panel-body" style="Display:inlineblock">
                <ul> ${data.name}</ul>
                <ul> ${data.company}</ul>
                <ul> ${data.location}</ul>
                <ul> ${data.email}</ul>
            </div>
        </div>
        <div> 
        `);

}

function RepoTest(data) {
    for (var i = 0; i < data.counter; i += 2) {
        if (data.updated[i + 1] == null) {
            $('#repos').append(`
    <div style="display:table; width:50%">
        <div style="display: table-row">         
            <div style="width: 600px; display: table-cell; background-color:lightblue; border:1px solid black">
                <ul>${data.name[i]}</ul> 
                <ul>${data.owner[i]}</ul>
                <ul>Last updated: ${data.updated[i]}</ul>
                <img class="thumbnail avatart" src="${data.avatar[i]}" width="50" height="70" align="right">
                <input id="${data.name[i]}" name="${data.owner[i]}" type="button" value="Get Commits" onclick="commits(this.id, this.name)"/>
            </div>
`);
        }
        else {
            $('#repos').append(`
    <div style="display:table; width:100%">
        <div style="display: table-row">         
            <div style="width: 600px; display: table-cell; background-color:lightblue; border:1px solid black">
                <ul>${data.name[i]}</ul> 
                <ul>${data.owner[i]}</ul>
                <ul>Last updated: ${data.updated[i]}</ul>
                <img class="thumbnail avatart" src="${data.avatar[i]}" width="50" height="70" align="right">
                <input id="${data.name[i]}" name="${data.owner[i]}" type="button" value="Get Commits" onclick="commits(this.id, this.name)"/>
            </div>
            <div style="width: 600px; display: table-cell; background-color:lightblue; border:1px solid black">
                <ul>${data.name[i + 1]}</ul> 
                <ul>${data.owner[i + 1]}</ul>
                <ul>Last updated: ${data.updated[i + 1]}</ul>
                <img class="thumbnail avatart" src="${data.avatar[i + 1]}" width="50" height="70" align="right">
                <input id="${data.name[i + 1]}" name="${data.owner[i + 1]}" type="button" value="Get commits" onclick="commits(this.id, this.name)" />
            </div>
        </div>
    </div>
    `);
        }
    }
}