import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'my-app',
    template: `
    <h1>DS Speeds</h1>
    <nav>
      <a routerLink="/all" routerLinkActive="active">All</a>
    </nav>
    <router-outlet></router-outlet>
    `,
   //styleUrls: ['../Content/bootstrap.css']
})
export class AppComponent {
}
