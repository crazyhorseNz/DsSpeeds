import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map'

@Injectable()
export class SpeedService {

    constructor(private http: Http) {
    }

    getSpeeds() {
        return this.http.get('api/speed/')
            .map((res: Response) => res.json());
    }

    getSite(id: string) {
        return this.http.get('api/site/' + id)
            .map((res: Response) => res.json());
    }

    getSpeed(id: string) {
        return this.http.get('api/speed/' + id)
            .map((res: Response) => res.json());
    }



}
