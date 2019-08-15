import { CanActivate } from '@angular/router';
import { Http } from '@angular/http';
import { PlatformLocation } from '@angular/common';
import { Injectable } from '@angular/core';
import { Observable, observable } from 'rxjs';

@Injectable()
export class LoggedInGuard implements CanActivate {
    constructor(private location: PlatformLocation, private http: Http) {

    }
    canActivate(): Observable<boolean> {

        return new Observable<boolean>((observer) => {
            this.http.get(this.location.pathname + 'api/account/IsLogined')
                .subscribe(value => {
                    observer.next(value.json());
                    observer.complete();
                });
        });
    }
    getLogined() {
        const data = this.http.get(this.location.pathname + 'api/account/IsLogined').toPromise();
        return data;
    }
    async Islogined() {
        const data = await this.getLogined();
        return data;
    }
}
