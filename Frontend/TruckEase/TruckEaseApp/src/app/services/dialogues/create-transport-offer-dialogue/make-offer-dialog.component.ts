import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TransportOfferApiService } from '../../transport-offer/transport-offer-api.service';
import { CreateTransportOfferRequest } from '../../../models/requests/createTransportOfferRequest';

@Component({
  selector: 'app-make-offer-dialog',
  templateUrl: './make-offer-dialog.component.html',
  styleUrls: ['./make-offer-dialog.component.scss']
})
export class MakeOfferDialogComponent implements OnInit {
  makeOfferForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private transportOfferApiService: TransportOfferApiService,
    private dialogRef: MatDialogRef<MakeOfferDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { requestPrice: number, transportRequestId: number }
  ) {}

  ngOnInit(): void {
    this.makeOfferForm = this.fb.group({
      price: [this.data.requestPrice],
      additionalInfo: ['']
    });
  }

  onSubmit(): void {
    if (this.makeOfferForm.valid) {
      const offerRequest: CreateTransportOfferRequest = {
        Price: this.makeOfferForm.value.price || this.data.requestPrice,
        AdditionalInfo: this.makeOfferForm.value.additionalInfo
      };

      this.transportOfferApiService.createTransportOffer(this.data.transportRequestId, offerRequest).subscribe({
        next: () => this.dialogRef.close(true),
        error: (err) => console.error('Error creating transport offer:', err)
      });
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
