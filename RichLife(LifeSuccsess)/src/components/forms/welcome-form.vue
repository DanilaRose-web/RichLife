<template>
   <div class="join-form-wrap">
      <h4 class="i-title dancing">Together with WellbeLife</h4>
      <h4 class="i-title form-title">Присоединиться!</h4>
      
      <!-- <invite-referal allWidth :color="'#fff'" alignCenter  :withButton="false"></invite-referal> -->

      <div class="join-form">
         <div class="grid-item">
            <i-new-input 
               ref="name"
               v-model="name"
               :name="'name'"
               :placeholder="'Имя'"
               :required="true"
               :regex="nameRegex"
               showError
               isStandart
            >
               <template slot="tooltip">Введите Имя латинскими буквами, как в загран паспорте (рекомендуется). Так как эти данные можно буде использовать для упрощения процедуры оформления программы</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="email"
               v-model="email"
               :name="'email'"
               :placeholder="'example@gmail.com'"
               :required="true"
               :regex="emailRegex"
               showError
               isStandart
            >
               <template slot="tooltip">Указывайте ТОЛЬКО gmail (Google-почта)</template>
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="password"
               v-model="password"
               :name="'password'"
               :placeholder="'Пароль'"
               :type="'password'"
               :required="true"
               showError
               isStandart
            >
            </i-new-input>
         </div>

         <div class="grid-item">
            <i-new-input 
               ref="passwordRepeat"
               v-model="passwordRepeat"
               :name="'passwordRepeat'"
               :placeholder="'Повторите пароль'"
               :type="'password'"
               :required="true"
               showError
               isStandart
            >
            </i-new-input>
         </div>

         <div class="radio-group grid-item column100">
            <i-input-radio @onSelected="onSelected" :array="initRadiInputs" ></i-input-radio>
         </div>

         <div class="i-button-wrap">
            <i-button @onClick="isValidationClick" :height="'45px'" :fontSize="'16px'" :padding="'13px 25px'" :maxWidth="'170px'">Отправить</i-button>
            <div class="policy-confirm-wrap">
               <div class="privacy-policy">
                  <p class="text">Нажимая на кнопку "Отправить" Вы соглашаетесь на обработку своих персональных данных, согласно условиям <a href="">политики конфиденциальности</a></p>
               </div>
            </div>
         </div>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import IInputRadioModel from "@components/i-input-radio/IInputRadioModel"
import IDropdownModel from "@components/i-dropdown/models/IDropdownModel"

