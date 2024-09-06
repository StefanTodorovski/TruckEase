import { Transport } from "../enums/transportType";

export class RequestInfoResponse {
    public readonly id!: number;
    public readonly description: string | undefined;
    public readonly startTime: Date | undefined;
    public readonly arrivalTime: Date | undefined;
    public readonly price!: number;
    public readonly startLocation: string | undefined;
    public readonly destination: string | undefined;
    public readonly isExpress: boolean | undefined;
    public readonly loadWeight: number | undefined;
    public readonly isDraft: boolean | undefined;
    public readonly transportType: Transport | undefined;
    }