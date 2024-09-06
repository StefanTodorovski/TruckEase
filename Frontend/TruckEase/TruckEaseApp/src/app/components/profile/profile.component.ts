import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyUserApiService } from '../../services/companyUser/company-user-api.service';
import { CompanyUserInfoViewModel } from '../../models/view-models/company-user-info.view-model';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { switchMap } from 'rxjs/operators';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { EditCompanyUserRequest } from '../../models/requests/editCompanyUserRequest';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-profile-settings',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public currentUser: CurrentUserViewModel = new CurrentUserViewModel();
  public userInfo: CompanyUserInfoViewModel = new CompanyUserInfoViewModel();
  public profileForm!: FormGroup;
  public isEditing: boolean = false;
  public isLoading: boolean = false;

  constructor(
    private companyUserApiService: CompanyUserApiService,
    private currentUserService: CurrentUserApiService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    private snackBar: MatSnackBar
    ) {}

  ngOnInit(): void {
    this.loadUserInfo();
  }

  private loadUserInfo(): void {
    this.currentUserService.getCurrentUser()
      .pipe(
        switchMap(user => {
          this.currentUser = user;
          return this.companyUserApiService.getCompanyUserInfo(user.id);
        })
      )
      .subscribe({
        next: (result) => {
          this.userInfo = result;
          this.initializeForm();
        },
        error: (error: { error: any; }) => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'There is no match for the entered credentials.' },
          });
        }
      });
  }

  private initializeForm(): void {
    this.profileForm = this.fb.group({
      firstName: [{ value: this.userInfo.firstName, disabled: true }, Validators.required],
      lastName: [{ value: this.userInfo.lastName, disabled: true }, Validators.required],
      email: [{ value: this.userInfo.email, disabled: true }],
      workPhone: [{ value: this.userInfo.workPhone || '', disabled: true }, Validators.pattern(/^\d{10}$/)],
      mobilePhone: [{ value: this.userInfo.mobilePhone || '', disabled: true }, Validators.pattern(/^\d{10}$/)],
    });
  }

  public toggleEdit(): void {
    this.isEditing = !this.isEditing;
    if (this.isEditing) {
      this.profileForm.enable();
      this.profileForm.get('email')?.disable();
    } else {
      this.profileForm.disable();
      this.profileForm.get('email')?.disable();
      this.saveChanges();
    }
  }

  private saveChanges(): void {
    this.isLoading = true;
    const formData = this.profileForm.value;
    const editCompanyUserRequest: EditCompanyUserRequest = {
      firstName: formData.firstName,
      lastName: formData.lastName,
      mobilePhone: formData.mobilePhone,
      workPhone: formData.workPhone
    };

    this.companyUserApiService.editCompanyUser(this.currentUser.id, editCompanyUserRequest)
      .subscribe({
        next: () => {
          this.isLoading = false;
          this.snackBar.open(
            'You successfully changed your company details.',
            'Close',
            { duration: 5000 }
          );
        },
        error: () => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Failed to update user information. Please try again later.' },
          });
        }
      });
  }
}
