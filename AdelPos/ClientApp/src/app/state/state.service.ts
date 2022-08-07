import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import {stateModel} from './stateModel'

@Injectable({
    providedIn: 'root'
})

export class Stateservice{
private Url:string='http://localhost:62729/'
 constructor (private http:HttpClient){

}
public GetStateData(){
   debugger;
   const header = new HttpHeaders().set('content-type','application/json')
   return this.http.get<stateModel[]>(this.Url + 'api/state/GetStateData')
}




}
