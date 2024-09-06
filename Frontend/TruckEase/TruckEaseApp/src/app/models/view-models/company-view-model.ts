import { CompanyType } from "../enums/companyType";

export class CompanyInfoViewModel {
    public id!: number;
    public companyName!: string;
    public registrationNumber!: string;
    public companyType!: CompanyType;
    public description!: string;
  }