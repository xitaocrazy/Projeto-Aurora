var Models;
(function (Models) {
    var Category = /** @class */ (function () {
        function Category(id) {
            this.setDefaultValues(id);
        }
        Category.prototype.setDefaultValues = function (id) {
            this.id = ko.observable(id);
            this.name = ko.observable('');
            this.rule = ko.observable('');
            this.calculation = ko.observable('');
            this.points = ko.observable(0);
            this.isBestOption = ko.observable(false);
        };
        return Category;
    }());
    Models.Category = Category;
})(Models || (Models = {}));
//# sourceMappingURL=Category.js.map