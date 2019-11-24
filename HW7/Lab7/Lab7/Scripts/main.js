
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

function errorOnAjax() {
    console.log('Error on AJAX return');
}

function test(data) {
    console.log(data);
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
        $('#repos').append(`
    <div style="display:table; width:100%">
        <div style="display: table-row">         
            <div style="width: 600px; display: table-cell; background-color:lightblue; border:1px solid black">
                <ul>${data.name[i]}</ul> 
                <ul>${data.owner[i]}</ul>
                <ul>Last updated: ${data.updated[i]}</ul>
            </div>
            <div style="width: 600px; display: table-cell; background-color:lightblue; border:1px solid black">
                <ul>${data.name[i+1]}</ul> 
                <ul>${data.owner[i+1]}</ul>
                <ul>Last updated: ${data.updated[i+1]}</ul>
            </div>
        </div>
    </div>
    `)
    }
}