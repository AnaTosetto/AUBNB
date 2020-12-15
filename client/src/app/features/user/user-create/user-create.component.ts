import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';

import { User } from '../shared/model/user.model';
import { UserService } from '../shared/user.service';

@Component({
    selector: 'app-user-create',
    templateUrl: './user-create.component.html',
    styleUrls: ['../styles/_style.scss']
})
export class UserCreateComponent implements OnInit {
    public form: FormGroup;
    public messageSuccess: boolean;
    public errorName: boolean;
    public errorEmail: boolean;
    public errorTelephone: boolean;
    public errorPassword: boolean;

    constructor(
        private userService: UserService) { }


    ngOnInit(): void {
        this.form = new FormGroup({});
        this.initForm();
    }

    public onSubmit(): void {
        if (this.validate()) {
            this.createUser();
        }
    }

    protected validate(): boolean {
        this.verifyName();
        this.verifyEmail();
        this.verifyTelephone();
        this.verifyPassword();

        return true;
    }

    protected initForm(): void {
        this.form = new FormGroup({
            name: new FormControl(null, Validators.required),
            email: new FormControl(null, Validators.required),
            password: new FormControl(null, Validators.required),
            telephoneNumber: new FormControl(null, Validators.required),
        });
    }

    private createUser(): void {
        const command: User = this.form.value;

        this.userService.post(command).subscribe(success => {
            this.form.reset();
            this.messageSuccess = true;
            return success;
        }, error => {
            return error;
        });
    }

    private verifyName(): void {
        this.errorName = false;

        const controlErrorsName: ValidationErrors = this.form.get('name').errors;

        if (controlErrorsName != null) {
            this.errorName = true;
        }
    }

    private verifyEmail(): void {
        this.errorEmail = false;

        const controlErrorsEmail: ValidationErrors = this.form.get('email').errors;

        if (controlErrorsEmail != null) {
            this.errorEmail = true;
        }
    }

    private verifyTelephone(): void {
        this.errorTelephone = false;

        const controlErrorsTelephone: ValidationErrors = this.form.get('telephoneNumber').errors;

        if (controlErrorsTelephone != null) {
            this.errorTelephone = true;
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
