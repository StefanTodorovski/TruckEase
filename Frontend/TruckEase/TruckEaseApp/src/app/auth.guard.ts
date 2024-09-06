import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { CurrentUserApiService } from './services/auth-service/current-user-api.service';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private currentUserService: CurrentUserApiService
  ) {}

  canActivate(): Promise<boolean> {
    return new Promise((resolve) => {
      this.currentUserService.getCurrentUser()
        .pipe(
          map(result => {
            if (result && (result.id >= 1)) {
              resolve(true);
            } else {
              resolve(false);
            }
          }),
          catchError(() => {
            resolve(false);
            return of(false);
          })
        )
        .subscribe();
    });
  }
}
