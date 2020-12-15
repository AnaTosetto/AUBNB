import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { User } from '../features/user/shared/model/user.model';

@Injectable()
export class Globals {
    private user: BehaviorSubject<User>;

    constructor() {
        this.user = new BehaviorSubject<User>(null);
    }

    public setValue(newValue): void {
        this.user.next(newValue);
    }

    public getValue(): Observable<User> {
        return this.user.asObservable();
    }
}
