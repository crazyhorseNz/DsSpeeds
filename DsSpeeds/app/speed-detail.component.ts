import { Component, OnInit, Injectable } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { SpeedService } from './speed.service';

@Component({
    moduleId: module.id,
    selector: 'speed-detail',
    templateUrl: './html/speed-detail.component.html'
})
@Injectable()
export class SpeedDetailComponent implements OnInit{
    constructor(
        private route: ActivatedRoute,
        private location: Location,
        private speedService: SpeedService) { 
    }

    public speed: Object;

    ngOnInit(): void {

        this.route.params
            .switchMap((params: Params) => this.speedService.getSpeed(params['id']))
            .subscribe(
                speed => this.speed = speed ,
                error => console.log('ERROR: ' + error));
    }

}
