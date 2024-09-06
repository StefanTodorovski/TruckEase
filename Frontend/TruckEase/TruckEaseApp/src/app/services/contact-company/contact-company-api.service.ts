import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ApiService } from '../base/api.service';
import { CompanyInfoViewModel } from '../../models/view-models/company-view-model';
import { CompanyInfoResponse } from '../../models/responses/company-info.response';
import { CompanyMapper } from '../../models/mappers/company.mapper';


@Injectable({
	providedIn: 'root'
})
export class ContactCompanyApiService {
	public constructor(private apiService: ApiService) { }


	public addCompanyAsContactCompany(companyId: number): Observable<{ }> {
		return this.apiService.post<{ }>(`contact-company/${companyId}/add-to-supply-chain`);
	}

    public getAllContactCompaniesWithInfo(companyId: number): Observable<CompanyInfoViewModel[]> {
		return this.apiService.get<CompanyInfoResponse[]>
		(`contact-company/${companyId}/all`)
			.pipe(
				map(
					(result: CompanyInfoResponse[]): CompanyInfoViewModel[] => result
						.map(element => CompanyMapper.toCompanyInfoViewModel(element))
				)
			);
	}

    public removeContactCompany(companyId: number): Observable<{ }> {
		return this.apiService.post<{ }>(`contact-company/${companyId}/remove`);
	}


}
