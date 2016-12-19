import { Component, Input } from '@angular/core';
import { Speed } from './speed';

@Component({
    moduleId: module.id,
    selector: 'speedlist',
    templateUrl: './html/speedlist.component.html'
})

export class SpeedListComponent {
    @Input()
    speeds: Speed[];
}
