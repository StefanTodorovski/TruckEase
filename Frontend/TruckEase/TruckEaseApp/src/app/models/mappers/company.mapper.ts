import { CompanyInfoResponse } from "../responses/company-info.response";
import { CompanyInfoViewModel } from "../view-models/company-view-model";

export namespace CompanyMapper {
  export function toCompanyInfoViewModel(companyResponse: CompanyInfoResponse): CompanyInfoViewModel {

    return {
        id: companyResponse.id,
        companyName: companyResponse.companyName,
        registrationNumber: companyResponse.registrationNumber,
        companyType: companyResponse.companyType,
        description: companyResponse.description
  }

}
}
