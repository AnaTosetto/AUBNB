import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginCommand } from '../shared/model/user.model';

import { UserService } from '../shared/user.service';
import { Globals } from '../../../core/globals';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['../styles/_style.scss']
})
export class LoginComponent implements OnInit {
    public form: FormGroup;
    public messageError: boolean;
    public errorEmail: boolean;
    public errorPassword: boolean;

    constructor(
        private userService: UserService,
        private router: Router,
        public globals: Globals
        ) { }


    ngOnInit(): void {
        this.form = new FormGroup({});
        this.initForm();
    }

    public onSubmit(): void {
        if (this.validate()) {
            this.verifyLogin();
        }
    }

    protected validate(): boolean {
        this.verifyEmail();
        this.verifyPassword();
        if (!this.form.valid) {
            return false;
        }

        return true;
    }

    protected initForm(): void {
        this.form = new FormGroup({
            email: new FormControl(null, Validators.required),
            password: new FormControl(null, Validators.required),
        });
    }

    private verifyLogin(): void {
        const command: LoginCommand = this.form.value;

        this.userService.login(command).subscribe(success => {
            this.router.navigate([`/view-hosting`]);
            this.globals.setValue(success);
            return success;
        }, error => {
            this.messageError = true;
            return error;
        });
    }

    private verifyEmail(): void {
        this.errorEmail = false;

        const controlErrorsEmail: ValidationErrors = this.form.get('email').errors;

        if (controlErrorsEmail != null) {
            this.errorEmail = true;
        }
    }

    private verifyPassword(): void {
        this.errorPassword = false;

        const controlErrorsPassword: ValidationErrors = this.form.get('password').errors;

        if (controlErrorsPassword != null) {
            this.errorPassword = true;
        }
    }
}
