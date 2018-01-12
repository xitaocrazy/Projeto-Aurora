describe('With an Category', () => {
    var vm: Models.Category;
    beforeEach(() => {
        vm = new Models.Category(1);
    });
    describe('when build the object', () => {
        it('shloud set "id" as expected', () => {
            expect(vm.id()).toEqual(1);
        });
        it('shloud set "name" as expected', () => {
            expect(vm.name()).toEqual('');
        });
        it('shloud set "rule" as expected', () => {
            expect(vm.rule()).toEqual('');
        });
        it('shloud set "calculation" as expected', () => {
            expect(vm.calculation()).toEqual('');
        });
        it('shloud set "points" as expected', () => {
            expect(vm.points()).toEqual(0);
        });
        it('shloud set "isBestOption" as expected', () => {
            expect(vm.isBestOption()).toBeFalsy();
        });
    });
});