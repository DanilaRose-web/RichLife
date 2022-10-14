<template>
   <div class="i-dropdown" :class="{'light' : light}">
      <label for="" v-if="hasLabel">{{ label }}</label>
      <div class="selected" @click="onShowOptions" v-if="selected">{{ selected.Name }}</div>

      <transition name="fadeOptions">
         <ul class="options" v-if="showOptions">
            <li v-for="item in innerItems" :key="item.Id" @click="onSelect(item.Id)" :class="{'current' : item.Selected}">
               <div class="name">{{ item.Name }}</div>
               <div class="icon" v-if="icon">{{ item.Image }}</div>
            </li>
         </ul> 
      </transition>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

import IDropdownModel from "./models/IDropdownModel";

@Component
export default class IDropdownComponent extends Vue {

   @Prop({ type: Array, default: () => [] as IDropdownModel[] }) items: IDropdownModel[]
   @Prop({ type: Boolean, default: false }) icon: boolean
   @Prop({ type: Boolean, default: false }) hasLabel: boolean
   @Prop({ type: Boolean, default: false }) light: boolean
   @Prop({ type: String, default: '' }) label: string

   innerItems: IDropdownModel[] // массив елементов option
   showOptions: boolean = false  // флаг открытия options
   selected: IDropdownModel = null  // выбранный язык

   @Watch('innerItems') change() {
      this.innerItems = this.items
   }

   created() {
      this.innerItems = this.items
      this.startSelected()
   }

   mounted () {
      document.addEventListener('click', this.clickOutside)
   }

   destroyed() {
      document.removeEventListener('click', this.clickOutside)
   }


   /**
    * Открытие options при клике на selected
    */
   onShowOptions() {
      this.showOptions = !this.showOptions
   }

   /**
    * Закрытие options
    */
   closeOptions() {
      this.showOptions = false
   }

   /**
    * Закрытие options при клике вне dropdown
    */
   clickOutside(event: any) {
      var showOptionsFlag = false;
      
      if (this.showOptions) {
         event.composedPath().find((el: any) => {
            if (!!el && !!el.classList) {
               if (
                  el.classList.contains("selected") ||
                  el.classList.contains("options")
               ) {
                  showOptionsFlag = true;
               }
            }
         });
      }
      if (!showOptionsFlag) {
         this.showOptions = false;
      }
   }

   /**
    * Выбор элемента
    */
   onSelect(id: number) {
      this.selected = this.innerItems.find(el => el.Id == id)
      this.innerItems.forEach(item => {
         item.Selected = false
      })
      if (this.selected) this.selected.Selected = true
      this.closeOptions()
      this.$emit('selected', this.selected)
   }

   /**
    * Отображение выбранного элемента в selected
    */
   startSelected() {
      this.selected = this.innerItems.find(el => el.Selected)
   }
}
</script>

<style scoped>

.i-dropdown {
   position: relative;
}

.selected {
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
   color: #000;
   border: 1px solid #000;
   position: relative;
   cursor: pointer;
   transition: all 0.3s ease-out;
}

.i-dropdown.light .selected {
   border: 1px solid rgba(18, 27, 35, 0.2);
}

/* options */
.options {
   position: absolute;
   top: 101%;
   left: 0;
   width: 100%;
   background: #fff;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

/* options */
.options {
   position: absolute;
   top: 105%;
   left: 0;
   opacity: 1;
   visibility: visible;
   width: 100%;
   /* border-radius: 20px; */
   background: #fff;
   min-height: 72px;
   overflow: auto;
   z-index: 2;
}

.options li {
   padding: 10px;
   display: flex;
   align-items: center;
   justify-content: space-between;
   cursor: pointer;
   font-size: 14px;
   font-weight: 600;
   color: #121B23;
   display: -webkit-box;
   -webkit-line-clamp: 1;
   -webkit-box-orient: vertical;
   overflow: hidden;
   transition: all 0.2s ease-out;
}

.options li:hover {
   background: #e6e6eb;
}

.options li.current {
   background: #12be83;
   color: #fff;
}

.options li .flex {
   margin-right: 10px;
   display: flex;
   align-items: center;
   flex: 1 1 auto;
}

label {
   margin-bottom: 8px;
   margin-left: 20px;
   display: inline-block;
   font-size: 14px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;
}

/* flag */
.options li .flag {
   margin-right: 10px;
   max-width: 26px;
}

.options li .flag img {
   width: 26px;
   height: auto;
}

.fadeOptions-enter-active, .fadeOptions-leave-active {
   transition: all 0.4s ease-out;
}

.fadeOptions-enter, .fadeOptions-leave-to {
   opacity: 0;
   visibility: hidden;
   top: 120%;
}
</style>