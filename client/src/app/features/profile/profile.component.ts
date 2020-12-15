import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Globals } from '../../core/globals';
import { LoginCommand, User } from '../user/shared/model/user.model';
import { UserService } from '../user/shared/user.service';

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./styles/_styles.scss']
})
export class ProfileComponent implements OnInit {

    public user: User;

    constructor(
        private userService: UserService,
        public globals: Globals,
        private router: Router
    ){

    }

    public ngOnInit(): void {
        this.globals.getValue().subscribe((value) => {
            this.user = value;
        });
        this.loadUser();
    }

    public btnClick(): void {
        this.router.navigate([`/user-edit`]);
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
