export default class UserRequestModel {
   constructor(
      public userId: number,
      public tookTheProgram?: boolean,
      public isAdmin?: boolean
   ) {}
}