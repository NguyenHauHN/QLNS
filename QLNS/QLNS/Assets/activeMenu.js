$(document).ready(function () {
    console.log(1234);
    $('li.treeview').click(function () {
        alert(12);
        $.each('li.treeview', function (idx, item) {
            $(item).removeClass('active');
        })
        $(this).addClass('active');
    });
});