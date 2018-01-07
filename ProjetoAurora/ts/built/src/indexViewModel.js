var IndexViewModel = /** @class */ (function () {
    function IndexViewModel() {
        this.dice1 = ko.observable('');
        this.dice2 = ko.observable('');
        this.dice3 = ko.observable('');
        this.dice4 = ko.observable('');
        this.dice5 = ko.observable('');
    }
    IndexViewModel.prototype.clean = function () {
        this.dice1('');
        this.dice2('');
        this.dice3('');
        this.dice4('');
        this.dice5('');
    };
    IndexViewModel.prototype.randon = function () {
        this.dice1(this.getRandomIntIncludingLimits(1, 6) + '');
        this.dice2(this.getRandomIntIncludingLimits(1, 6) + '');
        this.dice3(this.getRandomIntIncludingLimits(1, 6) + '');
        this.dice4(this.getRandomIntIncludingLimits(1, 6) + '');
        this.dice5(this.getRandomIntIncludingLimits(1, 6) + '');
    };
    IndexViewModel.prototype.getRandomIntIncludingLimits = function (min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1)) + min;
    };
    return IndexViewModel;
}());
//# sourceMappingURL=indexViewModel.js.map