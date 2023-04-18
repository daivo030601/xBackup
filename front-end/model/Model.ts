export interface LoginForm{
    email: string,
    password: string
}
export interface RegisterForm{
    email: string,
    password: string
    confirmPassword: string
    firstName: string,
    lastName: string,
}
export interface ResponseModel{
    code: number,
    message:string,
    data: object,
 }
 export interface ChangePasswordForm{
    email:string,
    oldPassword:string,
    newPassword:string,
    confirmNewPassword:string
 }