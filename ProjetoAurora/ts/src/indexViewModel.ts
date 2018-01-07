class IndexViewModel {       
    dice1: KnockoutObservable<string>;
    dice2: KnockoutObservable<string>;
    dice3: KnockoutObservable<string>;
    dice4: KnockoutObservable<string>;
    dice5: KnockoutObservable<string>;

    constructor() {
        this.dice1 = ko.observable(''); 
        this.dice2 = ko.observable('');
        this.dice3 = ko.observable(''); 
        this.dice4 = ko.observable('');
        this.dice5 = ko.observable(''); 
    }

    clean(){
        this.dice1('');
        this.dice2('');
        this.dice3('');
        this.dice4('');
        this.dice5('');
    }

    randon(){
        this.dice1(this.getRandomIntIncludingLimits(1,6) + '');
        this.dice2(this.getRandomIntIncludingLimits(1,6) + '');
        this.dice3(this.getRandomIntIncludingLimits(1,6) + '');
        this.dice4(this.getRandomIntIncludingLimits(1,6) + '');
        this.dice5(this.getRandomIntIncludingLimits(1,6) + '');
    }

    getRandomIntIncludingLimits(min : number, max : number) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1)) + min;
      }
}