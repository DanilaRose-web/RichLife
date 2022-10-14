<template>
   <button class="i-button" type="button"
      :style="getStyle()"
      @click="$emit('onClick')"
   >
      <span><slot /></span>
   </button>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"

@Component
export default class IButtonComponent extends Vue {
   @Prop({ type: String, default: '7px 20px' }) padding: string
   @Prop({ type: String, default: 'flex' }) display: string
   @Prop({ type: String, default: 'center' }) align: string
   @Prop({ type: String, default: 'center' }) justify: string
   @Prop({ type: String, default: '28px' }) borderRadius: string
   @Prop({ type: String, default: 'all 0.3s ease-out' }) transition: string
   @Prop({ type: String, default: 'inherit' }) fontFamily: string
   @Prop({ type: Number, default: 600 }) fontWeight: number
   @Prop({ type: String, default: '15px' }) fontSize: string
   @Prop({ type: String, default: '0' }) margin: string
   @Prop({ type: String, default: '' }) width: string
   @Prop({ type: String, default: '' }) height: string
   @Prop({ type: String, default: '' }) maxWidth: string
   @Prop({ type: String, default: '' }) minWidth: string
   @Prop({ type: String, default: '' }) minHeight: string
   

   getStyle(): Object {
      return {
         padding: this.padding,
         display: this.display,
         alignItems: this.align,
         justifyContent: this.justify,
         borderRadius: this.borderRadius,
         transition: this.transition,
         fontFamily: this.fontFamily,
         fontWeight: this.fontWeight,
         fontSize: this.fontSize,
         margin: this.margin,
         width: this.width,
         maxWidth: this.maxWidth,
         minWidth: this.minWidth,
         height: this.height,
         minHeight: this.minHeight
      }
   }

   
}
</script>

<style lang="css">

.i-button {
   background: #12be83;
   border: none;
   color: #fff;
}

.i-button:active {
   transform: scale(0.96);
}

.i-button:hover {
   color: #fff;
   background: #0da671;
}



/* grey button */
.i-button.grey {
   color: #9292a6;
   background: #f0f0f5;
}

.i-button.grey:hover {
   color: #9292a6;
   background: #e6e6eb;
}

.i-button.orange {
   background: #ff5405;
   z-index: 1;
}

.i-button.orange:hover {
   background: #ca4101;
}





/* disable button */
.i-button.disable {
   background: rgba(230, 230, 235, 0.7);
   color: rgba(146, 146, 166, 0.7);
   cursor: auto;
}

.i-button.disable:active {
   transform: scale(1);
}




/* transparent button with border */
.i-button.transparent {
   color: #12be83;
   background: transparent;
   border: 1px solid #12be83;
}

.i-button.transparent:hover {
   color: #fff;
   background: #12be83;
}

.i-button.mr15 {
   margin-right: 15px;
}

.i-button.tt-u {
   text-transform: uppercase;
}
</style>