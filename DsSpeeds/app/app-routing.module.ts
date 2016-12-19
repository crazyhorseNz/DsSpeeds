import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SpeedListComponent } from './speedlist.component';
import { AllSpeedsComponent } from './allspeeds.component';

const routes: Routes = [
    { path: '', redirectTo: '/allspeeds', pathMatch: 'full' },
    { path: 'speedlist', component: SpeedListComponent },
    { path: 'allspeeds', component: AllSpeedsComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {}