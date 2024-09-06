import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterCompanyRequest } from '../../models/requests/registerCompanyRequest';
import { Subscription, switchMap } from 'rxjs';
import { CompanyApiService } from '../../services/company/company-api.service';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { CompanyType } from '../../models/enums/companyType';
import { Router } from '@angular/router';
import { CurrentUserService } from '../../services/current-user.service.ts/current-user.service';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';

@Component({
  selector: 'app-register-company',
  templateUrl: './register-company.component.html',
  styleUrls: ['./register-company.component.scss']
})
export class RegisterCompanyComponent implements OnInit, OnDestroy {

  public currentUser: CurrentUserViewModel = new CurrentUserViewModel;
  private register$: Subscription = new Subscription;
  public registerCompanyForm!: FormGroup;
  public isLoading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private companyApiService: CompanyApiService,
    private dialog: MatDialog,
    private router: Router,
    private currentUserService: CurrentUserApiService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.createForm();
  }

  private createForm(): void {
    this.registerCompanyForm = this.fb.group({
      companyName: ['', [Validators.required, Validators.maxLength(50)]],
      registrationNumber: ['', [Validators.required, Validators.maxLength(20)]],
      companyType: ['', Validators.required],
      description: ['', [Validators.required, Validators.maxLength(200)]]  
      });
  }

  public onSubmit(): void {
    if (this.registerCompanyForm.valid) {
      this.createCompany();
  }
}

public createCompany(): void {
  this.isLoading = true;
  const formData = this.registerCompanyForm.value;
  const registerCompanyRequest: RegisterCompanyRequest = {
    companyName: formData.companyName,
    companyType: formData.companyType,
    registrationNumber: formData.registrationNumber,
    description: formData.description
  };


 this.register$ =  this.currentUserService.getCurrentUser()
  .pipe(
    switchMap(user => {
      this.currentUser = user;
      return this.companyApiService.registerCompany(registerCompanyRequest, this.currentUser.id);
    })
  )
  .subscribe({
    next: (result) => {
      this.isLoading = false;
      this.snackBar.open(
        'You successfully registered a company. Log in to explore TruckEase.',
        'Close',
        { duration: 5000 }
      );

      // if(result.companyType === CompanyType.Transporter){
      //   this.router.navigate(['/admin-transporter']);
      // } else if (result.companyType === CompanyType.Shipper){
      //   this.router.navigate(['/admin-shipper']);
      // };
      this.router.navigate(['/login']);

    },
    error: (error: { error: any; }) => {
      this.isLoading = false;
      this.dialog.open(ErrorDialogComponent, {
        data: { message: 'Company with same registration number exists, try with a different one.' },
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
