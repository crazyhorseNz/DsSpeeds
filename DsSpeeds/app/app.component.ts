import { Component } from '@angular/core';
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
        <speedlist [speeds]="speeds">></speedlist>
    </div>
    `
})

export class AppComponent {
    speeds: Speed[];
    constructor(private speedService: SpeedService) {
        this.speeds = speedService.getSpeeds();
    }
}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/