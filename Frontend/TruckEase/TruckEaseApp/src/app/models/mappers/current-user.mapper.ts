import { CurrentUserResponse } from "../responses/current-user.response";
import { CurrentUserViewModel } from "../view-models/current-user.view-model";

export namespace CurrentUserMapper {
  export function toCurrentUserViewModel(currentUser: CurrentUserResponse): CurrentUserViewModel {

    return {
      id: currentUser.id,
      firstName: currentUser.firstName,
      lastName: currentUser.lastName,
      email: currentUser.email,
      inCompanyFK: currentUser.inCompanyFK
    };
  }
}
