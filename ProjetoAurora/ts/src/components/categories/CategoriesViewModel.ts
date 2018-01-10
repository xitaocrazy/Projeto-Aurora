module KnockoutComponents{ 
    export class CategoriesViewModel {       
        dice1: KnockoutObservable<string>;
        dice2: KnockoutObservable<string>;
        dice3: KnockoutObservable<string>;
        dice4: KnockoutObservable<string>;
        dice5: KnockoutObservable<string>;
        ready: KnockoutObservable<boolean>;
        id: number;
        signatures: Array<any>;
        url = "http://localhost:5000/api/categories";

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
            this.id = this.params.id;
            this.ready = ko.observable<boolean>(false);
        }

        private setSignatures() {
            this.signatures = [];
            this.signatures.push(ko.postbox.subscribe('aurora.send.data', this.calculateCategoryPoints, this));
        }

        public calculateCategoryPoints(){
            var bet = {
                categoryid: this.id,
                dices: this.dice1() + ',' + this.dice2() + ',' + this.dice3() + ',' + this.dice4() + ',' + this.dice5()
            };
            var data = JSON.stringify(bet);
            $.post({
                url: this.url,
                data: data,
                contentType: "application/json"
            })
            .done(this.calculationSuccess)
            .fail(this.calculationError)
            .always(this.calculationDone);
        }       

        private calculationSuccess = (result: any) => {
            console.log(result);
        }

        private calculationError = (request: any, message: any, error: any) => {
            console.log('Ops. Algo errado não está certo. Tente novamente'); 
            console.log(message + '. Erro: ' + error);           
        }   
        
        private calculationDone = () => {
            this.ready(true);
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