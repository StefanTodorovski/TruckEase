import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { RegisterCompanyUserRequest } from '../../models/requests/registerCompanyUserRequest';
import { ApiService } from '../base/api.service';
import { RegisterCompanyUserViewModel } from '../../models/view-models/company-user.view-model';
import { RegisterCompanyUserResponse } from '../../models/responses/company-user.response';
import { CompanyUserMapper } from '../../models/mappers/company-user.mapper';
import { LoginCompanyUserRequest } from '../../models/requests/loginCompanyUserRequest';
import { CompanyUserWithTokenViewModel } from '../../models/view-models/company-user-with-token.view-model';
import { CompanyUserWithTokenResponse } from '../../models/responses/company-user-with-token.response';
import { CompanyUserInfoViewModel } from '../../models/view-models/company-user-info.view-model';
import { CompanyUserInfoResponse } from '../../models/responses/company-user-info.response';
import {  EditCompanyUserRequest } from '../../models/requests/editCompanyUserRequest';


@Injectable({
	providedIn: 'root'
})
export class CompanyUserApiService {
	public constructor(private apiService: ApiService) { }

	public register(request: RegisterCompanyUserRequest): Observable<RegisterCompanyUserViewModel> {
		return this.apiService.post<RegisterCompanyUserResponse>(
			'company-users/register',
			request)
			.pipe(
				map(
					(result: RegisterCompanyUserResponse) => CompanyUserMapper.toRegisterCompanyUserViewModel(result)
				)
			);
	}


	public login(request: LoginCompanyUserRequest): Observable<CompanyUserWithTokenViewModel> {
		return this.apiService.post<CompanyUserWithTokenResponse>(
			'company-users/login',
			request)
			.pipe(
				map(
					(result: CompanyUserWithTokenResponse) => CompanyUserMapper.toRegisterCompanyUserWithTokenViewModel(result)
				)
			);
	}

	public getCompanyUserInfo(companyUserid: number): Observable<CompanyUserInfoViewModel> {
		return this.apiService.get<CompanyUserInfoResponse>(
			`company-users/${companyUserid}/info`)
			.pipe(
				map(
					(result: CompanyUserInfoResponse) => CompanyUserMapper.toCompanyUserInfoViewModel(result)
				)
			);
	}

	public editCompanyUser(companyUserId: number, request: EditCompanyUserRequest): Observable<{ }> {
		return this.apiService.patch<{ }>(`company-users/${companyUserId}/edit`, request);
	}
}
