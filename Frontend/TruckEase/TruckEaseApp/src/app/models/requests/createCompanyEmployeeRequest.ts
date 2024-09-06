import { EmployeeType } from "../enums/employeeType";

export class CreateCompanyEmployeeRequest {
    public email!: string;
    public firstName!: string;
    public lastName!: string;
    public employeeType!: EmployeeType;
  }