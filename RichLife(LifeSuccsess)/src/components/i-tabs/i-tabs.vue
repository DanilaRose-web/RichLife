<template>
   <div class="i-tabs" ref='iTabs' >
      <div class="i-tab" v-for="(item, index) in tabArray" :key="index"
         @click="clickTab(item.title, index)">
         <span>{{ item.getTitle }}</span>
      </div>
      <slot></slot>
   </div>
</template>

<script lang="ts">

import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"
import ITabComponent from "./i-tab.vue";

@Component
export default class ITabsComponent extends Vue {
   @Prop({ type: String, default: '' }) title: string

   tabArray: any[] = []

   created() {
      
   }

   mounted() {
      // console.log(this.tabArray, 'tabArray');
      console.log(this.childTabs, 'childTabs');
       console.log(this.tabArray, 'tabArray');
      this.tabArray = this.childTabs
   }

   /**
    * Получаем все дочерние компоненты, которые принадлежат классу ITabComponent
    * instanceof - определяет к какому классу принадлежит объект с учетом наследования 
    */
   get childTabs(): ITabComponent[] {
     
      return this.tabArray = this.$children.filter(el => el instanceof ITabComponent) as ITabComponent[]
      
   }


   clickTab(value: string, index: number) {
      let i = 0
      this.tabArray.forEach(el => {
         if (i == index)  el.setActive(true)
            else el.setActive(false)
         i++
      })
   }
}
</script>

<style scoped>

.i-tabs {
   padding: 20px 0;
   display: flex;
   align-items: center;
   justify-content: space-between;
   width: 100%;
   border-bottom: 1px solid #121B23;
   
}
</style>