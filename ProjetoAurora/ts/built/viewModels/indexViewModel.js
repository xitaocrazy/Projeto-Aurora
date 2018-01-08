var ViewModels;
(function (ViewModels) {
    var IndexViewModel = /** @class */ (function () {
        function IndexViewModel() {
            this.setDefaultValues();
        }
        IndexViewModel.prototype.setDefaultValues = function () {
            this.dice1 = ko.observable('');
            this.dice2 = ko.observable('');
            this.dice3 = ko.observable('');
            this.dice4 = ko.observable('');
            this.dice5 = ko.observable('');
        };
        return IndexViewModel;
    }());
    ViewModels.IndexViewModel = IndexViewModel;
})(ViewModels || (ViewModels = {}));
//# sourceMappingURL=IndexViewModel.js.map