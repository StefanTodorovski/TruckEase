import { Injectable } from "@angular/core";
import { ApiService } from "../base/api.service";
import { map, Observable } from "rxjs";
import { CreateCompanyEmployeeRequest } from "../../models/requests/createCompanyEmployeeRequest";
import { CompanyEmployeeViewModel } from "../../models/view-models/company-employee.view-model";
import { CompanyEmployeeResponse } from "../../models/responses/company-employee.response";
import { CompanyEmployeeMapper } from "../../models/mappers/company-employee.mapper";

@Injectable({
	providedIn: 'root'
})
export class CompanyEmployeeApiService {
	public constructor(private apiService: ApiService) { }


	public createCompanyEmployee(request: CreateCompanyEmployeeRequest): Observable<{ }> {
		return this.apiService.post<{ }>(`company-employee/register`, request);
	}

	public getAllCompaniesWithInfo(companyId: number): Observable<CompanyEmployeeViewModel[]> {
		return this.apiService.get<CompanyEmployeeResponse[]>
		(`company-employee/${companyId}/all`)
			.pipe(
				map(
					(result: CompanyEmployeeResponse[]): CompanyEmployeeViewModel[] => result
						.map(element => CompanyEmployeeMapper.toCompanyEmployeeViewModel(element))
				)
			);
	}
}
