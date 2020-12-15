import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { HostingService } from '../shared/hosting.service';
import { Hosting, HostingCreate } from '../shared/model/hosting.model';
import { Globals } from '../../../core/globals';



@Component({
    selector: 'app-hosting-create',
    templateUrl: './hosting-create.component.html',
    styleUrls: ['../styles/_style.scss']
})
export class HostingCreateComponent implements OnInit {
    public form: FormGroup;
    public messageSuccess: boolean;
    public userId: number;

    constructor(
        public globals: Globals,
        private hostingService: HostingService) { }


    ngOnInit(): void {
        this.globals.getValue().subscribe((value) => {
            this.userId = value.id;
        });
        this.form = new FormGroup({});
        this.initForm();
    }


    public onSubmit(): void {
        if (this.validate()) {
            this.createHosting();
        }
    }

    protected validate(): boolean {
        return true;
    }

    protected initForm(): void {
        this.form = new FormGroup({
            description: new FormControl(null, Validators.required),
            price: new FormControl(null, Validators.required),
            note: new FormControl(null, Validators.required),
            availability: new FormControl(null, Validators.required),
            street: new FormControl(null, Validators.required),
            number: new FormControl(null, Validators.required),
            neighborhood: new FormControl(null, Validators.required),
            city: new FormControl(null, Validators.required),
            state: new FormControl(null, Validators.required),
            country: new FormControl(null, Validators.required),
            postalCode: new FormControl(null, Validators.required),
            additionalInfo: new FormControl(null, Validators.required),
            animalSize: new FormControl(null, Validators.required),
            hasDog: new FormControl(null, Validators.required),
            housingType: new FormControl(null, Validators.required),
            patioSize: new FormControl(null, Validators.required),
            placeDescription: new FormControl(null, Validators.required),
        });
    }

    private createHosting(): void {
        const command: HostingCreate = this.form.value;

        command.userId = this.userId;

        this.hostingService.post(command).subscribe(success => {
            this.form.reset();
            this.messageSuccess = true;
            return success;
        }, error => {
            return error;
        });
    }

}
