<template>
   <header :class="{'whtieHeader' : token != undefined}">
      <i-container :align="'center'" :display="'flex'" :justify="'space-between'">
         <div class="flex-block">
            <i-mobile-menu-icon @onClick="onShowMenu"  class="header-burger"></i-mobile-menu-icon>
            <logo headerLogo></logo>
         </div>

         <div class="i-button-group" v-if="token == undefined">
            <i-button @onClick="$emit('showJoinModal')">Регистрация</i-button>
            <router-link to="sign" class="i-button-link small grey" >Вход</router-link>
         </div>

         <div class="user-details" v-if="token != undefined">
            <!-- <router-link to="#" class="notifications">
               <span>9+</span>
               <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-notifications"></use></svg>
            </router-link> -->

            <div class="user-info" @click="openUserMenu">
               <div class="photo"><img src="/assets/img/user-menu/photo.webp" alt=""></div>
               <div class="name">Elisabeth Doe</div>
            </div>
            <user-menu :user="user" @getInTouch="$emit('getInTouch')" @click="onShowConfirmLogout" @close="closeUserMenu" @getMoney="$emit('getMoney')" :showUserMenu="showUserMenu"></user-menu>
         </div>
      </i-container>

      <!-- mobile-menu -->
      <mobile-menu-metlife @openNote="$emit('openNote')" @logout="onShowConfirmLogout" @showJoinModal="onShowJoin" @showGetInTouch="onShowGetInTouch" @changeShow="onChangeShow" @callUs="$emit('callUs')" :show="showMenu" @close="onCloseMenu" />

      <i-modal :contentMaxWidth="'600px'" :show="showConfirmLogout" @close="onCloseConfirmLogout">
         <notification-confirm @clickCancel="clickCancel" @clickConfirm="clickConfirm" :title="'Вы точно хотите выйти?'" :image="'/assets/img/icons/surprised.svg'" /> 
      </i-modal>
   </header>
</template>
 
<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import UserModel from "../models/UserModel";
import cookie from "js-cookie"

@Component
export default class MinimalHeaderMetlifeComponent extends Vue {

   @Prop({ type: Boolean, default: false }) innerShowMenu: boolean

   showMenu: boolean = false  // флаг на отображение мобильного меню
   showUserMenu: boolean = false  // флаг на открытие информации о пользователе в header (user-menu)
   user: UserModel = null
   token: string = ''
   showConfirmLogout: boolean = false  // флаг на отображение окна подтверждения на logout

   @Watch('innerShowMenu') change() {
      this.showMenu = this.innerShowMenu
   }

   created() {
      this.getCurrentUser()
   }

   mounted() {
      window.addEventListener('scroll', this.scrollHeader)
   }


   /**
    * Открытие формы Get in touch из мобильного меню
    */
   onShowGetInTouch() {
      this.showMenu = false
      this.$emit('showGetInTouch')
   }

   /**
    * Открытие формы регистрации из мобильного меню
    */
   onShowJoin() {
      this.showMenu = false
      this.$emit('showJoinModal')
   }

   
   /**
    * Изменения стилей header при скролле
    */
   scrollHeader() {
      var headerNode = document.querySelector('.header-fixed')

      if (window.pageYOffset > 70 && headerNode) {
         headerNode.classList.add('scroll')
      } else if (window.pageYOffset < 150 && headerNode) {
         headerNode.classList.remove('scroll')
      }  
   }

   // scrollHeaderStatic() {
   //    var headerNode = document.querySelector('header.static')

   //    if (window.pageYOffset > 150 && headerNode) {
   //       headerNode.classList.add('static-scroll')
   //    } else if (window.pageYOffset < 150 && headerNode) {
   //       headerNode.classList.remove('static-scroll')
   //    }  
   // }


   /**
    * Открытие мобильного меню
    */
   onShowMenu() {
      this.showMenu = true
   }

   /**
    * Передаем изменение флага открытия меню на false из i-mobile-menu 
    */
   onCloseMenu(innerShowMenu: boolean) {
      this.showMenu = innerShowMenu
   }


   /**
    * Открытие окна с информацией пользователя (user-menu) на страницах личного кабинета
    */
   openUserMenu() {
      this.showUserMenu = !this.showUserMenu
   }

