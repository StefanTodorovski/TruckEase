import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IPhotos } from '../models/photos';

@Injectable({
  providedIn: 'root',
})
export class PhotosService {
  private baseUrl = 'https://jsonplaceholder.typicode.com/photos';
  private localPhotos: IPhotos[] = [];

  constructor(private http: HttpClient) {}

  getPhotos(): Observable<IPhotos[]> {
    if (this.localPhotos.length > 0) {
      // If local data is available, return it
      return of(this.localPhotos);
    } else {
      // Otherwise, fetch data from the API
      return this.http.get<IPhotos[]>(this.baseUrl).pipe(
        tap((data) => {
          console.log('getData');
          this.localPhotos = data; // Update local data with fetched data
        }),
        catchError(this.handleError)
      );
    }
  }

  getPhoto(id: number): Observable<IPhotos> {
    if (id === 0) {
      return of(this.initializePhoto());
    }
    const url = `${this.baseUrl}/${id}`;
    const localPhoto = this.localPhotos.find((photo) => photo.id === id);

    if (localPhoto) {
      // If the photo is found in local data, return it
      return of(localPhoto);
    } else {
      // Otherwise, fetch the photo from the API
      return this.http.get<IPhotos>(url);
    }
  }

  createProduct(photo: IPhotos): Observable<IPhotos> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    // Find the maximum ID currently present in local data
    const maxId =
      this.localPhotos.length > 0
        ? Math.max(...this.localPhotos.map((photo) => photo.id))
        : 0;

    // Assign the next available ID to the new photo because it can not find id
    // greater than 5000 from the api
    photo.id = maxId + 1;

    // Update local data with the new photo
    this.localPhotos.push(photo);

    return this.http.post<IPhotos>(this.baseUrl, photo, { headers }).pipe(
      tap((data) => console.log('createProduct: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  updateProduct(photo: IPhotos): Observable<IPhotos> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.baseUrl}/${photo.id}`;

    // Check if the photo ID is greater than 5000
    if (photo.id > 5000) {
      // Update local data
      const updatedLocalPhotos = this.localPhotos.map((p) =>
        p.id === photo.id ? { ...p, ...photo } : p
      );

      // Update local data without sending HTTP request
      this.localPhotos = updatedLocalPhotos;

      // Return an observable with the updated local data
      return of(photo);
    }

    // If photo ID is not greater than 5000, proceed with HTTP request
    return this.http.put<IPhotos>(url, photo, { headers }).pipe(
      tap(() => {
        console.log('updatePhoto: ' + photo.id);
        // Update local data after successful API update
        this.localPhotos = this.localPhotos.map((p) =>
          p.id === photo.id ? { ...p, ...photo } : p
        );
      }),
      map(() => photo),
      catchError(this.handleError)
    );
  }

  deleteProduct(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.baseUrl}/${id}`;

    // Update local data by removing the deleted photo
    this.localPhotos = this.localPhotos.filter((photo) => photo.id !== id);

    return this.http.delete<IPhotos>(url, { headers }).pipe(
      tap((data) => console.log('deleteProduct: ' + id)),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }

  private initializePhoto(): IPhotos {
    // Return an initialized object
    return {
      id: 0,
      title: '',
      url: '',
      thumbnailUrl: '',
      albumId: 1,
    };
  }
}
