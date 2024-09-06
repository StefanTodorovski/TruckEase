import {
  AfterViewInit,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChildren,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription, fromEvent, merge } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { IPhotos } from '../../models/photos';
import { PhotosService } from '../../shared/photos.service';
import { GenericValidator } from '../../shared/generic-validator';
import { ConfirmationDialogComponent } from './confirmation-dialog.component';
import { SnackbarService } from '../../shared/snackbar.service';

@Component({
  selector: 'app-edit-photo',
  templateUrl: './edit-photo.component.html',
  styleUrls: ['./edit-photo.component.css'],
})
export class EditPhotoComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChildren('formControl') formInputElements!: ElementRef[];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private photoService: PhotosService,
    private dialog: MatDialog,
    private snackbarService: SnackbarService
  ) {
    this.validationMessages = {
      title: {
        required: 'Photo title is required.',
        minlength: 'Photo title must be at least three characters.',
        maxlength: 'Photo title cannot exceed 50 characters.',
      },
      url: {
        required: 'Photo url is required.',
      },
      thumbnailUrl: {
        required: 'Thumbnail URL is required.',
      },
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  errorMessage = '';
  photoForm!: FormGroup;
  pageTitle = 'Product Edit';
  photo!: IPhotos;
  private sub!: Subscription;

  displayMessage: { [key: string]: string } = {};
  private validationMessages!: { [key: string]: { [key: string]: string } };
  private genericValidator!: GenericValidator;

  ngOnInit(): void {
    this.photoForm = this.fb.group({
      title: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
        ],
      ],
      url: ['', Validators.required],
      thumbnailUrl: ['', Validators.required],
    });

    this.sub = this.route.paramMap.subscribe((params) => {
      const id = Number(this.route.snapshot.paramMap.get('id'));
      this.getPhoto(id);
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements.map(
      (formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur')
    );

    merge(this.photoForm.valueChanges, ...controlBlurs)
      .pipe(debounceTime(800))
      .subscribe((value) => {
        this.displayMessage = this.genericValidator.processMessages(
          this.photoForm
        );
      });
  }

  getPhoto(id: number): void {
    this.photoService.getPhoto(id).subscribe({
      next: (photo: IPhotos) => this.displayProduct(photo),
      error: (err) => (this.errorMessage = err),
    });
  }

  displayProduct(photo: IPhotos): void {
    if (this.photoForm) {
      this.photoForm.reset();
    }
    this.photo = photo;

    if (this.photo.id > 0) {
      this.pageTitle = `Edit Photo: ${this.photo.title}`;
    } else {
      this.pageTitle = `Add Photo:`;
    }

    this.photoForm.patchValue({
      title: this.photo.title,
      url: this.photo.url,
      thumbnailUrl: this.photo.thumbnailUrl,
    });
  }

  deletePhoto(): void {
    if (this.photo.id === 0) {
      // Don't delete, it was never saved.
      this.onSaveComplete();
    } else if (this.photo.id) {
      if (confirm(`Really delete the product: ${this.photo.title}?`)) {
        this.photoService.deleteProduct(this.photo.id).subscribe({
          next: () => this.onSaveComplete(),
          error: (err) => (this.errorMessage = err),
        });
      }
    }
  }

  savePhoto(): void {
    if (this.photoForm.dirty) {
      const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
        data: {
          message: 'Are you sure you want to save the changes to this photo?',
        },
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          // User clicked "Save" in the confirmation dialog
          const p = { ...this.photo, ...this.photoForm.value };

          if (p.id === 0) {
            this.photoService.createProduct(p).subscribe({
              next: () => {
                this.snackbarService.showSuccessMessage(
                  'Photo added successfully'
                );
                this.onSaveComplete();
              },
              error: (err) => (this.errorMessage = err),
            });
          } else {
            this.photoService.updateProduct(p).subscribe({
              next: () => {
                this.snackbarService.showSuccessMessage(
                  'Photo updated successfully'
                );
                this.onSaveComplete();
              },
              error: (err) => (this.errorMessage = err),
            });
          }
        }
      });
    } else {
      this.onSaveComplete();
    }
  }

  onSaveComplete(): void {
    this.photoForm.reset();
    this.router.navigate(['/photos']);
  }

  public openCancelConfirmationDialog(): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        message:
          'Are you sure you want to cancel editing? All changes will not be saved.',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.photoForm.reset();
        this.router.navigate(['/photos']);
      }
    });
  }
}
