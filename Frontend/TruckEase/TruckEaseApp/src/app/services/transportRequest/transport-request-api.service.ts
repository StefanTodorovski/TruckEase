import { map, Observable } from "rxjs";
import { CreateTransportRequest } from "../../models/requests/createTransportRequest";
import { ApiService } from "../base/api.service";
import { Injectable } from "@angular/core";
import { RequestInfoViewModel } from "../../models/view-models/request-info.view-model";
import { RequestInfoResponse } from "../../models/responses/request-info.response";
import { RequestMapper } from "../../models/mappers/request.mapper";
import { EditTransportRequest } from "../../models/requests/editTransportRequest";

@Injectable({
	providedIn: 'root'
})
export class TransportRequestApiService {
	public constructor(private apiService: ApiService) { }

	public createTransport(companyId: number, request: CreateTransportRequest): Observable<{ }> {
		return this.apiService.post<{ }>(`transport-requests/${companyId}/create`, request);
	}

	public editTransport(transportId: number, request: EditTransportRequest): Observable<{ }> {
		return this.apiService.patch<{ }>(`transport-requests/${transportId}/edit`, request);
	}

	public getAllRequestsForCompany(companyId: number): Observable<RequestInfoViewModel[]> {
		return this.apiService.get<RequestInfoResponse[]>
		(`transport-requests/${companyId}/all`)
			.pipe(
				map(
					(result: RequestInfoResponse[]): RequestInfoViewModel[] => result
						.map(element => RequestMapper.toRequestViewModel(element))
				)
			);
	}

	public getAllPublishedRequests(): Observable<RequestInfoViewModel[]> {
		return this.apiService.get<RequestInfoResponse[]>
		(`transport-requests/published`)
			.pipe(
				map(
					(result: RequestInfoResponse[]): RequestInfoViewModel[] => result
						.map(element => RequestMapper.toRequestViewModel(element))
				)
			);
	}

	public getTransportInfo(transportId: number): Observable<RequestInfoViewModel> {
		return this.apiService.get<RequestInfoResponse>(`transport-requests/${transportId}/info`)
			.pipe(
				map((element: RequestInfoResponse): RequestInfoViewModel =>
					RequestMapper.toRequestViewModel(element)
				)
			);
	}

}
