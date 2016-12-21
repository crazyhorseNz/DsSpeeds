import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map'

import { Speed } from './speed';

@Injectable()
export class SpeedService {

    private heroesUrl = 'api/speed';  // URL to web API

    constructor(private http: Http) {

    }

    getSpeeds() {
        return this.http.get(this.heroesUrl)
            .map((res: Response) => res.json());
    }



}
