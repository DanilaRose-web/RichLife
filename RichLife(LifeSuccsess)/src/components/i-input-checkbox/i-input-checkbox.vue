<template>
   <label for="" class="check-label">
      <input
         class="check-input"
         type="checkbox" 
         v-model="innerValue"
         @click="onClick">
   </label>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class IInputCheckboxComponent extends Vue  {

   @Prop({ type: Boolean, default: false }) value: boolean

   innerValue: boolean = false

   @Watch('value') change() {
      this.innerValue = this.value
      console.log(this.innerValue, 'value watch');
      
   }

   created() {
      this.innerValue = this.value
      console.log(this.innerValue, 'value');
   }

   onClick() {
      this.innerValue = !this.innerValue
      this.$emit("input", this.innerValue);
   }

}
</script>

<style scoped>

.check-label {
   cursor: pointer;
   width: 13px;
   height: 13px;
}

.check-input {
   /* -webkit-appearance: none; */
   /* -moz-appearance: none; */
   /* appearance: none; */
   cursor: pointer;
}
</style>