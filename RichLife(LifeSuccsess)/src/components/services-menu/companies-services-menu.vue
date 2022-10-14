<template>
   <nav>
      <i-container class="services-menu-container" :display="'flex'" :align="'center'" :justify="justify">
         <!-- max-width: 1130px -->
         <!-- <invite-referal @onClick="$emit('onClick')"></invite-referal> -->



         <!-- min-width: 1130px -->
         <ul class="services-menu">
            <li>
               <a>Страхование для меня</a>
               <ul class="services-submenu">
                  <li><router-link to="life-insurance"><img src="/assets/img/services-menu/icon1.svg" alt="Страхование жизни"> <span>Страхование жизни</span></router-link></li>
                  <li><router-link to="insurance-accident"><img src="/assets/img/services-menu/icon2.svg" alt="Страхование от несчастных случаев"> <span>Страхование от несчастных случаев</span></router-link></li>
                  <li><router-link to="critical-illness"><img src="/assets/img/services-menu/icon3.svg" alt="Страхование в случае критических заболеваний"> <span>Страхование в случае критических заболеваний</span></router-link></li>
                  <li><router-link to="womens-insurance"><img src="/assets/img/services-menu/icon4.svg" alt="Женское страхование"> <span>Женское страхование</span></router-link></li>
               </ul>
            </li>

            <li>
               <a>Страхование для моей семьи</a>
               <!-- <router-link to="insurance-for-family">Страхование для моей семьи</router-link> -->
               <ul class="services-submenu">
                  <li><router-link to="childhood-critical-illness"><img src="/assets/img/services-menu/icon5.svg" alt="Детское страхование от критических болезней"> <span>Детское страхование от критических болезней</span></router-link></li>
                  <li><router-link to="loss-of-breadwinner"><img src="/assets/img/services-menu/icon6.svg" alt="Страхование в случае потери кормильца"> <span>Страхование в случае потери кормильца</span></router-link></li>
                  <li><router-link to="capital-for-children"><img src="/assets/img/services-menu/icon7.svg" alt="Накопление капитала для детей"> <span>Накопление капитала для детей</span></router-link></li>
                  <li><router-link to="pension-capital"><img src="/assets/img/services-menu/icon8.svg" alt="Накопление на собственную пенсию"> <span>Накопление на собственную пенсию</span></router-link></li>
               </ul>
            </li>

            <li>
               <router-link to="">Клиентам</router-link>
               <ul class="services-submenu">
                  <li @click="gotoCallus"><a><img src="/assets/img/useful-links/link4.svg" alt="Связаться с нами"> <span>Связаться с нами</span></a></li>
                  <li><a href="https://www.portmone.com.ua/r3/oplata-strahuvannya-metlife" target="_blank"><img src="/assets/img/services-menu/icon13.svg" alt="Оплатить полис"> <span>Оплатить полис</span></a></li>
                  <li @click="gotoEvents"><router-link to=""><img src="/assets/img/services-menu/icon14.svg" alt="Страховые события"> <span>Страховые события</span></router-link></li>
                  <li @click="gotoForms"><router-link to=""><img src="/assets/img/services-menu/icon15.svg" alt="Бланки и формы заявлений"> <span>Бланки и формы заявлений</span></router-link></li>
               </ul>
            </li>

            <li>
               <router-link to="">Помощь консультантов</router-link>
               <ul class="services-submenu">
                  <li><a href="#partners"><img src="/assets/img/services-menu/icon17.svg" alt="Наши партнеры"> <span>Наши партнеры</span></a></li>
                  <li @click="gotoBrochure"><router-link to=""><img src="/assets/img/services-menu/icon18.svg" alt="Брошюры"> <span>Брошюры</span></router-link></li>
                  <li ><router-link to="insurance-rules"><img src="/assets/img/services-menu/icon19.svg" alt="Правила страхования"> <span>Правила страхования</span></router-link></li>
                  <!-- <li><router-link to=""><img src="/assets/img/services-menu/icon21.svg" alt="Электронная заявка"> <span>Электронная заявка</span></router-link></li>
                  <li><router-link to=""><img src="/assets/img/services-menu/icon20.svg" alt="Статистика выплат"> <span>Статистика выплат</span></router-link></li> -->
               </ul>
            </li>
         </ul>
      </i-container>
   </nav>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class CompaniesServicesMenuComponent extends Vue {

   @Prop({ type: Boolean, default: false }) registered: boolean

   justify: string = 'center'  // передаем параметр justify при разных размерах ширины window 
   token: string = '' // токен

   created() {
      this.token = cookie.get('token')
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

nav {
   width: 100%;
   background: #F8F9FC;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   position: relative;
   z-index: 1;
}

.services-menu {
   display: flex;
   position: relative;
   max-width: 1200px;
   width: 100%;
}

.services-menu > li {
   /* padding: 20px 10px; */
   /* position: relative; */
   flex: 0 1 100%;
   max-width: 100%;
   width: 100%;
   display: flex;
   transition: all 0.2s ease-out;
}

.services-menu > li::after {
   content: '';
   position: absolute;
   bottom: -3px;
   left: 50%;
   transform: translateX(-50%);
   height: 3px;
   width: 0;
   background: #12be83;
}

.services-menu > li:hover::after {
   width: 100%;
   transition: all 0.8s ease-out 0.45s;
}

.services-menu > li > a {
   padding: 15px 10px;
   display: flex;
   flex-direction: column;
   align-items: center;
   justify-content: center;
   width: 100%;
   font-size: 15px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
   text-transform: uppercase;
   text-align: center;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.services-menu > li:hover > a {
   color: #fff;
   background: #12be83;
}






@media all and (max-width: 1550px) {
   /* .services-menu { max-width: calc((100vw - 1380px)/(1550 - 1380) * (1320 - 1070) + 1070px); } */
}

@media all and (max-width: 1380px) {
   .services-submenu { max-width: 280px; }
   /* .services-menu { max-width: calc((100vw - 1000px)/(1380 - 1000) * (1070 - 900) + 900px); } */
   /* .services-menu > li > a { font-size: calc((100vw - 1000px)/(1380 - 1000) * (15 - 12) + 12px); } */
}

@media all and (max-width: 1350px) {
   .services-submenu { max-width: 280px; }
}

@media all and (max-width: 1250px) {
   .services-submenu { max-width: 240px; }
   .services-submenu li a { font-size: 14px; }
}

@media all and (max-width: 800px) {
   .services-menu { display: none; }
}




.services-submenu {
   position: absolute;
   top: 120%;
   left: 0;
   width: 100%;
   max-width: 100%;
   display: flex;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   background: rgba(248, 249, 252, 0.95);
   /* border-top: 3px solid transparent; */
   opacity: 0;
   visibility: hidden;
   transition: all 0.3s ease-out;
}

.services-menu > li:hover .services-submenu {
   opacity: 1;
   visibility: visible;
   top: 100%;
   transition-delay: 0.3s;
}

.services-submenu li {
   display: flex;
   flex: 0 1 100%;
   max-width: 100%;
   transition: all 0.2s ease-out;
}

.services-submenu li a {
   padding: 20px;
   display: flex;
   flex-direction: column;
   align-items: center;
   justify-content: center;
   width: 100%;
   height: 100%;
   font-size: 16px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   text-align: center;
   position: relative;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.services-submenu li a::after {
   content: '';
   position: absolute;
   bottom: 0;
   left: 50%;
   transform: translateX(-50%);
   width: 0;
   height: 3px;
   background: #12be83;
   transition: all 0.2s ease-out;
}

.services-submenu li:hover a {
   color: #12be83;
}

.services-submenu li:hover a::after {
   width: 100%;
}

.services-submenu a img {
   margin-bottom: 15px;
   display: inline-block;
   width: 50px;
   height: 50px;
   flex: 1 1 auto;
}

.services-submenu a span {
   flex: 1 1 auto;
}



/* burger */
.services-menu-burger { 
   display: none; 
}

@media all and (max-width: 1140px) {
   .services-menu-burger { display: flex; }
} 



</style>