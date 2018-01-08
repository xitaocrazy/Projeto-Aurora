module KnockoutComponents{ 
    export class DicesViewModel {       
        dice1: KnockoutObservable<string>;
        dice2: KnockoutObservable<string>;
        dice3: KnockoutObservable<string>;
        dice4: KnockoutObservable<string>;
        dice5: KnockoutObservable<string>;
        canSend: KnockoutComputed<boolean>;

        constructor(private params: any) {
             this.setDefaultValues();
             this.setComputeds();
        }

        private setDefaultValues(){
            this.dice1 = this.params.dice1; 
            this.dice2 = this.params.dice2;
            this.dice3 = this.params.dice3; 
            this.dice4 = this.params.dice4;
            this.dice5 = this.params.dice5;
        }

        private setComputeds(){
            this.canSend = ko.computed(this.verifyIfCanSend, this, { disposeWhenNodeIsRemoved: true });
        }

        private verifyIfCanSend(){
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
        }

        send(){
            ko.postbox.publish('aurora.send.data');
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

        private getRandomIntIncludingLimits(min : number, max : number) {
            min = Math.ceil(min);
            max = Math.floor(max);
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }
    }
}

ko.components.register("dices-component", {
    viewModel: KnockoutComponents.DicesViewModel,
    template: { require: "text!../ts/src/components/dices/DicesViewModel.html" }
});