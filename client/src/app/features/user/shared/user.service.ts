import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { LoginCommand, User, UserUpdate } from './model/user.model';

@Injectable()
export class UserService {
    public BASE_URL = 'http://localhost:5000/api/users';

    constructor(private http: HttpClient) {}

    public post(user: User): Observable<boolean> {
        return this.http.post(`${this.BASE_URL}`, user).pipe(map((data: boolean) => data));
    }

    public put(user: UserUpdate): Observable<boolean> {
        return this.http.put(`${this.BASE_URL}`, user).pipe(map((data: boolean) => data));
    }

    public login(user: LoginCommand): Observable<User> {
        return this.http.post(`${this.BASE_URL}/login`, user).pipe(map((data: User) => data));
    }
}
