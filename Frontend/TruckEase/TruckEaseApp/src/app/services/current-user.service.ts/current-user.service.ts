import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CurrentUserApiService } from '../auth-service/current-user-api.service';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {
  private currentUserSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public currentUser$: Observable<any> = this.currentUserSubject.asObservable();

  constructor(private currentUserApiService: CurrentUserApiService) {
    this.loadCurrentUser();
  }

  private loadCurrentUser(): void {
    this.currentUserApiService.getCurrentUser().subscribe(user => {
      this.currentUserSubject.next(user);
    });
  }

  public getCurrentUser(): Observable<any> {
    return this.currentUser$;
  }

  public setCurrentUser(user: any): void {
    this.currentUserSubject.next(user);
  }
}
