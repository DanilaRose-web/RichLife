<template>
   <div class="i-container"
      :style="getStyle()"
   >
      <slot />
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"

@Component
export default class IContainerComponents extends Vue {
   @Prop({ type: String, default: '0 15px' }) padding: string
   @Prop({ type: String, default: '1320px' }) maxWidth: string
   @Prop({ type: String, default: 'block' }) display: string
   @Prop({ type: String, default: 'center' }) align: string
   @Prop({ type: String, default: '' }) justify: string

   created() {}

   getStyle() {
      return {
         'padding': this.padding,
         'max-width': this.maxWidth,
         'display': this.display,
         'align-items': this.align,
         'justify-content': this.justify
      }
   }
}
</script>

<style lang="css">

.i-container {
   margin: 0 auto;
   width: 100%;
   position: relative;
   /* z-index: 1; */
}

@media all and (max-width: 520px) {
   .i-container.services-menu-container { justify-content: space-between; }
}
</style>