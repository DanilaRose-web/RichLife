import DropdownListItemsModel from "./DropdownListItemsModel";

export default class IDropdownModel {
   constructor(
      public Id: number,
      public Name: string,
      public Selected: boolean,
      public Disabled: boolean,
      public Image?: string,
   ) {}
}