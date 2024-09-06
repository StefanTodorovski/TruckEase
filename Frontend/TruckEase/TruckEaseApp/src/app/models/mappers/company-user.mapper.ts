import { CompanyUserWithTokenResponse } from "../responses/company-user-with-token.response";
import { RegisterCompanyUserResponse } from "../responses/company-user.response";
import { CompanyUserInfoViewModel } from "../view-models/company-user-info.view-model";
import { CompanyUserWithTokenViewModel } from "../view-models/company-user-with-token.view-model";
import { RegisterCompanyUserViewModel } from "../view-models/company-user.view-model";

export namespace CompanyUserMapper {

    export function toRegisterCompanyUserViewModel(registerCompanyUserResponse: RegisterCompanyUserResponse):
    RegisterCompanyUserViewModel {
  	return {
  		firstName: registerCompanyUserResponse.firstName,
  		lastName: registerCompanyUserResponse.lastName,
  		email: registerCompanyUserResponse.email,
  		isUserInCompany: registerCompanyUserResponse.isUserInCompany
  	};
  }

  export function toRegisterCompanyUserWithTokenViewModel(registerCompanyUserResponse: CompanyUserWithTokenResponse):
  CompanyUserWithTokenViewModel {
	return {
		firstName: registerCompanyUserResponse.firstName,
		lastName: registerCompanyUserResponse.lastName,
		email: registerCompanyUserResponse.email,
		isUserInCompany: registerCompanyUserResponse.isUserInCompany,
		token: registerCompanyUserResponse.token
	};
}

export function toCompanyUserInfoViewModel(companyUserInfo: CompanyUserInfoViewModel):
CompanyUserInfoViewModel {
  return {
	  firstName: companyUserInfo.firstName,
	  lastName: companyUserInfo.lastName,
	  email: companyUserInfo.email,
	  jobTitle: companyUserInfo.jobTitle,
	  workPhone: companyUserInfo.workPhone,
	  mobilePhone: companyUserInfo.mobilePhone
  };
}

}