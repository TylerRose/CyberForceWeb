import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationUserViewModel extends $models.ApplicationUser {
  name: string | null;
  id: string | null;
  userName: string | null;
  normalizedUserName: string | null;
  email: string | null;
  normalizedEmail: string | null;
  emailConfirmed: boolean | null;
  passwordHash: string | null;
  securityStamp: string | null;
  concurrencyStamp: string | null;
  phoneNumber: string | null;
  phoneNumberConfirmed: boolean | null;
  twoFactorEnabled: boolean | null;
  lockoutEnd: Date | null;
  lockoutEnabled: boolean | null;
  accessFailedCount: number | null;
}
export class ApplicationUserViewModel extends ViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, string> implements $models.ApplicationUser  {
  
  constructor(initialData?: DeepPartial<$models.ApplicationUser> | null) {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient(), initialData)
  }
}
defineProps(ApplicationUserViewModel, $metadata.ApplicationUser)

export class ApplicationUserListViewModel extends ListViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, ApplicationUserViewModel> {
  
  constructor() {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient())
  }
}


export interface UserDetailsViewModel extends $models.UserDetails {
  id: string | null;
}
export class UserDetailsViewModel extends ViewModel<$models.UserDetails, $apiClients.UserDetailsApiClient, string> implements $models.UserDetails  {
  
  constructor(initialData?: DeepPartial<$models.UserDetails> | null) {
    super($metadata.UserDetails, new $apiClients.UserDetailsApiClient(), initialData)
  }
}
defineProps(UserDetailsViewModel, $metadata.UserDetails)

export class UserDetailsListViewModel extends ListViewModel<$models.UserDetails, $apiClients.UserDetailsApiClient, UserDetailsViewModel> {
  
  constructor() {
    super($metadata.UserDetails, new $apiClients.UserDetailsApiClient())
  }
}


export class ApplicationUserServiceViewModel extends ServiceViewModel<typeof $metadata.ApplicationUserService, $apiClients.ApplicationUserServiceApiClient> {
  
  public get getRoles() {
    const getRoles = this.$apiClient.$makeCaller(
      this.$metadata.methods.getRoles,
      (c) => c.getRoles(),
      () => ({}),
      (c, args) => c.getRoles())
    
    Object.defineProperty(this, 'getRoles', {value: getRoles});
    return getRoles
  }
  
  public get hasRole() {
    const hasRole = this.$apiClient.$makeCaller(
      this.$metadata.methods.hasRole,
      (c, role: string | null) => c.hasRole(role),
      () => ({role: null as string | null, }),
      (c, args) => c.hasRole(args.role))
    
    Object.defineProperty(this, 'hasRole', {value: hasRole});
    return hasRole
  }
  
  public get getAllUsersInfo() {
    const getAllUsersInfo = this.$apiClient.$makeCaller(
      this.$metadata.methods.getAllUsersInfo,
      (c) => c.getAllUsersInfo(),
      () => ({}),
      (c, args) => c.getAllUsersInfo())
    
    Object.defineProperty(this, 'getAllUsersInfo', {value: getAllUsersInfo});
    return getAllUsersInfo
  }
  
  public get getRoleList() {
    const getRoleList = this.$apiClient.$makeCaller(
      this.$metadata.methods.getRoleList,
      (c) => c.getRoleList(),
      () => ({}),
      (c, args) => c.getRoleList())
    
    Object.defineProperty(this, 'getRoleList', {value: getRoleList});
    return getRoleList
  }
  
  public get toggleUserRole() {
    const toggleUserRole = this.$apiClient.$makeCaller(
      this.$metadata.methods.toggleUserRole,
      (c, userEmail: string | null, role: string | null, currentState: boolean | null) => c.toggleUserRole(userEmail, role, currentState),
      () => ({userEmail: null as string | null, role: null as string | null, currentState: null as boolean | null, }),
      (c, args) => c.toggleUserRole(args.userEmail, args.role, args.currentState))
    
    Object.defineProperty(this, 'toggleUserRole', {value: toggleUserRole});
    return toggleUserRole
  }
  
  constructor() {
    super($metadata.ApplicationUserService, new $apiClients.ApplicationUserServiceApiClient())
  }
}


export class LoginServiceViewModel extends ServiceViewModel<typeof $metadata.LoginService, $apiClients.LoginServiceApiClient> {
  
  public get login() {
    const login = this.$apiClient.$makeCaller(
      this.$metadata.methods.login,
      (c, email: string | null, password: string | null) => c.login(email, password),
      () => ({email: null as string | null, password: null as string | null, }),
      (c, args) => c.login(args.email, args.password))
    
    Object.defineProperty(this, 'login', {value: login});
    return login
  }
  
  public get getToken() {
    const getToken = this.$apiClient.$makeCaller(
      this.$metadata.methods.getToken,
      (c, email: string | null, password: string | null) => c.getToken(email, password),
      () => ({email: null as string | null, password: null as string | null, }),
      (c, args) => c.getToken(args.email, args.password))
    
    Object.defineProperty(this, 'getToken', {value: getToken});
    return getToken
  }
  
  public get logout() {
    const logout = this.$apiClient.$makeCaller(
      this.$metadata.methods.logout,
      (c) => c.logout(),
      () => ({}),
      (c, args) => c.logout())
    
    Object.defineProperty(this, 'logout', {value: logout});
    return logout
  }
  
  public get createAccount() {
    const createAccount = this.$apiClient.$makeCaller(
      this.$metadata.methods.createAccount,
      (c, name: string | null, email: string | null, password: string | null) => c.createAccount(name, email, password),
      () => ({name: null as string | null, email: null as string | null, password: null as string | null, }),
      (c, args) => c.createAccount(args.name, args.email, args.password))
    
    Object.defineProperty(this, 'createAccount', {value: createAccount});
    return createAccount
  }
  
  public get changePassword() {
    const changePassword = this.$apiClient.$makeCaller(
      this.$metadata.methods.changePassword,
      (c, currentPassword: string | null, newPassword: string | null) => c.changePassword(currentPassword, newPassword),
      () => ({currentPassword: null as string | null, newPassword: null as string | null, }),
      (c, args) => c.changePassword(args.currentPassword, args.newPassword))
    
    Object.defineProperty(this, 'changePassword', {value: changePassword});
    return changePassword
  }
  
  public get isLoggedIn() {
    const isLoggedIn = this.$apiClient.$makeCaller(
      this.$metadata.methods.isLoggedIn,
      (c) => c.isLoggedIn(),
      () => ({}),
      (c, args) => c.isLoggedIn())
    
    Object.defineProperty(this, 'isLoggedIn', {value: isLoggedIn});
    return isLoggedIn
  }
  
  public get getUserInfo() {
    const getUserInfo = this.$apiClient.$makeCaller(
      this.$metadata.methods.getUserInfo,
      (c) => c.getUserInfo(),
      () => ({}),
      (c, args) => c.getUserInfo())
    
    Object.defineProperty(this, 'getUserInfo', {value: getUserInfo});
    return getUserInfo
  }
  
  constructor() {
    super($metadata.LoginService, new $apiClients.LoginServiceApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  ApplicationUser: ApplicationUserViewModel,
  UserDetails: UserDetailsViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  ApplicationUser: ApplicationUserListViewModel,
  UserDetails: UserDetailsListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
  ApplicationUserService: ApplicationUserServiceViewModel,
  LoginService: LoginServiceViewModel,
}

