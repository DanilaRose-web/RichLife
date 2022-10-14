<template>
   <div class="langs-dropdown" :style="setStyle()" :class="[absolute ? 'absolute' : '', withInputLabel ? 'withLabel' : '']">
      <label v-if="hasLabel" for="">{{ label }}</label>
      <div @click="openOptions" class="selected lang" v-if="selectedLang && isLang" :style="setStyleSelected()"><div class="icon"><img :src="selectedLang.Flag" :alt="selectedLang.Country"></div> <span>{{ selectedLang.ShortName }}</span></div>
      <div @click="openOptions" class="selected" v-if="selectedLang && isCountry" :style="setStyleSelected()"><div class="icon"><img :src="selectedLang.Flag" :alt="selectedLang.Country"></div> {{ selectedLang.Country }}</div>
      <div @click="openOptions" class="selected" v-if="selectedLang && isPhone" :style="setStyleSelected()"><div class="icon"><img :src="selectedLang.Flag" :alt="selectedLang.Country"></div> <span>{{ selectedLang.CodeNumber }}</span></div>

      <transition name="showOptions">
         <ul class="options" v-if="langsArray && showOptions">
            <li v-for="item in langsArray" :key="item.Id" @click="selectLang(item.Id)" :class="{'current' : item.Selected}">
               <div class="flex">
                  <div class="flag"><img :src="item.Flag" :alt="item.Country"></div>
                  <div class="country">{{ item.Country }}</div>
               </div>
               
               <div class="code">{{ item.CodeNumber }}</div>
            </li>
         </ul>
      </transition>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

// import EnumCountry from "./Enums/EnumCountry"
import LangsModel from "./models/LangsModel"
import EnumLangs from "./Enums/EnumLangs"

@Component
export default class LangsDropdownComponent extends Vue {

   @Prop({ type: Boolean, default: false }) isCountry: boolean
   @Prop({ type: Boolean, default: false }) isPhone: boolean 
   @Prop({ type: Boolean, default: false }) isLang: boolean 
   @Prop({ type: Boolean, default: false }) absolute: boolean  // абсолюьное позиционирование langs-dropdown
   @Prop({ type: Boolean, default: false }) withInputLabel: boolean  // абсолюьное позиционирование langs-dropdown, если у input есть label
   @Prop({ type: Number, default: 1 }) zIndex: number
   @Prop({ type: String, default: '1px solid transparent' }) border: string
   @Prop({ type: Boolean, default: false }) hasLabel: boolean
   @Prop({ type: String, default: '' }) label: string

   langsArray: LangsModel[] = []  // массив языков
   selectedLang: LangsModel = null  // выбранный язык
   showOptions: boolean = false  // флаг на открытие options

   created() {
      this.langsArray = [
         new LangsModel(EnumLangs.RU, 'Russia', '/assets/img/flags/russia.svg', '+7', false, EnumLangs[0]),
         new LangsModel(EnumLangs.US, 'USA', '/assets/img/flags/usa.svg', '+1', false, EnumLangs[1]),
         new LangsModel(EnumLangs.UK, 'United Kingdom', '/assets/img/flags/united-kingdom.svg', '+44', false, EnumLangs[2]),
         new LangsModel(EnumLangs.UA, 'Ukraine', '/assets/img/flags/ukraine.svg', '+380', false, EnumLangs[3]),
         new LangsModel(EnumLangs.MD, 'Moldova', '/assets/img/flags/moldova.svg', '+373', true, EnumLangs[4]),
      ]

      this.startSelectedLang()
   }

   mounted () {
      document.addEventListener('click', this.clickOutside)
   }

   destroyed() {
      document.removeEventListener('click', this.clickOutside)
   }

   /**
    * Выбор элемента
    */
   selectLang(id: number) {
      this.selectedLang = this.langsArray.find(el => el.Id == id)
      this.langsArray.forEach(item => {
         item.Selected = false
      })
      if (this.selectedLang) this.selectedLang.Selected = true
      this.$emit('selectedItem', this.selectedLang)
      this.closeOptions()
   }

   /**
    * Отображение выбранного элемента в selected
    */
   startSelectedLang() {
      this.selectedLang = this.langsArray.find(el => el.Selected)
      this.$emit('selectedItem', this.selectedLang)
   }


   /**
    * Открытие options
    */
   openOptions() {
      this.showOptions = !this.showOptions
   }

   /**
    * Закрытие options
    */
   closeOptions() {
      this.showOptions = false
   }


   /**
    * Стилизация langs-dropdown
    */
   setStyle(): Object {
      return {
         zIndex: this.zIndex
      }
   }

   setStyleSelected(): Object {
      return {
         border: this.border
      }
   }

   
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
}
</script>

<style scoped>

.langs-dropdown {
   /* margin-bottom: 30px; */
   margin-right: 15px;
   position: relative;
   width: 100%;
   z-index: 1;
}

.langs-dropdown.absolute {
   margin-bottom: 0;
   position: absolute;
   top: 1px;
   left: 2px;
   max-width: 115px;
}

.langs-dropdown.absolute.hasLabel {
   top: 27px;
}

.langs-dropdown.withLabel {
   margin-bottom: 0;
   position: absolute;
   top: 26px;
   left: 2px;
   max-width: 115px;
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

.i-new-input.error .selected {
   background: #FACDD4;
}

.langs-dropdown.absolute .selected,
.langs-dropdown.withLabel .selected {
   padding: 5px 5px 5px 20px;
   border: none;
   min-height: 42px;
}

.selected.lang {
   text-transform: uppercase;
}

.selected .icon {
   margin-right: 10px;
   max-width: 26px;
}

.selected .icon {
   width: 26px;
   min-width: 26px;
   height: auto;
}

.selected .icon img {
   max-width: 100%;
   height: auto;
}




/* label */ 
label {
   margin-bottom: 8px;
   margin-left: 20px;
   display: inline-block;
   font-size: 14px;
   font-weight: 600;
   line-height: 120%;
   color: #121B23;

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
   height: 141px;
   overflow: auto;
   z-index: 2;
}

.langs-dropdown.absolute .options,
.langs-dropdown.withLabel .options {
   width: max-content;
   max-width: 300px;
}

.options li {
   padding: 10px;
   display: flex;
   align-items: center;
   justify-content: space-between;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.options li:hover,
.options li.current {
   background: #e6e6eb;
}

.options li .flex {
   margin-right: 10px;
   display: flex;
   align-items: center;
   flex: 1 1 auto;
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



/* country */
.options li .country {
   font-size: 14px;
   font-weight: 600;
   color: #121B23;
    display: -webkit-box;
   -webkit-line-clamp: 1;
   -webkit-box-orient: vertical;
   overflow: hidden;
}



/* code number */
.options li .code {
   font-size: 14px;
   font-weight: 50;
   color: #121B23;
   white-space: nowrap;
}


/* анимация появления options */
.showOptions-enter-active, .showOptions-leave-active {
   transition: all 0.3s ease-out;
}

.showOptions-enter, .showOptions-leave-to {
   top: 120%;
   opacity: 0;
   visibility: hidden;
}

@media all and (max-width: 400px) {
   .langs-dropdown.absolute .options { max-width: 250px; }
}

@media all and (max-width: 350px) {
   .langs-dropdown.absolute .options { max-width: 190px; }
}
</style>