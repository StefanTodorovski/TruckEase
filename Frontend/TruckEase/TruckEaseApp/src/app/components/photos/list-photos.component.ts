import { Component, OnDestroy, OnInit } from '@angular/core';
import { IPhotos } from '../../models/photos';
import { PhotosService } from '../../shared/photos.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackbarService } from '../../shared/snackbar.service';

@Component({
  selector: 'app-list-photos',
  templateUrl: './list-photos.component.html',
  styleUrls: ['./list-photos.component.css'],
})
export class ListPhotosComponent implements OnInit {
  imageWidth = 50;
  imageMargin = 2;
  errorMessage = '';
  loading: boolean = false;

  photos: IPhotos[] = [];
  pageSize = 5;
  currentPage = 1;
  totalPages = 0;
  isCardHovered: boolean = false;

  private successMessageSubscription!: Subscription;

  constructor(
    private photoService: PhotosService,
    private router: Router,
    private snackBar: MatSnackBar,
    private snackbarService: SnackbarService
  ) {}

  ngOnInit(): void {
    this.loadPhotos();
    this.subscribeToSuccessMessages();
  }

  private subscribeToSuccessMessages(): void {
    console.log('Subscribing to success messages...');
    this.successMessageSubscription =
      this.snackbarService.successMessage$.subscribe({
        next: (message) => {
          console.log('Received success message:', message);

          // Show success message using MatSnackBar
          this.snackBar.open(message, 'Close', {
            duration: 3000,
            horizontalPosition: 'center',
            verticalPosition: 'top',
          });
        },
        error: (error) => {
          console.error('Error in success message subscription:', error);
        },
        complete: () => {
          console.log('Success message subscription completed.');
        },
      });
  }

  loadPhotos(): void {
    this.loading = true;
    this.photoService.getPhotos().subscribe({
      next: (allPhotos) => {
        this.totalPages = Math.ceil(allPhotos.length / this.pageSize);

        const startIndex = (this.currentPage - 1) * this.pageSize;
        const endIndex = startIndex + this.pageSize;
        this.photos = allPhotos.slice(startIndex, endIndex);
        this.loading = false;
      },
      error: (err) => (this.errorMessage = err),
    });
  }

  onPageChange(page: number): void {
    this.currentPage = page;
    this.loadPhotos();
  }

  getPages(): number[] {
    const pages: number[] = [];
    const startPage = Math.max(1, this.currentPage - 1);
    const endPage = Math.min(this.totalPages, this.currentPage + 1);

    if (startPage > 1) {
      pages.push(1);
    }

    for (let i = startPage; i <= endPage; i++) {
      pages.push(i);
    }

    if (endPage < this.totalPages) {
      pages.push(this.totalPages);
    }

    return pages;
  }

  goToDetails(photoId: number): void {
    this.router.navigate(['/photos', photoId]);
  }

  onCardHover(hovered: boolean): void {
    this.isCardHovered = hovered;
  }
}
