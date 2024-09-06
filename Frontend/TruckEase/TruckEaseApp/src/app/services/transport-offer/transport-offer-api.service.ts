import { map, Observable } from "rxjs";
import { ApiService } from "../base/api.service";
import { Injectable } from "@angular/core";
import { CreateTransportOfferRequest } from "../../models/requests/createTransportOfferRequest";
import { TransportOfferInfoViewModel } from "../../models/view-models/transport-offer-info.view-model";
import { TransportOfferInfoResponse } from "../../models/responses/transport-offer-info.response";
import { TransportOfferMapper } from "../../models/mappers/transport-offer.mapper";

@Injectable({
	providedIn: 'root'
})
export class TransportOfferApiService {
	public constructor(private apiService: ApiService) { }

	public createTransportOffer(transportRequestId: number, request: CreateTransportOfferRequest): Observable<{ }> {
		return this.apiService.post<{ }>(`transport-offer/${transportRequestId}/create`, request);
	}

	public getAllOffersMadeByCompany(companyId: number): Observable<TransportOfferInfoViewModel[]> {
		return this.apiService.get<TransportOfferInfoResponse[]>
		(`transport-offer/${companyId}/all`)
			.pipe(
				map(
					(result: TransportOfferInfoResponse[]): TransportOfferInfoViewModel[] => result
						.map(element => TransportOfferMapper.toTransportOfferViewModel(element))
				)
			);
	}

	public getAllOffersForShipperCompany(companyId: number): Observable<TransportOfferInfoViewModel[]> {
		return this.apiService.get<TransportOfferInfoResponse[]>
		(`transport-offer/${companyId}/offers`)
			.pipe(
				map(
					(result: TransportOfferInfoResponse[]): TransportOfferInfoViewModel[] => result
						.map(element => TransportOfferMapper.toTransportOfferViewModel(element))
				)
			);
	}

	public getAllActiveTransportsForShipperCompany(companyId: number): Observable<TransportOfferInfoViewModel[]> {
		return this.apiService.get<TransportOfferInfoResponse[]>
		(`transport-offer/${companyId}/active-transports`)
			.pipe(
				map(
					(result: TransportOfferInfoResponse[]): TransportOfferInfoViewModel[] => result
						.map(element => TransportOfferMapper.toTransportOfferViewModel(element))
				)
			);
	}

	public getAllActiveTransportsForTransporterCompany(companyId: number): Observable<TransportOfferInfoViewModel[]> {
		return this.apiService.get<TransportOfferInfoResponse[]>
		(`transport-offer/${companyId}/active-transports-transporter`)
			.pipe(
				map(
					(result: TransportOfferInfoResponse[]): TransportOfferInfoViewModel[] => result
						.map(element => TransportOfferMapper.toTransportOfferViewModel(element))
				)
			);
	}

	public removeOffer(offerId: number): Observable<{ }> {
		return this.apiService.post<{ }>(`transport-offer/${offerId}/remove`);
	}

	public acceptOffer(offerId: number): Observable<{ }> {
		return this.apiService.post<{ }>(`transport-offer/${offerId}/accept`);
	}

	public declineOffer(offerId: number): Observable<{ }> {
		return this.apiService.post<{ }>(`transport-offer/${offerId}/decline`);
	}

	public finishTransport(offerId: number): Observable<{ }> {
		return this.apiService.post<{ }>(`transport-offer/${offerId}/finished`);
	}

}
