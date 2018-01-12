describe('With an DicesViewModel', () => {
    var vm: KnockoutComponents.DicesViewModel;
    var dice1: KnockoutObservable<string>;
    var dice2: KnockoutObservable<string>;
    var dice3: KnockoutObservable<string>;
    var dice4: KnockoutObservable<string>;
    var dice5: KnockoutObservable<string>;

    beforeEach(() => {
        dice1 = ko.observable<string>(''); 
        dice2 = ko.observable<string>('');
        dice3 = ko.observable<string>(''); 
        dice4 = ko.observable<string>('');
        dice5 = ko.observable<string>('');
        var params = {
            dice1: dice1,
            dice2: dice2,
            dice3: dice3,
            dice4: dice4,
            dice5: dice5
        }
        vm = new KnockoutComponents.DicesViewModel(params);
    });
    afterEach(() => {
        ko.postbox.reset();
    });
    describe('when build the object', () => {
        it('shloud set "dice1" as expected', () => {
            expect(vm.dice1()).toEqual(dice1());
        });
        it('shloud set "dice2" as expected', () => {
            expect(vm.dice2()).toEqual(dice2());
        });
        it('shloud set "dice3" as expected', () => {
            expect(vm.dice3()).toEqual(dice3());
        });
        it('shloud set "dice4" as expected', () => {
            expect(vm.dice4()).toEqual(dice4());
        });
        it('shloud set "dice5" as expected', () => {
            expect(vm.dice1()).toEqual(dice5());
        });
        it('should set "canSend" as expected', () => {
            expect(vm.canSend()).toBeFalsy();
        });        
    });
    describe('when set dice values', () => {
        describe('when set all dice values', () => {
            beforeEach(() => {
                vm.dice1('1');
                vm.dice2('2');
                vm.dice3('3');
                vm.dice4('4');
                vm.dice5('5');
            });
            it('should set "canSend" as expected', () => {
                expect(vm.canSend()).toBeTruthy();
            });
        });
        describe('when set some dice values', () => {
            beforeEach(() => {
                vm.dice1('1');
                vm.dice2('');
                vm.dice3('3');
                vm.dice4('');
                vm.dice5('5');
            });
            it('should set "canSend" as expected', () => {
                expect(vm.canSend()).toBeFalsy();
            });
        });
    }); 
    describe('when call "send"', () =>{
        var koPostboxPublishSpy: jasmine.Spy;
        beforeEach(() => {
            koPostboxPublishSpy = spyOn(ko.postbox, 'publish').and.callThrough();
            vm.send();
        });
        it('should publish in topic "aurora.send.data"', () => {
            expect(koPostboxPublishSpy).toHaveBeenCalledWith("aurora.send.data");
        });
    }); 
    describe('when call "clear"', () =>{
        var koPostboxPublishSpy: jasmine.Spy;
        beforeEach(() => {
            koPostboxPublishSpy = spyOn(ko.postbox, 'publish').and.callThrough();
            vm.clear();
        });
        it('should publish in topic "aurora.clear.data"', () => {
            expect(koPostboxPublishSpy).toHaveBeenCalledWith("aurora.clear.data");
        });
    }); 
    describe('when call "randon"', () =>{
        beforeEach(() => {
            vm.dice1('');
            vm.dice2('');
            vm.dice3('');
            vm.dice4('');
            vm.dice5('');
            vm.randon();
        });
        it('should set dice1 value between 1 and 6', () => {
            var value = parseInt(vm.dice1())
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice2 value between 1 and 6', () => {
            var value = parseInt(vm.dice2())
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice3 value between 1 and 6', () => {
            var value = parseInt(vm.dice3())
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice4 value between 1 and 6', () => {
            var value = parseInt(vm.dice4())
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice5 value between 1 and 6', () => {
            var value = parseInt(vm.dice5())
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
    }); 
});