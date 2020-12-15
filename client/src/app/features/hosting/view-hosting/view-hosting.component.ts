import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';

import { HostingService } from '../shared/hosting.service';
import { HostingResume } from '../shared/model/hosting.model';
import { DetailHostingComponent } from '../detail-hosting/detail-hosting.component';
import { Router } from '@angular/router';
import { Globals } from '../../../core/globals';

@Component({
    selector: 'app-view-hosting',
    templateUrl: './view-hosting.component.html',
    styleUrls: ['../styles/_style.scss']
})
export class ViewHostingComponent implements OnInit {

    public hostings: HostingResume[];
    public userId: number;

    constructor(
        private globals: Globals,
        private hostingService: HostingService,
        private router: Router
        ){ }

    public ngOnInit(): void {
        this.globals.getValue().subscribe((value) => {
            this.userId = value.id;
        });
        this.loadHostings();
    }

    public loadHostings(): void {
        this.hostingService.getAll(this.userId).pipe(take(1)).subscribe((response: any) => {
            this.hostings = response;
        });
    }

    public btnClick(id: number): void {
        this.router.navigate([`/detail-hosting/${id}`]);
    }
}
