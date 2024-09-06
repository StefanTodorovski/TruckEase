import { Component, OnInit } from '@angular/core';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { TransportOfferInfoViewModel } from '../../models/view-models/transport-offer-info.view-model';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { switchMap } from 'rxjs/operators';
import { OfferStatus } from '../../models/enums/offerStatus';
import { TransportOfferApiService } from '../../services/transport-offer/transport-offer-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-transporter-company-offers',
  templateUrl: './transporter-company-offers.component.html',
  styleUrls: ['./transporter-company-offers.component.scss']
})
export class TransporterCompanyOffersComponent implements OnInit {
  public offers: TransportOfferInfoViewModel[] = [];
  public filteredOffers: TransportOfferInfoViewModel[] = [];
  public offerStatuses = OfferStatus;
  public selectedStatus: OfferStatus | '' = '';
  public isLoading = false;

  constructor(
    private transportOfferApiService: TransportOfferApiService,
    private currentUserService: CurrentUserApiService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.fetchOffers();
  }

  fetchOffers(): void {
    this.currentUserService.getCurrentUser()
      .pipe(
        switchMap(user => {
          return this.transportOfferApiService.getAllOffersMadeByCompany(user.inCompanyFK);
        })
      )
      .subscribe({
        next: (result) => {
          this.offers = result;
          this.filteredOffers = this.offers;
        },
        error: () => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Error fetching offers, please contact support.' },
          });
        }
      });
  }

  filterOffers(): void {
    if (this.selectedStatus) {
      this.filteredOffers = this.offers.filter(offer => offer.offerStatus === this.selectedStatus);
    } else {
      this.filteredOffers = this.offers;
    }
  }

  deleteOffer(offerId: number): void {
    this.isLoading = true;
    this.transportOfferApiService.removeOffer(offerId)
    .subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open(
          'You successfully removed this offer.',
          'Close',
          { duration: 5000 }
        );
        this.fetchOffers();
      },
      error: () => {
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'Failed to remove the offer. Please try again later.' },
        });
      }
    });
  }
}
