<template>
   <div class="broker-request">
      <div class="row broker-row">
         <div class="col-6 broker-col">
            <div class="broker-item">
               <div class="img"><img src="/assets/img/profile/relationship.webp" alt=""></div>
            </div>
         </div>
         <div class="col-6 broker-col">
            <div class="broker-item">
               <h2 class="i-title congrates-title">Так держать!</h2>
               <p class="i-text congrates-text broker-text">Вы заключили контрактов на более, чем <strong>200 Е</strong> (единиц)! Теперь вы можете оставить заявку нашему брокеру на партнерство для еще более тесного и продуктивного сотрудничества и развития!</p>
               <i-button @onClick="$emit('click')" class="transparent" :margin="'20px 0 0 0'" :maxWidth="'250px'" :width="'100%'">Стать партнером</i-button>
            </div>
         </div>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class BrokerRequesComponent extends Vue {

}
</script>

<style scoped>

.broker-request {
   margin-top: 100px;
}

.broker-row {
   align-items: center;
}

.broker-col {
   margin-bottom: 30px;
   display: flex;
}

.broker-item {
   display: flex;
   flex-direction: column;
   align-items: center;
   width: 100%;
}

.img {
   width: 100%;
   overflow: hidden;
   min-height: 310px;
   background: url('/assets/img/profile/relationship.webp') no-repeat center;
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

.broker-text strong {
   font-size: 25px;
}

@media all and (max-width: 850px) {
   .broker-col { margin-bottom: 30px; flex: 0 0 100%; max-width: 100%; }
}

@media all and (max-width: 620px) {
   .img img { display: inline-block; }
   .img { background: none; min-height: auto; }
}
</style>