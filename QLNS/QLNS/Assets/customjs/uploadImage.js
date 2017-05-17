var image = {
    init: function () {
        image.registerEvents();
    },
    registerEvents: function () {
        $("#imageUpload").change(function () {
            if ($(this).val().length > 0) {

                var fileName = "";
                var data = new FormData();
                var files = $("#imageUpload").get(0).files;

                if (files.length > 0) { data.append("HelpSectionImages", files[0]); }
                $.ajax({
                    url: "/Admin/UploadImage/",
                    type: "POST",
                    processData: false,
                    data: data,
                    dataType: "json",
                    contentType: false,
                    success: function (srcImage) {
                        fileName = srcImage.name;
                        $(".avatar").attr("src", fileName);
                        $("#passSrcImage").val(fileName);
                    },
                    error: function () {
                        alert('error');
                    }
                });

            }
        });
    }
}
image.init();