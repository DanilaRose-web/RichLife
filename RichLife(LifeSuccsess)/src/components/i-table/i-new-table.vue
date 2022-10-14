<template>
   <div class="scroll-content">
      <div class="i-new-table" :style="setStyle()">
         <slot name="head"></slot>
         <template v-for="item in items">
            <slot name="body" :item="item"></slot>
         </template>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class INewTableComponent extends Vue {

   @Prop({ type: Array }) items: Object[]
   @Prop({ type: String, default: '' }) gridTemplateColumns: string
   @Prop({ type: String, default: 'auto' }) gridTemplateRows: string
   @Prop({ type: String, default: 'auto' }) columnGap: string
   @Prop({ type: String, default: 'auto' }) rowGap: string

   /**
    * Стили для таблицы
    */
   setStyle(): Object {
      return {
         gridTemplateColumns: this.gridTemplateColumns,
         gridTemplateRows: this.gridTemplateRows,
         columnGap: this.columnGap,
         rowGap: this.rowGap
      }
   }

}
</script>

<style scoped>

.scroll-content {
   overflow-x: auto;
   width: 100%;
   border-radius: 10px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.i-new-table {
   overflow: hidden;
   border-radius: 10px;
   display: grid;
}

.scroll-content.table-users .i-new-table {
   min-width: 800px;
}

.item {
   padding: 5px 10px;
   display: flex;
   align-items: center;
   justify-content: flex-start;
   height: 46px;
   max-height: 46px;
   background: #fff;
   font-size: 15px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
}

.item.center {
   justify-content: center;
}

.item.head {
   background: #12be83;
   color: #fff;
}

.table-head .item {
   background: #12be83;
   color: #fff;
}

.item.white {
   padding: 5px;
   background: rgba(18, 190, 131, 0.04);
   cursor: auto;
}

.item img {
   max-width: 40px;
   width: 100%;
   height: auto;
}
</style>