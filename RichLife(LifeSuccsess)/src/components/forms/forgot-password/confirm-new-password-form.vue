<template>
   <div class="forgot-password">
      <transition name="fadeThanks" mode="out-in">
         <div class="sign-form-wrap" v-if="!thanksBlock" key="1">
            <h4 class="i-title dancing">Forgot password?</h4>
            <h4 class="i-title form-title">Забыли пароль?</h4>

            <div class="sign-form">
               <div class="grid-item">
                  <i-new-input 
                     ref="code"
                     v-model="code"
                     :name="'code'"
                     :placeholder="'123456'"
                     :minlength="6"
                     :maxlength="6"
                     :required="true"
                     :regex="numberRegex"
                     showError
                     isStandart
                  >
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

               <p class="error-message">{{ errorMessage }}</p>

               <div class="form-item-flex column">
                  <i-button class="green" :maxWidth="'100%'" :width="'100%'" :margin="'0 0 15px 0'" @onClick="isValidationClick">Отправить</i-button>
                  <router-link class="i-button-link grey small" to="/">Вернуться на главную</router-link>
               </div>

               <div class="privacy-policy">
                  <p class="text">Нажимая на кнопку "Отправить" Вы соглашаетесь на обработку своих персональных данных, согласно условиям <a href="">политики конфиденциальности</a></p>
               </div>
            </div>
         </div>

         <div class="thanks-block fade-block" v-if="thanksBlock" key="2">
            <span class="i-title dancing">Thank You</span>
            <h1 class="i-title thank-you-title">Пароль изменен!</h1>
            <p class="i-text thank-you-text">Доступ в личный кабинет снова открыт. Советуем сохранить данный пароль</p>

            <div class="button-wrap">
               <router-link class="i-button-link green" to="/">Вернуться на главную</router-link>
            </div>
         </div>
      </transition>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class ConfirmNewPasswordFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   code: number = null
   password: string = ''  // пароль
   passwordRepeat: string = ''  // повторить пароль
   idForgotPassword: string = '' // id, который гененрируется м отправляется на почту, в методе forgotPassword

   /**
    * Переменные валидации формы
    */
   errorMessage: string = '' // сообщение об ошибке
   thanksBlock: boolean = false
   passwordMismatch: boolean = false // совпадение паролей

   /**
    * Регулярные выражения
    */
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 
   numberRegex: RegExp = /^[0-9]+$/ // только числа


   created() {
      this.idForgotPassword = cookie.get('idForgotPassword')
   }

   /**
    * Валидация формы
    */
   isValidationClick() {
      if (
         (this.GetRef('code') && !this.GetRef('code').checkValidation()) &&
         (this.GetRef('password') && !this.GetRef('password').checkValidation()) &&
         (this.GetRef('passwordRepeat') && !this.GetRef('passwordRepeat').checkValidation())
      ) {} 
      else if (
         (this.GetRef('code') && !this.GetRef('code').checkValidation()) ||
         (this.GetRef('password') && !this.GetRef('password').checkValidation()) ||
         (this.GetRef('passwordRepeat') && !this.GetRef('passwordRepeat').checkValidation())
      ) {}
      else if (this.GetRef('passwordRepeat').value.length != this.GetRef('password').value.length) {
         this.passwordMismatch = true
      }
      else { 
         this.confirmNewPassword()
      }
   }
   
   
   /**
    * Валидация Email
    */
   validEmail(value: string): boolean {
      let reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return reg.test(value);
   }

   confirmNewPassword() {
      var settings = {
         "url": "http://31.31.24.200:5051/Account/ConfirmForgotPassword",
         "method": "POST",
         "timeout": 0,
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "data": JSON.stringify({
            "toke": this.idForgotPassword,
            "code": this.code,
            "newPassword": this.password,
            "repeatNewPAssword": this.passwordRepeat
         })
      };
      
      var self = this

      $.ajax(settings).done(function (response) {
         // var user = new Function( 'return (' + response + ')' )();
         cookie.remove('idForgotPassword')
         self.thanksBlock = true
         self.passwordMismatch = false
      });
   }
}
</script>

<style scoped>

.forgot-password {
   z-index: 1;
}

/* thank you block */
.thank-you-title {
   text-transform: none;
   font-size: 30px;
   color: #fff;
}

.thank-you-text {
   margin-top: 15px;
   margin-bottom: 15px;
   font-size: 17px;
   text-align: center;
   color: #fff;
   max-width: 500px;
}

/* Заголовок в форме */
.i-title.form-title {
   margin-bottom: 30px;
   font-size: 25px;
   font-weight: 700;
   line-height: 120%;
   color: #fff;
   text-align: center;
   position: relative;
   z-index: 1;
}

/* Dancing */
.i-title.dancing {
   margin-bottom: 30px;
   font-size: 50px;
   font-weight: 700;
   color: #12be83;
   text-align: center;
   position: relative;
   z-index: 1;
   text-transform: none;
}





.sign-form-wrap {
   padding: 40px 20px;
   border-radius: 15px;
   box-shadow: 20px 20px 50px rgba(0, 0, 0, 0.5);
   background: rgba(255, 255, 255, 0.1);
   border-top: 1px solid rgba(255, 255, 255, 0.5);
   border-left: 1px solid rgba(255, 255, 255, 0.5);
   max-width: 500px;
   width: 100%;
   position: relative;
   z-index: 1;
}

.sign-form {
   display: grid;
   grid-template-columns: 1fr;
   grid-template-rows: auto;
   column-gap: 15px;
   row-gap: 21px;
}





/* fade-block */
.fade-block {
   opacity: 1;
   visibility: visible;
}

.fadeThanks-enter-active, .fadeThanks-leave-active {
   transition: all 0.3s ease-out;
}

.fadeThanks-enter, .fadeThanks-leave-to {
   opacity: 0;
   visibility: hidden;
}





@media all and (max-width: 450px) {
   .i-title.form-title { font-size: calc((100vw - 280px)/(450 - 280) * (25 - 20) + 20px); }
}
</style>