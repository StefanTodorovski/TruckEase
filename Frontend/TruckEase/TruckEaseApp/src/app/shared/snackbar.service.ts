import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';


@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  private successMessageSource = new Subject<string>();

  successMessage$ = this.successMessageSource.asObservable();

  showSuccessMessage(message: string) {
    console.log('Success message emitted:', message);
    this.successMessageSource.next(message);
  }
}
