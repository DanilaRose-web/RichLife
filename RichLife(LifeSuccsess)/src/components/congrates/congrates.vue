<template>
   <div class="congrates-wrap">
      <div class="congrates">
         <div class="congrates-col">
            <div class="img">
               <img src="/assets/img/profile/congrates.webp" alt="">
            </div>
         </div>

         <div class="congrates-col">
            <div class="info">
               <h2 class="i-title congrates-title">Поздравляем!</h2>
               <p class="i-text congrates-text"><strong>5</strong> лет и <strong>246</strong> дней</p>
               <p class="i-text congrates-text">Мы помогаем друг другу расти, развиваться и становиться лучше! Искренне рады нашему сотрдничеству, за это время у нас много общих достижений!</p>
               <p class="i-text congrates-text dedicated">Спасибо, что вы с нами!</p>
            </div>
         </div>
      </div>

      <congrates-numbers></congrates-numbers>
   </div>
</template>

<script lang="ts">

import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class CongratesComponent extends Vue {

}
</script>

<style scoped>

/* congrates */
.congrates {
   margin: 0 -15px;
   display: flex;
   align-items: center;
   flex-wrap: wrap;
}

.congrates-col {
   padding: 0 15px;
   flex: 0 0 50%;
   max-width: 50%;
   display: flex;
}

.img {
   width: 100%;
   overflow: hidden;
   min-height: 310px;
   background: url('/assets/img/profile/congrates3.webp') no-repeat center;
   background-size: cover;
   border-radius: 20px;
   box-shadow: 0 0 42px rgb(0 0 0 / 10%);
}

.img img {
   max-width: 100%;
   height: auto;
   border-radius: 20px;
   display: none;
}




.info {
   display: flex;
   flex-direction: column;
   align-items: center;
   width: 100%;
}



@media all and (max-width: 850px) {
   .congrates-col { margin-bottom: 30px; flex: 0 0 100%; max-width: 100%; }
}

@media all and (max-width: 620px) {
   .img img { display: inline-block; }
   .img { background: none; min-height: auto; }
}

</style>