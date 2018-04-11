var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewEncapsulation } from '@angular/core';
import { ScriptLoaderService } from '../../../../../../../_services/script-loader.service';
var WidgetsBootstrapDatepickerComponent = (function () {
    function WidgetsBootstrapDatepickerComponent(_script) {
        this._script = _script;
    }
    WidgetsBootstrapDatepickerComponent.prototype.ngOnInit = function () {
    };
    WidgetsBootstrapDatepickerComponent.prototype.ngAfterViewInit = function () {
        this._script.loadScripts('app-widgets-bootstrap-datepicker', ['assets/demo/default/custom/components/forms/widgets/bootstrap-datepicker.js']);
    };
    WidgetsBootstrapDatepickerComponent = __decorate([
        Component({
            selector: "app-widgets-bootstrap-datepicker",
            templateUrl: "./widgets-bootstrap-datepicker.component.html",
            encapsulation: ViewEncapsulation.None,
        }),
        __metadata("design:paramtypes", [ScriptLoaderService])
    ], WidgetsBootstrapDatepickerComponent);
    return WidgetsBootstrapDatepickerComponent;
}());
export { WidgetsBootstrapDatepickerComponent };
//# sourceMappingURL=widgets-bootstrap-datepicker.component.js.map