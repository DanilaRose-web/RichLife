<template>
   <div class="sign-form-wrap">
      <h4 class="i-title dancing">Come on</h4>
      <h4 class="i-title form-title">Мы ждем тебя!</h4>

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

         <p class="error-message">{{ errorMessage }}</p>

         <div class="form-item-flex">
            <i-button class="enter-btn" @onClick="isValidationClick">Войти</i-button>
            <a @click="$emit('showGetMail')" class="form-nav-link">Забыли пароль?</a>
            <!-- <i-button @onClick="$emit('showGetMail')">Забыли пароль?</i-button> -->
         </div>

         <div class="form-item-flex column">
            <p class="form-nav-link no-hover mb">Еще нет аккаунта?</p>
            <!-- <i-button class="transparent" :maxWidth="'100%'" :width="'100%'" :margin="'0 0 15px 0'" @onClick="$emit('click')">Присоединяйтесь</i-button> -->
            <router-link class="i-button-link green small" to="register-referal">Регистрация</router-link>
            <router-link class="i-button-link grey small" to="/">Вернуться на главную</router-link>
         </div>
         
         <div class="privacy-policy">
            <p class="text">Нажимая на кнопку "Войти" Вы соглашаетесь на обработку своих персональных данных, согласно условиям <a href="">политики конфиденциальности</a></p>
         </div>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"
import cookie from "js-cookie"

import UserModel from "../../models/UserModel"

@Component
export default class SignFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   email: string = 'example@gmail.com' 
   password: string = 'qwerty123456' 

   /**
    * Переменные валидации формы
    */
   valid: boolean = false

   errorMessage: string = '' // сообщение об ошибке

   /**
    * Инфа о пользователе (response метода Login)
    */
   user: UserModel = null

   /**
    * Регулярные выражения
    */
   emailRegex: RegExp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ // email 





   /**
    * Валидация формы
    */
   isValidationClick() {
      if (
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) &&
         (this.GetRef('password') && !this.GetRef('password').checkValidation())
      ) {} 
      else if (
         (this.GetRef('email') && !this.GetRef('email').checkValidation()) ||
         (this.GetRef('password') && !this.GetRef('password').checkValidation()) 
      ) {}
      else { 
         cookie.set('token', 'authorization-token')
         this.$router.push({ name: 'home' })
         // this.requestLogin()
      }
   }
   
   // requestLogin() {
   //    var form = new FormData();
   //    form.append("Email", this.email);
   //    form.append("Password", this.password);

   //    var self = this

   //    var settings = {
   //       "url": "http://31.31.24.200:5051/Account/Login",
   //       "method": "POST",
   //       "timeout": 0,
   //       "headers": {
   //          "accept": "application/json",
   //          "Content-Type": "application/json"
   //       },
   //       "data": JSON.stringify({
   //          "email": this.email,
   //          "password": this.password
   //       }),
   //       "error": function(xhr, status, error) {
   //          var errorMessage = new Function( 'return (' + xhr.responseText + ')' )();
   //          console.log(errorMessage.error, 'errorMessage');
   //          self.errorMessage = errorMessage.error
   //       } 
   //    };
      

   //    $.ajax(settings).done(function (response) {
   //       // var user = new Function( 'return (' + response + ')' )();
   //       console.log(response, 'response');
   //       cookie.remove('refferalKeyForRegister')
   //       if (response) {
   //          self.user = new UserModel(
   //             response.data.userId,
   //             response.data.token,
   //             response.data.name,
   //             response.data.email ? response.data.email : '',
   //             response.data.phoneNumber ? response.data.phoneNumber : '',
   //             response.data.codeNumber ? response.data.codeNumber : '',
   //             response.data.isAdmin,
   //             response.data.tookTheProgram,
   //             response.data.refferalLink
   //          )
   //          cookie.set('token', response.data.token)
   //          cookie.set('refferal', response.data.refferalLink)

   //          self.$router.push({ name: 'home' })
   //       }
   //    });
   // }
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


/* nav links and buttons */
.form-item-flex {
   display: flex;
   align-items: center;
   justify-content: space-between;
   grid-column: 1 / 2;

}

.form-item-flex.column {
   margin-top: 20px;
   flex-direction: column;
   align-items: center;
}

.form-nav-link {
   margin-right: 15px;
   display: inline-block;
   font-size: 16px;
   font-weight: 500;
   line-height: 120%;
   color: #fff;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.form-nav-link:hover {
   color: #12be83;
}

.form-nav-link.mb {
   margin-bottom: 15px;
}

.form-nav-link.no-hover:hover {
   color: #fff;
}


@media all and (max-width: 450px) {
   .i-title.form-title { font-size: calc((100vw - 280px)/(450 - 280) * (25 - 20) + 20px); }
}

@media all and (max-width: 350px) {
   .form-item-flex.column { margin-top: 0; }
   .form-item-flex { flex-direction: column; align-items: center; }
   .form-nav-link { margin-top: 15px; margin-right: 0; }
   .enter-btn { max-width: 100%; width: 100%; }
}
</style>