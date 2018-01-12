describe('With an IndexViewModel', function () {
    var vm;
    beforeEach(function () {
        vm = new ViewModels.IndexViewModel();
    });
    afterEach(function () {
        ko.postbox.reset();
    });
    describe('when build the object', function () {
        it('shloud set "dice1" as expected', function () {
            expect(vm.dice1()).toEqual('');
        });
        it('shloud set "dice2" as expected', function () {
            expect(vm.dice2()).toEqual('');
        });
        it('shloud set "dice3" as expected', function () {
            expect(vm.dice3()).toEqual('');
        });
        it('shloud set "dice4" as expected', function () {
            expect(vm.dice4()).toEqual('');
        });
        it('shloud set "dice5" as expected', function () {
            expect(vm.dice1()).toEqual('');
        });
        it('should set "categories" as expected', function () {
            for (var i = 0; i < 14; i++) {
                ValidateCategory(vm.categories()[i], i + 1, 0);
            }
        });
    });
    describe('when set the points to categories', function () {
        beforeEach(function () {
            for (var i = 1; i < 15; i++) {
                var category = ko.utils.arrayFirst(vm.categories(), function (category) {
                    return category.id() == i;
                });
                category.points(i);
            }
        });
        it('should sort "categories" as expected', function () {
            for (var i = 0; i < 14; i++) {
                var value = 15 - (i + 1);
                ValidateCategory(vm.categories()[i], 14, 14);
            }
        });
    });
});
function ValidateCategory(category, id, points) {
    it('shloud set "id" as expected', function () {
        expect(category.id()).toEqual(id);
    });
    it('shloud set "name" as expected', function () {
        expect(category.name()).toEqual('');
    });
    it('shloud set "rule" as expected', function () {
        expect(category.rule()).toEqual('');
    });
    it('shloud set "calculation" as expected', function () {
        expect(category.calculation()).toEqual('');
    });
    it('shloud set "points" as expected', function () {
        expect(category.points()).toEqual(points);
    });
    it('shloud set "isBestOption" as expected', function () {
        expect(category.isBestOption()).toBeFalsy();
    });
}
;
//# sourceMappingURL=IndexViewModelSpecs.js.map