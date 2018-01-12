describe('With an CategoriesViewModel', function () {
    var vm;
    var dice1;
    var dice2;
    var dice3;
    var dice4;
    var dice5;
    var category;
    beforeEach(function () {
        dice1 = ko.observable('');
        dice2 = ko.observable('');
        dice3 = ko.observable('');
        dice4 = ko.observable('');
        dice5 = ko.observable('');
        category = new Models.Category(1);
        var params = {
            dice1: dice1,
            dice2: dice2,
            dice3: dice3,
            dice4: dice4,
            dice5: dice5,
            category: category
        };
        vm = new KnockoutComponents.CategoriesViewModel(params);
    });
    afterEach(function () {
        ko.postbox.reset();
        vm.dispose();
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
        it('should set "category" as expected', function () {
            expect(vm.category).toEqual(category);
        });
        it('should set "style" as expected', function () {
            expect(vm.style()).toEqual('panel-info');
        });
        it('should set "isOk" as expected', function () {
            expect(vm.isOk()).toBeFalsy();
        });
        it('should register signatures', function () {
            expect(vm.signatures.length).toBe(2);
        });
    });
    describe('when set "isBestOption"', function () {
        describe('when set to true', function () {
            beforeEach(function () {
                category.isBestOption(true);
            });
            it('should set "style" as expected', function () {
                expect(vm.style()).toEqual('panel-success');
            });
        });
        describe('when set to false', function () {
            beforeEach(function () {
                category.isBestOption(false);
            });
            it('should set "style" as expected', function () {
                expect(vm.style()).toEqual('panel-info');
            });
        });
    });
    describe('when set category data', function () {
        describe('when set all', function () {
            beforeEach(function () {
                category.name('name');
                category.rule('rule');
                category.calculation('calculation');
            });
            it('should set "isOk" as expected', function () {
                expect(vm.isOk()).toBeTruthy();
            });
        });
        describe('when are blank values', function () {
            beforeEach(function () {
                category.name('name');
                category.rule('');
                category.calculation('calculation');
            });
            it('should set "isOk" as expected', function () {
                expect(vm.isOk()).toBeFalsy();
            });
        });
    });
    describe('when something publish in aurora.clear.data', function () {
        beforeEach(function () {
            category.name('name');
            category.calculation('calculation');
            category.rule('rule');
            category.points(20);
            category.isBestOption(true);
            ko.postbox.publish('aurora.clear.data');
        });
        it('should clear all data', function () {
            expect(vm.category.name()).toEqual('');
            expect(vm.category.calculation()).toEqual('');
            expect(vm.category.rule()).toEqual('');
            expect(vm.category.points()).toEqual(0);
            expect(vm.category.isBestOption()).toEqual(false);
        });
    });
    describe('when something publish in aurora.send.data', function () {
        var postSpy;
        var consoleSpy;
        var bet;
        var object;
        var categoryResponse;
        beforeEach(function () {
            bet = JSON.stringify({
                categoryid: category.id(),
                dices: dice1() + ',' + dice2() + ',' + dice3() + ',' + dice4() + ',' + dice5()
            });
            object = {
                url: 'http://localhost:5000/api/categories',
                data: bet,
                contentType: 'application/json'
            };
        });
        describe('when operation success', function () {
            beforeEach(function () {
                category.name('');
                category.calculation('');
                category.rule('');
                category.points(0);
                categoryResponse = {
                    id: 1,
                    name: 'name',
                    rule: 'rule',
                    calculation: 'calculation',
                    points: 6
                };
                postSpy = spyOn($, 'post').and.callFake(function () {
                    var def = $.Deferred();
                    def.resolve(categoryResponse);
                    return def.promise();
                });
                consoleSpy = spyOn(console, 'log').and.callThrough();
                ko.postbox.publish('aurora.send.data');
            });
            it('should post the data', function () {
                expect(postSpy).toHaveBeenCalledWith(object);
            });
            it('should set the category values', function () {
                expect(vm.category.name()).toEqual('Categoria: name');
                expect(vm.category.calculation()).toEqual('calculation');
                expect(vm.category.rule()).toEqual('rule');
                expect(vm.category.points()).toEqual(6);
            });
        });
        describe('when operation fail', function () {
            beforeEach(function () {
                category.name('name');
                category.calculation('calculation');
                category.rule('rule');
                category.points(20);
                postSpy = spyOn($, 'post').and.callFake(function () {
                    var def = $.Deferred();
                    def.reject();
                    return def.promise();
                });
                consoleSpy = spyOn(console, 'log').and.callThrough();
                ko.postbox.publish('aurora.send.data');
            });
            it('should post the data', function () {
                expect(postSpy).toHaveBeenCalledWith(object);
            });
            it('should clear category values', function () {
                expect(vm.category.name()).toEqual('');
                expect(vm.category.calculation()).toEqual('');
                expect(vm.category.rule()).toEqual('');
                expect(vm.category.points()).toEqual(0);
            });
        });
    });
});
//# sourceMappingURL=CategoriesViewModelSpecs.js.map