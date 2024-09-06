import { CompanyEmployeeResponse } from "../responses/company-employee.response";
import { CompanyEmployeeViewModel } from "../view-models/company-employee.view-model";

export namespace CompanyEmployeeMapper {

    export function toCompanyEmployeeViewModel(companyEmployeeResponse: CompanyEmployeeResponse):
    CompanyEmployeeViewModel {
  	return {
  		firstName: companyEmployeeResponse.firstName,
  		lastName: companyEmployeeResponse.lastName,
  		email: companyEmployeeResponse.email,
  		employeeType: companyEmployeeResponse.employeeType
  	};
  }

}