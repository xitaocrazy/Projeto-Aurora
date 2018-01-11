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
            this.category1 = ko.observable(new Models.Category(1));
            this.category2 = ko.observable(new Models.Category(2));
            this.category3 = ko.observable(new Models.Category(3));
            this.category4 = ko.observable(new Models.Category(4));
            this.category5 = ko.observable(new Models.Category(5));
            this.category6 = ko.observable(new Models.Category(6));
            this.category7 = ko.observable(new Models.Category(7));
            this.category8 = ko.observable(new Models.Category(8));
            this.category9 = ko.observable(new Models.Category(9));
            this.category10 = ko.observable(new Models.Category(10));
            this.category11 = ko.observable(new Models.Category(11));
            this.category12 = ko.observable(new Models.Category(12));
            this.category13 = ko.observable(new Models.Category(13));
            this.category14 = ko.observable(new Models.Category(14));
        };
        return IndexViewModel;
    }());
    ViewModels.IndexViewModel = IndexViewModel;
})(ViewModels || (ViewModels = {}));
//# sourceMappingURL=IndexViewModel.js.map