<template>
   <div class="notification-wrap">
      <p class="i-text note-text">Оставить заявку или посмотреть скрытый контент могут только авторизованные пользователи. Для этого перейдите на страницу входа или зарегистрируйтесь, если у Вас еще нет аккаунта</p>
      <div class="i-button-group">
         <i-button @onClick="$emit('click')" class="green" :width="width" :margin="margin">Регистрация</i-button>
         <router-link @click="removeBodyHidden" class="i-button-link small grey no-mb note-link" to="sign">Вход</router-link>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class NotificationGetInTouchComponent extends Vue {

   @Prop({ type: String, default: '' }) title: string

   /**
    * Переменные стилизации кнопок
    */
   margin: string = '5px 7.5px'
   width: string = 'auto'  


   created() {
      this.changeStyleButtons()
      window.addEventListener('resize', this.changeStyleButtons)
   }

   changeStyleButtons() { 
      console.log('changeStyleButtons');
      
      let windowWidth = window.innerWidth
      if (windowWidth <= 340) {
         this.margin = '5px 0'
         this.width = '100%'
      } else {
         this.margin = '5px 7.5px'
         this.width = 'auto'
      }
   }

   removeBodyHidden() {
      let bodyOverflowHidden = document.querySelector('body')
      bodyOverflowHidden.classList.remove('hidden')
   }

}
</script>

<style scoped>

.notification-wrap {
   display: flex;
   flex-direction: column;
   align-items: center;
   border-radius: 20px;
   width: 100%;
   height: 100%;
}

.note-img {
   margin-bottom: 20px;
   width: 70px;
   height: 70px;
}

.note-img img {
   max-width: 100%;
   height: auto;
}

.note-text {
   color: #fff;
   text-align: center;
}




.i-button-group {
   display: flex;
   align-items: center;
   justify-content: center;
   width: 100%;
}

.i-button-link.note-link {
   max-width: 150px;
}


@media all and (max-width: 340px) {
   .i-button-group { display: flex; flex-direction: column; align-items: center; }
}
</style>