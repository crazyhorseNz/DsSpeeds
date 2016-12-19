import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { SpeedService } from './speed.service';

import { SpeedListComponent } from './speedlist.component';
import { AppComponent } from './app.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        SpeedListComponent,
    ],
    bootstrap: [AppComponent],
    providers: [SpeedService]
})
export class AppModule { }
