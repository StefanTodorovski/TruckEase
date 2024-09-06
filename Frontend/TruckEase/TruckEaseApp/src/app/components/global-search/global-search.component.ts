import { Component, OnInit } from '@angular/core';
import { CurrentUserService } from '../../services/current-user.service.ts/current-user.service';
import { switchMap } from 'rxjs/operators';
import { CompanyApiService } from '../../services/company/company-api.service';
import { CompanyInfoViewModel } from '../../models/view-models/company-view-model';
import { ContactCompanyApiService } from '../../services/contact-company/contact-company-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';

@Component({
  selector: 'app-global-search',
  templateUrl: './global-search.component.html',
  styleUrls: ['./global-search.component.scss']
})
export class GlobalSearchComponent implements OnInit {
  public companies: CompanyInfoViewModel[] = [];
  public isLoading: boolean = false;
  public errorMessage: string = '';

  constructor(
    private currentUserService: CurrentUserService,
    private companyService: CompanyApiService,
    private contactCompanyApiService: ContactCompanyApiService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog

  ) {}

  ngOnInit(): void {
    this.fetchCompanies();
  }

  private fetchCompanies(): void {
    this.isLoading = true;
    this.currentUserService.getCurrentUser()
      .pipe(
        switchMap(user => this.companyService.getAllCompaniesWithInfo()
          .pipe(
            switchMap(companies => {
              this.isLoading = false;
              this.companies = companies.filter(company => company.id !== user.inCompanyFK);
              return [];
            })
          )
        )
      )
      .subscribe({
        next: () => this.isLoading = false,
        error: (error) => {
          this.isLoading = false;
          this.errorMessage = 'Failed to load companies. Please try again later.';
        }
      });
  }


  public AddCompanyToSupplyChain(companyId: number) : void {
    this.isLoading = true;
    this.contactCompanyApiService.addCompanyAsContactCompany(companyId)
    .subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open(
          'You successfully added this company to supply chain.',
          'Close',
          { duration: 5000 }
        );
      },
      error: () => {
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'Failed to add the company to supply chain. Please try again later.' },
        });
      }
    });

  }
}
