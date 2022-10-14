<template>
   <i-mobile-menu :show="show" @close="onCloseMenu" @changeShow="onChangeShow">
      <nav class="mobile-nav">
         <ul class="mobile-menu">
            <li><router-link to="/"><span>Главная</span></router-link></li>
            <li><router-link to="users" v-if="user && user.IsAdmin"><span>Пользователи</span></router-link></li>

            <li class="has-children">
               <router-link to=""><span>Страхование для меня</span></router-link>
               <ul class="mobile-submenu">
                  <!-- <li><router-link to="insurance-for-me">Страхование для меня</router-link></li> -->
                  <li><router-link to="life-insurance">Страхование жизни</router-link></li>
                  <li><router-link to="insurance-accident">Страхование от несчастных случаев</router-link></li>
                  <li><router-link to="critical-illness">Страхование в случае критических заболеваний</router-link></li>
                  <li><router-link to="womens-insurance">Женское страхование</router-link></li>
               </ul>
            </li>

            <li class="has-children">
               <router-link to=""><span>Страхование для моей семьи</span></router-link>
               <ul class="mobile-submenu">
                  <!-- <li><router-link to="insurance-for-family"><span>Страхование для моей семьи</span></router-link></li> -->
                  <li><router-link to="childhood-critical-illness">Детское страхование от критических болезней</router-link></li>
                  <li><router-link to="loss-of-breadwinner">Страхование в случае потери кормильца</router-link></li>
                  <li><router-link to="capital-for-children">Накопление капитала для детей</router-link></li>
                  <li><router-link to="pension-capital">Накопление на собственную пенсию</router-link></li>
               </ul>
            </li>

            <li class="has-children">
               <router-link to=""><span>Клиентам</span></router-link>
               <ul class="mobile-submenu">
                  <li><a href="https://www.portmone.com.ua/r3/oplata-strahuvannya-metlife" target="_blank">Оплатить полис</a></li>
                  <li @click="gotoEvents"><router-link to="">Страховые события</router-link></li>
                  <li @click="gotoForms"><router-link to="">Бланки и формы заявлений</router-link></li>
               </ul>
            </li>

            <li class="has-children">
               <router-link to=""><span>Помощь консультантов</span></router-link>
               <ul class="mobile-submenu">
                  <li><a href="#partners">Наши партнеры</a></li>
                  <li @click="gotoBrochure"><router-link to="">Брошюры</router-link></li>
                  <li @click="gotoRules"><router-link to="insurance-rules">Правила страхования</router-link></li>
                  <!-- <li><router-link to="">Электронная заявка</router-link></li>
                  <li><router-link to="">Статистика выплат</router-link></li> -->
               </ul>
            </li>

            <!-- Элементы меню для Uniqa -->
         </ul>
      </nav>

      <div class="i-button-group mobile-group">
         <!-- Ссылка на оформление прогаммы (видно только после авторизации) -->
         <i-button class="i-button-link small mobile tt-u" @onClick="onShowGetInTouch">Оставить заявку</i-button>
         <i-button :margin="'10px 0 0 0'" class="i-button-link small transparent mobile" @onClick="$emit('callUs')">Связаться с нами</i-button>
         <i-button :margin="'10px 0 0 0'" class="i-button-link small transparent mobile" @onClick="onShowJoin">Регистрация</i-button>
         <router-link to="sign" class="i-button-link mt10 small transparent mobile grey" v-if="token == undefined">Вход</router-link>
         <i-button :margin="'10px 0 0 0'" class="i-button-link small mobile grey" @onClick="$emit('logout')" v-if="token != undefined">Выйти</i-button>
      </div>

      <div class="socials-wrap">
         <h5>Подписывайся:</h5>
         <div class="social-block">
            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-vk"></use></svg></a>
            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-youtube"></use></svg></a>
            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-instagram"></use></svg></a>
            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-whatsapp"></use></svg></a>
            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-telegram"></use></svg></a>
            <a href=""><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-viber"></use></svg></a>
         </div>
      </div>

      <div class="logo-wrap">
         <div class="mob-logo">WellbeLife</div>
         <p class="copyright">&copy; 2019-2021 ООО «WellbeLife»</p>
      </div>
   </i-mobile-menu>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import cookie from "js-cookie"
import UserModel from "../../models/UserModel";

@Component
export default class MobileMenuUniqaComponent extends Vue {

   @Prop({ type: Boolean, default: false }) show: boolean  // prop - принимает значение флага меню из вне
   @Prop({ type: Object, default: null }) user: UserModel

   token: string = '' // токен

   @Watch('token') change() {
      this.token = cookie.get('token')
   }   

   created() {
      this.token = cookie.get('token')
      if (this.user) {
         console.log(this.user, 'user');
      } 
   }

   mounted() {
      this.initjQueryAccordion()
   }

   /**
    * Открытие формы getInTouch
    */
   onShowGetInTouch() {
      this.onCloseMenu()
      this.$emit('showGetInTouch')
   }

   /**
    * Открытие формы регистрации
    */
   onShowJoin() {
      this.onCloseMenu()
      this.$emit('showJoinModal')
   }

   /**
    * Закрытие мобильного меню
    */
   onCloseMenu() {
      this.$emit('close')
   }

   /**
    * Инициализация аккордиона
    */
   initjQueryAccordion() {
      $('.mobile-submenu').hide()

      $('.has-children').on('click', function () {
         $('.has-children').not($(this)).removeClass('show')
         $('.mobile-submenu').not($(this).children('.mobile-submenu')).slideUp()
         $(this).toggleClass('show').children('.mobile-submenu').slideToggle();
      })
   }

   onChangeShow(show: boolean) {
      this.$emit('changeShow', show)
   }

   gotoCallus() {
      this.$emit("callUs")
   }

   gotoEvents() {
      if (this.token != undefined) 
         this.$router.push({ name: "insurance-event" })
         else this.$emit("openNote")
   }

   gotoForms() {
      if (this.token != undefined) 
         this.$router.push({ name: "" })
         else this.$emit("openNote")
   }

   gotoRules() {
      if (this.token != undefined) 
         this.$router.push({ name: "insurance-rules" })
         else this.$emit("openNote")
   }

   gotoBrochure() {
      if (this.token != undefined) 
         this.$router.push({ name: "" })
         else this.$emit("openNote")
   }

}
</script>

<style scoped>

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
   font-size: 50px;
   font-family: 'Fineday', cursive;
   font-weight: 500;
   color: #121B23;
   line-height: 0.8;
   white-space: nowrap;
}


/* copyright */
.copyright {
   font-size: 15px;
   font-weight: 400;
   line-height: 120%;
   color: #121B23;
   text-align: center;
}


@media all and (max-width: 400px) {
   .mobile-menu > li > a { padding: 7px 10px; font-size: 15px; }
}
</style>