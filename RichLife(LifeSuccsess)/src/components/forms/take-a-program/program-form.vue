<template>  
   <i-container>
      <div class="steps-number" v-if="stepsArray">
         <div class="step-item" 
         v-for="item in stepsArray.Steps" 
         :key="item.Id"
         :class="[item.Id == stepsArray.Active ? 'active' : '', item.Complete ? 'complete' : '']">
            <span v-if="!item.Complete">{{ item.Id }}</span>
            <span v-if="item.Complete"><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-check"></use></svg></span>
         </div>
      </div>

      <div class="steps-form">
         <transition name="fadeStep" mode="out-in">
            <step-one @next="nextStep" v-if="stepsArray.Active == 1"></step-one>
            <step-two @prev="prevStep" @next="nextStep" v-if="stepsArray.Active == 2"></step-two>
            <step-three @prev="prevStep" @next="nextStep" v-if="stepsArray.Active == 3"></step-three>
            <step-four @prev="prevStep" @next="nextStep" v-if="stepsArray.Active == 4"></step-four>
            <step-five @prev="prevStep" @next="nextStep" v-if="stepsArray.Active == 5"></step-five>
            <step-six @prev="prevStep" @send="send" v-if="stepsArray.Active == 6"></step-six>
         </transition>
      </div>
   </i-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import StepModel from "./steps/models/StepModel";
import StepsModel from "./steps/models/StepsModel"
import ProgramFormModel from "./steps/models/ProgramFormModel"
import StepOneFormModel from "./steps/models/steps/StepOneFormModel";
import StepTwoFormModel from "./steps/models/steps/StepTwoFormModel";
import StepThreeFormModel from "./steps/models/steps/StepThreeFormModel";
import StepFourFormModel from "./steps/models/steps/StepFourFormModel";
import StepFiveFormModel from "./steps/models/steps/StepFiveFormModel";
import HeirsModel from "./heirs/HearsModel";

@Component
export default class ProgramFormComponent extends Vue {

   stepsArray: StepsModel = null  // массив шагов такого типа FormStepsModel

   programForm: ProgramFormModel = null
   stepOneForm: StepOneFormModel = null
   stepTwoForm: StepTwoFormModel = null
   stepThreeForm: StepThreeFormModel = null
   stepFourForm: StepFourFormModel =  null
   stepFiveForm: StepFiveFormModel = null
   stepSixForm: HeirsModel[] = []

   created() {
      this.stepsArray = new StepsModel(
         [
            new StepModel(1, false),
            new StepModel(2, false),
            new StepModel(3, false),
            new StepModel(4, false),
            new StepModel(5, false),
            new StepModel(6, false)
         ], 1
      )
      
      
   }

   nextStep(complete: boolean, stepForm: any, stepId: number) {
      this.stepsArray.Active++
      let currentStep = this.stepsArray.Steps.find(el => el.Id == this.stepsArray.Active-1)
      if (currentStep) 
         currentStep.Complete = true

      console.log(stepForm, 'stepForm');
      switch (stepId) {
         case 1:
            return this.stepOneForm = stepForm
         case 2: 
            return this.stepTwoForm = stepForm
         case 3:
            return this.stepThreeForm = stepForm
         case 4:
            return this.stepFourForm = stepForm
         case 5:
            return this.stepFiveForm = stepForm
      }
   }

   send(heirs: HeirsModel[]) {
      if (heirs) {
         this.stepSixForm = heirs
         this.programForm = new ProgramFormModel(
            this.stepOneForm.Name,
            this.stepOneForm.Surname,
            this.stepOneForm.Patronymic,
            this.stepOneForm.DateOfBirth,
            this.stepOneForm.Age,
            this.stepOneForm.MaidenName,
            this.stepTwoForm.PasportNumber,
            this.stepTwoForm.PasportSeries,
            this.stepTwoForm.Inn,
            this.stepTwoForm.Phone,
            this.stepTwoForm.Email,
            this.stepThreeForm.MaritalStatus,
            this.stepThreeForm.Attitude,
            this.stepThreeForm.PlaceOfWork,
            this.stepThreeForm.Position,
            this.stepThreeForm.Responsibilities,
            this.stepThreeForm.ManOrWoman,
            this.stepFourForm.AddictedPeople,
            this.stepFourForm.PlaceOfResidence,
            this.stepFourForm.AddressMail,
            this.stepFourForm.IndexEmail,
            this.stepFourForm.LeftOrRight,
            this.stepFourForm.Motorcyclist,
            this.stepFiveForm.Height,
            this.stepFiveForm.Weight,
            this.stepFiveForm.CountOfCigarettes,
            this.stepFiveForm.CountOfAlcohol,
            this.stepFiveForm.KindOfAlcohol,
            this.stepFiveForm.Income,
            this.stepFiveForm.Profit,
            this.stepSixForm
         )
      }
      console.log(this.programForm, 'programForm');
   }

   prevStep() {
      this.stepsArray.Active--
      let currentStep = this.stepsArray.Steps.find(el => el.Id == this.stepsArray.Active)
      if (currentStep) 
         currentStep.Complete = false
   }
   
}
</script>

<style scoped>

.steps-number {
   margin: 0 auto 40px auto;
   display: flex;
   align-items: center;
   justify-content: space-around;
   width: 100%;
   max-width: 800px;
}

.step-item {
   width: 50px;
   height: 50px;
   border-radius: 50%;
   display: flex;
   align-items: center;
   justify-content: center;
   font-size: 18px;
   font-weight: 600;
   color: #121B23;
   background: #F8F9FC;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.2);
   transition: all 0.3s ease-out;
}

.step-item svg {
   width: 20px;
   height: 20px;
   fill: #12be83;
}

.step-item.complete {
   background: #f0f0f5;
   color: #9292a6;
}

.step-item.active {
   background: #12be83;
   color: #fff;
}

.step-item.active svg {
   fill: #fff;
}


.fadeStep-enter-active, .fadeStep-leave-active {
   transition: all 0.3s ease-out;
}

.fadeStep-enter, .fadeStep-leave-to {
   opacity: 0;
   visibility: hidden;
   transform: translateX(-5%);
}
</style>