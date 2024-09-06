import { Component, OnInit } from '@angular/core';
import { RequestInfoViewModel } from '../../models/view-models/request-info.view-model';
import { TransportRequestApiService } from '../../services/transportRequest/transport-request-api.service';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { switchMap } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { MakeOfferDialogComponent } from '../../services/dialogues/create-transport-offer-dialogue/make-offer-dialog.component';

@Component({
  selector: 'app-transporter-request-page',
  templateUrl: './transporter-request-page.component.html',
  styleUrls: ['./transporter-request-page.component.scss']
})
export class TransporterRequestPageComponent implements OnInit {

  public requests: RequestInfoViewModel[] = [];
  public toggledIndexes: Set<number> = new Set();

  constructor(
    private transportRequestApiService: TransportRequestApiService,
    private currentUserService: CurrentUserApiService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.fetchPublishedRequests();
  }

  fetchPublishedRequests(): void {
    this.currentUserService.getCurrentUser()
    .pipe(
      switchMap(user => {
        return this.transportRequestApiService.getAllPublishedRequests();
      })
    )
    .subscribe({
      next: (result) => {
        this.requests = result;
      },
      error: (error: { error: any; }) => {
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'Error fetching requests, please contact support.' },
        });
      }
    });
  }

  toggleDetails(index: number): void {
    if (this.toggledIndexes.has(index)) {
      this.toggledIndexes.delete(index);
    } else {
      this.toggledIndexes.add(index);
    }
  }

  makeOffer(id: number, price: number): void {
    const dialogRef = this.dialog.open(MakeOfferDialogComponent, {
      width: '400px',
      data: { transportRequestId: id, requestPrice: price }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Offer submitted successfully');
      }
    });
  }
}
