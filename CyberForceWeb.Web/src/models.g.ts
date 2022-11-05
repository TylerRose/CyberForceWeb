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


export interface ContactUsForm extends Model<typeof metadata.ContactUsForm> {
  contactUsFormId: number | null
  name: string | null
  email: string | null
  phoneNumber: string | null
  fileUploadId: number | null
  upload: FileUpload | null
}
export class ContactUsForm {
  
  /** Mutates the input object and its descendents into a valid ContactUsForm implementation. */
  static convert(data?: Partial<ContactUsForm>): ContactUsForm {
    return convertToModel(data || {}, metadata.ContactUsForm) 
  }
  
  /** Maps the input object and its descendents to a new, valid ContactUsForm implementation. */
  static map(data?: Partial<ContactUsForm>): ContactUsForm {
    return mapToModel(data || {}, metadata.ContactUsForm) 
  }
  
  /** Instantiate a new ContactUsForm, optionally basing it on the given data. */
  constructor(data?: Partial<ContactUsForm> | {[k: string]: any}) {
      Object.assign(this, ContactUsForm.map(data || {}));
  }
}


export interface Email extends Model<typeof metadata.Email> {
  emailId: number | null
  senderName: string | null
  senderEmailAddress: string | null
}
export class Email {
  
  /** Mutates the input object and its descendents into a valid Email implementation. */
  static convert(data?: Partial<Email>): Email {
    return convertToModel(data || {}, metadata.Email) 
  }
  
  /** Maps the input object and its descendents to a new, valid Email implementation. */
  static map(data?: Partial<Email>): Email {
    return mapToModel(data || {}, metadata.Email) 
  }
  
  /** Instantiate a new Email, optionally basing it on the given data. */
  constructor(data?: Partial<Email> | {[k: string]: any}) {
      Object.assign(this, Email.map(data || {}));
  }
}


export interface FileUpload extends Model<typeof metadata.FileUpload> {
  fileUploadId: number | null
  fileName: string | null
  content: string | null
}
export class FileUpload {
  
  /** Mutates the input object and its descendents into a valid FileUpload implementation. */
  static convert(data?: Partial<FileUpload>): FileUpload {
    return convertToModel(data || {}, metadata.FileUpload) 
  }
  
  /** Maps the input object and its descendents to a new, valid FileUpload implementation. */
  static map(data?: Partial<FileUpload>): FileUpload {
    return mapToModel(data || {}, metadata.FileUpload) 
  }
  
  /** Instantiate a new FileUpload, optionally basing it on the given data. */
  constructor(data?: Partial<FileUpload> | {[k: string]: any}) {
      Object.assign(this, FileUpload.map(data || {}));
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


