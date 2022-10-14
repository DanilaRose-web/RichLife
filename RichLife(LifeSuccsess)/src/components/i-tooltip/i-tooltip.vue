<template>
   <div class="i-tooltip" :class="[top ? 'top' : '', bottom ? 'bottom' : '', right ? 'right' : '', left ? 'left' : '']">
      <p><slot /></p>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class ITooltipComponent extends Vue {

   @Prop({ type: Boolean, default: false }) show: boolean
   @Prop({ type: Boolean, default: false }) top: boolean
   @Prop({ type: Boolean, default: false }) right: boolean
   @Prop({ type: Boolean, default: false }) bottom: boolean
   @Prop({ type: Boolean, default: false }) left: boolean

   innerShow: boolean = false

   @Watch('show') change() {
      this.innerShow = this.show
   }

   created() {
      this.innerShow = this.show
   }
}
</script>

<style scoped>



.i-tooltip {
   padding: 10px;
   position: absolute;
   width: max-content;
   max-width: 240px;
   background: rgba(18, 27, 35, 0.8);
   border-radius: 10px;
   opacity: 0;
   visibility: hidden;
   z-index: 2;
   transition: all 0.2s ease-out;
}

.i-tooltip p {
   font-size: 12px;
   font-weight: 500;
   color: #fff;
   line-height: 160%;
   word-break: break-all;
}


/* top */
.i-tooltip.top {
   bottom: 15px;
   left: 0;
}



/* right */
.i-tooltip.right {
   right: 120%;
   top: 50%;
   transform: translateY(-50%);
}



/* bottom */
.i-tooltip.bottom {
   top: 15px;
   left: 0;
}




/* left */
.i-tooltip.left {
   left: 120%;
   top: 50%;
   transform: translateY(-50%);
}


</style>


<style>

.i-tooltip-hover {
   position: relative;
}

.i-tooltip-hover:hover svg {
   fill: #12be83;
}
.i-tooltip-hover:hover .i-tooltip.top {
   bottom: 20px;
   opacity: 1;
   visibility: visible;
}
.i-tooltip-hover:hover .i-tooltip.right {
   right: 100%;
   opacity: 1;
   visibility: visible;
}
.i-tooltip-hover:hover .i-tooltip.bottom {
   top: 35px;
   opacity: 1;
   visibility: visible;
}
.i-tooltip-hover:hover .i-tooltip.left {
   left: 100%;
   opacity: 1;
   visibility: visible;
}
</style>