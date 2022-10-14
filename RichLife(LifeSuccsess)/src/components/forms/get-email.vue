<template>
   <div class="forgot-password">
      <transition name="fadeThanks" mode="out-in">
         <div class="getEmail-form-wrap" v-if="!thanksBlock" key="1">
            <h4 class="i-title dancing">Forgot password?</h4>
            <h4 class="i-title form-title">Забыли пароль?</h4>

            <div class="sign-form">
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
            <h1 class="i-title thank-you-title">Ваши данные успешно отправлены!</h1>
            <p class="i-text thank-you-text">Мы отправили на Ваш электронный адрес 6-ти значный код подтверждения. Перейдите в свой почтовый клиент для дальнейших действий</p>

            <div class="button-wrap">
               <a class="i-button-link big green" href="https://mail.google.com" target="blank" @click="goToGmail">Открыть Gmail</a>
            </div>
         </div>
      </transition>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"
import cookie from "js-cookie"

import UserModel from "../../models/UserModel"

@Component
export default class GetEmailFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   email: string = '' 
   idForgotPassword: string = '' // id, который гененрируется м отправляется на почту, в методе forgotPassword

   /**
    * Переменные валидации формы
    */
   errorMessage: string = '' // сообщение об ошибке
   thanksBlock: boolean = false

   /**
    * Регулярные выражения
    */
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 


   /**
    * Валидация формы
    */
   isValidationClick() {
      if (
         (this.GetRef('email') && !this.GetRef('email').checkValidation())
      ) {} 
      else if (
         (this.GetRef('email') && !this.GetRef('email').checkValidation())
      ) {}
      else { 
         this.thanksBlock = true
         this.forgotPassword()
      }
   }
   
   
   forgotPassword() {
      var settings = {
         "url": "http://31.31.24.200:5051/Account/ForgotPassword",
         "method": "POST",
         "timeout": 0,
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         "data": JSON.stringify({
            "email": this.email
         })
      };
      
      var self = this

      $.ajax(settings).done(function (response) {
         // var user = new Function( 'return (' + response + ')' )();
         self.idForgotPassword = response.data
         cookie.set('idForgotPassword',  self.idForgotPassword)
         console.log(self.idForgotPassword, 'idForgotPasswords');
      });
   }

   /**
    * Валидация Email
    */
   validEmail(value: string): boolean {
      let reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return reg.test(value);
   }

   goToGmail() {

   }
}
</script>

<style scoped>

/* thank you block */
.thank-you-title {
   text-transform: none;
   font-size: 23px;
   color: #fff;
}

.thank-you-text {
   margin-top: 15px;
   margin-bottom: 15px;
   font-size: 17px;
   text-align: center;
   color: #fff;
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