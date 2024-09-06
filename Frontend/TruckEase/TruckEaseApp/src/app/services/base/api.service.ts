import { HttpClient, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
	providedIn: 'root'
})
export class ApiService {
  private httpHeaders: HttpHeaders = new HttpHeaders({
  	'Content-Type': 'application/json',
  	'Accept': 'application/json'
  });

  constructor(private http: HttpClient) {}

  private getAuthHeaders(): HttpHeaders {
  	const token = localStorage.getItem('jwtToken');
  	if (token) {
  		return this.httpHeaders.set('Authorization', `Bearer ${token}`);
  	}
  	return this.httpHeaders;
  }

  public get<T>(url: string, params: HttpParams = new HttpParams()): Observable<T> {
  	return this.http.get<T>(`${environment.baseApiUrl}${url}`, { headers: this.getAuthHeaders(), params });
  }

  public getWithOriginalUrl<T>(url: string, responseType: string, parameters: HttpParams = new HttpParams()): Observable<T> {
  	const options = {
  		headers: this.getAuthHeaders(),
  		params: parameters,
  		origin: window.location.host
  	};

  	return this.http.get<T>(`${url}`, options);
  }

  public getWithHeaderAppend<T>(url: string, name: string, value: string, params: HttpParams = new HttpParams()): Observable<T> {
  	return this.http.get<T>(`${environment.baseApiUrl}${url}`, { headers: this.getAuthHeaders().append(name, value), params });
  }

  public post<T>(url: string, data: Object = { }): Observable<T> {
  	return this.http.post<T>(`${environment.baseApiUrl}${url}`, JSON.stringify(data), { headers: this.getAuthHeaders() });
  }

  public put<T>(url: string, data: Object = { }): Observable<T> {
  	return this.http.put<T>(`${environment.baseApiUrl}${url}`, JSON.stringify(data), { headers: this.getAuthHeaders() });
  }

  public delete<T>(url: string): Observable<T> {
  	return this.http.delete<T>(`${environment.baseApiUrl}${url}`, { headers: this.getAuthHeaders() });
  }

  public deleteWithBody<R>(url: string, data: Object = { }): Observable< R> {
  	return this.http.request<R>('delete', `${environment.baseApiUrl}${url}`, { body: JSON.stringify(data), headers: this.getAuthHeaders() });
  }

  public patch<T>(url: string, data: Object = { }): Observable<T> {
  	return this.http.patch<T>(`${environment.baseApiUrl}${url}`, JSON.stringify(data), { headers: this.getAuthHeaders() });
  }

  public request(request: HttpRequest<any>): Observable<any> {
  	return this.http.request(request.clone({
  		headers: this.getAuthHeaders()
  	}));
  }
}
