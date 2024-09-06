import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TransportRequestApiService } from '../../transportRequest/transport-request-api.service';
import { RequestInfoViewModel } from '../../../models/view-models/request-info.view-model';
import { Transport } from '../../../models/enums/transportType';

@Component({
  selector: 'app-edit-request-dialog',
  templateUrl: './edit-transport-request-dialog.component.html',
  styleUrls: ['./edit-transport-request-dialog.component.scss']
})
export class EditRequestDialogComponent implements OnInit {
  editRequestForm!: FormGroup;
  transportTypes = Object.values(Transport);

  constructor(
    private fb: FormBuilder,
    private transportRequestApiService: TransportRequestApiService,
    private dialogRef: MatDialogRef<EditRequestDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: RequestInfoViewModel & { transportId: number }
  ) { }

  ngOnInit(): void {
    this.editRequestForm = this.fb.group({
      startLocation: [this.data.startLocation, Validators.required],
      destination: [this.data.destination, Validators.required],
      description: [this.data.description, Validators.required],
      price: [this.data.price, [Validators.required, Validators.min(0)]],
      loadWeight: [this.data.loadWeight, [Validators.required, Validators.min(0)]],
      transportType: [this.data.transportType, Validators.required],
      isExpress: [this.data.isExpress],
      isDraft: [this.data.isDraft],
      startTime: [this.data.startTime, Validators.required],
      arrivalTime: [this.data.arrivalTime, Validators.required]
    });
  }

  onSubmit(): void {
    if (this.editRequestForm.valid) {
      const updatedRequest = {
        ...this.editRequestForm.value,
        id: this.data.transportId 
      };

      this.transportRequestApiService.editTransport(this.data.transportId, updatedRequest).subscribe({
        next: () => this.dialogRef.close(true),
        error: (err) => console.error('Error updating request:', err)
      });
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}