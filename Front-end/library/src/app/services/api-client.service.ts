import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class ApiClientService {

  constructor(private http: HttpClient) { }

  get<T>(url: string): Observable<any> {
    return this.http.get<T>(url, httpOptions);
  }

  post<T>(url: string, data: any): Observable<any> {
    return this.http.post<T>(url, data, httpOptions);
  }

  put<T>(url: string, data: any): Observable<any> {
    return this.http.put<T>(url, data, httpOptions);
  }

  delete(url: string): Observable<any> {
    return this.http.delete(url, httpOptions);
  }
}
