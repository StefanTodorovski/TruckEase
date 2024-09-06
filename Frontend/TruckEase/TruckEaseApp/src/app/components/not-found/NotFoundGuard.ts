import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { EditPhotoComponent } from '../photos/edit-photo.component';


@Injectable({
  providedIn: 'root'
})
export class EditPhotoGuard implements CanDeactivate<EditPhotoComponent>  {

  canDeactivate(component: EditPhotoComponent,
                currentRoute: ActivatedRouteSnapshot,
                currentState: RouterStateSnapshot,
                nextState?: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {

    if (component.photoForm.dirty) {
      const title = component.photo.title || 'New Photo';
      return confirm(`Navigate away and lose all changes to ${title}?`);
    }
    return true;
  }

}
