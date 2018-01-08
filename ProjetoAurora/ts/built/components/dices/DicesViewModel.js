var KnockoutComponents;
(function (KnockoutComponents) {
    var DicesViewModel = /** @class */ (function () {
        function DicesViewModel() {
            this.dice1 = ko.observable('');
            this.dice2 = ko.observable('');
            this.dice3 = ko.observable('');
            this.dice4 = ko.observable('');
            this.dice5 = ko.observable('');
        }
        DicesViewModel.prototype.clean = function () {
            this.dice1('');
            this.dice2('');
            this.dice3('');
            this.dice4('');
            this.dice5('');
        };
        DicesViewModel.prototype.randon = function () {
            this.dice1(this.getRandomIntIncludingLimits(1, 6) + '');
            this.dice2(this.getRandomIntIncludingLimits(1, 6) + '');
            this.dice3(this.getRandomIntIncludingLimits(1, 6) + '');
            this.dice4(this.getRandomIntIncludingLimits(1, 6) + '');
            this.dice5(this.getRandomIntIncludingLimits(1, 6) + '');
        };
        DicesViewModel.prototype.getRandomIntIncludingLimits = function (min, max) {
            min = Math.ceil(min);
            max = Math.floor(max);
            return Math.floor(Math.random() * (max - min + 1)) + min;
        };
        return DicesViewModel;
    }());
    KnockoutComponents.DicesViewModel = DicesViewModel;
})(KnockoutComponents || (KnockoutComponents = {}));
ko.components.register("dices-component", {
    viewModel: KnockoutComponents.DicesViewModel,
    template: { require: "text!../ts/src/components/dices/DicesViewModel.html" }
});
//# sourceMappingURL=DicesViewModel.js.map