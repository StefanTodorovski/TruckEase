import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeType } from '../../models/enums/employeeType';
import { CompanyEmployeeApiService } from '../../services/company-employee/company-employee-api.service';
import { CreateCompanyEmployeeRequest } from '../../models/requests/createCompanyEmployeeRequest';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-employee',
  templateUrl: './company-employee.component.html',
  styleUrls: ['./company-employee.component.scss']
})
export class CompanyEmployeeComponent implements OnInit, OnDestroy {

  private register$: Subscription = new Subscription;  
  public employeeForm!: FormGroup;
  public employeeTypes = EmployeeType;
  public isLoading = false;

  constructor(
    private fb: FormBuilder,
    private companyEmployeeApiService: CompanyEmployeeApiService,
    private dialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  private initializeForm(): void {
    this.employeeForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      employeeType: ['', Validators.required]
    });
  }

  public onSubmit(): void {
    if (this.employeeForm.valid) {
        this.isLoading = true;
        const formData = this.employeeForm.value;
        const createCompanyEmployeeRequest: CreateCompanyEmployeeRequest = {
            email: formData.email,
            lastName: formData.lastName,
            firstName: formData.firstName,
            employeeType: formData.employeeType
        };
    
        this.register$ = this.companyEmployeeApiService.createCompanyEmployee(createCompanyEmployeeRequest)
        .subscribe({
          next: (result) => {
            this.isLoading = false;
          },
          error: (error: { error: any; }) => {
            this.isLoading = false;
            this.dialog.open(ErrorDialogComponent, {
              data: { message: 'Company Employee with that email already exist.' },
            });
          }
        });
    }
  }

  public goBack(): void {
    this.router.navigate(['/admin-shipper/employees']);
  }

  public ngOnDestroy(): void {
    if (this.register$) {
        this.register$.unsubscribe();
    }
}
}
