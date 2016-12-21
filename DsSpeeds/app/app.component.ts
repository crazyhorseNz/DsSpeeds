import { Component, Injectable, OnInit } from '@angular/core';

import { Speed } from './speed';
import { SpeedListComponent } from './speedlist.component';
import { SpeedService } from './speed.service';

export class Hero {
    id: number;
    name: string;
}

@Component({
    selector: 'my-app',
    template: `
    <h1>DS Speeds</h1>
    <h2>All Speeds</h2>
    <div>
        <speedlist [speeds]="speeds"></speedlist>
    </div>
    `
})

@Injectable()
export class AppComponent implements OnInit{
    public speeds: Speed[];
    constructor(private speedService: SpeedService) {
    }

    ngOnInit() {
        this.speedService.getSpeeds()
            .subscribe(speeds => {
                console.log('toMap' + speeds);
                this.speeds = speeds; 
                console.log('mapped' + this.speeds);
            },
            error => console.log('ERROR: ' + error));

        //for (let entry in this.speeds) {
        //    console.log(entry); // 1, "string", false
        //}

    }

}
