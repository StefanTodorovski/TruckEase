import { RequestInfoResponse } from "../responses/request-info.response";
import { RequestInfoViewModel } from "../view-models/request-info.view-model";

export namespace RequestMapper {
    export function toRequestViewModel(response: RequestInfoResponse): RequestInfoViewModel {
  
      return {
        id: response.id,
        description: response.description,
        startTime: response.startTime,
        arrivalTime: response.arrivalTime,
        price: response.price,
        startLocation: response.startLocation,
        destination: response.destination,
        isExpress: response.isExpress,
        loadWeight: response.loadWeight,
        isDraft: response.isDraft,
        transportType: response.transportType
    }
  
  }
  }