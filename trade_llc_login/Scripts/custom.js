
// VARIABLES
var url = window.location.href;


// MAIN RUNNING CODE WILL GO HERE
setBreadcrumbs(url);

/////////////////////////////////


function setBreadcrumbs(location) {

    // get words from the url and remove localhost (the first word)
    var breadcrummies = location.match(/\/\w+/g);
    breadcrummies.shift();

    //get the base href (e.g. https://localhost:#####/);
    var href = location.match(/.+\d+/g)[0];

    // if there are no words, we are on the home page
    if (breadcrummies.length == 0) {
        $('#main-breadcrumb').html('<li>Home</a></li>')
    }
    //if there are words, used them to populate breadcrumbs
    else {

        //get rid of backslash (e.g. "/Home" becomes "Home")
        breadcrummies = breadcrummies.map(t => t.replace('/', ''));

        // loop through text and turn it into html string
        var crumb_html = breadcrummies
            .map(function (crumb, index, array) {
                // if we are on the last element of the breadcrumbs array, make it the active <li>
                href += "/" + crumb;
                return '<li><a href="' + href + '">' + crumb + '</a></li>';
            })
            .join('');

        // use jquery to populate html on screen
        $('#main-breadcrumb').html(crumb_html);
    }
}
//To clear the Contact form (temporary fix for Project #1)
function clearContact() {
    $("#inputName").text("")
    $("#inputPhone").text("")
    $("#inputEmail").text("")
    $("#inputSubject").value = ""
    $("#inputMessage").text("")
}

$("#inputMessage").on("keyup", function () {
    var iCount = $("#inputMessage").val().length
    $("#characterCount").text("Characters Remaining: " + ($("#inputMessage").attr("maxlength") - iCount))
})

var count = 1;

function SubmitStatus() {

    var sStatus = $("#comment").val();
    $("#comment").val("");
    $("#allComments").append("<div style='padding: 10px; background-color:grey; border: solid black 1px;' id='realComment" + count + "'>" + sStatus + '</div>'
        + '<a id= "hideReply' + count + '" onclick= "replyComment(' + count + ')" > Reply</a>'
        + '<br><span id="replyLabel' + count + '" style="display:none;"><b>Reply: </b></span><textarea style= "display:none" class="form-control" rows= "1" cols= "500" id= "replyComment' + count + '" ></textarea >'
        + '<br><a style= "display:none; width: 200px" id= "submitReply' + count + '" class="btn btn-primary btn-large" onclick= "SubmitReply(' + count + ')" > Submit Reply</a > ');
    count++;
}

function replyComment(num) {

    $('#replyLabel' + num).css('display', "block");
    $('#replyComment' + num).css('display', "block");
    $('#submitReply' + num).css('display', "block");
    $('#hideReply' + num).css('display', "none");
}

function SubmitReply(num) {
    $('#replyLabel' + num).css('display', "none");
    $('#replyComment' + num).css('display', "none");
    $('#submitReply' + num).css('display', "none");
    var sStatus = $("#replyComment" + num).val();
    $("#realComment" + num).append("<div style='padding-left: 30px;'><b>Reply: </b>" + sStatus + "</div>");
}


