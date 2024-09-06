import { Component, OnInit } from '@angular/core';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { TransportOfferInfoViewModel } from '../../models/view-models/transport-offer-info.view-model';
import { CompanyEmployeeViewModel } from '../../models/view-models/company-employee.view-model';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { TransportOfferApiService } from '../../services/transport-offer/transport-offer-api.service';
import { CompanyApiService } from '../../services/company/company-api.service';
import { CompanyEmployeeApiService } from '../../services/company-employee/company-employee-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { switchMap } from 'rxjs/operators';
import { CompanyInfoViewModel } from '../../models/view-models/company-view-model';
import { EmployeeType } from '../../models/enums/employeeType';

@Component({
  selector: 'app-shipper-company-active-transports',
  templateUrl: './active-transports-shipper-company.component.html',
  styleUrls: ['./active-transports-shipper-company.component.scss']
})
export class ShipperCompanyActiveTransportsComponent implements OnInit {
  public transports: TransportOfferInfoViewModel[] = [];
  public filteredTransports: TransportOfferInfoViewModel[] = [];
  public companyInfo: CompanyInfoViewModel | null = null;
  public supportEmployees: CompanyEmployeeViewModel[] = [];
  public isLoading = false;

  constructor(
    private transportOfferApiService: TransportOfferApiService,
    private currentUserService: CurrentUserApiService,
    private companyApiService: CompanyApiService,
    private companyEmployeeApiService: CompanyEmployeeApiService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.fetchTransports();
  }

  fetchTransports(): void {
    this.currentUserService.getCurrentUser()
      .pipe(
        switchMap(user => {
          return this.transportOfferApiService.getAllActiveTransportsForShipperCompany(user.inCompanyFK);
        })
      )
      .subscribe({
        next: (result) => {
          this.transports = result;
          this.filteredTransports = this.transports;
          if (this.transports.length > 0) {
            this.fetchCompanyInfo(this.transports[0].requesterCompanyId);
            this.fetchSupportEmployees(this.transports[0].requesterCompanyId);
          }
        },
        error: () => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Error fetching transports, please contact support.' },
          });
        }
      });
  }

  fetchCompanyInfo(companyId: number): void {
    this.companyApiService.getCompanyInfo(companyId)
      .subscribe({
        next: (companyInfo) => {
          this.companyInfo = companyInfo;
        },
        error: () => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Error fetching company info, please contact support.' },
          });
        }
      });
  }

  fetchSupportEmployees(companyId: number): void {
    this.companyEmployeeApiService.getAllCompaniesWithInfo(companyId)
      .subscribe({
        next: (employees) => {
          this.supportEmployees = employees.filter(employee => employee.employeeType === EmployeeType.CustomerSupport);
        },
        error: () => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Error fetching support employees, please contact support.' },
          });
        }
      });
  }

  calculateEstimatedDelivery(arrivalTime: Date): number {
    const now = new Date();
    const arrival = new Date(arrivalTime);
    const diffInMs = arrival.getTime() - now.getTime();
    return Math.ceil(diffInMs / (1000 * 60 * 60 * 24));
  }

  getEstimatedDeliveryColor(arrivalTime: Date): string {
    const days = this.calculateEstimatedDelivery(arrivalTime);

    if (days <= 0) {
      return 'red'; // Past due
    } else if (days <= 5) {
      return 'lightcoral'; // Near due
    } else if (days <= 10) {
      return 'lightgreen'; // Far due
    } else {
      return 'green'; // Safe
    }
  }

  showEstimatedDeliveryInfo(arrivalTime: Date): void {
    const days = this.calculateEstimatedDelivery(arrivalTime);
    this.snackBar.open(`Estimated Delivery: ${days} days`, 'Close', {
      duration: 3000
    });
  }
}
