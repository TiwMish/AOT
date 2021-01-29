import {HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { pallModel } from "./pallModel.model";


@Injectable({
    providedIn: 'root'
  })
export class pall {
    word : pallModel = new pallModel();
    readonly baseURL = 'http://localhost:50594/api';

    constructor(private http: HttpClient) { }
    
    postProduct() {  
        return this.http.post(this.baseURL + '/Pallindromes', this.word);
        
      } 


}
