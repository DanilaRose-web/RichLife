<template>
   <div class="i-textarea" :class="[showValidation ? 'error' : '', light ? 'light' : '']">
      <div class="label-wrap" v-if="hasLabel">
         <label :for="name" >{{ label }}</label>
         <div class="tooltip-wrap i-tooltip-hover" v-if="hasTooltip">
            <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-question"></use></svg>
            <i-tooltip bottom><slot name="tooltip" /></i-tooltip>
         </div>
      </div>

      <div class="input-wrap">
         <textarea 
            :ref="'input'+name"
            :value="value"
            @input="onInput($event.target.value)"
            :name="name"
            :id="name"
            :placeholder="placeholder"
            :regex="regex"
            :maxlength="maxlength"
            :minlength="minlength"
            :style="getStyle()"
         />
         <slot />
      </div>

      <transition name="showErrorMessage">
         <p class="error-message" v-if="showError">{{ error }}</p>
      </transition>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class INewInputComponent extends Vue {

   @Prop({ type: String, default: '', required: false }) label: string 
   @Prop({ default: '', required: true }) value: string | number;
   @Prop({ type: String, default: '', required: true }) name: string;
   @Prop({ type: String, default: '', required: false }) placeholder: string;
   @Prop({ type: RegExp, default: undefined, required: false, }) regex?: RegExp
   @Prop({ type: Boolean, default: false, required: false }) required: boolean;
   @Prop({ type: Boolean, default: false, required: false }) showError: boolean;
   @Prop({ type: Boolean, default: false, required: false }) hasLabel: boolean;
   @Prop({ type: Boolean, default: false, required: false }) light: boolean;
   @Prop({ type: Boolean, default: false, required: false }) isPhone: boolean;
   @Prop({ type: Boolean, default: false, required: false }) isCard: boolean;
   @Prop({ type: Boolean, default: false, required: false }) isStandart: boolean;
   @Prop({ type: Boolean, default: false, required: false }) hasTooltip: boolean;
   @Prop({ type: Number, default: null, required: false }) maxlength: number
   @Prop({ type: Number, default: null, required: false }) minlength: number
   @Prop({ type: String, default: '100px', required: false }) minHeight: string 


   innerValue: string | number;
   showValidation: boolean = false
   error: string = ''

   @Watch('value') changeValue() {
      this.$emit('changeValue', this.value)
      this.innerValue = this.value;
      this.checkValidation();
      console.log(this.value, 'value');
      
   }


   created() {
      this.innerValue = this.value;
   }



   isValid(): boolean {
      if (this.required && (this.innerValue === undefined || this.innerValue === "" || this.innerValue === null)) {
         this.error = 'Это обязательное поле'
         return false;
      } 
      else {
         this.error = ''
         return true
      }
  }

   checkValidation(): boolean {
      if (this.isValid()) this.showValidation = false;
      else this.showValidation = true;
      this.$emit('valid', this.showValidation)
      return !this.showValidation
   }

  
   /**
    * Переопределение value при вводе (событие input)
    */
   onInput(newValue: string) {
      this.innerValue = newValue;
      this.$emit("input", this.innerValue);
      this.checkValidation();
  }

  /**
   * Стилизация через Props
   */
  getStyle(): Object {
     return {
        minHeight: this.minHeight
     }
  }
}
</script>

<style scoped>

.i-textarea {
   position: relative;
}

textarea {
   padding: 5px 10px 5px 20px;
   display: flex;
   align-items: center;
   flex: 1 1 auto;
   min-height: 45px;
   width: 100%;
   border-radius: 28px;
   background: #fff;
   font-family: 'Montserrat', sans-serif;
   font-size: 14px;
   font-weight: 500;
   border: 1px solid transparent;
   color: #000;
   transition: all 0.3s ease-out;
}


.label-wrap {
   margin-bottom: 8px;
   display: flex;
   align-items: flex-start;
   justify-content: flex-start;
   position: relative;
   width: max-content;
}

.label-wrap svg {
   margin-left: 10px;
   width: 15px;
   height: 15px;
   fill: #121B23;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.label-wrap svg:hover {
   fill: #12be83;
}

label {
   margin-left: 20px;
   display: inline-block;
   font-size: 14px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;
}


/* light */
.i-textarea.light textarea {
   border: 1px solid rgba(18, 27, 35, 0.2);
}




/* Ошибка */
.i-textarea.error textarea {
   border: 1px solid #B10444;
   background: #FACDD4;
   color: #B10444;
}

.i-textarea.error span {
   opacity: 1;
   visibility: visible;
   left: 0;;
}



/* error message */
.error-message {
   margin-top: 5px;
   /* position: absolute; */
   bottom: -7px;
   left: 0;
   display: flex;
   color: #B10444;
   font-weight: 500;
   font-size: 13px;
   line-height: 120%;
   opacity: 1;
   visibility: visible;
   transition: all 0.2s ease-out;
}





.showErrorMessage-enter-active,
.showErrorMessage-leave-active {
   transition: all 0.3s ease-out;
}
.showErrorMessage-enter,
.showErrorMessage-leave-to {
   opacity: 0;
   visibility: hidden;
   left: 20px;
}





/* placeholder в разных состояниях */
::-webkit-textarea-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
:-moz-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
::-moz-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
:-ms-textarea-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
::-ms-textarea-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
:-ms-textarea-placeholder { /* Internet Explorer 10-11 */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
::-ms-textarea-placeholder { /* Microsoft Edge */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}





.i-textarea.error ::-webkit-textarea-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.i-textarea.error :-moz-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.i-textarea.error ::-moz-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.i-textarea.error :-ms-textarea-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.i-textarea.error ::-ms-textarea-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.i-textarea.error ::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.i-textarea.error :-ms-textarea-placeholder { /* Internet Explorer 10-11 */
   color: #B10444;
}
.i-textarea.error ::-ms-textarea-placeholder { /* Microsoft Edge */
   color: #B10444;
}
</style>