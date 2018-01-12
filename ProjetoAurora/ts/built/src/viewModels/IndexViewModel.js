var ViewModels;
(function (ViewModels) {
    var IndexViewModel = /** @class */ (function () {
        function IndexViewModel() {
            this.setDefaultValues();
            this.setComputeds();
        }
        IndexViewModel.prototype.setComputeds = function () {
            ko.computed(this.sortCategories, this, { disposeWhenNodeIsRemoved: true });
        };
        IndexViewModel.prototype.setDefaultValues = function () {
            this.setCategories();
            this.setDices();
        };
        IndexViewModel.prototype.setDices = function () {
            this.dice1 = ko.observable('');
            this.dice2 = ko.observable('');
            this.dice3 = ko.observable('');
            this.dice4 = ko.observable('');
            this.dice5 = ko.observable('');
        };
        IndexViewModel.prototype.setCategories = function () {
            this.categories = ko.observableArray([]);
            for (var i = 1; i < 15; i++) {
                this.categories.push(new Models.Category(i));
            }
        };
        IndexViewModel.prototype.sortCategories = function () {
            ko.utils.arrayForEach(this.categories(), function (category) {
                category.isBestOption(false);
            });
            this.categories.sort(function (l, r) {
                return l.points() === r.points()
                    ? l.points() < r.points() ? 1 : -1
                    : l.points() < r.points() ? 1 : -1;
            });
            this.categories()[0].isBestOption(true);
        };
        return IndexViewModel;
    }());
    ViewModels.IndexViewModel = IndexViewModel;
})(ViewModels || (ViewModels = {}));
//# sourceMappingURL=IndexViewModel.js.map