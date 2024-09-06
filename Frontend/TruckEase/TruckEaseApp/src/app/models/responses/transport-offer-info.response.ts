import { OfferStatus } from "../enums/offerStatus";

export class TransportOfferInfoResponse {
    public readonly offerId!: number;
    public readonly additionalInfo?: string;
    public readonly price?: number;
    public readonly offerStatus!: OfferStatus;
    public readonly startTime!: Date;
    public readonly arrivalTime!: Date;
    public readonly startLocation!: string;
    public readonly destination!: string;
    public readonly transportType!: string;
    public readonly requesterCompanyId!: number;
}