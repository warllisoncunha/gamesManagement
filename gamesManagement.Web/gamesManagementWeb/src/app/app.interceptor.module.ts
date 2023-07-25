import { Injectable, NgModule } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable()
export class HttpsRequestInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var _user = localStorage.getItem('token');

        if(_user !== null && _user !== undefined && _user !== ''){
            const dupReq = req.clone({
                headers: req.headers.set('Authorization', (_user) ? 'Bearer ' + _user : '')
            });
            return next.handle(dupReq);
        }

        return next.handle(req);
    }
}
@NgModule({
    providers: [{
        provide: HTTP_INTERCEPTORS,
        useClass: HttpsRequestInterceptor,
        multi: true,
    }]
})
export class Interceptor { }