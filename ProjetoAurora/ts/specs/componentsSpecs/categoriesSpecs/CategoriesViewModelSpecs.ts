describe('With an CategoriesViewModel', () => {
    var vm: KnockoutComponents.CategoriesViewModel;
    var dice1: KnockoutObservable<string>;
    var dice2: KnockoutObservable<string>;
    var dice3: KnockoutObservable<string>;
    var dice4: KnockoutObservable<string>;
    var dice5: KnockoutObservable<string>;
    var category: Models.Category;

    beforeEach(() => {
        dice1 = ko.observable<string>(''); 
        dice2 = ko.observable<string>('');
        dice3 = ko.observable<string>(''); 
        dice4 = ko.observable<string>('');
        dice5 = ko.observable<string>('');
        category = new Models.Category(1);
        var params = {
            dice1: dice1,
            dice2: dice2,
            dice3: dice3,
            dice4: dice4,
            dice5: dice5,
            category: category
        }
        vm = new KnockoutComponents.CategoriesViewModel(params);
    });
    afterEach(() => {
        ko.postbox.reset();
        vm.dispose();
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
        it('should set "category" as expected', () => {
            expect(vm.category).toEqual(category);
        }); 
        it('should set "style" as expected', () => {
            expect(vm.style()).toEqual('panel-info');
        });  
        it('should set "isOk" as expected', () => {
            expect(vm.isOk()).toBeFalsy();
        });  
        it('should register signatures', () => {
            expect(vm.signatures.length).toBe(2);
        });    
    });
    describe('when set "isBestOption"', () =>{
        describe('when set to true', () =>{
            beforeEach(() => {
                category.isBestOption(true);
            })
            it('should set "style" as expected', () => {
                expect(vm.style()).toEqual('panel-success');
            });
        })
        describe('when set to false', () =>{
            beforeEach(() => {
                category.isBestOption(false);
            })
            it('should set "style" as expected', () => {
                expect(vm.style()).toEqual('panel-info');
            });
        })
    })
    describe('when set category data', () =>{
        describe('when set all', () =>{
            beforeEach(() => {
                category.name('name');
                category.rule('rule');
                category.calculation('calculation');
            })
            it('should set "isOk" as expected', () => {
                expect(vm.isOk()).toBeTruthy();
            });
        })
        describe('when are blank values', () =>{
            beforeEach(() => {
                category.name('name');
                category.rule('');
                category.calculation('calculation');
            })
            it('should set "isOk" as expected', () => {
                expect(vm.isOk()).toBeFalsy();
            });
        })
    })
    describe('when something publish in aurora.clear.data', () =>{
        beforeEach(() => {
            category.name('name');
            category.calculation('calculation');
            category.rule('rule');
            category.points(20);
            category.isBestOption(true);
            ko.postbox.publish('aurora.clear.data');
        })
        it('should clear all data', () => {
            expect(vm.category.name()).toEqual('');
            expect(vm.category.calculation()).toEqual('');
            expect(vm.category.rule()).toEqual('');
            expect(vm.category.points()).toEqual(0);
            expect(vm.category.isBestOption()).toEqual(false);
        });
    })   
    describe('when something publish in aurora.send.data', () =>{
        var postSpy: jasmine.Spy;
        var consoleSpy: jasmine.Spy;
        var bet: any;
        var object: any;
        var categoryResponse: any;
        beforeEach(() => {
            bet = JSON.stringify({
                categoryid: category.id(),
                dices: dice1() + ',' + dice2() + ',' + dice3() + ',' + dice4() + ',' + dice5()
            });
            object = {
                url: 'http://localhost:5000/api/categories',
                data: bet,
                contentType: 'application/json'
            };
        })
        describe('when operation success', () =>{
            beforeEach(() => {
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
                }
                postSpy = spyOn($, 'post').and.callFake(() => {
                    var def = $.Deferred();
                    def.resolve(categoryResponse);
                    return def.promise();
                });
                consoleSpy = spyOn(console, 'log').and.callThrough();
                ko.postbox.publish('aurora.send.data');
            })
            it('should post the data', () => {
                expect(postSpy).toHaveBeenCalledWith(object);
            });
            it('should set the category values', () => {
                expect(vm.category.name()).toEqual('Categoria: name');
                expect(vm.category.calculation()).toEqual('calculation');
                expect(vm.category.rule()).toEqual('rule');
                expect(vm.category.points()).toEqual(6);
            });
        });
        describe('when operation fail', () =>{
            beforeEach(() => {
                category.name('name');
                category.calculation('calculation');
                category.rule('rule');
                category.points(20);
                postSpy = spyOn($, 'post').and.callFake(() => {
                    var def = $.Deferred();
                    def.reject();
                    return def.promise();
                });
                consoleSpy = spyOn(console, 'log').and.callThrough();
                ko.postbox.publish('aurora.send.data');
            })
            it('should post the data', () => {
                expect(postSpy).toHaveBeenCalledWith(object);
            });
            it('should clear category values', () => {
                expect(vm.category.name()).toEqual('');
                expect(vm.category.calculation()).toEqual('');
                expect(vm.category.rule()).toEqual('');
                expect(vm.category.points()).toEqual(0);
            });
        }); 
    })
});