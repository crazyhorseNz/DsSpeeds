import { Component } from '@angular/core';


@Component({
    moduleId: module.id,
    selector: 'my-app',
    template: `
    <h1>DS Speeds</h1>
    <nav>
      <a routerLink="/all" routerLinkActive="active">All</a>
      <a routerLink="/detail/1" routerLinkActive="active">First</a>
      <a routerLink="/detail/2" routerLinkActive="active">Second</a>
    </nav>
    <router-outlet></router-outlet>
    `
})
//@Injectable()
//export class AppComponent implements OnInit {
export class AppComponent {
    //public speeds: Object[];
    //constructor(private speedService: SpeedService) {
    //}

    //ngOnInit() {
    //    this.speedService.getSpeeds()
    //        .subscribe(speeds => {
    //            console.log(speeds);
    //            this.speeds = speeds; 
    //            console.log(this.speeds);
    //        },
    //        error => console.log('ERROR: ' + error));

    //}

}
