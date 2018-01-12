describe('With an DicesViewModel', function () {
    var vm;
    var dice1;
    var dice2;
    var dice3;
    var dice4;
    var dice5;
    beforeEach(function () {
        dice1 = ko.observable('');
        dice2 = ko.observable('');
        dice3 = ko.observable('');
        dice4 = ko.observable('');
        dice5 = ko.observable('');
        var params = {
            dice1: dice1,
            dice2: dice2,
            dice3: dice3,
            dice4: dice4,
            dice5: dice5
        };
        vm = new KnockoutComponents.DicesViewModel(params);
    });
    afterEach(function () {
        ko.postbox.reset();
    });
    describe('when build the object', function () {
        it('shloud set "dice1" as expected', function () {
            expect(vm.dice1()).toEqual(dice1());
        });
        it('shloud set "dice2" as expected', function () {
            expect(vm.dice2()).toEqual(dice2());
        });
        it('shloud set "dice3" as expected', function () {
            expect(vm.dice3()).toEqual(dice3());
        });
        it('shloud set "dice4" as expected', function () {
            expect(vm.dice4()).toEqual(dice4());
        });
        it('shloud set "dice5" as expected', function () {
            expect(vm.dice1()).toEqual(dice5());
        });
        it('should set "canSend" as expected', function () {
            expect(vm.canSend()).toBeFalsy();
        });
    });
    describe('when set dice values', function () {
        describe('when set all dice values', function () {
            beforeEach(function () {
                vm.dice1('1');
                vm.dice2('2');
                vm.dice3('3');
                vm.dice4('4');
                vm.dice5('5');
            });
            it('should set "canSend" as expected', function () {
                expect(vm.canSend()).toBeTruthy();
            });
        });
        describe('when set some dice values', function () {
            beforeEach(function () {
                vm.dice1('1');
                vm.dice2('');
                vm.dice3('3');
                vm.dice4('');
                vm.dice5('5');
            });
            it('should set "canSend" as expected', function () {
                expect(vm.canSend()).toBeFalsy();
            });
        });
    });
    describe('when call "send"', function () {
        var koPostboxPublishSpy;
        beforeEach(function () {
            koPostboxPublishSpy = spyOn(ko.postbox, 'publish').and.callThrough();
            vm.send();
        });
        it('should publish in topic "aurora.send.data"', function () {
            expect(koPostboxPublishSpy).toHaveBeenCalledWith("aurora.send.data");
        });
    });
    describe('when call "clear"', function () {
        var koPostboxPublishSpy;
        beforeEach(function () {
            koPostboxPublishSpy = spyOn(ko.postbox, 'publish').and.callThrough();
            vm.clear();
        });
        it('should publish in topic "aurora.clear.data"', function () {
            expect(koPostboxPublishSpy).toHaveBeenCalledWith("aurora.clear.data");
        });
    });
    describe('when call "randon"', function () {
        beforeEach(function () {
            vm.dice1('');
            vm.dice2('');
            vm.dice3('');
            vm.dice4('');
            vm.dice5('');
            vm.randon();
        });
        it('should set dice1 value between 1 and 6', function () {
            var value = parseInt(vm.dice1());
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice2 value between 1 and 6', function () {
            var value = parseInt(vm.dice2());
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice3 value between 1 and 6', function () {
            var value = parseInt(vm.dice3());
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice4 value between 1 and 6', function () {
            var value = parseInt(vm.dice4());
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
        it('should set dice5 value between 1 and 6', function () {
            var value = parseInt(vm.dice5());
            expect(value).toBeGreaterThanOrEqual(1);
            expect(value).toBeLessThanOrEqual(6);
        });
    });
});
//# sourceMappingURL=DicesViewModelSpecs.js.map