import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { take } from 'rxjs/operators';

import { HostingService } from '../shared/hosting.service';
import { HostingResume } from '../shared/model/hosting.model';

@Component({
    selector: 'app-detail-hosting',
    templateUrl: './detail-hosting.component.html',
    styleUrls: ['../styles/_style.scss']
})
export class DetailHostingComponent implements OnInit {

    public hosting: HostingResume;
    public id: number;

    constructor(
        private hostingService: HostingService,
        private activatedRoute: ActivatedRoute
    ) {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params.id;
        });
    }

    public ngOnInit(): void {
        this.loadHosting(this.id);
    }

    public loadHosting(id: number): void {
        this.hostingService.getById(id).pipe(take(1)).subscribe((response: any) => {
            this.hosting = response;
        });
        console.log(this.hosting);
    }
}
