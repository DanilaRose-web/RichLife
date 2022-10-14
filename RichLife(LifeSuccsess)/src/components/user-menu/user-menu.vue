<template>
   <transition name="showMenu">
      <div class="user-menu-wrap" v-if="innerShowuserMenu">
         <div class="user-menu-content">
            <div class="user-info">
               <!-- <div class="photo"><img src="/assets/img/user-menu/photo.webp" alt=""></div> -->
               <div class="name">Elisabeth Doe</div>
            </div>

            <!-- links -->
            <nav class="user-menu">
               <ul>
                  <li><router-link to="profile">Профиль</router-link></li>
                  <li><router-link to="settings">Настройки</router-link></li>
                  <li><router-link to="users">Пользователи</router-link></li>
                  <li><router-link to="take-a-program">Оставить заявку (страница)</router-link></li>
                  <li class="i-tooltip-hover no-hover">
                     <router-link to="">Реферальная ссылка</router-link>
                     <i-tooltip bottom>{{ refferalLink }}</i-tooltip>
                  </li>
               </ul>
            </nav>

            <!-- Ссылка на оформление прогаммы -->
            <i-button @onClick="$emit('getInTouch')" :maxWidth="'100%'" :width="'100%'" :margin="'0 0 6px 0'">Оставить заявку</i-button>

            <!-- Log Out -->
            <i-button @onClick="logout" class="grey" :maxWidth="'100%'" :width="'100%'">Выйти</i-button>
         </div>
      </div>
   </transition>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import cookie from "js-cookie"
import UserModel from "../../models/UserModel";

@Component
export default class UserMenuComponent extends Vue {

   @Prop({ type: Boolean, default: false }) showUserMenu: boolean
   @Prop({ type: Object, default: null }) user: UserModel

   innerShowuserMenu: boolean = false
   token: string = ''

   refferalLink: string = 'рефферальная ссылка'

   @Watch('showUserMenu') change() {
      this.innerShowuserMenu = this.showUserMenu
   }

   created() {
      // this.innerShowuserMenu = this.showUserMenu
      // if (this.user && this.user.RefferalLink) {
      //    this.refferalLink = window.location.origin + "/register-referal/" + this.user.RefferalLink
      //    console.log(this.refferalLink, 'refferalLink')
      //    console.log(this.user, 'user');
      // } else {
      //    this.refferalLink = 'Реферальная ссылка появится только после оформления программы'
      // }

      this.token = cookie.get('token')
   }


   mounted() {
      document.addEventListener('click', this.clickOutside)  // подписка на событие
   }

   destroyed() { 
      document.removeEventListener('click', this.clickOutside)  // отписка от события
   }


   /**
    * Метод закрытия меню при клике вне блока
    */
   clickOutside(event: any) {
      var showInnerShowuserMenuFlag = false;
      
      if (this.innerShowuserMenu) {
         event.composedPath().find((el: any) => {
            if (!!el && !!el.classList) {
               if (
                  el.classList.contains("user-info") ||
                  el.classList.contains("user-menu")
               ) {
                  showInnerShowuserMenuFlag = true;
               }
            }
         });
      }
      if (!showInnerShowuserMenuFlag) {
         this.innerShowuserMenu = false;
      }
      this.$emit('close', this.innerShowuserMenu)
   }

   /**
    * Logout
    */
   logout() {
      cookie.remove('token')
      
      if (this.$route.name == 'home' || '') 
         location.reload()
         else this.$router.push({ name: 'home' })
   }

}
</script>

<style scoped>

.user-menu-wrap {
   padding: 15px 20px;
   position: absolute;
   width: 100%;
   max-width: 300px;
   right: 0;
   top: 118%;
   opacity: 1;
   visibility: visible;
   background: #fff;
   border-left: 3px solid #12be83;
   /* box-shadow: 0 0 20px rgba(0, 0, 0, 0.2); */
}




/* user info (photo + name) */
.user-info {
   margin-bottom: 20px;
   display: flex;
   align-items: center;
}

.user-info .photo {
   margin-right: 10px;
   width: 50px;
   min-width: 50px;
   height: 50px;
   min-height: 50px;
   overflow: hidden;
   border-radius: 50%;
}

.user-info .photo img {
   max-width: 100%;
   height: auto;
}



.user-info .name {
   margin: 0 7px;
   font-size: 18px;
   font-weight: 600;
   line-height: 120%;
   color: #12be83;
}





/* user menu (links) */
.user-menu {
   margin-bottom: 20px;
}

.user-menu li {
   margin: 0 7px;
   position: relative;
}

/* .user-menu li:not(:last-child) {
   border-bottom: 1px solid rgba(18, 27, 35, 0.2);
} */

.user-menu li a {
   padding: 12px 0;
   display: flex;
   font-size: 14px;
   font-weight: 600;
   color: #121B23;
   word-break: break-all;
   transform: translate(0);
   transition: all 0.3s ease-out;
}

.user-menu li:hover a {
   color: #12be83;
   transform: translate(5px);
}

.user-menu li.no-hover:hover a {
   transform: translate(0);
}

/* animate */
.showMenu-enter-active, .showMenu-leave-active {
   transition: all 0.3s ease-out;
}

.showMenu-enter, .showMenu-leave-to {
   top: 120%;
   opacity: 0;
   visibility: hidden;
}

.button-wrap {
   margin-bottom: 10px;
}


@media all and (max-width: 360px) {
   .user-menu-wrap { padding: 15px 10px; max-width: 250px; }
}

</style>