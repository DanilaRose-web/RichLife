export default class LangsModel {
   constructor (
      public Id: number,
      public Country: string,
      public Flag: string,
      public CodeNumber: string,
      public Selected: boolean,
      public ShortName?: string,
      public Disabled?: boolean
   ) {}
}