import { TransportOfferInfoResponse } from "../responses/transport-offer-info.response";
import { TransportOfferInfoViewModel } from "../view-models/transport-offer-info.view-model";

export namespace TransportOfferMapper {
    export function toTransportOfferViewModel(response: TransportOfferInfoResponse): TransportOfferInfoViewModel {
  
      return {
        offerId: response.offerId,
        additionalInfo: response.additionalInfo,
        price: response.price,
        offerStatus: response.offerStatus,
        startTime: response.startTime,
        arrivalTime: response.arrivalTime,
        startLocation: response.startLocation,
        destination: response.destination,
        transportType: response.transportType,
        requesterCompanyId: response.requesterCompanyId
    }
  
  }
  }
  