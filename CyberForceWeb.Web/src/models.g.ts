import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  name: string | null
  id: string | null
  userName: string | null
  normalizedUserName: string | null
  email: string | null
  normalizedEmail: string | null
  emailConfirmed: boolean | null
  passwordHash: string | null
  securityStamp: string | null
  concurrencyStamp: string | null
  phoneNumber: string | null
  phoneNumberConfirmed: boolean | null
  twoFactorEnabled: boolean | null
  lockoutEnd: Date | null
  lockoutEnabled: boolean | null
  accessFailedCount: number | null
}
export class ApplicationUser {
  
  /** Mutates the input object and its descendents into a valid ApplicationUser implementation. */
  static convert(data?: Partial<ApplicationUser>): ApplicationUser {
    return convertToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid ApplicationUser implementation. */
  static map(data?: Partial<ApplicationUser>): ApplicationUser {
    return mapToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Instantiate a new ApplicationUser, optionally basing it on the given data. */
  constructor(data?: Partial<ApplicationUser> | {[k: string]: any}) {
      Object.assign(this, ApplicationUser.map(data || {}));
  }
}


export interface UserDetails extends Model<typeof metadata.UserDetails> {
  id: string | null
}
export class UserDetails {
  
  /** Mutates the input object and its descendents into a valid UserDetails implementation. */
  static convert(data?: Partial<UserDetails>): UserDetails {
    return convertToModel(data || {}, metadata.UserDetails) 
  }
  
  /** Maps the input object and its descendents to a new, valid UserDetails implementation. */
  static map(data?: Partial<UserDetails>): UserDetails {
    return mapToModel(data || {}, metadata.UserDetails) 
  }
  
  /** Instantiate a new UserDetails, optionally basing it on the given data. */
  constructor(data?: Partial<UserDetails> | {[k: string]: any}) {
      Object.assign(this, UserDetails.map(data || {}));
  }
}


export interface UserInfoDto extends Model<typeof metadata.UserInfoDto> {
  name: string | null
  email: string | null
  userRoles: string[] | null
}
export class UserInfoDto {
  
  /** Mutates the input object and its descendents into a valid UserInfoDto implementation. */
  static convert(data?: Partial<UserInfoDto>): UserInfoDto {
    return convertToModel(data || {}, metadata.UserInfoDto) 
  }
  
  /** Maps the input object and its descendents to a new, valid UserInfoDto implementation. */
  static map(data?: Partial<UserInfoDto>): UserInfoDto {
    return mapToModel(data || {}, metadata.UserInfoDto) 
  }
  
  /** Instantiate a new UserInfoDto, optionally basing it on the given data. */
  constructor(data?: Partial<UserInfoDto> | {[k: string]: any}) {
      Object.assign(this, UserInfoDto.map(data || {}));
  }
}


