import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ApiService } from '../base/api.service';
import { RegisterCompanyRequest } from '../../models/requests/registerCompanyRequest';
import { CompanyInfoViewModel } from '../../models/view-models/company-view-model';
import { CompanyMapper } from '../../models/mappers/company.mapper';
import { CompanyInfoResponse } from '../../models/responses/company-info.response';
import { EditCompanyRequest } from '../../models/requests/editCompanyRequest';


@Injectable({
	providedIn: 'root'
})
export class CompanyApiService {
	public constructor(private apiService: ApiService) { }


    public registerCompany(request: RegisterCompanyRequest, companyUserId: number): Observable<CompanyInfoViewModel> {
		return this.apiService.post<CompanyInfoResponse>(
			`companies/${companyUserId}/register`,
			request)
			.pipe(
				map(
					(result: CompanyInfoResponse) => CompanyMapper.toCompanyInfoViewModel(result)
				)
			);
	}

	public editCompany(companyId: number, request: EditCompanyRequest): Observable<{ }> {
		return this.apiService.patch<{ }>(`companies/${companyId}/edit`, request);
	}


    public getCompanyInfo(companyId: number): Observable<CompanyInfoViewModel> {
		return this.apiService.get<CompanyInfoResponse>(`companies/${companyId}/info`)
			.pipe(
				map((CompanyInfoResponse: CompanyInfoResponse): CompanyInfoViewModel =>
					CompanyMapper.toCompanyInfoViewModel(CompanyInfoResponse)
				)
			);
	}

	public getAllCompaniesWithInfo(): Observable<CompanyInfoViewModel[]> {
		return this.apiService.get<CompanyInfoResponse[]>
		(`companies`)
			.pipe(
				map(
					(result: CompanyInfoResponse[]): CompanyInfoViewModel[] => result
						.map(element => CompanyMapper.toCompanyInfoViewModel(element))
				)
			);
	}
}
