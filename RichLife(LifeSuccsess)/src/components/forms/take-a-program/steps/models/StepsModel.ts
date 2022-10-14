import FormStepModel from "./FormStepModel";

export default class FormStepsModel {
   constructor (
      public Steps: Array<FormStepModel>,
      public Active: number
   ) {}
}