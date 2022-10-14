<template>
   <div class="step step-five">
      <div class="step-form">
         <div class="grid-item">
            <i-new-input 
               ref="height"
               v-model="height"
               :name="'height'"
               :placeholder="'182'"
               :required="true"
               :regex="numberRegex"
               :label="'Рост (см)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите ТОЛЬКО число</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="weight"
               v-model="weight"
               :name="'weight'"
               :placeholder="'84'"
               :required="true"
               :regex="numberRegex"
               :label="'Вес (кг)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите ТОЛЬКО число</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="countOfCigarettes"
               v-model="countOfCigarettes"
               :name="'countOfCigarettes'"
               :placeholder="'45'"
               :required="true"
               :regex="numberRegex"
               :label="'Кол-во сигарет в день'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите ТОЛЬКО число</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="countOfAlcohol"
               v-model="countOfAlcohol"
               :name="'countOfAlcohol'"
               :placeholder="'5'"
               :required="true"
               :regex="numberRegex"
               :label="'Кол-во алкоголя в неделю (л)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите ТОЛЬКО число</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="income"
               v-model="income"
               :name="'income'"
               :placeholder="'20 000'"
               :required="true"
               :regex="numberRegex"
               :label="'Совокупный доход ($)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите Ваш общий ежемесячный доход (ТОЛЬКО число)</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="profit"
               v-model="profit"
               :name="'profit'"
               :placeholder="'10 000'"
               :required="true"
               :regex="numberRegex"
               :label="'Чистый доход ($)'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите Ваш чистый ежемесячный доход (ТОЛЬКО число)</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="kindOfAlcohol"
               v-model="kindOfAlcohol"
               :name="'kindOfAlcohol'"
               :placeholder="'бурбон, малибу'"
               :required="true"
               :label="'Вид алкоголя'"
               hasLabel
               hasTooltip
               light
               showError
               isStandart
            >
               <template slot="tooltip">Укажите Ваш предпочтительный вид алкоголя, которого вы выпиваете больше остальных видов</template>
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

import StepModel from "./models/StepModel";
import StepFiveFormModel from "./models/steps/StepFiveFormModel"

@Component
export default class StepFiveComponent extends Vue {

   /**
    * Переменные - value инпутов
    */
   height: number = null  // рост
   weight: number = null  // вес
   countOfCigarettes: number = null  // кол-во сигарет в день
   countOfAlcohol: number = null  // кол-во алкоголя в неделю
   kindOfAlcohol: string = ''  // вид алкоголя
   income: number = null  // совокупный доход
   profit: number = null  // чистый доход


   /**
    * Переменные - поля текста с ошибками
    */
   errorHeight: string = '' 
   errorWeight: string = '' 
   errorСountOfCigarettes: string = ''  
   errorCountOfAlcohol: string = ''  
   errorKindOfAlcohol: string = ''  
   errorIncome: string = '' 
   errorProfit: string = '' 
   

   /**
    * Модель шага 5
    */
   stepFiveForm: StepFiveFormModel = null


   

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


   created() {
      this.step = new StepModel(5)
      this.$emit('step', this.step)
   }



   /**
    * Валидация формы
    */
   isValid(event: any) {
       /* Рост */
      if (this.height == null || this.height == 0 || this.height == undefined) {
         this.errorHeight = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.height)) {
         this.errorHeight = 'Введите число'
         this.valid = false
      } else {
         this.errorHeight = '';
         this.valid = true
      }

      /* Вес */
      if (this.weight == null || this.weight == 0 || this.weight == undefined) {
         this.errorWeight = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.weight)) {
         this.errorWeight = 'Введите число'
         this.valid = false
      } else {
         this.errorWeight = '';
         this.valid = true
      }

      /* Кол-во сигарет в день */
      if (this.countOfCigarettes == null || this.countOfCigarettes == 0 || this.countOfCigarettes == undefined) {
         this.errorСountOfCigarettes = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.countOfCigarettes)) {
         this.errorСountOfCigarettes = 'Введите число'
         this.valid = false
      } else {
         this.errorСountOfCigarettes = '';
         this.valid = true
      }

      /* Кол-во алкоголя в неделю */
      if (this.countOfAlcohol == null || this.countOfAlcohol == 0 || this.countOfAlcohol == undefined) {
         this.errorCountOfAlcohol = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.countOfAlcohol)) {
         this.errorCountOfAlcohol = 'Введите число'
         this.valid = false
      } else {
         this.errorCountOfAlcohol = '';
         this.valid = true
      }

      /* Вид алкоголя */
      if (this.kindOfAlcohol == '' || this.kindOfAlcohol == undefined) {
         this.errorKindOfAlcohol = 'Это обязательное поле'
         this.valid = false
      } else {
         this.errorKindOfAlcohol = ''
         this.valid = true
      }

      /* Совокупный доход */
      if (this.income == null || this.income == 0 || this.income == undefined) {
         this.errorIncome = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.income)) {
         this.errorIncome = 'Введите число'
         this.valid = false
      } else {
         this.errorIncome = '';
         this.valid = true
      }

      /* Чистый доход */
      if (this.profit == null || this.profit == 0 || this.profit == undefined) {
         this.errorProfit = 'Это обязательное поле'
         this.valid = false
      } else if (!this.numberRegex.test(this.profit)) {
         this.errorProfit = 'Введите число'
         this.valid = false
      } else {
         this.errorProfit = '';
         this.valid = true
      }

      if (this.valid) {
         this.stepFiveForm = new StepFiveFormModel(
            this.height,
            this.weight,
            this.countOfCigarettes,
            this.countOfAlcohol,
            this.kindOfAlcohol,
            this.income,
            this.profit
         )
         this.$emit('next', this.step.Complete = true, this.stepFiveForm, this.step.Id)
      } else {
         console.log('форма 5 не отправилась');
      }
      
   }

   isValidationClick() {
      if (
         (this.GetRef('height') && !this.GetRef('height').checkValidation()) &&
         (this.GetRef('weight') && !this.GetRef('weight').checkValidation()) && 
         (this.GetRef('countOfCigarettes') && !this.GetRef('countOfCigarettes').checkValidation()) &&
         (this.GetRef('countOfAlcohol') && !this.GetRef('countOfAlcohol').checkValidation()) &&
         (this.GetRef('income') && !this.GetRef('income').checkValidation()) && 
         (this.GetRef('profit') && !this.GetRef('profit').checkValidation()) &&
         (this.GetRef('kindOfAlcohol') && !this.GetRef('kindOfAlcohol').checkValidation())
      ) {
         
      } else if (
         (this.GetRef('height') && !this.GetRef('height').checkValidation()) ||
         (this.GetRef('weight') && !this.GetRef('weight').checkValidation()) || 
         (this.GetRef('countOfCigarettes') && !this.GetRef('countOfCigarettes').checkValidation()) ||
         (this.GetRef('countOfAlcohol') && !this.GetRef('countOfAlcohol').checkValidation()) ||
         (this.GetRef('income') && !this.GetRef('income').checkValidation()) || 
         (this.GetRef('profit') && !this.GetRef('profit').checkValidation()) ||
         (this.GetRef('kindOfAlcohol') && !this.GetRef('kindOfAlcohol').checkValidation())
      ) {
         
      } else { 
         this.$emit('next', this.step.Complete = true, this.stepFiveForm, this.step.Id)
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

.checkbox-wrap {
   margin-top: 20px;
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