$(document).ready(function () {
    //$("#BrandId").change(function () {
    //    console.log($(this).val());
    //    var brandId = $(this).val();
    //    $.ajax(
    //    {
    //            url: "/Ajax/GetModels?brandId=" + brandId,
    //            type: "GET",
    //            success: function (response) {
    //                $("#ModelId").html(response);
    //                $("#ModelId").prepend("<option value=''>Bütün Modellər</option>");

    //                //$("#ModelId").html("");
    //                //$("#ModelId").html(response);
    //            }
    //    });

    //})

    $(".s-brand-select").change(function () {
        console.log($(this).val());
        var brandId = $(this).val();
        $.ajax(
        {
                url: "/Ajax/GetModels?brandId=" + brandId,
                type: "GET",
                success: function (response) {
                    $(".s-model-select").html(response);
                    $(".s-model-select").prepend("<option value=''>Bütün Modellər</option>");

                    //$(".s-model-select").html("");
                    //$(".s-model-select").html(response);
                }
        });

    })
})