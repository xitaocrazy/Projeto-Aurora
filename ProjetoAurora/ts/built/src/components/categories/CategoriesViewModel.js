var KnockoutComponents;
(function (KnockoutComponents) {
    var CategoriesViewModel = /** @class */ (function () {
        function CategoriesViewModel(params) {
            var _this = this;
            this.params = params;
            this.url = 'http://localhost:5000/api/categories';
            this.calculationSuccess = function (result) {
                console.log(result);
                _this.setCategoryData(result);
            };
            this.calculationError = function (request, message, error) {
                console.log('Ops. Algo errado não está certo. Tente novamente');
                console.log(message + '. Erro: ' + error);
                _this.clearCategoryData();
            };
            this.setDefaultValues();
            this.setComputeds();
            this.setSignatures();
        }
        CategoriesViewModel.prototype.setDefaultValues = function () {
            this.dice1 = this.params.dice1;
            this.dice2 = this.params.dice2;
            this.dice3 = this.params.dice3;
            this.dice4 = this.params.dice4;
            this.dice5 = this.params.dice5;
            this.category = this.params.category;
        };
        CategoriesViewModel.prototype.setComputeds = function () {
            this.style = ko.computed(this.verifyIfIsBestOption, this, { disposeWhenNodeIsRemoved: true });
            this.isOk = ko.computed(this.verifyIfWasLoaded, this, { disposeWhenNodeIsRemoved: true });
        };
        CategoriesViewModel.prototype.setSignatures = function () {
            this.signatures = [];
            this.signatures.push(ko.postbox.subscribe('aurora.send.data', this.calculateCategoryPoints, this));
            this.signatures.push(ko.postbox.subscribe('aurora.clear.data', this.clearCategoryData, this));
        };
        CategoriesViewModel.prototype.verifyIfIsBestOption = function () {
            return this.category.isBestOption() ? 'panel-success' : 'panel-info';
        };
        CategoriesViewModel.prototype.verifyIfWasLoaded = function () {
            return this.category.name() != '' &&
                this.category.rule() != '' &&
                this.category.calculation() != '';
        };
        CategoriesViewModel.prototype.calculateCategoryPoints = function () {
            this.clearCategoryData();
            var object = this.createObjectToPost();
            $.post(object)
                .done(this.calculationSuccess)
                .fail(this.calculationError);
        };
        CategoriesViewModel.prototype.clearCategoryData = function () {
            this.category.name('');
            this.category.calculation('');
            this.category.rule('');
            this.category.points(0);
            this.category.isBestOption(false);
        };
        CategoriesViewModel.prototype.createObjectToPost = function () {
            var bet = this.setBet();
            var object = {
                url: this.url,
                data: bet,
                contentType: 'application/json'
            };
            return object;
        };
        CategoriesViewModel.prototype.setBet = function () {
            var bet = {
                categoryid: this.category.id(),
                dices: this.dice1() + ',' + this.dice2() + ',' + this.dice3() + ',' + this.dice4() + ',' + this.dice5()
            };
            return JSON.stringify(bet);
        };
        CategoriesViewModel.prototype.setCategoryData = function (result) {
            this.category.name('Categoria: ' + result.name);
            this.category.calculation(result.calculation);
            this.category.rule(result.rule);
            this.category.points(result.points);
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
ko.components.register('categories-component', {
    viewModel: KnockoutComponents.CategoriesViewModel,
    template: { require: 'text!../ts/src/components/categories/CategoriesViewModel.html' }
});
//# sourceMappingURL=CategoriesViewModel.js.map