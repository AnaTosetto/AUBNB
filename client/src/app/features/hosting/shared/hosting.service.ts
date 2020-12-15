import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { HostingCreate, HostingResume } from './model/hosting.model';

@Injectable()
export class HostingService {
    public BASE_URL = 'http://localhost:5000/api/hostings';

    constructor(private http: HttpClient) { }

    public getAll(userId: number): Observable<HostingResume> {
        return this.http.get(`${this.BASE_URL}/${userId}`).pipe(map((response: HostingResume) => response));
    }

    public getById(id: number): Observable<HostingResume>{
        return this.http.get(`${this.BASE_URL}/by-id/${id}`).pipe(map((response: HostingResume) => response));
    }

    public post(user: HostingCreate): Observable<boolean> {
        return this.http.post(`${this.BASE_URL}`, user).pipe(map((data: boolean) => data));
    }
}
