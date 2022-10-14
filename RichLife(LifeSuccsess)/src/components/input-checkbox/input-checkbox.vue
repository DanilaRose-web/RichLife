<template>
   <div class="input-checkbox" @click="setChecked" :class="{'checked' : innerChecked}">
      <div class="checkbox"></div>
      <div class="label">{{ label }}</div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class InputCheckboxComponent extends Vue {

   @Prop({ type: Boolean, default: false }) checked: boolean
   @Prop({ type: String, default: '' }) label: string

   innerChecked: boolean = false

   @Watch('checked') change() {
      this.innerChecked = this.checked
   }

   created() {
      this.innerChecked = this.checked
   }

   setChecked() {
      this.innerChecked = !this.innerChecked
      this.$emit('click', this.innerChecked)
   }

}
</script>

<style scoped>

.input-checkbox {
   display: flex;
   align-items: center;
   cursor: pointer;
}

.checkbox {
   margin-right: 10px;
   display: flex;
   align-items: center;
   max-width: 350px;
   position: relative;
   width: 20px;
   height: 20px;
}


.input-checkbox .label {
   position: relative;
   font-weight: 500;
   font-size: 15px;
   line-height: 112%;
   color: #121B23;
   cursor: pointer;
   user-select: none;
}

.checkbox::after {
   content: '';
   display: block;
   width: 20px;
   height: 20px;
   border: 2px solid #12be83;
   border-radius: 3px;
   position: absolute;
   left: 0;
   top: 0;
   opacity: .6;
   transition: all .12s, border-color .08s;
}

.input-checkbox.checked .checkbox::after {
   width: 10px;
   top: -5px;
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

.checkbox.error .label {
   color: #eb2207;
}
</style>