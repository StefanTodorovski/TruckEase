import { CompanyType } from "../enums/companyType";

export class CompanyInfoResponse  {
    public readonly id!: number;
    public readonly companyName!: string;
    public readonly registrationNumber!: string;
    public readonly companyType!: CompanyType;
    public readonly description!: string;
  }