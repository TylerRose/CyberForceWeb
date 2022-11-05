import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const ApplicationUser = domain.types.ApplicationUser = {
  name: "ApplicationUser",
  displayName: "Application User",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "ApplicationUser",
  get keyProp() { return this.props.id }, 
  behaviorFlags: 7,
  props: {
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    id: {
      name: "id",
      displayName: "Id",
      type: "string",
      role: "primaryKey",
      hidden: 3,
    },
    userName: {
      name: "userName",
      displayName: "User Name",
      type: "string",
      role: "value",
    },
    normalizedUserName: {
      name: "normalizedUserName",
      displayName: "Normalized User Name",
      type: "string",
      role: "value",
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      role: "value",
    },
    normalizedEmail: {
      name: "normalizedEmail",
      displayName: "Normalized Email",
      type: "string",
      role: "value",
    },
    emailConfirmed: {
      name: "emailConfirmed",
      displayName: "Email Confirmed",
      type: "boolean",
      role: "value",
    },
    passwordHash: {
      name: "passwordHash",
      displayName: "Password Hash",
      type: "string",
      role: "value",
    },
    securityStamp: {
      name: "securityStamp",
      displayName: "Security Stamp",
      type: "string",
      role: "value",
    },
    concurrencyStamp: {
      name: "concurrencyStamp",
      displayName: "Concurrency Stamp",
      type: "string",
      role: "value",
    },
    phoneNumber: {
      name: "phoneNumber",
      displayName: "Phone Number",
      type: "string",
      role: "value",
    },
    phoneNumberConfirmed: {
      name: "phoneNumberConfirmed",
      displayName: "Phone Number Confirmed",
      type: "boolean",
      role: "value",
    },
    twoFactorEnabled: {
      name: "twoFactorEnabled",
      displayName: "Two Factor Enabled",
      type: "boolean",
      role: "value",
    },
    lockoutEnd: {
      name: "lockoutEnd",
      displayName: "Lockout End",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
    lockoutEnabled: {
      name: "lockoutEnabled",
      displayName: "Lockout Enabled",
      type: "boolean",
      role: "value",
    },
    accessFailedCount: {
      name: "accessFailedCount",
      displayName: "Access Failed Count",
      type: "number",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const ContactUsForm = domain.types.ContactUsForm = {
  name: "ContactUsForm",
  displayName: "Contact Us Form",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "ContactUsForm",
  get keyProp() { return this.props.contactUsFormId }, 
  behaviorFlags: 7,
  props: {
    contactUsFormId: {
      name: "contactUsFormId",
      displayName: "Contact Us Form Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      role: "value",
    },
    phoneNumber: {
      name: "phoneNumber",
      displayName: "Phone Number",
      type: "string",
      role: "value",
    },
    fileUploadId: {
      name: "fileUploadId",
      displayName: "File Upload Id",
      type: "number",
      role: "value",
    },
    upload: {
      name: "upload",
      displayName: "Upload",
      type: "model",
      get typeDef() { return (domain.types.FileUpload as ModelType) },
      role: "value",
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Email = domain.types.Email = {
  name: "Email",
  displayName: "Email",
  get displayProp() { return this.props.emailId }, 
  type: "model",
  controllerRoute: "Email",
  get keyProp() { return this.props.emailId }, 
  behaviorFlags: 7,
  props: {
    emailId: {
      name: "emailId",
      displayName: "Email Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    senderName: {
      name: "senderName",
      displayName: "Sender Name",
      type: "string",
      role: "value",
    },
    senderEmailAddress: {
      name: "senderEmailAddress",
      displayName: "Sender Email Address",
      type: "string",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const FileUpload = domain.types.FileUpload = {
  name: "FileUpload",
  displayName: "File Upload",
  get displayProp() { return this.props.fileUploadId }, 
  type: "model",
  controllerRoute: "FileUpload",
  get keyProp() { return this.props.fileUploadId }, 
  behaviorFlags: 7,
  props: {
    fileUploadId: {
      name: "fileUploadId",
      displayName: "File Upload Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    content: {
      name: "content",
      displayName: "Content",
      type: "binary",
      base64: true,
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const UserDetails = domain.types.UserDetails = {
  name: "UserDetails",
  displayName: "User Details",
  get displayProp() { return this.props.id }, 
  type: "model",
  controllerRoute: "UserDetails",
  get keyProp() { return this.props.id }, 
  behaviorFlags: 7,
  props: {
    id: {
      name: "id",
      displayName: "Id",
      type: "string",
      role: "primaryKey",
      hidden: 3,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const UserInfoDto = domain.types.UserInfoDto = {
  name: "UserInfoDto",
  displayName: "User Info Dto",
  get displayProp() { return this.props.name }, 
  type: "object",
  props: {
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      role: "value",
    },
    userRoles: {
      name: "userRoles",
      displayName: "User Roles",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "string",
      },
      role: "value",
    },
  },
}
export const ApplicationUserService = domain.services.ApplicationUserService = {
  name: "ApplicationUserService",
  displayName: "Application User Service",
  type: "service",
  controllerRoute: "ApplicationUserService",
  methods: {
    getRoles: {
      name: "getRoles",
      displayName: "Get Roles",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "collection",
        itemType: {
          name: "$collectionItem",
          displayName: "",
          role: "value",
          type: "string",
        },
        role: "value",
      },
    },
    hasRole: {
      name: "hasRole",
      displayName: "Has Role",
      transportType: "item",
      httpMethod: "POST",
      params: {
        role: {
          name: "role",
          displayName: "Role",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    getAllUsersInfo: {
      name: "getAllUsersInfo",
      displayName: "Get All Users Info",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "collection",
        itemType: {
          name: "$collectionItem",
          displayName: "",
          role: "value",
          type: "object",
          get typeDef() { return (domain.types.UserInfoDto as ObjectType) },
        },
        role: "value",
      },
    },
    getRoleList: {
      name: "getRoleList",
      displayName: "Get Role List",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "collection",
        itemType: {
          name: "$collectionItem",
          displayName: "",
          role: "value",
          type: "string",
        },
        role: "value",
      },
    },
    toggleUserRole: {
      name: "toggleUserRole",
      displayName: "Toggle User Role",
      transportType: "item",
      httpMethod: "POST",
      params: {
        userEmail: {
          name: "userEmail",
          displayName: "User Email",
          type: "string",
          role: "value",
        },
        role: {
          name: "role",
          displayName: "Role",
          type: "string",
          role: "value",
        },
        currentState: {
          name: "currentState",
          displayName: "Current State",
          type: "boolean",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
  },
}
export const LoginService = domain.services.LoginService = {
  name: "LoginService",
  displayName: "Login Service",
  type: "service",
  controllerRoute: "LoginService",
  methods: {
    login: {
      name: "login",
      displayName: "Login",
      transportType: "item",
      httpMethod: "POST",
      params: {
        email: {
          name: "email",
          displayName: "Email",
          type: "string",
          role: "value",
        },
        password: {
          name: "password",
          displayName: "Password",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    getToken: {
      name: "getToken",
      displayName: "Get Token",
      transportType: "item",
      httpMethod: "POST",
      params: {
        email: {
          name: "email",
          displayName: "Email",
          type: "string",
          role: "value",
        },
        password: {
          name: "password",
          displayName: "Password",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        // Type not supported natively by Coalesce - falling back to unknown.
        type: "unknown",
        role: "value",
      },
    },
    logout: {
      name: "logout",
      displayName: "Logout",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    createAccount: {
      name: "createAccount",
      displayName: "Create Account",
      transportType: "item",
      httpMethod: "POST",
      params: {
        name: {
          name: "name",
          displayName: "Name",
          type: "string",
          role: "value",
        },
        email: {
          name: "email",
          displayName: "Email",
          type: "string",
          role: "value",
        },
        password: {
          name: "password",
          displayName: "Password",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    changePassword: {
      name: "changePassword",
      displayName: "Change Password",
      transportType: "item",
      httpMethod: "POST",
      params: {
        currentPassword: {
          name: "currentPassword",
          displayName: "Current Password",
          type: "string",
          role: "value",
        },
        newPassword: {
          name: "newPassword",
          displayName: "New Password",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    isLoggedIn: {
      name: "isLoggedIn",
      displayName: "Is Logged In",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    getUserInfo: {
      name: "getUserInfo",
      displayName: "Get User Info",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "object",
        get typeDef() { return (domain.types.UserInfoDto as ObjectType) },
        role: "value",
      },
    },
  },
}
export const UploadService = domain.services.UploadService = {
  name: "UploadService",
  displayName: "Upload Service",
  type: "service",
  controllerRoute: "UploadService",
  methods: {
    test: {
      name: "test",
      displayName: "Test",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
    uploadFile: {
      name: "uploadFile",
      displayName: "Upload File",
      transportType: "item",
      httpMethod: "POST",
      params: {
        file: {
          name: "file",
          displayName: "File",
          type: "file",
          role: "value",
        },
        formId: {
          name: "formId",
          displayName: "Form Id",
          type: "number",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "model",
        get typeDef() { return (domain.types.FileUpload as ModelType) },
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    ApplicationUser: typeof ApplicationUser
    ContactUsForm: typeof ContactUsForm
    Email: typeof Email
    FileUpload: typeof FileUpload
    UserDetails: typeof UserDetails
    UserInfoDto: typeof UserInfoDto
  }
  services: {
    ApplicationUserService: typeof ApplicationUserService
    LoginService: typeof LoginService
    UploadService: typeof UploadService
  }
}

solidify(domain)

export default domain as unknown as AppDomain
