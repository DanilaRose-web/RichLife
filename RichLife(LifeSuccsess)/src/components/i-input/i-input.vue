<template>
   <div class="form-item" :style="getStyle()" :class="[innerError != '' ? 'error' : '']">
      <div class="label-wrap" v-if="hasLabel">
         <label :for="name" >{{ label }}</label>
         <div class="prompt-wrap i-tooltip-hover" v-if="hasTooltip">
            <!-- <svg class=""><use xlink:href="/assets/img/svg-sprite.svg#icon-question"></use></svg>
            <slot name="tooltip" /> -->
         </div>
      </div>

      <div class="input-wrap" >
         <input 
            :style="setStyleInput()"
            :ref="name"
            :type="type" 
            :id="name"
            :name="value"
            :required="required"
            :maxlength="maxlength"
            :minlength="minlength"
            v-model="innerValue"
            :placeholder="placeholder"
            :autocomplite="autocomplite"
            :pattern="pattern"
            @change="$emit('change')"
            @input="onInput($event.target.value)"
         >
         <slot />
      </div>
     <transition name="showErrorMessage">
         <span class="error-message" v-if="showError && innerError != '' ">{{ error }}</span>
     </transition>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch, Model } from "vue-property-decorator"

@Component
export default class IInputComponent extends Vue {
   @Prop({ type: Boolean, default: false }) hasLabel: boolean   // отображение label
   @Prop({ type: Boolean, default: false }) readonly: boolean  // (только для чтения) блокирует редактирования инпута
   @Prop({ type: Boolean, default: false }) required: boolean  // обязателен для заполнения
   @Prop({ type: String, default: 'text' }) type: string  // тип поля (аттрибут type)
   @Prop({ type: String, default: '' }) placeholder: string  // placeholder
   @Prop({ type: String, default: 'on' }) autocomplite: string  // браузер автоматически подставляет значения
   @Prop({ type: String, default: '' }) label: string  // label
   @Prop({ type: String, default: '' }) mb: string  // margin-right элементу .form-item
   @Prop({ type: String, default: '' }) mr: string  // margin-left элементу .form-item
   @Prop({ type: Number, default: null }) minlength: number  // минимальное кол-во вводимых символов
   @Prop({ type: Number, default: null }) maxlength: number  // максимальное кол-во вводимых символов
   @Model('input',  { default: '' }) value!: string;
   @Prop({ type: String, default: '' }) name: string  // name
   @Prop({ type: RegExp, required: false, default: undefined }) regex?: RegExp;  // регулярное выражение 
   @Prop({ type: Boolean, default: true }) showError: boolean  // флаг для отображения ошибки
   @Prop({ type: String, default: '' }) error: string = '' // текст об ошибке
   @Prop({ type: String, default: '1px solid transparent' }) border: string  // border инпута
   @Prop({ type: Boolean, default: false }) hasTooltip: boolean  // флаг для отображения блока с tooltip
   @Prop({ type: String, default: '' }) pattern: string // запрещает ввод символов, не соответствующих регулярному выражению

   innerValue = this.value 
   innerError: string = ''

   @Watch('innerValue') changeInnerValue() {
      if (this.innerValue !== this.value) {
         this.innerError = this.error
         this.$emit('input', this.innerValue);
         // console.log(this.innerValue, 'innerValue');
         
      }
   }
   @Watch('value') changeValue() {
      if (this.innerValue !== this.value) {
         this.innerError = this.error
         this.innerValue = this.value;
      }
   }

   @Watch('error') changeError() {
      if (this.innerError !== this.error) {
         this.innerError = this.error
      }
   }

   onInput(newValue: string) {
      this.innerValue = newValue;
      this.$emit("input", this.innerValue);
   }





   created() {
      this.innerValue = this.value
      this.innerError = this.error
   }

   mounted() {
      
   }
   updated() {}
   destroyed() {}


  
   

   getStyle(): Object {
      return {
         marginBottom: this.mb,
         marginRight: this.mr
      }
   }

   setStyleInput(): Object {
      if (this.innerError == '') 
         return { border: this.border }
      else 
         return { border: '1px solid #B10444' }
   }
}
</script>

<style scoped>

.form-item-flex {
   display: flex;
   align-items: flex-start;
   justify-content: space-between;
   width: 100%;
}

.form-item {
   position: relative;
   width: 100%;
   min-height: 55px;
}

.input-wrap {
   position: relative;
}


.label-wrap {
   margin-bottom: 8px;
   display: flex;
   align-items: center;
   justify-content: flex-start;
}

.prompt-wrap {
   position: relative;
}

.prompt-wrap svg {
   margin-left: 15px;
   width: 13px;
   height: 13px;
   fill: #121B23;
}

input {
   padding: 5px 10px 5px 20px;
   display: flex;
   align-items: center;
   flex: 1 1 auto;
   min-height: 45px;
   width: 100%;
   border-radius: 28px;
   background: #fff;
   font-size: 16px;
   font-weight: 500;
   border: 1px solid transparent;
   color: #000;
   transition: all 0.3s ease-out;
}

label {
   margin-left: 20px;
   display: inline-block;
   font-size: 14px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;
}

.form-item span {
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



/* Ошибка */

.form-item.error input {
   border: 1px solid #B10444;
   background: #FACDD4;
   color: #B10444;
}

.form-item.error span {
   opacity: 1;
   visibility: visible;
   left: 0;;
}





/* placeholder в разных состояниях */
::-webkit-input-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
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
:-ms-input-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
::-ms-input-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
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
:-ms-input-placeholder { /* Internet Explorer 10-11 */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}
::-ms-input-placeholder { /* Microsoft Edge */
   color: #000;
   font-weight: 500;
   font-style: italic;
   opacity: 0.5;
}





.form-item.error ::-webkit-input-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.form-item.error :-moz-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.form-item.error ::-moz-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.form-item.error :-ms-input-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.form-item.error ::-ms-input-placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.form-item.error ::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
   color: #B10444;
   opacity: 1; /* Firefox */
}
.form-item.error :-ms-input-placeholder { /* Internet Explorer 10-11 */
   color: #B10444;
}
.form-item.error ::-ms-input-placeholder { /* Microsoft Edge */
   color: #B10444;
}











/* checkbox */
.checkbox {
   margin-left: 15px;
   display: flex;
   align-items: center;
   max-width: 350px;
   position: relative;
}

.checkbox .check {
   position: relative;
   width: 20px;
   height: 20px;
}

.checkbox label {
   padding-left: 15px;
   position: relative;
   font-weight: 400;
   font-size: 15px;
   line-height: 112%;
   color: #fff;
   cursor: pointer;
   user-select: none;
}

.checkbox .check::after {
   content: '';
   margin-top: -15px;
   display: block;
   width: 20px;
   height: 20px;
   border: 2px solid #eb4707;
   border-radius: 3px;
   position: absolute;
   left: 0;
   top: 50%;
   opacity: .6;
   transition: all .12s, border-color .08s;
}

.checkbox.checked .check::after {
   margin-top: -19px;
   width: 10px;
   top: 50%;
   left: 5px;
   border-radius: 0;
   opacity: 1;
   border-top-color: transparent;
   border-left-color: transparent;
   -webkit-transform: rotate(45deg);
   transform: rotate(45deg);
}

.checkbox.error .check::after {
   border: 2px solid #eb2207;
}

.checkbox.error label {
   color: #eb2207;
}
</style>