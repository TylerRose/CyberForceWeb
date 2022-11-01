import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationUserApiClient extends ModelApiClient<$models.ApplicationUser> {
  constructor() { super($metadata.ApplicationUser) }
}


export class UserDetailsApiClient extends ModelApiClient<$models.UserDetails> {
  constructor() { super($metadata.UserDetails) }
}


export class ApplicationUserServiceApiClient extends ServiceApiClient<typeof $metadata.ApplicationUserService> {
  constructor() { super($metadata.ApplicationUserService) }
  public getRoles($config?: AxiosRequestConfig): AxiosPromise<ItemResult<string[]>> {
    const $method = this.$metadata.methods.getRoles
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
  public hasRole(role: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.hasRole
    const $params =  {
      role,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public getAllUsersInfo($config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.UserInfoDto[]>> {
    const $method = this.$metadata.methods.getAllUsersInfo
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
  public getRoleList($config?: AxiosRequestConfig): AxiosPromise<ItemResult<string[]>> {
    const $method = this.$metadata.methods.getRoleList
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
  public toggleUserRole(userEmail: string | null, role: string | null, currentState: boolean | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.toggleUserRole
    const $params =  {
      userEmail,
      role,
      currentState,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


export class LoginServiceApiClient extends ServiceApiClient<typeof $metadata.LoginService> {
  constructor() { super($metadata.LoginService) }
  public login(email: string | null, password: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.login
    const $params =  {
      email,
      password,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public getToken(email: string | null, password: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<unknown>> {
    const $method = this.$metadata.methods.getToken
    const $params =  {
      email,
      password,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public logout($config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.logout
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
  public createAccount(name: string | null, email: string | null, password: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.createAccount
    const $params =  {
      name,
      email,
      password,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public changePassword(currentPassword: string | null, newPassword: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.changePassword
    const $params =  {
      currentPassword,
      newPassword,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public isLoggedIn($config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.isLoggedIn
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
  public getUserInfo($config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.UserInfoDto>> {
    const $method = this.$metadata.methods.getUserInfo
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
}


