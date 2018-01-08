var KnockoutComponents;
(function (KnockoutComponents) {
    var DicesViewModel = /** @class */ (function () {
        function DicesViewModel() {
            this.setDefaultValues();
            this.setComputeds();
        }
        DicesViewModel.prototype.setDefaultValues = function () {
            this.dice1 = ko.observable('');
            this.dice2 = ko.observable('');
            this.dice3 = ko.observable('');
            this.dice4 = ko.observable('');
            this.dice5 = ko.observable('');
        };
        DicesViewModel.prototype.setComputeds = function () {
            this.canSend = ko.computed(this.verifyIfCanSend, this, { disposeWhenNodeIsRemoved: true });
        };
        DicesViewModel.prototype.verifyIfCanSend = function () {
            return this.dice1() != '' &&
                this.dice2() != '' &&
                this.dice3() != '' &&
                this.dice4() != '' &&
                this.dice5() != '' &&
                this.dice1() != undefined &&
                this.dice2() != undefined &&
                this.dice3() != undefined &&
                this.dice4() != undefined &&
                this.dice5() != undefined &&
                this.dice1() != null &&
                this.dice2() != null &&
                this.dice3() != null &&
                this.dice4() != null &&
                this.dice5() != null;
        };
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