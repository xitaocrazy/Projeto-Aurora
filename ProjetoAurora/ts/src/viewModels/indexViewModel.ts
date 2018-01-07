class IndexViewModel {       
    loaded: KnockoutObservable<boolean>;

    constructor() {
        this.loaded = ko.observable(false);
    }

    start(){
        this.loaded(true);
    }
}