$(function () {
    var productList = function () {
        var dataSource, productListApiEndPoint, productListTable, productListBrandId, productListSearchingKey;

        var initDom = function () {
            productListApiEndPoint = "/ProductList/Home/ProductListDataModelAsString";
            productListTable = $("#product-list-table");
            productListBrandId = $("#ProductBrandId");
            productListSearchingKey = $("#SearchingKey");
            dataSource = [];
        };

        var productListTableRender = function () {
            initDom();
            initDataTables();
        };

        var initDataTables = function () {
            if (productListBrandId.val()) {
                onAjaxGetData(productListBrandId.val(), productListSearchingKey.val());
            } else {
                for (var i = 1; i <= 5; i++) {
                    onAjaxGetData(i, productListSearchingKey.val());
                }
            }
        };

        var onAjaxGetData = function (brandId, searchingKey) {
            $.get(productListApiEndPoint, {
                    productBrandId: brandId,
                    searchingKey: searchingKey
                },
                function (data, status, xhr) {
                    onSetDataSource(JSON.parse(data));
                });
        };

        var onSetDataSource = function (data) {
            var prevDataSource = dataSource;
            dataSource = $.merge(prevDataSource, data);
            onSetDataTables(dataSource);
        };

        var onSetDataTables = function (data) {   
            productListTable.DataTable({
                destroy: true,
                processing: false,
                serverSide: false,
                data: dataSource,
                columns: [{
                        data: "Images",
                        render: onRenderImage
                    },
                    {
                        data: "PartNumber"
                    },
                    {
                        data: "Brand"
                    },
                    {
                        data: "Stock"
                    },
                    {
                        data: "Price",
                        render: onRenderPrice
                    },
                    {
                        data: "Button",
                        render: onRenderButton
                    }
                ],
                stateSave: true
            });
            onRemoveProductListFilter();
            additionalCssDataTables();
        };

        var onRemoveProductListFilter = function () {
            $("#product-list-table_filter").remove();
        };

        var onDataFilter = function (data) {
            return data;
        };

        var onRenderImage = function (data, type, row) {
            return '<img src="' + data + '" height="70" width="70" />';
        };

        var onRenderPrice = function (data, type, row) {
            return data;
        };

        var onRenderButton = function (data, type, row) {
            return data;
        };

        var additionalCssDataTables = function () {
             $("#product-list-table_wrapper").find(".col-sm-6").addClass("pull-right");
             $(".input-sm").css("margin-top", "13px");
             $(".paging_simple_numbers").addClass("pull-right");
        };

        return {
            run: productListTableRender
        };
    }();
    productList.run();
});