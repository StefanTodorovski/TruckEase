import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginCompanyUserRequest } from '../../models/requests/loginCompanyUserRequest';
import { Subscription, switchMap } from 'rxjs';
import { CompanyUserApiService } from '../../services/companyUser/company-user-api.service';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { Router } from '@angular/router';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { CompanyApiService } from '../../services/company/company-api.service';
import { CompanyType } from '../../models/enums/companyType';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  private login$: Subscription = new Subscription;
  public loginForm!: FormGroup;
  public isLoading = false;
  public currentUser: CurrentUserViewModel = new CurrentUserViewModel;

  constructor(
    private fb: FormBuilder,
    private companyUserApiService: CompanyUserApiService,
    private dialog: MatDialog,
    private router: Router,
    private currentUserService: CurrentUserApiService,
    private companyApiService: CompanyApiService
  ) {}

  ngOnInit(): void {
    this.createForm();
  }

  private createForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  public get form() {
    return this.loginForm.controls;
  }

 public onSubmit(): void {
    if (this.loginForm.valid) {
      this.isLoading = true;
      const formData = this.loginForm.value;
      const loginCompanyUserRequest: LoginCompanyUserRequest = {
          email: formData.email,
          password: formData.password
      };
  
      this.login$ = this.companyUserApiService.login(loginCompanyUserRequest)
      .subscribe({
        next: (result) => {
          const token = result.token;
          localStorage.setItem('jwtToken', token);
          if (!result.isUserInCompany){
            this.router.navigate(['/register-company']);
          } else {
            this.navigateToCompany();
          }
        },
        error: (error: { error: any; }) => {
          this.isLoading = false;
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'There is no match for the entered credentials.' },
          });
        }
      });
    }
  }

  public navigateToCompany(): void {
    this.currentUserService.getCurrentUser()
      .pipe(
        switchMap((currentUser) => {
          const companyId = currentUser.inCompanyFK;
          return this.companyApiService.getCompanyInfo(companyId);
        })
      )
      .subscribe({
        next: (result) => {
          if (result.companyType === CompanyType.Transporter) {
            this.router.navigate(['/admin-transporter']);
          } else if (result.companyType === CompanyType.Shipper) {
            this.router.navigate(['/admin-shipper']);
          }
        },
        error: (error: { error: any; }) => {
          this.isLoading = false;
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Error, please contact support.' },
          });
        }
      });
  }
  


  public ngOnDestroy(): void {
    if (this.login$) {
        this.login$.unsubscribe();
    }
}
}
