<template>
   <layout-clean> 
      <section class="section-sign">
         <transition name="fadeThanks" mode="out-in">
            <div class="sign-form-wrap fade-block" v-if="!thanksBlock" key="1">
               <div class="form-wrap">
                  <join-form @success="successRegister"/>
                  <div class="i-link-wrap">
                     <router-link class="i-button-link transparent small" to="sign">Войти</router-link>
                     <router-link class="i-button-link grey small mt" to="/">Вернуться на главную</router-link>
                  </div>
               </div>
            </div>
            
            <div class="thanks-block fade-block" v-if="thanksBlock" key="2">
               <span class="i-title dancing">Thank you for register</span>
               <h1 class="i-title thank-you-title">Первый этап регистрации пройден!</h1>
               <p class="i-text thank-you-text">На Ваш электронный адрес, указанный ранее отправлен письмо для подтверждения Вашей электронной почты. Для завершения регистрации следуйте инструкциям в письме</p>

               <div class="i-button-wrap">
                  <router-link class="i-button-link green" to="/">Вернуться на главную</router-link>
                  <a class="i-button-link grey mt" @click="closeThanksBlock">Назад</a>
               </div>
            </div>
         </transition>
      </section>
   </layout-clean>
</template>  

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class ConfirmNewPasswordPasswordComponent extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   showGetEmail: boolean = false  // флаг на открытие формы get email
   thanksBlock: boolean = false  // флаг на отображение блок после регистрации

   refForReg: string = ''



   created() {
      console.log(this.$route.params, 'this.$route.params');
      this.refForReg = window.location.href.split("register-referal/")[1]
      console.log(this.refForReg, 'refForReg');
      

      cookie.set('refferalKeyForRegister', this.refForReg)
   }  

   /**
    * Открытие модального окна с формой join
    */
   onShowJoinModal() {
      this.showJoinModal = true
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
   }

   /**
    * Открытие модалки формы get email
    */
   onShowGetEmail() {
      this.showGetEmail = true
      console.log(this.showGetEmail, 'showGetEmail');
      
   }

   /**
    * ЗАкрытие модалки формы get email
    */
   onCloseGetEmail() {
      this.showGetEmail = false
   }

   successRegister() {
      this.thanksBlock = true
   }

   /**
    * Закрытия блока после регистрации
    */
   closeThanksBlock() {
      this.thanksBlock = false
   }

}
</script>

<style scoped>

.i-link-wrap {
   margin-top: 60px;
   display: flex;
   align-items: center;
   justify-content: center;
}

.i-link-wrap a.mt {
   margin-left: 15px;
}

.i-link-wrap

/* thank you block */
.thamks-block {
   margin: 0 auto;
}

.thank-you-title {
   text-transform: none;
   font-size: 30px;
   color: #fff;
}

.thank-you-text {
   margin: 15px auto;
   font-size: 17px;
   text-align: center;
   color: #fff;
}


/* fade-block */
.fade-block {
   margin: 0 auto;
   opacity: 1;
   visibility: visible;
   max-width: 600px;
   z-index: 1;
}

.form-wrap {
   margin: 0 auto;
   max-width: 600px;
}

.fadeThanks-enter-active, .fadeThanks-leave-active {
   transition: all 0.3s ease-out;
}

.fadeThanks-enter, .fadeThanks-leave-to {
   opacity: 0;
   visibility: hidden;
}

.i-button-wrap {
   margin-top: 30px;
   display: flex;
   align-items: center;
   justify-content: center;
}

.i-button-wrap a {
   cursor: pointer;
}

.i-button-wrap a.mt {
   margin-left: 15px;
}



.sign-form-wrap {
   padding: 40px 20px;
   border-radius: 15px;
   box-shadow: 20px 20px 50px rgba(0, 0, 0, 0.5);
   background: rgba(255, 255, 255, 0.1);
   border-top: 1px solid rgba(255, 255, 255, 0.5);
   border-left: 1px solid rgba(255, 255, 255, 0.5);
   max-width: 700px;
   width: 100%;
   position: relative;
   z-index: 1;
}

.section-sign {
   padding: 20px 15px;
   display: flex;
   align-items: center;
   justify-content: center;
   min-height: 100vh;
   width: 100%;
   background: url('/assets/img/backgrounds/bg3.webp') no-repeat center;
   background-size: cover;
   position: relative;
}

.section-sign::after {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   background: rgba(0, 0, 0, 0.5);
}

@media all and (max-width: 570px) {
   .i-button-wrap, .i-link-wrap  { flex-direction: column; align-items: center; }
   .i-button-wrap a, .i-link-wrap a { max-width: 400px; }
   .i-button-wrap a.mt { margin-left: 0; margin-top: 15px; }
   .i-link-wrap a.mt { margin-left: 0; }
}

</style>