import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Globals } from 'src/app/core/globals';

import { LoginCommand, User, UserUpdate } from '../shared/model/user.model';
import { UserService } from '../shared/user.service';

@Component({
    selector: 'app-user-edit',
    templateUrl: './user-edit.component.html',
    styleUrls: ['../styles/_style.scss']
})
export class UserEditComponent implements OnInit {
    public form: FormGroup;
    public messageSuccess: boolean;
    public errorName: boolean;
    public errorEmail: boolean;
    public errorTelephone: boolean;
    public errorPassword: boolean;

    public user: User;

    constructor(
        public globals: Globals,
        private userService: UserService,
        private router: Router) {
    }


    ngOnInit(): void {
        this.globals.getValue().subscribe((value) => {
            this.user = value;
        });
        this.loadUser();
        this.form = new FormGroup({});
        this.initForm();      
    }

    public onSubmit(): void {
        if (this.validate()) {
            this.editUser();
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
            name: new FormControl(this.user.name, Validators.required),
            email: new FormControl(this.user.email, Validators.required),
            password: new FormControl('*******', Validators.required),
            telephoneNumber: new FormControl(this.user.telephoneNumber, Validators.required),
        });
    }

    private editUser(): void {
        const command: UserUpdate = this.form.value;

        command.id = this.user.id;

        if (this.form.get('password').value === '*******') {
            command.password = this.user.password;
        } else {
            command.password = this.form.get('password').value;
        }

        this.userService.put(command).subscribe(success => {
            this.router.navigate([`/profile`])
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

    private loadUser(): void {
        const command: LoginCommand = new LoginCommand();

        command.email = this.user.email;
        command.password = this.user.password;

        this.userService.login(command).subscribe(success => {
            this.user = success;
            return success;
        }, error => {
            return error;
        });
    }
}
