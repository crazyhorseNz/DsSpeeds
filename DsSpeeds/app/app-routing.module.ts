import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SpeedDetailComponent } from './speed-detail.component';
import { AllSpeedsComponent } from './all-speeds.component';

const routes: Routes = [
    { path: '', redirectTo: '/all', pathMatch: 'full' },
    { path: 'all', component: AllSpeedsComponent },
    { path: 'detail/:id', component: SpeedDetailComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {
    
}