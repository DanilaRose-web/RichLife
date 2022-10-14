export default class IInputRadioModel {
   constructor (
      public Id: number,
      public id: string | number,
      public Label: string | number,
      public Selected: boolean,
      public Recommended?: boolean
   ) {}
}