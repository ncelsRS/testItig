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
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
var RegisterComponent = (function () {
    function RegisterComponent(router, fb) {
        this.router = router;
        this.form = fb.group({
            name: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
            email: ['', Validators.compose([Validators.required, emailValidator])],
            password: ['', Validators.required],
            confirmPassword: ['', Validators.required]
        }, { validator: matchingPasswords('password', 'confirmPassword') });
        this.name = this.form.controls['name'];
        this.email = this.form.controls['email'];
        this.password = this.form.controls['password'];
        this.confirmPassword = this.form.controls['confirmPassword'];
    }
    RegisterComponent.prototype.onSubmit = function (values) {
        if (this.form.valid) {
            console.log(values);
            this.router.navigate(['/login']);
        }
    };
    RegisterComponent.prototype.ngAfterViewInit = function () {
        document.getElementById('preloader').classList.add('hide');
    };
    RegisterComponent = __decorate([
        Component({
            selector: 'app-register',
            templateUrl: './register.component.html',
            styleUrls: ['./register.component.scss'],
            encapsulation: ViewEncapsulation.None
        }),
        __metadata("design:paramtypes", [Router, FormBuilder])
    ], RegisterComponent);
    return RegisterComponent;
}());
export { RegisterComponent };
export function emailValidator(control) {
    var emailRegexp = /[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/;
    if (control.value && !emailRegexp.test(control.value)) {
        return { invalidEmail: true };
    }
}
export function matchingPasswords(passwordKey, passwordConfirmationKey) {
    return function (group) {
        var password = group.controls[passwordKey];
        var passwordConfirmation = group.controls[passwordConfirmationKey];
        if (password.value !== passwordConfirmation.value) {
            return passwordConfirmation.setErrors({ mismatchedPasswords: true });
        }
    };
}
//# sourceMappingURL=register.component.js.map