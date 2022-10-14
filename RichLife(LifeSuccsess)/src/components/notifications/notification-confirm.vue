<template>
   <div class="notification-wrap">
      <div class="note-img"><img :src="image" alt=""></div>
      <p class="i-text note-text" v-if="hasTitle">{{ title }}</p>
      <slot v-if="!hasTitle" />
      <div class="i-button-group">
         <i-button @onClick="$emit('clickCancel')" class="grey" :width="width" :margin="margin">Отмена</i-button>
         <i-button @onClick="$emit('clickConfirm')" :width="width" :margin="'5px 7.5px'">Подтвердить</i-button>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class NotificationConfirmComponent extends Vue {

   @Prop({ type: String, default: '' }) title: string
   @Prop({ type: Boolean, default: true }) hasTitle: boolean
   @Prop({ type: String, default: '' }) image: string

   /**
    * Переменные стилизации кнопок
    */
   margin: string = '5px 7.5px'
   width: string = 'auto'  

   /**
    * Отображение slot
    */
   hasContent: boolean = false


   created() {
      this.changeStyleButtons()
      window.addEventListener('resize', this.changeStyleButtons)

      if (!this.hasTitle) 
         this.hasContent = true
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

.note-text strong {
   font-weight: 700;
   color: #12be83;
}

.note-text strong.tt-u {
   text-transform: uppercase;
}




.i-button-group {
   display: flex;
   align-items: center;
   justify-content: center;
   width: 100%;
}


@media all and (max-width: 340px) {
   .i-button-group { display: flex; flex-direction: column; align-items: center; }
}
</style>