
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
    if (breadcrummies.length == 0 )
    {
        $('#main-breadcrumb').html('<li class="active">Home</a></li>')
    }
    //if there are words, used them to populate breadcrumbs
    else
    {

        //get rid of backslash (e.g. "/Home" becomes "Home")
        breadcrummies = breadcrummies.map(t => t.replace('/', ''));
        
        // loop through text and turn it into html string
        var crumb_html = breadcrummies
            .map(function (crumb, index, array) {
                // if we are on the last element of the breadcrumbs array, make it the active <li>
                href += "/" + crumb;
                return index === (array.length - 1)
                    ? '<li class="active">' + crumb + '</a></li>'
                    : '<li><a href="'+href+'">' + crumb + '</a></li>';
            })
            .join('');

        // use jquery to populate html on screen
        $('#main-breadcrumb').html(crumb_html);
    }
}
