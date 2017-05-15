var urlCurrent = window.location.href;

$("li.treeview a").each(function () {
    if (urlCurrent.includes($(this).attr('href'))) {
        console.log('yes');
        $(this).parent().addClass('active');
    }
    else {
        $(this).parent().removeClass('active');
    }
});