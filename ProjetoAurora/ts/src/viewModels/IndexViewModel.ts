module ViewModels{ 
    export class IndexViewModel {
        dice1: KnockoutObservable<string>;
        dice2: KnockoutObservable<string>;
        dice3: KnockoutObservable<string>;
        dice4: KnockoutObservable<string>;
        dice5: KnockoutObservable<string>;

        constructor() {
            this.setDefaultValues();
        }

       private setDefaultValues(){
            this.dice1 = ko.observable<string>(''); 
            this.dice2 = ko.observable<string>('');
            this.dice3 = ko.observable<string>(''); 
            this.dice4 = ko.observable<string>('');
            this.dice5 = ko.observable<string>('');
        }
    }    
}