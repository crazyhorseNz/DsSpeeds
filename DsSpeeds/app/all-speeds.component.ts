import { Component, Injectable, OnInit } from '@angular/core';

import { SpeedListComponent } from './speedlist.component';
import { SpeedService } from './speed.service';


@Component({
    moduleId: module.id,
    selector: 'all-speeds',
    template: `
    <h2>All Speeds</h2>
    <div>
        <speedlist [speeds]="speeds">loading...</speedlist>
    </div>
    `
})

@Injectable()
export class AllSpeedsComponent implements OnInit{
    public speeds: Object[] = [];

    constructor(private speedService: SpeedService) {
    }

    ngOnInit() {
        this.speedService.getSpeeds()
            .subscribe(speeds => {
                console.log(speeds);
                this.speeds = speeds;
                console.log(this.speeds);
            },
            error => console.log('ERROR: ' + error));

    }

}
