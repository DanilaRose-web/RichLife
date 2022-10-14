<template>
   <div class="step step-four">
      <div class="step-form">
         <div class="grid-item">
            <i-new-input 
               ref="addictedPeople"
               v-model="addictedPeople"
               :name="'addictedPeople'"
               :placeholder="'2'"
               :required="true"
               :regex="numberRegex"
               :label="'Кол-во финансово зависимых людей'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите только количество (только число)</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="placeOfResidence"
               v-model="placeOfResidence"
               :name="'placeOfResidence'"
               :placeholder="'г. Тирасполь, улица Федько 105, 98'"
               :required="true"
               :label="'Место проживания'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите адрес, по которому вы проживаете в данный момент</template>
            </i-new-input>
         </div>
         
         <div class="grid-item">
            <i-new-input 
               ref="indexEmail"
               v-model="indexEmail"
               :name="'indexEmail'"
               :placeholder="'3300'"
               :required="true"
               :regex="numberRegex"
               :label="'Почтовый индекс'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите почтовый индекс вашего региона</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="addressMail"
               v-model="addressMail"
               :name="'addressMail'"
               :placeholder="'г. Тирасполь, улица Федько 105, 98'"
               :required="true"
               :label="'Адрес для корреспонденции'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите адрес, по которому Вам могжет приходить различная корреспонденция, касательно страхования</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <!-- Левша / правша -->
            <div class="radio-group">
               <i-input-radio class="no-mb" :darkTheme="true" @onSelected="onSelected" :array="handsRadio" ></i-input-radio>
            </div> 
         </div>

         <div class="grid-item">
            <!-- Мотоциклист -->
            <div class="checkbox-wrap">
               <input-checkbox 
                  :label="'Мотоциклист'" 
                  :checked="motorcyclist" 
                  @click="setMotorcyclist">
               </input-checkbox>
            </div>
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
import StepFourFormModel from "./models/steps/StepFourFormModel"

@Component
export default class StepFourComponent extends Vue {

   /**
    * Переменные - value инпутов
    */
   addictedPeople: number = null  // кол-во финансово зависимых людей
   placeOfResidence: string = ''  // место проживания
   addressMail: string = '' // адрес для корреспонденции
   indexEmail: number = null  // почтовый индекс
   motorcyclist: boolean = false  // мотоциклист


   /**
    * Переменные - поля текста с ошибками
    */
   errorAddictedPeople: string = ''     
   errorPlaceOfResidence: string = ''
   errorAddressMail: string = ''
   errorIndexEmail: string = ''

   /**
    * Модель шага 4
    */
   stepFourForm: StepFourFormModel = null

   /**
    * Регулярные выражения
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+';  // имя
   numberRegex: RegExp = /^[0-9]+$/ // только числа

   /**
    * Переменные валиации формы
    */
   valid: boolean = false
   step: StepModel = null  // номер шага формы

   /**
    * Переменные для radio input (левша/правша)
    */
   handsRadio = [  
      new IInputRadioModel(1,'right', 'Правша', true),
      new IInputRadioModel(2, 'left', 'Левша', false)
   ]

   selectedRadio: IInputRadioModel = new IInputRadioModel(1,'right', 'Правша', true)  // активный radio


   created() {
      this.step = new StepModel(4)
      this.$emit('step', this.step)
   }


   /**
    * Выбор текущего значения input radio
    */
   onSelected(current: IInputRadioModel) {
      this.selectedRadio = current
   }
  
  
   /**
    * Клик по чекбоксу мотоциклист
    */
   setMotorcyclist() {
      this.motorcyclist = !this.motorcyclist
   }


   



   /**
    * Валидация формы
    */
   isValid(event: any) {
      /* Кол-во финансово зависимых людей */
      if (this.addictedPeople == null || this.addictedPeople == 0 || this.addictedPeople == undefined) {
         this.errorAddictedPeople = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.addictedPeople)) {
         this.errorAddictedPeople = 'Введите число'
         this.valid = false
      } else {
         this.errorAddictedPeople = '';
         this.valid = true
      }

      /* Место проживания */
      if (this.placeOfResidence == '' || this.placeOfResidence == undefined) {
         this.errorPlaceOfResidence = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorPlaceOfResidence = '';
         this.valid = true
      }
            

      /* Адрес для корреспонденции */
      if (this.addressMail == '' || this.addressMail == undefined) {
         this.errorAddressMail = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorAddressMail = '';
         this.valid = true
      }

      /* Почтовый индекс */
      if (this.indexEmail == null || this.indexEmail == 0 || this.indexEmail == undefined) {
         this.errorIndexEmail = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.indexEmail)) {
         this.errorIndexEmail = 'Введите число'
         this.valid = false
      } else {
         this.errorIndexEmail = '';
         this.valid = true
      }


     


      if (this.valid) {
         this.stepFourForm = new StepFourFormModel(
            this.addictedPeople,
            this.placeOfResidence,
            this.addressMail,
            this.indexEmail,
            this.selectedRadio.id,
            this.motorcyclist
         )
         this.$emit('next', this.step.Complete = true, this.stepFourForm, this.step.Id)
      } else {
         console.log('форма 4 не отправилась');
      }
   }

   isValidationClick() {
      if (
         (this.GetRef('addictedPeople') && !this.GetRef('addictedPeople').checkValidation()) &&
         (this.GetRef('placeOfResidence') && !this.GetRef('placeOfResidence').checkValidation()) && 
         (this.GetRef('indexEmail') && !this.GetRef('indexEmail').checkValidation()) &&
         (this.GetRef('addressMail') && !this.GetRef('addressMail').checkValidation())
      ) {
         
      } else if (
         (this.GetRef('addictedPeople') && !this.GetRef('addictedPeople').checkValidation()) ||
         (this.GetRef('placeOfResidence') && !this.GetRef('placeOfResidence').checkValidation()) || 
         (this.GetRef('indexEmail') && !this.GetRef('indexEmail').checkValidation()) ||
         (this.GetRef('addressMail') && !this.GetRef('addressMail').checkValidation())
      ) {
         
      } else { 
         this.$emit('next', this.step.Complete = true, this.stepFourForm, this.step.Id)
      }
   }
}
</script>

<style scoped>

.step-form {
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   gap: 15px;
}

.grid-item.column100 {
   grid-column: 1/3;
}

.radio-wrap {
   display: flex;
   align-items: center;
}

.checkbox-wrap {
   width: max-content;
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