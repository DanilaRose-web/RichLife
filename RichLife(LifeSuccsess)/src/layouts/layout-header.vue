<template>
   <header :class="{'absolute' : ($route.name == 'home' || $route.name == '') || absolute}">
      <i-container :align="'center'" :display="'flex'" :justify="'space-between'">

         <div class="flex-block">
            <i-mobile-menu-icon @onClick="onShowMenu"  class="header-burger"></i-mobile-menu-icon>
            <logo headerLogo></logo>
         </div>

         
         <!-- header-menu -->
         <nav class="header-nav">
            <ul class="header-menu" :class="{'headerAbsolute' : $route.name == 'home' || $route.name == ''}">
               <li><router-link class="link-hover" to="partnership">Партнерство</router-link></li>
               <li><router-link class="link-hover" to="about-insurance">О страховании</router-link></li>
               <li>
                  <router-link class="link-hover" to="profile">Страховые компании</router-link>
                  <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-arrow-right"></use></svg>

                  <ul class="header-submenu">
                     <li><router-link to="">MetLife</router-link></li>
                     <li><router-link to="">Uniqa</router-link></li>
                     <li><router-link to="">Grawe</router-link></li>
                     <li><router-link to="">TAC Life</router-link></li>
                  </ul>
               </li>
            </ul>


            <div v-if="$route.name == 'home' || $route.name == ''" class="i-button-group">
               <i-button :margin="'0 10px 0 0'" @onClick="$emit('onClick')">Присоединиться</i-button>
               <i-button @onClick="$router.push({ name: 'sign' })" class="transparent">Войти</i-button>
            </div>

            <div class="user-details" v-else>
               <router-link to="#"  class="notifications">
                  <span>9+</span>
                  <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-notifications"></use></svg>
               </router-link>

               <div class="user-info" @click="openUserMenu">
                  <div class="photo"><img src="/assets/img/user-menu/photo.webp" alt=""></div>
                  <div class="name">Наталья Колесниченко</div>
               </div>
               <user-menu @click="onShowConfirmLogout" @close="closeUserMenu" @getMoney="$emit('getMoney')" :showUserMenu="showUserMenu"></user-menu>
            </div>
         </nav>
      </i-container> 



      <!-- mobile-menu -->
      <mobile-menu :show="showMenu" @close="onCloseMenu" />

      <i-modal :contentMaxWidth="'600px'" :show="showConfirmLogout" @close="onCloseConfirmLogout">
         <notification-confirm @clickCancel="clickCancel" @clickConfirm="clickConfirm" :title="'Вы точно хотите выйти?'">
            <img src="/assets/img/icons/surprised.svg" alt="">
         </notification-confirm>
      </i-modal>
   </header>
</template>

<script lang='ts'>
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"
import $ from "jquery";

@Component
export default class LayoutHeaderComponent extends Vue {

   @Prop({ type: Boolean, default: false }) absolute: boolean

   showMenu: boolean = false  // флаг на отображение мобильного меню
   showUserMenu: boolean = false  // флаг на открытие информации о пользователе в header (user-menu)

   showConfirmLogout: boolean = false  // флаг на отображение окна подтверждения на logout

   mounted() {
      this.initjQueryAccordion()
   }

   initjQueryAccordion() {
      $('.mobile-submenu').hide()

      $('.has-children').on('click', function () {
         $('.has-children').not($(this)).removeClass('show')
         $('.mobile-submenu').not($(this).children('.mobile-submenu')).slideUp()
         $(this).toggleClass('show').children('.mobile-submenu').slideToggle();
      })
   }


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
      this.$router.push({ name: 'sign' })
      // здесь будет вызван метод Logout
   }


   /**
    * Отмена выхода (клик на отмену в модальном окне с подтверждением выхода)
    */
   clickCancel() {
      this.onCloseConfirmLogout()
   }

}
</script>

<style scoped>

header {
   margin-bottom: 40px;
   position: relative;
   z-index: 2;
   background: #fff;
   width: 100%;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
}

header.absolute {
   margin-bottom: 0;
   position: absolute;
   width: 100%;
   top: 0;
   left: 0;
   background: rgba(255, 255, 255, 0.95);
   width: 100%;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.3);
   z-index: 3;
}

header.static {
   margin-bottom: 0;
}

.header-nav,
.flex-block {
   display: flex;
   align-items: center;
}



/* logo */
.logo {
   font-size: 35px;
   font-weight: 700;
   color: #121B23;
   text-transform: uppercase;
}



/* menu */
.header-menu {
   margin-right: 40px;
   display: flex;
   align-items: center;
}

.header-menu.headerAbsolute > li {
   padding: 10px 10px;
   position: relative;
}

.header-menu > li {
   padding: 15px 10px;
   position: relative;
}

.header-menu > li svg {
   position: absolute;
   top: 50%;
   transform: translateY(-50%) rotate(90deg);
   right: 0;
   width: 9px;
   height: 9px;
   fill: #121B23;
   transition: all 0.2s ease-out;
}

.header-menu > li > a {
   padding: 10px 5px;
   font-size: 17px;
   font-weight: 600;
   transition: all 0.2s ease-out;
}

.header-menu > li:hover svg {
   transform: translateY(-50%) rotate(0);
   fill: #12be83;
   transition-delay: 0.2s;
}



/* submenu */
.header-submenu {
   position: absolute;
   left: 0;
   top: 140%;
   min-width: 200px;
   width: 100%;
   opacity: 0;
   visibility: hidden;
   background: rgba(255, 255, 255, 0.95);
   border-left: 3px solid #12be83;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   transition: all 0.2s ease-out;
}

