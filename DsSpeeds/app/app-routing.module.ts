import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SpeedDetailComponent } from './speed-detail.component';

const routes: Routes = [
    //{ path: '', redirectTo: '/', pathMatch: 'full' },
    //{ path: './detail/:id', component: SpeedDetailComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {
    
}