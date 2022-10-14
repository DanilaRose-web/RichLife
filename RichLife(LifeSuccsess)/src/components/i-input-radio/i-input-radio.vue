<template>
   <div class="i-inputs-radio" :class="{'darkTheme' : darkTheme}">
      <div class="i-input-radio" v-for="item in array" :key="item.Id" @click="selectitem(item.Id)">
         <div class="radio" :id="item.Id" :class="{'checked' : item.Selected}"></div>
         <div class="label" :for="item.Id" :class="{'recommended' : item.Recommended}">{{ item.Label }}</div>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"
import IInputRadioModel from "./IInputRadioModel";

@Component
export default class IInputRadioComponent extends Vue {

   @Prop({ type: Array, default: () => [] as IInputRadioModel[] }) array: IInputRadioModel[]
   @Prop({ type: Boolean, default: false }) darkTheme: boolean

   innerChecked: boolean = false

   created() {
      this.startSelectedItem()
   }
 
   selectitem(id: number) {
      let current = this.array.find(el => el.Id == id)
      this.array.forEach(item => {
         item.Selected = false
         if (current) {
            current.Selected = true
         }
      })
      this.$emit('onSelected', current)
   }

   startSelectedItem() {
      let current = this.array.find(el => el.Selected)
      this.$emit('onSelected', current)
   }
}
</script>

<style scoped>

.i-inputs-radio {
   display: flex;
   align-items: center;
   justify-content: center;
   flex-wrap: wrap;
}

.i-input-radio {
   display: flex;
   align-items: center;
   position: relative;
   cursor: pointer;
}

.i-input-radio {
   margin-bottom: 10px;
   margin-right: 15px;
}

.radio {
   margin-right: 7px;
   display: flex;
   align-items: center;
   justify-content: center;
   width: 20px;
   height: 20px;
   border-radius: 50%;
   border: 1px solid #12be83;
   position: relative;
   transition: all 0.2s ease-out;
}

.radio::after {
   content: '';
   position: absolute;
   top: 50%;
   left: 50%;
   transform: translate(-50%, -50%);
   width: 60%;
   height: 60%;
   opacity: 0;
   visibility: hidden;
   background: #12be83;
   border-radius: 50%;
   overflow: hidden;
   transition: all 0.2s ease-out;
}

.radio.checked {
   border: 1px solid #12be83;
}

.radio.checked::after {
   opacity: 1;
   visibility: visible;
}


/* label */ 
.label {
   font-size: 15px;
   font-weight: 500;
   color: #e6e6eb;
   user-select: none;
   transition: all 0.2s ease-out;
}

.label.recommended {
   font-size: 17px;
   font-weight: 700;
}

.i-inputs-radio.darkTheme .radio {
   border: 1px solid #12be83;
}

.i-inputs-radio.darkTheme .radio.checked {
   border: 1px solid #12be83;
}

.i-inputs-radio.darkTheme .label {
   color: #121B23;
}

/* .i-input-radio:hover .label,
.radio.checked + .label {
   color: #12be83;
} */
</style>