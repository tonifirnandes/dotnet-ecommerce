$(function () {
  var searchProducts = (function () {
    var searchBrandListTempId,
      searchApiEndpoints,
      searchApiGetBrand,
      type,
      searchInput,
      searchBrandListOption,
      searchBrandListSelected,
      searchButton;

    var brandsCount;
    var dataSource = [];
    const MIN_SEARCH_QUERY_LENGTH = 3;

    var initDom = function () {
      searchApiEndpoints = "/SearchProducts/Search/Index";
      searchApiGetBrand = "/SearchProducts/Search/GetBrandCount";
      type = "GET";
      searchInput = $(".search-input");
      searchBrandListOption = $(".search-brand-list-option");
      searchBrandListSelected = $(".search-brand-list-selected");
      searchButton = $(".search-button");
    };

    var search = function () {
      initDom();
      getBrands();
      searchOnSelect();
      searchAutoComplete();
      searchOnSubmit();
    };

    var searchAutoComplete = function () {
      searchInput.autocomplete({
        search: onAutoCompleteSearchEvent,
        open: onAutoCompleteOpenEvent,
        source: onGetDataSource,
        select: onSelectAutoCompleteListener,
        minLength: MIN_SEARCH_QUERY_LENGTH
      });
    };

    var onAutoCompleteSearchEvent = function () {
      $(this).addClass("autocomplete-loading");
      reinitDataSource();
    };

    var reinitDataSource = function () {
      dataSource.length = 0;
    };

    var onAutoCompleteOpenEvent = function () {
      $(this).removeClass("autocomplete-loading");
    };

    var onSelectAutoCompleteListener = function (event, ui) {
      var selectedObj = ui.item;
      searchGoToProductList(selectedObj.value);
    };

    var searchOnSelect = function () {
      searchBrandListOption.click(function (e) {
        searchBrandListTempId = $(this).attr("id");
        searchBrandListSelected.text($(this).text());
      });
    };

    var onGetDataSource = function (request, response) {
      if (searchBrandListTempId) {
        getSearchSuggestion(request, response, searchBrandListTempId);
      } else {
        for (var i = 1; i <= 5; i++) {
          getSearchSuggestion(request, response, i);
        } 
      }
    };

    var getBrands = function () {
      $.get(searchApiGetBrand, function (data, status, xhr){
        brandsCount = data;
      });
    };

    var getSearchSuggestion = function (request, response, productBrandId) {
      $.get(
        searchApiEndpoints, {
          productBrandId: productBrandId,
          searchingKey: request.term
        },
        function (data, status, xhr) {
          onUpdateDataSource(request, response, JSON.parse(data));
        });
    };

    var mergeResponseData = function (responseToBeMerged) {
      var prevDataSource = dataSource;
      dataSource = $.merge(prevDataSource, responseToBeMerged);
    };

    var onUpdateDataSource = function (request, response, data) {
      mergeResponseData(data);
      response(dataSource);
    };

    var searchOnSubmit = function () {
      searchButton.click(function () {
        searchGoToProductList(searchInput.val());
      });
    };

    var searchGoToProductList = function (searchingKey) {
      if (searchBrandListTempId == null) {
        location.href =
          "/ProductList/Home/Index" +
          "?productBrandId=" +
          "&searchingKey=" +
          searchingKey;
      } else {
        location.href =
          "/ProductList/Home/Index" +
          "?productBrandId=" +
          searchBrandListTempId +
          "&searchingKey=" +
          searchingKey;
      }
    };

    return {
      run: search
    };
  })();
  searchProducts.run();
});