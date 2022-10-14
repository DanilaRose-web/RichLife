<template>
   <div class="congrates-numbers">
      <h3 class="congrates-number-title i-title section-title">Мои достижения:</h3>

      <div class="row congrates-number-row">
         <div class="col-4 congrates-number-col">
            <div class="congrates-item">
               <div class="icon"><img src="/assets/img/profile/congrates-icon1.svg" alt=""></div>
               <p>Заключено контрактов на общую сумму</p>
               <div class="count">145 650 125</div>
            </div>
         </div>

         <div class="col-4 congrates-number-col">
            <div class="congrates-item">
               <div class="icon"><img src="/assets/img/profile/congrates-icon2.svg" alt=""></div>
               <p>Количество заключенных вами контрактов</p>
               <div class="count">145 650 125</div>
            </div>
         </div>

         <div class="col-4 congrates-number-col">
            <div class="congrates-item">
               <div class="icon"><img src="/assets/img/profile/congrates-icon3.svg" alt=""></div>
               <p>Общая сумма контрактов</p>
               <div class="count">145 650 125</div>
            </div>
         </div>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class CongratesNumbersComponent extends Vue {



}
</script>

<style scoped>

.congrates-number-title {
   margin: 60px auto 40px auto;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
   text-align: center;
}

.congrates-number-row {
   justify-content: center;
}

.congrates-number-col {
   margin-bottom: 30px;
   display: flex;
}



/* congrates number item */
.congrates-item {
   padding: 20px 10px;
   display: flex;
   flex-direction: column;
   align-items: center;
   width: 100%;
   border-radius: 20px;
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.1);
   transition: all 0.2s ease-out;
}

.congrates-item:hover {
   transform: translateY(-5px);
   box-shadow: 0 0 42px rgba(0, 0, 0, 0.15);
}

.icon {
   margin-bottom: 20px;
   width: 70px;
   height: 70px;
   transition: all 0.3s ease-out;
}

.congrates-item:hover .icon {
   transform: rotateY(360deg);
}

.icon img {
   max-width: 100%;
   height: auto;
}


.congrates-item p {
   margin-bottom: 15px;
   font-size: 16px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
   text-align: center;
   max-width: 300px;
   flex: 1 1 auto;
}

.count {
   font-size: 35px;
   font-weight: 900;
   color: #12be83;
}


@media all and (max-width: 920px) {
   .count { font-size: calc((100vw - 710px)/(920 - 710) * (35 - 27) + 27px); }
}

@media all and (max-width: 710px) {
   .congrates-number-col { flex: 0 0 50%; max-width: 50%; }
   .count { font-size: calc((100vw - 500px)/(710 - 500) * (35 - 27) + 27px); }
}

@media all and (max-width: 500px) {
   .congrates-number-col { flex: 0 0 100%; max-width: 100%; }
   .count { font-size: calc((100vw - 280px)/(500 - 280) * (35 - 28) + 28px); }
}
</style>