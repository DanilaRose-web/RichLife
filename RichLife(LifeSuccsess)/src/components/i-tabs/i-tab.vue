<template>
   <div class="i-tab" :class="{'active' : innerActive}">
      <template v-if="innerActive">
         <slot />
      </template>
   </div>
</template>

<script lang="ts">

import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"
import ITabModel from "./models/ITabModel"

@Component
export default class ITabComponent extends Vue {

   @Prop({ type: String, default: '' }) title: string
   @Prop({ type: Boolean, default: false }) active: boolean

   innerActive: boolean = false

   created() {
      this.innerActive = this.active
   }

   /**
    * Флаг активной вкладки и отображения контента внутри нее
    */
   setActive(value: boolean) {
      this.innerActive = value
   }


   /**
    * Чтение свойства title вкладки
    */
   get getTitle(): String {
      return this.title
   }
}
</script>

<style>

</style>