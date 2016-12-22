import { Component, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { SpeedListComponent } from './speedlist.component';
import { SpeedService } from './speed.service';


@Component({
    moduleId: module.id,
    selector: 'site-speeds',
    templateUrl: './html/site-speeds.component.html'
})

@Injectable()
export class SiteSpeedsComponent implements OnInit{
    public site: Object;

    constructor(
        private route: ActivatedRoute,
        private location: Location,
        private speedService: SpeedService) {
    }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.speedService.getSite(params['id']))
            .subscribe(
                site => { this.site = site, console.log(site); },
                error => console.log('ERROR: ' + error));
    }
}
