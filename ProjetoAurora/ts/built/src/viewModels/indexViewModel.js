var IndexViewModel = /** @class */ (function () {
    function IndexViewModel() {
        this.loaded = ko.observable(false);
    }
    IndexViewModel.prototype.start = function () {
        this.loaded(true);
    };
    return IndexViewModel;
}());
//# sourceMappingURL=indexViewModel.js.map