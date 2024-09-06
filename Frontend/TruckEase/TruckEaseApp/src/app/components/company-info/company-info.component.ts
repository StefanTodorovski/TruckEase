import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CurrentUserService } from '../../services/current-user.service.ts/current-user.service';
import { CompanyApiService } from '../../services/company/company-api.service';
import { CompanyInfoViewModel } from '../../models/view-models/company-view-model';
import { switchMap } from 'rxjs/operators';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { EditCompanyRequest } from '../../models/requests/editCompanyRequest';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-company-info',
  templateUrl: './company-info.component.html',
  styleUrls: ['./company-info.component.scss']
})
export class CompanyInfoComponent implements OnInit {
  public companyInfo!: CompanyInfoViewModel;
  public isLoading: boolean = false;
  public isEditing: boolean = false;
  public errorMessage: string = '';
  public companyForm!: FormGroup;
  public currentUser!: CurrentUserViewModel;

  constructor(
    private currentUserService: CurrentUserApiService,
    private companyService: CompanyApiService,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.fetchCompanyInfo();
  }

  private fetchCompanyInfo(): void {
    this.isLoading = true;
    this.currentUserService.getCurrentUser()
      .pipe(
        switchMap(user => {
          this.currentUser = user;
          return this.companyService.getCompanyInfo(user.inCompanyFK);
        })
      )
      .subscribe({
        next: (companyInfo: CompanyInfoViewModel) => {
          this.isLoading = false;
          this.companyInfo = companyInfo;
          this.initializeForm();
        },
        error: () => {
          this.isLoading = false;
          this.errorMessage = 'Failed to load company information. Please try again later.';
        }
      });
  }

  private initializeForm(): void {
    this.companyForm = this.fb.group({
      companyName: [{ value: this.companyInfo.companyName, disabled: true }],
      registrationNumber: [{ value: this.companyInfo.registrationNumber, disabled: true }],
      description: [{ value: this.companyInfo.description, disabled: true }],
      companyType: [{ value: this.companyInfo.companyType, disabled: true }]
    });
  }

  private getCompanyTypeLabel(companyType: number): string {
    return companyType === 0 ? 'Transporter' : 'Shipper';
  }

  public toggleEdit(): void {
    this.isEditing = !this.isEditing;
    if (this.isEditing) {
      this.companyForm.enable();
      this.companyForm.controls['companyType'].disable(); // Ensure companyType stays disabled
    } else {
      this.companyForm.disable();
      this.saveChanges();
    }
  }

  private saveChanges(): void {

    this.isLoading = true;
    const formData = this.companyForm.value;
    const editCompany: EditCompanyRequest = {
      companyName: formData.companyName,
      registrationNumber: formData.registrationNumber,
      description: formData.description
    };

    this.companyService.editCompany(this.currentUser.inCompanyFK ,editCompany)
      .subscribe({
        next: () => {
          this.isLoading = false;
          this.snackBar.open(
            'You successfully changed your company details.',
            'Close',
            { duration: 5000 }
          );
    
        },
        error: (error: { error: any; }) => {
          this.isLoading = false;
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Company with same registration number exists, try with a different one.' },
          });
          this.fetchCompanyInfo();
        }
      });
  }
}
