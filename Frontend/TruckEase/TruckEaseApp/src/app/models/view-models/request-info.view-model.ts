import { Transport } from "../enums/transportType";

export class RequestInfoViewModel {
public id!: number;    
public description: string | undefined;
public startTime: Date | undefined;
public arrivalTime: Date | undefined;
public price!: number;
public startLocation: string | undefined;
public destination: string | undefined;
public isExpress: boolean | undefined;
public loadWeight: number | undefined;
public isDraft: boolean | undefined;
public transportType: Transport | undefined;
}