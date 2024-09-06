import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { TransportRequestApiService } from '../../services/transportRequest/transport-request-api.service';
import { CreateTransportRequest } from '../../models/requests/createTransportRequest';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { CurrentUserService } from '../../services/current-user.service.ts/current-user.service';
import { switchMap } from 'rxjs';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { Transport } from '../../models/enums/transportType';

@Component({
  selector: 'app-create-transport-request',
  templateUrl: './request-transport.component.html',
  styleUrls: ['./request-transport.component.scss']
})
export class CreateTransportRequestComponent implements OnInit {
  public transportRequestForm!: FormGroup;
  public isLoading: boolean = false;
  public transports = Object.values(Transport);
  public currentUser: CurrentUserViewModel = new CurrentUserViewModel();


  constructor(
    private fb: FormBuilder,
    private dialog: MatDialog,
    private router: Router,
    private transportRequestApiService: TransportRequestApiService,
    private currentUserService: CurrentUserService
  ) {}

  ngOnInit(): void {
    this.createForm();
  }

  private createForm(): void {
    this.transportRequestForm = this.fb.group({
      description: ['', [Validators.required, Validators.maxLength(200)]],
      startTime: ['', Validators.required],
      arrivalTime: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      startLocation: ['', Validators.required],
      destination: ['', Validators.required],
      isExpress: [false],
      loadWeight: [0, [Validators.required, Validators.min(0)]],
      isDraft: [false],
      transportType: ['', Validators.required],
    });
  }

  public onSubmit(): void {
    if (this.transportRequestForm.valid) {
      this.createTransportRequest();
    }
  }

  private createTransportRequest(): void {
    this.isLoading = true;
    const formData = this.transportRequestForm.value;
    const createTransportRequest: CreateTransportRequest = {
      Description: formData.description,
      StartTime: formData.startTime,
      ArrivalTime: formData.arrivalTime,
      StartLocation: formData.startLocation,
      Destination: formData.destination,
      IsExpress: formData.isExpress,
      LoadWeight: formData.loadWeight,
      IsDraft: formData.isDraft,
      TransportType: formData.transportType,
      Price: formData.price
    };

      this.currentUserService.getCurrentUser()
      .pipe(
        switchMap(user => {
          this.currentUser = user;
          return this.transportRequestApiService.createTransport(user.inCompanyFK, createTransportRequest);
        })
      )
      .subscribe({
        next: (result) => {
          this.router.navigate(['admin-shipper/all-requests']);
        },
        error: (error: { error: any; }) => {
          this.dialog.open(ErrorDialogComponent, {
            data: { message: 'Failed to create transport request. Please try again or contact support.' },
          });
        }
      });
  }

  public navigateToRequests(): void {
    this.router.navigate(['admin-shipper/all-requests']);
  }
}
