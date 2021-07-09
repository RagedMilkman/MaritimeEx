import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observer } from 'rxjs';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RESTService {

    private _ApiUrl : string;

    constructor(private _HttpClient : HttpClient) {
        this._ApiUrl = "http://localhost:5000/api/DataController";
    }

    public Get(endpoint: string) : Observable<any> {
        return this._HttpClient.get(this._ApiUrl + "/" + endpoint, { headers: this.CreateHeaders(), withCredentials: false, responseType: "json" });
    }

    private CreateHeaders() : HttpHeaders {
         let headers = new HttpHeaders(
             {
                 'Content-Type': 'application/json',
             }
         );
         return headers;
     }
}
