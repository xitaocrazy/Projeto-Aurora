module KnockoutComponents{ 
    export class CategoriesViewModel {       
        dice1: KnockoutObservable<string>;
        dice2: KnockoutObservable<string>;
        dice3: KnockoutObservable<string>;
        dice4: KnockoutObservable<string>;
        dice5: KnockoutObservable<string>;        
        category: Models.Category;
        style: KnockoutComputed<string>;
        isOk: KnockoutComputed<boolean>;

        signatures: Array<any>;
        url = 'http://localhost:5000/api/categories';

        constructor(private params: any) {
             this.setDefaultValues();
             this.setComputeds();
             this.setSignatures();
        }

        private setDefaultValues(){
            this.dice1 = this.params.dice1; 
            this.dice2 = this.params.dice2;
            this.dice3 = this.params.dice3; 
            this.dice4 = this.params.dice4;
            this.dice5 = this.params.dice5;
            this.category = this.params.category;
        }

        private setComputeds(){
            this.style = ko.computed(this.verifyIfIsBestOption, this, { disposeWhenNodeIsRemoved: true });
            this.isOk = ko.computed(this.verifyIfWasLoaded, this, { disposeWhenNodeIsRemoved: true });
        }

        private setSignatures() {
            this.signatures = [];
            this.signatures.push(ko.postbox.subscribe('aurora.send.data', this.calculateCategoryPoints, this));
            this.signatures.push(ko.postbox.subscribe('aurora.clear.data', this.clearCategoryData, this));
        }

        private verifyIfIsBestOption(){
            return this.category.isBestOption() ? 'panel-success' : 'panel-info';
        }

        private verifyIfWasLoaded(){
            return this.category.name() != '' &&
            this.category.rule() != '' &&
            this.category.calculation() != '';
        }

        public calculateCategoryPoints(){
            this.clearCategoryData();
            var object = this.createObjectToPost();
            $.post(object)
            .done(this.calculationSuccess)
            .fail(this.calculationError)
        }   
        
        private clearCategoryData(){
            this.category.name('');
            this.category.calculation('');
            this.category.rule('');
            this.category.points(0);
            this.category.isBestOption(false);
        }

        private createObjectToPost(){
            var bet = this.setBet();
            var object = {
                url: this.url,
                data: bet,
                contentType: 'application/json'
            };
            return object;
        }

        private setBet(){
            var bet = {
                categoryid: this.category.id(),
                dices: this.dice1() + ',' + this.dice2() + ',' + this.dice3() + ',' + this.dice4() + ',' + this.dice5()
            };
            return JSON.stringify(bet);
        }

        private calculationSuccess = (result: any) => {
            //console.log(result);
            this.setCategoryData(result);
        }

        private setCategoryData(result: any){
            this.category.name('Categoria: ' + result.name);
            this.category.calculation(result.calculation);
            this.category.rule(result.rule);
            this.category.points(result.points);
        }

        private calculationError = (request: any, message: any, error: any) => {
            //console.log('Ops. Algo errado não está certo. Tente novamente'); 
            //console.log(message + '. Erro: ' + error); 
            this.clearCategoryData();          
        } 

        dispose() {
            for (let i = 0; i < this.signatures.length; i++) {
                this.signatures[i].dispose();
            }
        }
    }
}

ko.components.register('categories-component', {
    viewModel: KnockoutComponents.CategoriesViewModel,
    template: { require: 'text!../ts/src/components/categories/CategoriesViewModel.html' }
});