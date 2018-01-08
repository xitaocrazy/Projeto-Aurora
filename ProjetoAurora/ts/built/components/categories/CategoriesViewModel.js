var KnockoutComponents;
(function (KnockoutComponents) {
    var CategoriesViewModel = /** @class */ (function () {
        function CategoriesViewModel(params) {
            this.params = params;
            this.setDefaultValues();
            this.setSignatures();
        }
        CategoriesViewModel.prototype.setDefaultValues = function () {
            this.dice1 = this.params.dice1;
            this.dice2 = this.params.dice2;
            this.dice3 = this.params.dice3;
            this.dice4 = this.params.dice4;
            this.dice5 = this.params.dice5;
        };
        CategoriesViewModel.prototype.setSignatures = function () {
            this.signatures = [];
            this.signatures.push(ko.postbox.subscribe('aurora.send.data', this.getData, this));
        };
        CategoriesViewModel.prototype.getData = function () {
            alert("here man");
        };
        CategoriesViewModel.prototype.dispose = function () {
            for (var i = 0; i < this.signatures.length; i++) {
                this.signatures[i].dispose();
            }
        };
        return CategoriesViewModel;
    }());
    KnockoutComponents.CategoriesViewModel = CategoriesViewModel;
})(KnockoutComponents || (KnockoutComponents = {}));
ko.components.register("categories-component", {
    viewModel: KnockoutComponents.CategoriesViewModel,
    template: { require: "text!../ts/src/components/categories/CategoriesViewModel.html" }
});
//# sourceMappingURL=CategoriesViewModel.js.map