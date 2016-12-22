import { Component, Injectable, OnInit } from '@angular/core';

import { SpeedListComponent } from './speedlist.component';
import { SpeedService } from './speed.service';


@Component({
    moduleId: module.id,
    selector: 'all-speeds',
    templateUrl: './html/all-speeds.component.html'
})

@Injectable()
export class AllSpeedsComponent implements OnInit{
    public speeds: Object[] = [];

    constructor(private speedService: SpeedService) {
    }

    ngOnInit() {
        this.speedService.getSpeeds()
            .subscribe(
                speeds => this.speeds = speeds,
                error => console.log('ERROR: ' + error));
    }
}
