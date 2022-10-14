<template>
   <div class="step step-five">
      <div class="step-form">
         <heirs @prev="$emit('prev')" @send="send"></heirs>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"
import HeirsModel from "../heirs/HearsModel";

import StepModel from "./models/StepModel";

@Component
export default class StepSixComponent extends Vue {

   step: StepModel = null  // номер шага формы
   // heirs: HeirsModel[] = []

   created() {
      this.step = new StepModel(6)
      this.$emit('step', this.step)
   }

   send(heirs: HeirsModel[]) {
      this.$emit('send', heirs)
   }

}
</script>

<style scoped>

.step-form {
   display: grid;
   grid-template-columns: 1fr;
   grid-template-rows: auto;
   gap: 15px;
}

.grid-item {
   align-self: center;
}

.radio-wrap,
.column100 {
   grid-column: 1/3;
}

.checkbox-wrap {
   margin-top: 20px;
   width: max-content;
}


.item-btn {
   margin-top: 30px;
   width: 100%;
   grid-column: 1/3;
   display: flex;
   justify-content: flex-end;
}

@media all and (max-width: 620px) {
   .step-form { grid-template-columns: 1fr; }
   .item-btn { grid-column: 1/2; }
}
</style>








<style>

.i-inputs-radio.no-mb .i-input-radio {
   margin-bottom: 0;
}

.step {
   margin: 0 auto;
   max-width: 900px;
}
</style>