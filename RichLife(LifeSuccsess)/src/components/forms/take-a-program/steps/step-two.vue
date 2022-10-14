<template>
   <div class="step step-two">
      <div class="step-form">
         <div class="grid-item">
            <i-new-input 
               ref="pasportNumber"
               v-model="pasportNumber"
               :name="'pasportNumber'"
               :placeholder="'Номер паспорта'"
               :required="true"
               :regex="numberRegex"
               :label="'Паспорт, свидетельство (номер)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите номер паспорта/свидетельства (загран)</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="pasportSeries"
               v-model="pasportSeries"
               :name="'pasportSeries'"
               :placeholder="'Серия паспорта'"
               :required="true"
               :regex="numberRegex"
               :label="'Паспорт, свидетельство (серия)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите серию паспорта/свидетельства (загран)</template>
            </i-new-input>
         </div>

         <!-- Фото паспорта -->

         <div class="grid-item">
            <i-new-input 
               ref="inn"
               v-model="inn"
               :name="'inn'"
               :placeholder="'ИНН'"
               :required="true"
               :regex="numberRegex"
               :label="'ИНН (украинский)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">ИНН состоит из 11-ти цифр</template>
            </i-new-input>
         </div>

         <div class="grid-item flex-item phone-item">
            <i-new-input 
               class="phone"
               ref="phone"
               v-model="phone"
               :name="'phone'"
               :placeholder="'565 556 56 65'"
               :required="true"
               :regex="phoneRegex"
               :label="'Телефон'"
               hasLabel
               hasTooltip
               light
               showError
               isPhone>
               <langs-dropdown class="hasLabel" :isPhone="true" :absolute="true"></langs-dropdown>
               <template slot="tooltip">Укажите номер телефона без кода страны. Если номер ПМР, то введите его в формате: 779 123 45</template>
            </i-new-input>
         </div>
            
         <div class="grid-item column100">
            <i-new-input 
               ref="email"
               v-model="email"
               :name="'email'"
               :placeholder="'example@gmail.com'"
               :required="true"
               :regex="emailRegex"
               :label="'Email'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Указывайте ТОЛЬКО gmail (Google-почта)</template>
            </i-new-input>
         </div>

         <div class="grid-item column100 item-btn">
            <i-button @onClick="$emit('prev')" class="transparent" :margin="'0 10px 0 0'">Назад</i-button>
            <i-button @onClick="isValidationClick">Вперед</i-button>
         </div>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import IInputRadioModel from "@components/i-input-radio/IInputRadioModel";
import StepModel from "./models/StepModel";
import StepTwoFormModel from "./models/steps/StepTwoFormModel"

@Component
export default class StepTwoComponent extends Vue {

   /**
    * Переменные - value инпутов
    */
   
   pasportNumber: string = ''  // номер паспорта
   pasportSeries: string = ''  // паспорт серия
   inn: number = null  // ИНН
   phone: string = ''  // phone
   email: string = ''  // email


   /**
    * Переменные - поля текста с ошибками
    */
   errorPasportNumber: string = ''
   errorPasportSeries: string = ''
   errorInn: string = ''
   errorPhone: string = ''
   errorEmail: string = ''

   /**
    * Модель шага 2
    */
   stepTwoForm: StepTwoFormModel = null

   /**
    * Регулярные выражения
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+';  // имя
   numberRegex: RegExp = /^[0-9]+$/ // только числа
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/;  // телефон
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 

   /**
    * Переменные валиации формы
    */
   valid: boolean = false
   step: StepModel = null  // номер шага формы

   selectedRadio: IInputRadioModel = null  // активный radio


   created() {
      this.step = new StepModel(2)
      this.$emit('step', this.step)
   }



   /**
    * Валидация формы
    */
   isValid(event: any) {
      /* номер паспорта */
      if (this.pasportNumber == '' || this.pasportNumber == undefined) {
         this.errorPasportNumber = 'Это обязательное поле'
         this.valid = false
      }  else {
         this.errorPasportNumber = '';
         this.valid = true
      }

      /* серия паспорта */
      if (this.pasportSeries == '' || this.pasportSeries == undefined) {
         this.errorPasportSeries = 'Это обязательное поле'
         this.valid = false
      }  else {
         this.errorPasportSeries = '';
         this.valid = true
      }

      /* ИНН */
      if (this.inn == null || this.inn == 0 || this.inn == undefined) {
         this.errorInn = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.inn)) {
         this.errorInn = 'Введите корректный ИНН'
         this.valid = false
      } else {
         this.errorInn = '';
         this.valid = true
      }

      /* phone */
      if (this.phone == '' || this.phone == undefined) {
         this.errorPhone = 'Это обязательное поле'
         this.valid = false
      } else if (!this.phoneRegex.test(this.phone)) {
         this.errorPhone = 'Введите корректный номер телефона'
         this.valid = false
      } else {
         this.errorPhone = ''
         this.valid = true
      }
      
      /* email */
      if (this.email == '' || this.email == undefined) {
         this.errorEmail = 'Это обязательное поле'
         this.valid = false
      } else if (!this.validEmail(this.email)) {
         this.errorEmail = 'Введите корректный email'
         this.valid = false
      } else {
         this.errorEmail = ''
         this.valid = true
      }


      if (this.valid) {
         console.log('форма отправилась');
         this.stepTwoForm = new StepTwoFormModel(
            this.pasportNumber,
            this.pasportSeries,
            this.inn,
            this.phone,
            this.email
         )
         this.$emit('next', this.step.Complete = true, this.stepTwoForm, this.step.Id)
      } else {
         console.log('форма 2 не отправилась');
      }
      
   }

   isValidationClick() {
      if (
         (this.GetRef('pasportNumber') && !this.GetRef('pasportNumber').checkValidation()) &&
         (this.GetRef('pasportSeries') && !this.GetRef('pasportSeries').checkValidation()) && 
         (this.GetRef('inn') && !this.GetRef('inn').checkValidation()) &&
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) &&
         (this.GetRef('email') && !this.GetRef('email').checkValidation())
      ) {
         
      } else if (
         (this.GetRef('pasportNumber') && !this.GetRef('pasportNumber').checkValidation()) ||
         (this.GetRef('pasportSeries') && !this.GetRef('pasportSeries').checkValidation()) || 
         (this.GetRef('inn') && !this.GetRef('inn').checkValidation()) ||
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) ||
         (this.GetRef('email') && !this.GetRef('email').checkValidation())
      ) {
         
      } else { 
         this.$emit('next', this.step.Complete = true, this.stepTwoForm, this.step.Id)
      }
   }


   /**
    * Валидация Email
    */
   validEmail(value: string): boolean {
      let reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return reg.test(value);
   }

}
</script>

<style scoped>

.step-form {
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
}

.grid-item.column100 {
   grid-column: 1/3;
}

.item-btn {
   margin-top: 30px;
   width: 100%;
   display: flex;
   justify-content: flex-end;
}

@media all and (max-width: 620px) {
   .step-form { grid-template-columns: 1fr; }
   .grid-item.column100 { grid-column: 1/2; }
}
</style>








<style>

.i-inputs-radio.no-mb .i-input-radio {
   margin-bottom: 0;
}

.step {
   margin: 0 auto;
   max-width: 900px;
}
</style>