.header-menu > li:hover .header-submenu {
   opacity: 1;
   visibility: visible;
   top: 101%;
   transition-delay: 0.2s;
}



.header-submenu li,
.header-submenu li a {
   position: relative;
}

.header-submenu li {
   margin: 0 7px;
}

.header-submenu li:not(:last-child) {
   border-bottom: 1px solid rgba(18, 27, 35, 0.2);
}


.header-submenu li a {
   padding: 20px;
   display: flex;
   align-items: center;
   font-weight: 600;
   font-size: 14px;
   color: #121B23;
   transition: all 0.3s ease-out;
}

.header-submenu li:hover a {
   color: #12be83;
   transform: translateX(5px);
}






/* button group */
.i-button-group {
   display: flex;
   align-items: center;
}


/* mobile menu icon (header-burger) */
.header-burger {
   display: none;
}










/* mobile menu */
.mobile-menu > li {
   margin-bottom: 7px;
   position: relative;
   border-radius: 28px;
}

.mobile-menu > li > a {
   padding: 10px 10px;
   font-size: 18px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
   display: inline-block;
   width: 100%;
   border-radius: 28px;
   position: relative;
   transition: all 0.2s ease-out;
}

.mobile-menu > li > a > span {
   padding-right: 20px;
}

.mobile-menu > li.has-children > a::after {
   content: '';
   position: absolute;
   top: 50%;
   right: 10px;
   transform: translateY(-50%);
   width: 12px;
   height: 12px;
   background: url('/assets/img/icons/arrow-right.svg') no-repeat center;
   background-size: contain;
   transition: all 0.2s ease-out;
}

.mobile-menu > li.show {
   background: #fff;
   border-bottom: 1px solid #e6e6eb;
   /* border-right: 1px solid #12be83; */
   /* border-left: 1px solid #12be83; */
}

.mobile-menu > li:hover > a,
.mobile-menu > li.show > a {
   color: #fff;
   background: #12be83;
}

.mobile-menu > li.has-children.show > a::after {
   transform: translateY(-50%) rotate(90deg);
}

.mobile-submenu {
   padding: 15px 0 15px 0;
}

.mobile-submenu li:not(:last-child) {
   margin-bottom: 5px;
}

.mobile-submenu li a {
   padding: 7px 0 7px 20px;
   font-size: 15px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
   display: inline-block;
   width: 100%;
   border-radius: 28px;
   transition: all 0.2s ease-out;
}

.mobile-submenu li a:hover {
   background: #9292a6;
   color: #fff;
}


/* mobile-button-group */
.i-button-group.mobile-group {
   margin-top: 40px;
   display: flex;
   width: 100%;
   flex-direction: column;
   align-items: flex-start;
}



/* socials */
.socials-wrap {
   margin-top: 40px;
   display: flex;
   flex-direction: column;
   align-items: center;
}

.socials-wrap h5 {
   margin-bottom: 15px;
   font-size: 18px;
   font-weight: 600;
   color: #121B23;
   text-transform: uppercase;
}

.social-block {
   display: flex;
   align-items: center;
}

.social-block a {
   display: flex;
   width: 33px;
   height: 33px;
}

.social-block a:not(:last-child) {
   margin-right: 7px;
}

.social-block svg {
   width: 33px;
   height: 33px;
   fill: #12be83;
   transition: all 0.2s ease-out;
}

.social-block svg:hover {
   fill: #9292a6;
}



/* logo */
.logo-wrap {
   margin-top: 40px;
   margin-bottom: 15px;
   display: flex;
   flex-direction: column;
   align-items: center;
}
.mob-logo {
   margin-bottom: 20px;
   font-size: 40px;
   font-weight: 700;
   line-height: 0.8;
   white-space: nowrap;
   text-transform: uppercase;
}


/* copyright */
.copyright {
   font-size: 15px;
   font-weight: 400;
   line-height: 120%;
   color: #121B23;
   text-align: center;
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
   margin-right: 15px;
   width: 60px;
   min-width: 60px;
   height: 60px;
   min-height: 60px;
   border-radius: 50%;
   overflow: hidden;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.user-info .photo img {
   max-width: 100%;
   height: auto;
}

/* name */
.user-info .name {
   font-size: 14px;
   font-weight: 600;
   line-height: 130%;
   color: #121B23;
    display: -webkit-box;
   -webkit-line-clamp: 2;
   -webkit-box-orient: vertical;
   overflow: hidden;
   max-width: 140px;
}






@media all and (max-width: 1140px) {
   .header-menu { margin-right: 20px; }
   .header-menu > li > a { font-size: 15px; }
}

@media all and (max-width: 1050px) {
   header.absolute { padding: 10px 0; }
   header { padding: 5px 0; }
   .header-menu { display: none; }
   .header-burger { display: flex; }
}

@media all and (max-width: 620px) {
   .i-button-group { display: none; }
   header.absolute .flex-block { width: 100%; justify-content: space-between; }
   .notifications { display: none; }
}

@media all and (max-width: 520px) {
   .user-info .name { display: none; }
   .user-info .photo { margin-right: 0; }
}

@media all and (max-width: 350px) {
   .logo { font-size: 30px; }
}

@media all and (max-width: 400px) {
   .mobile-menu > li > a { padding: 7px 10px; font-size: 15px; }
}

@media all and (max-width: 380px) {
   .notifications { display: none; }
}


</style>



