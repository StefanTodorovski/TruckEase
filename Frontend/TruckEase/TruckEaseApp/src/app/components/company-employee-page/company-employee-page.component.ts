import { Component, OnInit } from '@angular/core';
import { CompanyEmployeeApiService } from '../../services/company-employee/company-employee-api.service';
import { switchMap } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { CompanyEmployeeViewModel } from '../../models/view-models/company-employee.view-model';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeType } from '../../models/enums/employeeType';

@Component({
  selector: 'app-company-employee-page',
  templateUrl: './company-employee-page.component.html',
  styleUrls: ['./company-employee-page.component.scss']
})
export class CompanyEmployeePageComponent implements OnInit {

  public isLoading = true;
  public companyEmployees: CompanyEmployeeViewModel[] = [];
  public currentUser: CurrentUserViewModel = new CurrentUserViewModel;

  constructor(
    private currentUserApiService: CurrentUserApiService,
    private companyEmployeeApiService: CompanyEmployeeApiService,
    private router: Router,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.fetchData();
  }

  
  private fetchData(): void {
    this.isLoading = true;
    this.currentUserApiService.getCurrentUser()
      .pipe(
        switchMap(user => {
          this.currentUser = user;
          return this.companyEmployeeApiService.getAllCompaniesWithInfo(user.inCompanyFK);
        })
      )
      .subscribe({
        next: (result) => {
          this.isLoading = false;
          this.companyEmployees = result;
        },
        error: (error: { error: any; }) => {
            this.dialog.open(ErrorDialogComponent, {
              data: { message: 'Error getting company employees, please contact support.' },
            });
          }
      });
  }

  public onAddEmployee(): void {
    const urlPath = this.router.url;
    if (urlPath.includes('/admin-shipper/')) {
      this.router.navigate(['/admin-shipper/create-employee']);
    } else if (urlPath.includes('/admin-transporter/')) {
      this.router.navigate(['/admin-transporter/create-employee']);
    } else {
      console.error('Unknown layout or URL path');
    }
  }
  
  

}
