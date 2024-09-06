import { Component, OnInit } from '@angular/core';
import { IPhotos } from '../../models/photos';
import { ActivatedRoute, Router } from '@angular/router';
import { PhotosService } from '../../shared/photos.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from './confirmation-dialog.component';

@Component({
  selector: 'app-photo-detail',
  templateUrl: './photo-detail.component.html',
  styleUrls: ['./photo-detail.component.css'],
})
export class PhotoDetailComponent implements OnInit {
  errorMessage = '';
  photo: IPhotos | undefined;
  loading: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private photoService: PhotosService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      const id = +param;
      this.getPhoto(id);
    }
  }

  getPhoto(id: number): void {
    this.loading = true;

    this.photoService.getPhoto(id).subscribe({
      next: (photo) => {
        this.photo = photo;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading photo details', err);
        this.errorMessage = err;
        this.loading = false;
      },
    });
  }

  onDelete(): void {
    if (this.photo) {
      const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
        data: { message: 'Are you sure you want to delete this photo?' },
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          if (this.photo) {
            const id = this.photo.id;
            this.photoService.deleteProduct(id).subscribe({
              next: () => this.onDeleteComplete(),
              error: (err) => {
                console.error('Error deleting photo', err);
                this.errorMessage = err;
              },
            });
          }
        }
      });
    }
  }

  private onDeleteComplete(): void {
    this.router.navigate(['/photos']);
  }

  onBack(): void {
    this.router.navigate(['/photos']);
  }

  GotoEdit(): void {
    this.router.navigate(['/photos', this.photo?.id, 'edit']);
  }
}
