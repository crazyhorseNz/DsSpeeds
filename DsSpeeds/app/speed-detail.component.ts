import { Component, OnInit, Injectable } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    moduleId: module.id,
    selector: 'speed-detail',
   // templateUrl: './html/speedlist.component.html'
    template: `<p>details go here</p>`
})
@Injectable()
export class SpeedDetailComponent implements OnInit{
    constructor(private route: ActivatedRoute, private location: Location) { 
        console.log('YEs!');
    }

    speed: Object;

    ngOnInit(): void {
        console.log(this.route.params['id']);
        //this.route.params
        //    .switchMap((params: Params) => this.heroService.getHero(+params['id']))
        //    .subscribe(hero => this.hero = hero);
    }

}
