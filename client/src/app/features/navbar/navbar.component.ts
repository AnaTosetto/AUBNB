import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

import { Globals } from 'src/app/core/globals';
import { User } from '../user/shared/model/user.model';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./styles/_style.scss']
})
export class NavbarComponent implements OnInit {
    public hosting = '/view-hosting';
    public hostingCreate = '/create-hosting';
    public profile = '/profile';
    public order = '/order';
    public help = '/help';
    public login = '/login';
    public loginText = 'Entrar';

    public isLogged: boolean;

    constructor(
        public globals: Globals,
        private router: Router,
    ) {
    }

    public ngOnInit(): void {
        this.globals.getValue().subscribe((value) => {
            this.setLogged(value);
        });
    }

    public setLogged(user: User): void {
        if (user) {
            this.help = '/help';
            this.isLogged = true;
            this.loginText = 'Sair';

        } else {
            this.isLogged = false;
            this.login = '/login';
        }
    }

    public onClick(): void {
        if (this.loginText === 'Sair') {
            this.globals.setValue(null);
            this.router.navigate([`/`]);
            this.loginText = 'Entrar';
        } else {
            this.router.navigate([`/login`]);
        }
    }
}
