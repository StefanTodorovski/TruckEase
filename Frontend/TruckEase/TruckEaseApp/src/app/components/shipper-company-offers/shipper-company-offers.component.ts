import { Component, OnInit } from '@angular/core';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { TransportOfferInfoViewModel } from '../../models/view-models/transport-offer-info.view-model';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { switchMap, forkJoin, of } from 'rxjs';
import { OfferStatus } from '../../models/enums/offerStatus';
import { TransportOfferApiService } from '../../services/transport-offer/transport-offer-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CompanyInfoViewModel } from '../../models/view-models/company-view-model';
import { CompanyApiService } from '../../services/company/company-api.service';

@Component({
  selector: 'app-shipper-company-offers',
  templateUrl: './shipper-company-offers.component.html',
  styleUrls: ['./shipper-company-offers.component.scss']
})
export class ShipperCompanyOffersComponent implements OnInit {
  public offers: TransportOfferInfoViewModel[] = [];
  public filteredOffers: TransportOfferInfoViewModel[] = [];
  public offerStatuses = OfferStatus;
  public selectedStatus: OfferStatus | '' = '';
  public isLoading = false;
  public companyInfoMap: { [key: number]: CompanyInfoViewModel } = {};

  constructor(
    private transportOfferApiService: TransportOfferApiService,
    private currentUserService: CurrentUserApiService,
    private companyApiService: CompanyApiService,
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
          return this.transportOfferApiService.getAllOffersForShipperCompany(user.inCompanyFK);
        }),
        switchMap(offers => {
          this.offers = offers;
          const companyInfoCalls = offers.map(offer => 
            this.companyInfoMap[offer.requesterCompanyId]
              ? of(this.companyInfoMap[offer.requesterCompanyId])
              : this.companyApiService.getCompanyInfo(offer.requesterCompanyId)
          );
          return forkJoin(companyInfoCalls);
        })
      )
      .subscribe({
        next: (companyInfos) => {
          companyInfos.forEach((companyInfo, index) => {
            const requesterCompanyId = this.offers[index].requesterCompanyId;
            this.companyInfoMap[requesterCompanyId] = companyInfo;
          });
          this.filteredOffers = this.offers;
        },
        error: () => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Error fetching offers or company information, please contact support.' },
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

  acceptOffer(offerId: number): void {
    this.isLoading = true;
    this.transportOfferApiService.acceptOffer(offerId)
    .subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open(
          'You successfully accepted this offer. Now you can see more details in Active Transports tab',
          'Close',
          { duration: 5000 }
        );
        this.fetchOffers();
      },
      error: () => {
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'Failed to accept the offer. Please try again later.' },
        });
      }
    });
  }

  declineOffer(offerId: number): void {
    this.isLoading = true;
    this.transportOfferApiService.declineOffer(offerId)
    .subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open(
          'You successfully declined this offer.',
          'Close',
          { duration: 5000 }
        );
        this.fetchOffers();
      },
      error: () => {
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'Failed to decline the offer. Please try again later.' },
        });
      }
    });
  }

  getCompanyInfo(offer: TransportOfferInfoViewModel): CompanyInfoViewModel | undefined {
    return this.companyInfoMap[offer.requesterCompanyId];
  }
}
