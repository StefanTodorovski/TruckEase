import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterCompanyUserRequest } from '../../models/requests/registerCompanyUserRequest';
import { CompanyUserApiService } from '../../services/companyUser/company-user-api.service';
import { Subscription, switchMap } from 'rxjs';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { CompanyApiService } from '../../services/company/company-api.service';
import { CompanyType } from '../../models/enums/companyType';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
    
 private register$: Subscription = new Subscription;
 public registerForm!: FormGroup;
 public isLoading = false;


  constructor(
    private fb: FormBuilder,
    private companyUserApiService: CompanyUserApiService,
    private router: Router,
    private dialog: MatDialog,
    private currentUserApiService: CurrentUserApiService,
    private companyApiService: CompanyApiService
) {}

  private createForm(): void {
    this.registerForm = this.fb.group({
        email: ['', [Validators.required, Validators.email]],
        firstName: ['', [Validators.required, Validators.maxLength(15)]],
        lastName: ['', [Validators.required, Validators.maxLength(15)]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', Validators.required]
      }, { validator: this.passwordMatchValidator });
}

  ngOnInit(): void {
    this.fetchComponentData();

  }

  public fetchComponentData(): void {
    this.createForm();
  }

  public get form(): { [key: string]: AbstractControl } {
    return this.registerForm.controls;
  }

  passwordMatchValidator(form: FormGroup): { [key: string]: boolean } | null {
    return form.get('password')?.value === form.get('confirmPassword')?.value ? null : { mismatch: true };
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
        this.registerUser()
    }
  }

  public registerUser(): void {
    this.isLoading = true;
    const formData = this.registerForm.value;
    const registerCompanyUserRequest: RegisterCompanyUserRequest = {
        email: formData.email,
        password: formData.password,
        lastName: formData.lastName,
        firstName: formData.firstName,
    };

    this.register$ = this.companyUserApiService.register(registerCompanyUserRequest)
    .subscribe({
      next: (result) => {
        this.isLoading = false;
        if(!result.isUserInCompany){
          this.router.navigate(['/login']);
        }
        else{
          this.navigateToCompany();
        }
      },
      error: (error: { error: any; }) => {
        this.isLoading = false;
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'This email address is already in use. Please use a different one.' },
        });
      }
    });

  }

  public navigateToCompany(): void {
    this.currentUserApiService.getCurrentUser()
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
    if (this.register$) {
        this.register$.unsubscribe();
    }
}
}
