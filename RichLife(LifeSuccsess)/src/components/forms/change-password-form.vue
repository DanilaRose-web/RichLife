<template>
   <div class="settings-form">

      <!-- Изменить пароль -->
      <div class="password-settings settings-form-block">
         <h3 class="form-block-title">Изменение пароля</h3>

         <transition name="fadeThanks" mode="out-in">
            <div class="form-wrap fade-block" key="1" v-if="!thanksBlock"> 
               <div class="form-block">
                  <i-input 
                     v-model="password"
                     :error="errorPassword"
                     :type="'password'" 
                     :name="'password'"
                     :placeholder="'Пароль'" 
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     :label="'Пароль'"
                     hasLabel/>

                  <i-input 
                     v-model="newPassword"
                     :error="errorNewPassword"
                     :type="'password'" 
                     :name="'newPassword'"
                     :placeholder="'Новый пароль'" 
                     :border="'1px solid rgba(18, 27, 35, 0.2)'"
                     :label="'Новый пароль'"
                     hasLabel/>

                  <div class="form-item-flex">
                     <i-input 
                        v-model="repeatNewPassword"
                        :error="errorRepeatNewPassword"
                        :type="'password'" 
                        :name="'repeatNewPassword'"
                        :placeholder="'Повторить новый пароль'" 
                        :border="'1px solid rgba(18, 27, 35, 0.2)'"
                        :label="'Повторить новый пароль'"
                        hasLabel/>
                  </div>
               </div>
            </div>

            <div class="thanks-block fade-block" v-if="thanksBlock" key="2">
               <h1 class="i-title thank-you-title">Пароль изменен!</h1>
               <p class="i-text thank-you-text">Пароль успешно изменен! Советуем запомнить новый пароль</p>

               <div class="button-wrap">
                  <i-button @onClick="closeThanksBlock" class="green">Вернуться к редактированию</i-button>
               </div>
            </div>
         </transition>
      </div>

      <i-button :height="'max-content'" @onClick="isValid" :fontSize="'16px'" :padding="'13px 25px'" :maxWidth="'170px'">Сохранить</i-button>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class ChangePasswordFormComponent extends Vue {

   /**
    * Переменные - v-model инпутов
    */
   
   password: string = ''  // текущий пароль
   newPassword: string = ''  // новый пароль
   repeatNewPassword: string = ''  // повторить новый пароль
   

   /**
    * переменные - текст ошибки при валидации
    */
   errorPassword: string = ''
   errorNewPassword: string = ''
   errorRepeatNewPassword: string = ''

   /**
    * Пользователь
    */
   user: any = null

   thanksBlock: boolean = false // флаг об успешном изменении пароля

   /**
    * Валидация формы
    */
   valid: boolean = false  // флаг на валидацию формы

   created() {}

   /**
    * Получение пользователя из localStorage
    */
   getUser() {
      this.user = JSON.parse(localStorage.getItem('user'))
      console.log(this.user, 'user');
   }


   /**
    * Валидация формы
    */
   isValid(event: any) {
      /* текущий пароль */
      if (this.password != '' && this.password != undefined && this.password.length < 8) {
         this.errorPassword = 'Пароль должен быть не меньше 8 символов'
         this.valid = false
      } else {
         this.errorPassword = ''
         this.valid = true
      }
            

      /* новый пароль */
      if (this.newPassword != '' && this.newPassword != undefined && this.newPassword.length < 8) {
         this.errorNewPassword = 'Пароль должен быть не меньше 8 символов'
         this.valid = false
      } else if ( this.password != '' && this.password != undefined && this.newPassword == '') {
         this.errorNewPassword = 'Введите новый пароль'
         this.valid = false
      } else {
         this.errorNewPassword = ''
         this.valid = true
      }

      /* повторить новый пароль */
      if (this.repeatNewPassword != this.newPassword) {
         this.errorRepeatNewPassword = 'Пароли не совпадают'
         this.valid = false
      } else if ( this.password != '' && this.password != undefined && this.repeatNewPassword == '') {
         this.errorRepeatNewPassword = 'Повторите новый пароль'
         this.valid = false
      } else {
         this.errorRepeatNewPassword = ''
         this.valid = true
      }

      if (this.valid) {
         console.log('форма отправилась');
         this.thanksBlock = true
      } else {
         console.log('форма не отправилась');
      }    
   }

   /**
    * Скрытие блока об успешном изменении данных профиля
    */
   closeThanksBlock() {
      this.thanksBlock = false
      this.password = ''
      this.newPassword = ''
      this.repeatNewPassword = ''
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

/* thank you block */
.thanks-block {
   margin: 30px auto;
}

.thank-you-title {
   text-transform: none;
   font-size: 30px;
   color: #121B23;
}

.thank-you-text {
   margin: 15px auto;
   font-size: 17px;
   text-align: center;
   color: #121B23;
   max-width: 500px;
}

.fadeThanks-enter-active, .fadeThanks-leave-active {
   transition: all 0.3s ease-out;
}

.fadeThanks-enter, .fadeThanks-leave-to {
   opacity: 0;
   visibility: hidden;
}

.settings-form {
   margin: 0 auto;
   max-width: 900px;
}

.settings-form-block {
   margin-bottom: 30px;
   border-radius: 20px;
   border: 1px solid #e6e6eb;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.form-block-title {
   padding: 20px;
   font-size: 20px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;
   border-bottom: 1px solid #e6e6eb;
}

.form-block {
   padding: 30px 20px;
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-rows: auto;
   gap: 20px;
}

.form-item-flex {
   grid-column: 1/3;
}









</style>