   /**
    * Закрытие окна с информацией пользователя (user-menu) на страницах личного кабинета
    */
   closeUserMenu(showUserMenu: boolean) {
      this.showUserMenu = showUserMenu
   }



   /**
    * Открытие окна с подтверждением выхода
    */
   onShowConfirmLogout() {
      this.showConfirmLogout = true
   }

   /**
    * Закрытие окна с подтверждением выхода
    */
   onCloseConfirmLogout() {
      this.showConfirmLogout = false
   }


   /**
    * Подтверждение выхода (клик на подтвердить в модальном коне подтверждения выхода)
    */
   clickConfirm() {
      this.onCloseConfirmLogout()
      cookie.remove('token')
      cookie.remove('refferal')
      localStorage.setItem('user', null)
      this.$router.go()
      // здесь будет вызван метод Logout
   }


   /**
    * Отмена выхода (клик на отмену в модальном окне с подтверждением выхода)
    */
   clickCancel() {
      this.onCloseConfirmLogout()
   }

   onChangeShow(show: boolean) {
      this.$emit('changeShow', show)
   }

   /**
    * Получение текущего пользователя
    */
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
            self.token,
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

header {
   margin-bottom: 40px;
   padding: 7px 0;
   position: relative;
   width: 100%;
   z-index: 3;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   transition: all 0.2s ease-out;
}

header.header-fixed {
   position: fixed;
   top: 0;
   left: 0;
   box-shadow: none;
}

header.whtieHeader {
   background: rgba(255, 255, 255);
} 

header.static {
   margin-bottom: 0;
   position: relative;
   top: 0;
   left: 0;
   background: #F8F9FC;
   width: 100%;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   transition: all 0.2s ease-out;
}

header.static-scroll {
   position: fixed;
   top: 0;
   left: 0;
   width: 100%;
   animation: fadeHeader 0.2s ease-out forwards;
}

header.scroll {
   background: #F8F9FC;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
}

.flex-block {
   display: flex;
   align-items: center;
}


/* mobile menu icon (header-burger) */
.header-burger {
   display: none;
}

.i-button-group {
   display: flex;
   align-items: center;
}

.i-button-group a {
   margin-left: 10px;
   margin-bottom: 0;
}





/* user details */
.user-details {
   display: flex;
   align-items: center;
}

.notifications {
   margin-right: 30px;
   position: relative;
   display: flex;
   align-items: center;
   justify-content: center;
   cursor: pointer;
}

.notifications svg {
   margin-top: -2.5px;
   margin-left: 2px;
   width: 25px;
   height: 30px;
   fill: #12be83;
}

.notifications span {
   position: absolute;
   top: -7px;
   right: -7px;
   width: 19px;
   height: 19px;
   background: #FF2626;
   border: 2px solid #fff;
   overflow: hidden;
   border-radius: 50%;
   display: flex;
   align-items: center;
   justify-content: center;
   font-size: 10px;
   font-weight: 500;
   color: #FFE6E6;
   line-height: 9px;
}






/* user info (фото + имя пользователя в личном кабинете) */
.user-info {
   display: flex;
   align-items: center;
   cursor: pointer;
}


/* photo */
.user-info .photo {
   width: 60px;
   min-width: 60px;
   height: 60px;
   min-height: 60px;
   border-radius: 50%;
   overflow: hidden;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.2);
}

.user-info .photo img {
   max-width: 100%;
   height: auto;
}

/* name */
.user-info .name {
   margin-left: 15px;
   font-size: 16px;
   font-weight: 600;
   line-height: 130%;
   color: #121B23;
    display: -webkit-box;
   -webkit-line-clamp: 2;
   -webkit-box-orient: vertical;
   overflow: hidden;
   max-width: 160px;
}





@media all and (max-width: 800px) {
   .header-burger { display: flex; }
}

@media all and (max-width: 495px) {
   .i-button-group { display: none; }
   .flex-block { width: 100%; justify-content: space-between; }
   header.whtieHeader .flex-block { width: auto; }
}

@media all and (max-width: 420px) {
   .user-info .name { font-size: 14px; max-width: 112px; }
}

@media all and (max-width: 350px) {
   .logo { font-size: 30px; }
}

@keyframes fadeHeader {
   0% { top: -100%; }
   100% { top: 0; }
}

</style>