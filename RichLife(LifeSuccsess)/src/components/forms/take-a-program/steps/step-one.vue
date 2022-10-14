<template>
   <div class="step step-one">
      <div class="step-form">
         <div class="grid-item">
            <i-new-input 
               ref="name"
               v-model="name"
               :name="'name'"
               :placeholder="'Ivan'"
               :required="true"
               :regex="nameRegexLat"
               :label="'Имя'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Имя латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="surname"
               v-model="surname"
               :name="'surname'"
               :placeholder="'Ivanov'"
               :required="true"
               :regex="nameRegexLat"
               :label="'Фамилия'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Фамилию латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="patronymic"
               v-model="patronymic"
               :name="'patronymic'"
               :placeholder="'Ivanovich'"
               :required="true"
               :regex="nameRegexLat"
               :label="'Отчество'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Отчество латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="dateOfBirth"
               v-model="dateOfBirth"
               :name="'dateOfBirth'"
               :placeholder="'01.01.2021'"
               :required="true"
               :label="'Дата рождения'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Дату Рождения в формате 01.01.2021</template>
            </i-new-input>
         </div>
            
         <div class="grid-item">
            <i-new-input 
               ref="age"
               v-model="age"
               :name="'age'"
               :placeholder="'35'"
               :required="true"
               :regex="numberRegex"
               :label="'Полных лет'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Вводите только числа</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="maidenName"
               v-model="maidenName"
               :name="'maidenName'"
               :placeholder="'Ivanova'"
               :required="false"
               :regex="nameRegexLat"
               :label="'Девичья фамилия (если есть)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Девичью Фамилию (если она есть) латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <div class="grid-item item-btn">
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
import StepOneFormModel from "./models/steps/StepOneFormModel"

@Component
export default class StepOneComponent extends Vue {

   /**
    * Переменные - value инпутов
    */
   name: string = ''  // имя
   surname: string = ''  // фамилия
   patronymic: string = ''  // отчество
   dateOfBirth: string = ''  // дата рождения
   age: number = null  // полных лет
   maidenName: string = ''  // девичья фамилия


   /**
    * Переменные - поля текста с ошибками
    */
   errorName: string = ''  // имя
   errorSurname: string = ''  // фамилия
   errorPatronymic: string = ''  // отчество
   errorDateOfBirth: string = ''  // дата рождения
   errorAge: string = ''  // полных лет
   errorMaidenName: string = ''  // девичья фамилия

   /**
    * Модель шага 1
    */
   stepOneForm: StepOneFormModel = null

   /**
    * Регулярные выражения
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\_]+$/; //'[\\w\s]+';  // имя
   nameRegexLat: RegExp = /^\w+[^0-9\s\_]([- _]\w+)*$/ // имя на литинском
   numberRegex: RegExp = /^[0-9]+$/ // только числа

   /**
    * Переменные валиации формы
    */
   valid: boolean = false
   step: StepModel = null  // номер шага формы

   /**
    * Переменные для radio input (пол)
    */
   genderRadio = [
      new IInputRadioModel(1,'man', 'Мужчина', true),
      new IInputRadioModel(2, 'woman', 'Женщина', false)
   ]

   selectedRadio: IInputRadioModel = null  // активный radio


   created() {
      this.step = new StepModel(1)
      this.$emit('step', this.step)
   }


   /**
    * Выбор текущего значения input radio
    */
   onSelected(current: IInputRadioModel) {
      this.selectedRadio = current
   }


   



   /**
    * Валидация формы
    */
   isValid(event: any) {
      /* Имя */
      if (this.name == '' || this.name == undefined) {
         this.errorName = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.name)) {
         this.errorName = 'Введите корректное имя'
         this.valid = false
      } else {
         this.errorName = '';
         this.valid = true
      }
            

      /* Фамилия */
      if (this.surname == '' || this.surname == undefined) {
         this.errorSurname = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.surname)) {
         this.errorSurname = 'Введите корректую фамилию'
         this.valid = false
      } else {
         this.errorSurname = '';
         this.valid = true
      }

      /* Отчество */
      if (this.patronymic == '' || this.patronymic == undefined) {
         this.errorPatronymic = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.patronymic)) {
         this.errorPatronymic = 'Введите корректое отчество'
         this.valid = false
      } else {
         this.errorPatronymic = '';
         this.valid = true
      }
      
      /* Дата рождения */
      if (this.dateOfBirth == '' || this.dateOfBirth == undefined) {
         this.errorDateOfBirth = 'Это обязательное поле'
         this.valid = false
      }  else {
         this.errorDateOfBirth = '';
         this.valid = true
      }

      /* Полных лет */
      if (this.age == null || this.age == 0 || this.age == undefined) {
         this.errorAge = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.age)) {
         this.errorAge = 'Введите корректный возраст'
         this.valid = false
      } else if (this.age >= 100) {
         this.errorAge = 'Введите корректный возраст'
         this.valid = false
      } else {
         this.errorAge = '';
         this.valid = true
      }
      

      /**
       * Девичья фамилия
       */
      if (!this.nameRegex.test(this.maidenName)) {
         this.errorMaidenName = 'Цифры не допустимы'
         this.valid = false
      } else if (this.maidenName == '' || this.maidenName == undefined) {
         this.errorMaidenName = ''
         this.valid = true
      }


      if (this.valid) {
         this.stepOneForm = new StepOneFormModel(
            this.name, 
            this.surname, 
            this.patronymic, 
            this.dateOfBirth, 
            this.age, 
            this.maidenName
         )
         this.$emit('next', this.step.Complete = true, this.stepOneForm, this.step.Id)
      } else {
         console.log('форма 1 не отправилась');
      }
      
      
   }

   isValidationClick() {
      if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) &&
         (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) && 
         (this.GetRef('patronymic') && !this.GetRef('patronymic').checkValidation()) &&
         (this.GetRef('dateOfBirth') && !this.GetRef('dateOfBirth').checkValidation()) &&
         (this.GetRef('age') && !this.GetRef('age').checkValidation()) &&
         (this.GetRef('maidenName') && !this.GetRef('maidenName').checkValidation()) 
      ) {
         
      } else if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) ||
         (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) || 
         (this.GetRef('patronymic') && !this.GetRef('patronymic').checkValidation()) ||
         (this.GetRef('dateOfBirth') && !this.GetRef('dateOfBirth').checkValidation()) ||
         (this.GetRef('age') && !this.GetRef('age').checkValidation()) ||
         (this.GetRef('maidenName') && !this.GetRef('maidenName').checkValidation()) 
      ) {
         
      } else { 
         this.$emit('next', this.step.Complete = true, this.stepOneForm, this.step.Id)
      }
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

.radio-wrap {
   height: 100%;
   display: flex;
   align-items: flex-end;
}

.item-btn {
   margin-top: 30px;
   width: 100%;
   grid-column: 1/3;
   display: flex;
   justify-content: flex-end;
}

@media all and (max-width: 620px) {
   .step-form { grid-template-columns: 1fr; }
   .item-btn { grid-column: 1/2; }
}
</style>








<style>

.i-inputs-radio.no-mb .i-input-radio {
   margin-bottom: 0;
}

.step {
   margin: 0 auto;
   max-width: 900px;
   transform: translateX(0);
   opacity: 1;
   visibility: visible;
}
</style>