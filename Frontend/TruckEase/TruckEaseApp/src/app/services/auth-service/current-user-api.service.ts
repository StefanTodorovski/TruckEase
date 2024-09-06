
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { CurrentUserResponse } from '../../models/responses/current-user.response';
import { environment } from '../../environments/environment';
import { CurrentUserMapper } from '../../models/mappers/current-user.mapper';
import { ApiService } from '../base/api.service';

@Injectable({
	providedIn: 'root'
})
export class CurrentUserApiService {
	public constructor(private apiService: ApiService) { }

	public getCurrentUser(): Observable<CurrentUserViewModel> {
		return this.apiService.get<CurrentUserResponse>(`currentuser`)
			.pipe(
				map(
					(result: CurrentUserResponse): CurrentUserViewModel => CurrentUserMapper.toCurrentUserViewModel(result))
				);
	}

}
