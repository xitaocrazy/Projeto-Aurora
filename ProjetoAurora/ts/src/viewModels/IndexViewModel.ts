module ViewModels{ 
    export class IndexViewModel {
        dice1: KnockoutObservable<string>;
        dice2: KnockoutObservable<string>;
        dice3: KnockoutObservable<string>;
        dice4: KnockoutObservable<string>;
        dice5: KnockoutObservable<string>;
        category1: KnockoutObservable<Models.Category>;
        category2: KnockoutObservable<Models.Category>;
        category3: KnockoutObservable<Models.Category>;
        category4: KnockoutObservable<Models.Category>;
        category5: KnockoutObservable<Models.Category>;
        category6: KnockoutObservable<Models.Category>;
        category7: KnockoutObservable<Models.Category>;
        category8: KnockoutObservable<Models.Category>;
        category9: KnockoutObservable<Models.Category>;
        category10: KnockoutObservable<Models.Category>;
        category11: KnockoutObservable<Models.Category>;
        category12: KnockoutObservable<Models.Category>;
        category13: KnockoutObservable<Models.Category>;
        category14: KnockoutObservable<Models.Category>;

        constructor() {
            this.setDefaultValues();
        }

       private setDefaultValues(){
            this.dice1 = ko.observable<string>(''); 
            this.dice2 = ko.observable<string>('');
            this.dice3 = ko.observable<string>(''); 
            this.dice4 = ko.observable<string>('');
            this.dice5 = ko.observable<string>('');
            this.category1 = ko.observable<Models.Category>(new Models.Category(1));
            this.category2 = ko.observable<Models.Category>(new Models.Category(2));
            this.category3 = ko.observable<Models.Category>(new Models.Category(3));
            this.category4 = ko.observable<Models.Category>(new Models.Category(4));
            this.category5 = ko.observable<Models.Category>(new Models.Category(5));
            this.category6 = ko.observable<Models.Category>(new Models.Category(6));
            this.category7 = ko.observable<Models.Category>(new Models.Category(7));
            this.category8 = ko.observable<Models.Category>(new Models.Category(8));
            this.category9 = ko.observable<Models.Category>(new Models.Category(9));
            this.category10 = ko.observable<Models.Category>(new Models.Category(10));
            this.category11 = ko.observable<Models.Category>(new Models.Category(11));
            this.category12 = ko.observable<Models.Category>(new Models.Category(12));
            this.category13 = ko.observable<Models.Category>(new Models.Category(13));
            this.category14 = ko.observable<Models.Category>(new Models.Category(14));
        }
    }    
}