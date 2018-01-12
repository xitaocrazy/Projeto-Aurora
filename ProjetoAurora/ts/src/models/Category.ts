module Models{ 
    export class Category {
        id: KnockoutObservable<number>;
        name: KnockoutObservable<string>;
        rule: KnockoutObservable<string>;
        calculation: KnockoutObservable<string>;
        points: KnockoutObservable<number>;
        isBestOption: KnockoutObservable<boolean>;

        constructor(id: number) {
            this.setDefaultValues(id);
        }

       private setDefaultValues(id: number){
            this.id = ko.observable<number>(id); 
            this.name = ko.observable<string>('');
            this.rule = ko.observable<string>(''); 
            this.calculation = ko.observable<string>('');
            this.points = ko.observable<number>(0);
            this.isBestOption = ko.observable(false);
        }
    }    
}