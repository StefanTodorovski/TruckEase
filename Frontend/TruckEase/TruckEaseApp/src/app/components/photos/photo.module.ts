import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../shared/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ListPhotosComponent } from './list-photos.component';
import { RouterModule } from '@angular/router';
import { PhotoDetailComponent } from './photo-detail.component';
import { EditPhotoComponent } from './edit-photo.component';
import { ConfirmationDialogComponent } from './confirmation-dialog.component';
import { EditPhotoGuard } from '../not-found/NotFoundGuard';


@NgModule({
  declarations: [
    ListPhotosComponent,
    PhotoDetailComponent,
    EditPhotoComponent,
    ConfirmationDialogComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {path: 'photos', component: ListPhotosComponent },
      {path: 'photos/:id', component: PhotoDetailComponent },
      {path: 'photos/:id/edit',
       component: EditPhotoComponent,
       canDeactivate: [EditPhotoGuard]},
      
    ])

    
  ]
})
export class PhotoModule { }
