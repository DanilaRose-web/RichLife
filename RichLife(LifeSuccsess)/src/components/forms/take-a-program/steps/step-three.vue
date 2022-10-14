<template>
   <div class="step step-three">
      <div class="step-form">
         <div class="grid-item">
            <i-new-input 
               ref="maritalStatus"
               v-model="maritalStatus"
               :name="'maritalStatus'"
               :placeholder="'холост'"
               :required="true"
               :regex="nameRegex"
               :label="'Семейное положение'"
               hasLabel
               light
               showError
               isStandart
            >
               <template slot="tooltip">Введите Имя латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="attitude"
               v-model="attitude"
               :name="'attitude'"
               :placeholder="'сын'"
               :required="true"
               :regex="nameRegex"
               :label="'Отношение к страхователю'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите кем вы приходитесь страхователю, (степень родства, друг, знакомый)</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="placeOfWork"
               v-model="placeOfWork"
               :name="'placeOfWork'"
               :placeholder="'ООО «Организация»'"
               :required="true"
               :label="'Место работы'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите Ваше место работы, желательно полное и правильное название организации, ИП и т.д.</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="position"
               v-model="position"
               :name="'position'"
               :placeholder="'менеджер'"
               :required="true"
               :label="'Должность'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите занимаемую должность на текущем месте работы</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="responsibilities"
               v-model="responsibilities"
               :name="'responsibilities'"
               :placeholder="'реализация товара'"
               :required="true"
               :label="'Служебные обязанности'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите Ваши обязанности на занимаемой должности</template>
            </i-new-input>
         </div>

         <div class="grid-item radio-wrap grid-item">
            <!-- Пол -->
            <div class="radio-group">
               <i-input-radio class="no-mb" :darkTheme="true" @onSelected="onSelected" :array="genderRadio" ></i-input-radio>
            </div>
         </div>

         <div class="grid-item item-btn column100">
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
import StepThreeFormModel from "./models/steps/StepThreeFormModel";

@Component
export default class StepThreeComponent extends Vue {

   /**
    * Переменные - value инпутов
    */
   maritalStatus: string = ''  // семейное положение
   attitude: string = ''  // отношение к страхователю
   placeOfWork: string = ''  // место работы
   position: string = ''  // должность 
   responsibilities: string = ''  // служебные обязанности
   addressMail: string = ''  // адрес для корреспонденции
   indexEmail: number = null  // почтовый индекс


   /**
    * Переменные - поля текста с ошибками
    */
   errorAttitude: string = ''
   errorMaritalStatus: string = ''  // семейное положение
   errorPlaceOfWork: string = ''  
   errorPosition: string = '' 
   errorResponsibilities: string = ''
   errorAddressMail: string = ''
   errorIndexEmail: string = ''  

   /**
    * Модель шага 3
    */
   stepThreeForm: StepThreeFormModel = null

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
    * Переменные для radio input (пол)
    */
   genderRadio = [
      new IInputRadioModel(1,'man', 'Мужчина', true),
      new IInputRadioModel(2, 'woman', 'Женщина', false)
   ]

   /**
    * Выбранный radio
    */
   selectedRadio: IInputRadioModel = new IInputRadioModel(1,'man', 'Мужчина', true)  // активный radio




   created() {
      this.step = new StepModel(3)
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
      /* Семейное положение */
      if (this.maritalStatus == '' || this.maritalStatus == undefined) {
         this.errorMaritalStatus = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.maritalStatus)) {
         this.errorMaritalStatus = 'Введите корректное семейное положение'
         this.valid = false
      } else {
         this.errorMaritalStatus = '';
         this.valid = true
      }

      /* Отношение к страхователю */
      if (this.attitude == '' || this.attitude == undefined) {
         this.errorAttitude = 'Это обязательное поле'
         this.valid = false
      } else if (!this.nameRegex.test(this.attitude)) {
         this.errorAttitude = 'Введите корректные данные'
         this.valid = false
      } else {
         this.errorAttitude = '';
         this.valid = true
      }

      

      

      /* Место работы */
      if (this.placeOfWork == '' || this.placeOfWork == undefined) {
         this.errorPlaceOfWork = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorPlaceOfWork = '';
         this.valid = true
      }

      /* Должность */
      if (this.position == '' || this.position == undefined) {
         this.errorPosition = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorPosition = '';
         this.valid = true
      }

      /* Служебные обязанности */
      if (this.responsibilities == '' || this.responsibilities == undefined) {
         this.errorResponsibilities = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorResponsibilities = '';
         this.valid = true
      }

      if (this.valid) {
         this.stepThreeForm = new StepThreeFormModel(
            this.maritalStatus,
            this.attitude,
            this.placeOfWork,
            this.position,
            this.responsibilities,
            this.selectedRadio.id
         )
         this.$emit('next', this.step.Complete = true, this.stepThreeForm, this.step.Id)
      } else {
         console.log('форма 3 не отправилась');
      }
      
   }

   isValidationClick() {
      if (
         (this.GetRef('maritalStatus') && !this.GetRef('maritalStatus').checkValidation()) &&
         (this.GetRef('attitude') && !this.GetRef('attitude').checkValidation()) && 
         (this.GetRef('placeOfWork') && !this.GetRef('placeOfWork').checkValidation()) &&
         (this.GetRef('position') && !this.GetRef('position').checkValidation()) &&
         (this.GetRef('responsibilities') && !this.GetRef('responsibilities').checkValidation())
      ) {
         
      } else if (
         (this.GetRef('maritalStatus') && !this.GetRef('maritalStatus').checkValidation()) ||
         (this.GetRef('attitude') && !this.GetRef('attitude').checkValidation()) || 
         (this.GetRef('placeOfWork') && !this.GetRef('placeOfWork').checkValidation()) ||
         (this.GetRef('position') && !this.GetRef('position').checkValidation()) ||
         (this.GetRef('responsibilities') && !this.GetRef('responsibilities').checkValidation())
      ) {
         
      } else { 
         this.$emit('next', this.step.Complete = true, this.stepThreeForm, this.step.Id)
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

.grid-item.column100 {
   grid-column: 1/3;
}

.radio-wrap {
   height: 100%;
   display: flex;
   align-items: center;
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