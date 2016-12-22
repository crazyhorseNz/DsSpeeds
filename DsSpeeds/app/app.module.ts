import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule} from '@angular/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { SpeedService } from './speed.service';
import { SpeedListComponent } from './speedlist.component';
import { SpeedDetailComponent } from './speed-detail.component';
import { AllSpeedsComponent } from './all-speeds.component';
import { SiteSpeedsComponent } from './site-speeds.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        AppRoutingModule,
    ],
    declarations: [
        AppComponent,
        SpeedListComponent, 
        SpeedDetailComponent,
        AllSpeedsComponent,
        SiteSpeedsComponent
    ],
    bootstrap: [AppComponent],
    providers: [SpeedService]
})
export class AppModule { }
