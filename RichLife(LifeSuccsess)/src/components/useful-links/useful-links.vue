<template>
   <div class="useful-links">
      <i-container>
         <h5 class="i-title section-title">Полезные ссылки</h5>
         <h6 class="i-subtitle">Данные ссылки содержат информацию нашего основного партнера - MetLife. Подобную информацию можно также посмотреть в разделе каждой компании</h6>
         <div class="links-row">
            <a href="https://www.portmone.com.ua/r3/oplata-strahuvannya-metlife" class="link" target="_blank">
               <img src="/assets/img/useful-links/link1.svg" alt="">
               Оплатить полис
            </a>
            
            <a @click="goToEvents" class="link">
               <img src="/assets/img/useful-links/link2.webp" alt=""> 
               Произошло страховое событие?
            </a>

            <a @click="goToRules" class="link">
               <img src="/assets/img/useful-links/link3.svg" alt="">
               Правила страхования
            </a>

            <a class="link" @click="$emit('callUs')">
               <img src="/assets/img/useful-links/link4.svg" alt="">
               Связаться с нами
            </a>
         </div>
      </i-container>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class UsefulLinksComponent extends Vue {

   /**
    * Открытие окна с проверкой авторизации при переходе на "страховые события"
    */
   goToEvents() {
      if (cookie.get('token') == undefined) 
         this.$emit("openNote")
      else this.$router.push({ name: 'insurance-event' })
   }

   /**
    * Открытие окна с проверкой авторизации при переходе на "правила страхования"
    */
   goToRules() {
      if (cookie.get('token') == undefined) 
         this.$emit("openNote")
      else this.$router.push({ name: 'insurance-rules' })
   }

}
</script>

<style scoped>

.useful-links {
   margin-bottom: 80px;
}

.useful-links-title {
   text-align: center;
   font-size: 25px;
   font-weight: 600;
   line-height: 120%;
   align-self: center;
   color: #121B23;
}

/* ссылки */

.links-row {
   display: grid;
   grid-template-columns: repeat(4, 1fr);
   grid-template-rows: 1fr;
   /* box-shadow: inset 2px 2px 5px rgba(154, 147, 140, 0.5), 1px 1px 5px rgba(255, 255, 255, 1); */
}

.link {
   padding: 30px 10px;
   display: flex;
   flex-direction: column;
   align-items: center;
   /* justify-content: center; */
   font-size: 16px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;
   text-align: center;
   border-radius: 28px;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.link img {
   margin-bottom: 15px;
   width: 60px;
   height: 60px;
   display: inline-block;
   transition: all 0.4s ease-out;
}

.link:hover img {
   transform: rotateY(360deg);
}

.link:hover {
   transform: translateY(-5px);
   box-shadow: 0 0 17px rgba(0, 0, 0, 0.15);
}

.link:nth-child(2):hover {
   color: #12be83;
}
.link:nth-child(3):hover {
   color: #FF2626;
}
.link:nth-child(4):hover {
   color: #007abc;
}
.link:nth-child(5):hover {
   color: #f39320;
}


@media all and (max-width: 900px) {
   .links-row { grid-template-columns: repeat(4, 1fr); grid-template-rows: auto 1fr; padding: 20px 0; }
   .useful-links-title { grid-column: 1/5; margin-bottom: 20px; }
   .link { padding: 20px 10px; }
}

@media all and (max-width: 570px) {
   .links-row { grid-template-columns: repeat(2, 1fr); grid-template-rows: auto 1fr 1fr; padding: 20px 0; }
   .useful-links-title { grid-column: 1/3; }
}

@media all and (max-width: 430px) {
   .links-row { grid-template-columns: 1fr; grid-template-rows: auto repeat(4, 1fr); padding: 20px 0; }
   .useful-links-title { grid-column: 1/2; }
}
</style>