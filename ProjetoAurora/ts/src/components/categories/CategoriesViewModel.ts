module KnockoutComponents{ 
    export class CategoriesViewModel {       
        dice1: KnockoutObservable<string>;
        dice2: KnockoutObservable<string>;
        dice3: KnockoutObservable<string>;
        dice4: KnockoutObservable<string>;
        dice5: KnockoutObservable<string>;
        signatures: Array<any>;

        constructor(private params: any) {
             this.setDefaultValues();
             this.setSignatures();
        }

        private setDefaultValues(){
            this.dice1 = this.params.dice1; 
            this.dice2 = this.params.dice2;
            this.dice3 = this.params.dice3; 
            this.dice4 = this.params.dice4;
            this.dice5 = this.params.dice5;
        }

        private setSignatures() {
            this.signatures = [];
            this.signatures.push(ko.postbox.subscribe('aurora.send.data', this.getData, this));
        }

        private getData(){
            alert("here man");
        }

        dispose() {
            for (let i = 0; i < this.signatures.length; i++) {
                this.signatures[i].dispose();
            }
        }
    }
}

ko.components.register("categories-component", {
    viewModel: KnockoutComponents.CategoriesViewModel,
    template: { require: "text!../ts/src/components/categories/CategoriesViewModel.html" }
});