@Component
export default class WelcomeFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   name: string = ''  // value имя
   surname: string = ''  // value фамилия
   email: string = ''  // value email
   emailRepeat: string = ''  // повторить email
   password: string = ''  // пароль
   passwordRepeat: string = ''  // повторить пароль
   country: string = ''  // страна
   phone: string = ''  // value phone

   /**
    * переменные - текст ошибки при валидации
    */
   errorName: string = ''
   errorSurname: string = ''
   errorEmail: string = ''
   errorEmailRepeat: string = ''
   errorPassword: string = ''
   errorPasswordRepeat: string = ''
   errorPhone: string = ''

   /**
    * Валидация формы
    */
   valid: boolean = false  // флаг на валидацию формы
   passwordMismatch: boolean = false // показываем сообщение, если пароли не совпадают
   registered: boolean = false
   
   /**
    * Переменные для radio input
    */
   initRadiInputs: IInputRadioModel[] = []  // массив с input radio
   selectedRadio: IInputRadioModel = null  // активный radio

   /**
    * Регулярки
    */
   nameRegex: RegExp = /^[A-zА-я\s^_][^0-9\s_]+$/; //'[\\w\s]+';  // имя
   phoneRegex: RegExp = /^(\s*)?(\+)?([- _():+]?\d[- _():+]?){8,14}(\s*)?$/;  // телефон
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 

   /**
    * Модель для способов оплаты
    */
   paymentTypes: IDropdownModel[] = []

   /**
    * Выбранный способ оплаты
    */
   selectedPaymentType: IDropdownModel = null


   created() {
      this.initRadiInputs = [
         new IInputRadioModel(1,'man', 'Мужчина', true),
         new IInputRadioModel(2, 'woman', 'Женщина', false)
      ]

      this.paymentTypes = [
         new IDropdownModel(1, 'Платежная карта', true, false),
         new IDropdownModel(2, 'QIWI', false, false),
      ]
   }


   /**
    * Выбор текущего значения input radio
    */
   onSelected(current: IInputRadioModel) {
      this.selectedRadio = current
   }


   /**
    * Получение выбранного способа платежа из i-dropdown
    */
   onSelect(selected: IDropdownModel) {
      this.selectedPaymentType = selected
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
               

      /* password */
      if (this.password == '' || this.password == undefined) {
         this.errorPassword = 'Это обязательное поле'
         this.valid = false
      } else if (this.password.length < 8) {
         this.errorPassword = 'Пароль должен быть не меньше 8 символов'
         this.valid = false
      } else {
         this.errorPassword = ''
         this.valid = true
      }
            

      /* password repeat */
      if (this.passwordRepeat == '' || this.passwordRepeat == undefined) {
         this.errorPasswordRepeat = 'Это обязательное поле'
         this.valid = false
      } else if (this.passwordRepeat != this.password) {
         this.errorPasswordRepeat = 'Пароли не совпадают'
         this.valid = false
      } else {
         this.errorPasswordRepeat = ''
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
         this.$emit('closeForm')
      } else {
         console.log('форма не отправилась');
      }
            
   }

   /**
    * Валидация Email
    */
   validEmail(value: string): boolean {
      let reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return reg.test(value);
   }


   isValidationClick() {
      if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) &&
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) &&
         (this.GetRef('password') && !this.GetRef('password').checkValidation()) &&
         (this.GetRef('passwordRepeat') && !this.GetRef('passwordRepeat').checkValidation())
      ) {} 
      else if (
         (this.GetRef('name') && !this.GetRef('name').checkValidation()) ||
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) ||
         (this.GetRef('password') && !this.GetRef('password').checkValidation()) ||
         (this.GetRef('passwordRepeat') && !this.GetRef('passwordRepeat').checkValidation())
      ) {} 
      else if (this.GetRef('passwordRepeat').value.length != this.GetRef('password').value.length) {
         this.passwordMismatch = true
      }
      else { 
         console.log('форма отправилась');
         this.passwordMismatch = false
         this.$router.push({name: 'profile' })
      }
   }
}


</script>

<style scoped>

/* i-form */
.join-form {
   display: grid;
   grid-template-columns: 1fr;
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
   position: relative;
   z-index: 2;
}

.flex-item {
   display: flex;
   align-items: center;
   width: 100%;
}


/* radio group */
.radio-group {
   margin-bottom: 30px;
   display: flex;
   justify-content: center;
}






/* Dancing */
.i-title.dancing {
   margin-bottom: 15px;
   /* font-family: 'Dancing Script', cursive; */
   font-family: 'Fineday', cursive;
   font-size: 50px;
   font-weight: 500;
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




/* phone */
.phone-wrap {
   width: 100%;
   position: relative;
   z-index: 1;
}

.error-message {
   font-size: 15px;
   font-weight: 500;
   line-height: 140%;
   color: #eb2207;
   text-align: center;
}



.i-button-wrap {
   display: flex;
   align-items: center;
   justify-content: space-between;
}


@media all and (max-width: 600px) {
   .i-button-wrap { flex-direction: column; }
}

@media all and (max-width: 450px) {
   .i-title.form-title { font-size: calc((100vw - 280px)/(450 - 280) * (25 - 20) + 20px); }
}
</style>

<style>

.phone-item .form-item input {
   padding-left: 115px;
}

.join-form .grid-item .langs-dropdown {
   margin-right: 0;
}
</style>