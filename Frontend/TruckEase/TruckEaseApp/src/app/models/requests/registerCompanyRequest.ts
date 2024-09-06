import { UserType } from "../enums/userType.enum";

export class RegisterCompanyRequest {
    public companyName!: string;
    public registrationNumber!: string;
    public companyType!: UserType;
    public description!: string;
  }