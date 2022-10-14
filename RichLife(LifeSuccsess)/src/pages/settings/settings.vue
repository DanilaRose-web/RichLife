<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch"> 
      <template slot="header">
         <minimal-header-home @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />
      </template>

      <section class="section-take-program">
         <i-container>
            <h1 class="take-program-title i-title">Изменить профиль</h1>
            <h3 class="i-subtitle take-program-subtitle">Здесь вы можете изменить настройки, которые указали при регистрации</h3>

            <!-- Форма редактирования профиля -->
            <div class="form-wrap fade-block" key="1">
               <settings-form :user="user"></settings-form>
            </div>

            <!-- Форма смены пароля -->
            <!-- <div class="form-wrap">
               <change-password-form></change-password-form>
            </div> -->
         </i-container>
      </section>

      <!-- Форма "Присоединиться" -->
      <i-modal :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
      </i-modal>

      <i-modal :contentMaxWidth="'600px'" :show="noteGetInTouch" @close="noteGetInTouch = false">
         <notification-get-in-touch @click="onShowJoinModal"></notification-get-in-touch>
      </i-modal>

      <!-- Форма "Оставить заявку" -->
      <i-modal :contentMaxWidth="'600px'" :show="getInTouch" @close="getInTouch = false">
         <get-in-touch></get-in-touch>
      </i-modal>

      <modal-chat :innerOpen="openChat" @closeChat="onCloseChat"></modal-chat>
   </layout>
</template>  

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"
import UserModel from "../../models/UserModel";

@Component
export default class PageSettingsComponent extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   noteGetInTouch: boolean = false // фдаг на открытие окна с проверкой на авторизацию

   /**
    * Пользователь
    */
   user: UserModel = null


   created() {
      if (cookie.get('token') == undefined) 
         this.$router.push({ name: 'home' })
      
      this.getCurrentUser()
      
      // this.user = JSON.parse(localStorage.getItem('user'))
      // console.log(this.user, 'user');
      
   }

   /**
    * Emit, который передает значение флага для открытия формы join из layout (т.к. layout-footer инициализируется в layout, а не на этой странице)
    */
   onShowJoinModalFooter(showJoinModalFooter: boolean) {
      this.showJoinModal = showJoinModalFooter
   }

   /**
    * Открытие модального окна с формой join
    */
   onShowJoinModal() {
      this.showJoinModal = true
      this.noteGetInTouch = false
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
   }
   
   /**
    * Окрытие окна с чатом при клике на "связаться с нами" из services-menu
    */
   onCallUs() {
      this.openChat = true
      this.innerShowMenu = false
   }

   onChangeShow(show: boolean) {
      this.innerShowMenu = show
   }

   /**
    * Передача флага open: false, из компонента modal-chat при закрытии чата
    */
   onCloseChat(open: boolean) {
      this.openChat = open
   }

   /**
    * Открытие модального окна с проверкой на авторизацию
    */
   openNoteModal() {
      this.noteGetInTouch = true
   }

   /**
    * Открытие модалки на проверку авторизации, при клике на "Оставить заявку"
    */
   onGetInTouch() {
      if (cookie.get('token') == '' || cookie.get('token') == undefined) {
         this.noteGetInTouch = true
      } else {
         this.getInTouch = true
      }
   }

   getCurrentUser() {
      var self = this

      var settings = {
         "url": "http://31.31.24.200:5051/Account/GetCurrentUser",
         "method": "GET",
         "timeout": 0,
         "headers": {
            "Authorization": "Bearer " + cookie.get('token'),
            "accept": "application/json",
            "Content-Type": "application/json"
         },
         
      };
      

      $.ajax(settings).done(function (response) {
         // var user = new Function( 'return (' + response + ')' )();
         console.log(response, 'response');

         self.user = new UserModel(
            response.data.id,
            cookie.get('token'),
            response.data.name,
            response.data.email,
            response.data.phoneNumber,
            response.data.codeNumber,
            response.data.isAdmin,
            response.data.tookTheProgram,
            response.data.refferalKey
         )
      });
   }

}
</script>

<style scoped>



.section-take-program {
   padding: 0 0 90px 0;
   display: flex;
   justify-content: center;
   min-height: 100vh;
   width: 100%;
   position: relative;
   background: #F8F9FC;
}

.form-wrap {
   margin-bottom: 70px;
}

.take-program-title {
   margin: 40px auto 10px auto;
   text-transform: none;
   color: #121B23;
}




@media all and (max-width: 450px) {
   .section-take-program { font-size: calc((100vw - 280px)/(450 - 280) * (35 - 28) + 28px); }
   .take-program-subtitle { font-size: calc((100vw - 280px)/(450 - 280) * (19 - 15) + 15px); }
}
</style>