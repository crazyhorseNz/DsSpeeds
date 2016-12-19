import { Injectable } from '@angular/core';

import { Speed } from './speed';
import { SPEEDS } from './mock-speeds';

@Injectable()
export class SpeedService {
    getSpeeds(): Speed[] {
        return SPEEDS;
    }
}
