﻿(($: any) => {

    $("input[data-type='date']").datepicker({
        "dateFormat": "yy-mm-dd"
    });

    $(".date-picker").datepicker({
        "dateFormat": "yy-mm-dd"
    });

    $(() => {

        $(".form-search").on("change", "select", function () {
            $(this).parents("form").submit();
        });

    });


})(jQuery);
