describe('With an IndexViewModel', () => {
    var vm: ViewModels.IndexViewModel;
    beforeEach(() => {
        vm = new ViewModels.IndexViewModel();
    });
    describe('when build the object', () => {
        it('shloud set "dice1" as expected', () => {
            expect(vm.dice1()).toEqual('');
        });
        it('shloud set "dice2" as expected', () => {
            expect(vm.dice2()).toEqual('');
        });
        it('shloud set "dice3" as expected', () => {
            expect(vm.dice3()).toEqual('');
        });
        it('shloud set "dice4" as expected', () => {
            expect(vm.dice4()).toEqual('');
        });
        it('shloud set "dice5" as expected', () => {
            expect(vm.dice1()).toEqual('');
        });
        it('should set "categories" as expected', () => {
            for (let i = 0; i < 14; i++) {
                ValidateCategory(vm.categories()[i], i+1, 0);
            }
        });        
    });
    describe('when set the points to categories', () => {
        beforeEach(() => {
            for (var i=1; i<15; i++){
                var category = ko.utils.arrayFirst(vm.categories(), function(category) {
                    return category.id() == i;
                });
                category.points(i);
            }
        });
        it('should sort "categories" as expected', () => {
            for (let i = 0; i < 14; i++) {
                var value = 15 - (i+1);
                ValidateCategory(vm.categories()[i], 14, 14);
            }
        });
    });
});
function ValidateCategory(category: Models.Category, id: number, points: number) {
    it('shloud set "id" as expected', () => {
        expect(category.id()).toEqual(id);
    });
    it('shloud set "name" as expected', () => {
        expect(category.name()).toEqual('');
    });
    it('shloud set "rule" as expected', () => {
        expect(category.rule()).toEqual('');
    });
    it('shloud set "calculation" as expected', () => {
        expect(category.calculation()).toEqual('');
    });
    it('shloud set "points" as expected', () => {
        expect(category.points()).toEqual(points);
    });
    it('shloud set "isBestOption" as expected', () => {
        expect(category.isBestOption()).toBeFalsy();
    });
};