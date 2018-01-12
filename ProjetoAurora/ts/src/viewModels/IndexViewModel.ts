module ViewModels{ 
    export class IndexViewModel {
        dice1: KnockoutObservable<string>;
        dice2: KnockoutObservable<string>;
        dice3: KnockoutObservable<string>;
        dice4: KnockoutObservable<string>;
        dice5: KnockoutObservable<string>;
        categories: KnockoutObservableArray<Models.Category>;

        constructor() {
            this.setDefaultValues();
            this.setComputeds();
        }        

        private setComputeds(){
            ko.computed(this.sortCategories, this, { disposeWhenNodeIsRemoved: true });
        }

        private setDefaultValues() {
            this.setDices();
            this.setCategories();
        }

        private setDices() {
            this.dice1 = ko.observable<string>(''); 
            this.dice2 = ko.observable<string>('');
            this.dice3 = ko.observable<string>(''); 
            this.dice4 = ko.observable<string>('');
            this.dice5 = ko.observable<string>('');
        }

        private setCategories() {
            this.categories = ko.observableArray<Models.Category>([]);
            for (var i = 1; i<15; i++){
                this.categories.push(new Models.Category(i));
            }
        }

        private sortCategories() {
            ko.utils.arrayForEach(this.categories(), function(categorie) {
                categorie.isBestOption(false);
            });
        
            this.categories.sort( (l, r) => {
                return l.points() === r.points() 
                ? l.points() < r.points() ? 1 : -1
                : l.points() < r.points() ? 1 : -1}
            );
            this.categories()[0].isBestOption(true);
        }
    }    
}