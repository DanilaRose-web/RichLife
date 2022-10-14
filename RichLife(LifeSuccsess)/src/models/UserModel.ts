export default class UserModel {
   constructor (
      public Id: number,
      public Token: string,
      public Name: string,
      public Email: string,
      public Phone: string,
      public CodeCountry: string,
      public IsAdmin: boolean,
      public TookTheProgram: boolean,
      public RefferalLink: string,
      public Delete?: boolean,
      public Index?: number
   ) {}
   
}