<template>
   <div class="broker-request-form-wrap">
      <h4 class="i-title dancing">Welcome</h4>
      <h4 class="i-title form-title">Мы ждем тебя!</h4>

      <div class="broker-request-form">
         <div class="grid-item">
            <i-new-input 
               ref="name"
               v-model="name"
               :name="'name'"
               :placeholder="'Ivan'"
               :required="true"
               :regex="nameRegexLat"
               hasTooltip
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
               hasTooltip
               showError
               isStandart
            >
               <template slot="tooltip">Введите Фамилию латинскими буквами, как в загран паспорте.</template>
            </i-new-input>
         </div>

         <langs-dropdown :isCountry="true" :zIndex="2"></langs-dropdown>

         <div class="grid-item flex-item phone-item">
            <i-new-input 
               class="phone"
               ref="phone"
               v-model="phone"
               :name="'phone'"
               :placeholder="'565 556 56 65'"
               :required="true"
               :regex="phoneRegex"
               hasTooltip
               showError
               isPhone>
               <langs-dropdown :isPhone="true" :absolute="true"></langs-dropdown>
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
               hasTooltip
               showError
               isStandart
            >
               <template slot="tooltip">Указывайте ТОЛЬКО gmail (Google-почта)</template>
            </i-new-input>
         </div>

         <div class="grid-item column100 radio-group">
            <i-input-radio @onSelected="onSelected" :array="initRadiInputs" ></i-input-radio>
         </div>

         <i-button @onClick="isValidationClick" :fontSize="'16px'" :padding="'13px 25px'" :maxWidth="'170px'" :height="'45px'">Отправить</i-button>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import IInputRadioModel from "@components/i-input-radio/IInputRadioModel"

@Component
export default class BrokerRequestFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   name: string = ''  // value имя
   surname: string = ''  // value фамилия
   email: string = ''  // value email
   country: string = ''  // страна
   phone: string = ''  // value phone

   /**
    * переменные - текст ошибки при валидации
    */
   errorName: string = ''
   errorSurname: string = ''
   errorEmail: string = ''
   errorPhone: string = ''

   /**
    * Валидация формы
    */
   valid: boolean = false  // флаг на валидацию формы

   /**
    * Переменные для radio input
    */
   initRadiInputs: IInputRadioModel[] = []  // массив с input radio
   selectedRadio: IInputRadioModel = null  // активный radio

   /**
    * Регулярки
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+';  // имя
   nameRegexLat: RegExp = /^\w+([- _]\w+)*$/ // имя на литинском
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/;  // телефон
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 


   created() {
      this.initRadiInputs = [
         new IInputRadioModel(1,'man', 'Мужчина', true),
         new IInputRadioModel(2, 'woman', 'Женщина', false)
      ]
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
      /* name */
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
            

      /* surname */
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

      if (this.valid) {
         console.log('форма отправилась');
      } else {
         console.log('форма не отправилась');
      }
            
   }

   isValidationClick() {
      if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) &&
         (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) && 
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) &&
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) 
      ) {
         
         console.log('форма не отправилась условие 1');
      } else if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) ||
         (this.GetRef('surname') && !this.GetRef('surname').checkValidation()) || 
         (this.GetRef('phone') && !this.GetRef('phone').checkValidation()) ||
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) 
      ) {
         
         console.log('форма не отправилась условие 2');
      } else { 
         console.log('форма отправилась');
         this.$emit('success')
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

.broker-request-form {
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   gap: 15px;
}

/* radio group */
.grid-item.radio-group {
   align-self: center;
}


/* Dancing */
.i-title.dancing {
   margin-bottom: 15px;
   font-family: 'Dancing Script', cursive;
   font-size: 50px;
   font-weight: 700;
   color: #12be83;
   text-align: center;
   position: relative;
   z-index: 1;
   text-transform: none;
}

/* Заголовок в форме */
.i-title.form-title {
   margin-bottom: 40px;
   font-size: 25px;
   font-weight: 700;
   line-height: 120%;
   color: #fff;
   text-align: center;
   position: relative;
   z-index: 1;
}


.grid-item.column100 {
   grid-column: 1/3;
}


/* phone */
.phone-wrap {
   width: 100%;
   position: relative;
   z-index: 1;
}


@media all and (max-width: 660px) {
   .broker-request-form { grid-template-columns: 1fr; grid-template-rows: repeat(7, 1fr); }
   .grid-item.column100 { grid-column: 1/2; }
   .i-button.form-btn { order: 2; }
   .checkbox { margin: 15px 0 30px 0; order: 1; }
}

@media all and (max-width: 450px) {
   .i-title.form-title { font-size: calc((100vw - 280px)/(450 - 280) * (25 - 20) + 20px); }
}
</style>

<style>

.phone-wrap .form-item input {
   padding-left: 115px;
}
</style>