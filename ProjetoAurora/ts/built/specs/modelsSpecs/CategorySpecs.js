describe('With an Category', function () {
    var vm;
    beforeEach(function () {
        vm = new Models.Category(1);
    });
    describe('when build the object', function () {
        it('shloud set "id" as expected', function () {
            expect(vm.id()).toEqual(1);
        });
        it('shloud set "name" as expected', function () {
            expect(vm.name()).toEqual('');
        });
        it('shloud set "rule" as expected', function () {
            expect(vm.rule()).toEqual('');
        });
        it('shloud set "calculation" as expected', function () {
            expect(vm.calculation()).toEqual('');
        });
        it('shloud set "points" as expected', function () {
            expect(vm.points()).toEqual(0);
        });
        it('shloud set "isBestOption" as expected', function () {
            expect(vm.isBestOption()).toBeFalsy();
        });
    });
});
//# sourceMappingURL=CategorySpecs.js.map