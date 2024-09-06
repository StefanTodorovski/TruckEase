import { Component, OnInit } from '@angular/core';
import { CompanyApiService } from '../../services/company/company-api.service';
import { CompanyInfoViewModel } from '../../models/view-models/company-view-model';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { switchMap } from 'rxjs';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { ContactCompanyApiService } from '../../services/contact-company/contact-company-api.service';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-network-directory',
  templateUrl: './network-directory.component.html',
  styleUrls: ['./network-directory.component.scss']
})
export class NetworkDirectoryComponent implements OnInit {
  public companies: CompanyInfoViewModel[] = [];
  public isLoading: boolean = false;
  public errorMessage: string = '';
  public currentUser: CurrentUserViewModel = new CurrentUserViewModel;

  constructor(
    private contactCompaniesApiService: ContactCompanyApiService,
    private currentUserService: CurrentUserApiService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private router: Router

  ) {}

  ngOnInit(): void {
    this.fetchContactCompanies();
  }

  public fetchContactCompanies(): void {
    this.isLoading = true;
    this.currentUserService.getCurrentUser()
      .pipe(
        switchMap(user => {
          this.currentUser = user;
          return this.contactCompaniesApiService.getAllContactCompaniesWithInfo(user.inCompanyFK);
        })
      )
      .subscribe({
        next: (result) => {
            this.isLoading = false;
            this.companies = result;
        },
        error: (error: { error: any; }) => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Error getting contact companies, please contact support.' },
          });
        }
      });
  }

  public removeFromSupplyChain(companyId: number): void {

    this.isLoading = true;
    this.contactCompaniesApiService.removeContactCompany(companyId)
    .subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open(
          'You successfully removed this company from supply chain.',
          'Close',
          { duration: 5000 }
        );
        this.fetchContactCompanies();
      },
      error: () => {
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'Failed to remove the company from supply chain. Please try again later.' },
        });
      }
    });
  }

  public navigateToAddCompanies(): void{
    this.router.navigate(['admin-shipper/global-search']);
  }
}
