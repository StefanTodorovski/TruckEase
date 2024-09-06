import { OfferStatus } from "../enums/offerStatus";

export class TransportOfferInfoViewModel {
    public offerId!: number;
    public additionalInfo?: string;
    public price?: number;
    public offerStatus!: OfferStatus;
    public startTime!: Date;
    public arrivalTime!: Date;
    public startLocation!: string;
    public destination!: string;
    public transportType!: string;
    public requesterCompanyId!: number;
}