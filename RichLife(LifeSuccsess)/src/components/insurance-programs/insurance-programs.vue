<template>
   <!-- ПОКА НЕ ИСПОЛЬЗУЕТСЯ -->

   <div class="programs">
      <i-container>
         <div class="tabs">
            <div class="tab" 
               v-for="(tab, index) in tabs.tabArray" :key="index"
               @click="tabs.activeTab = tab"
               :class="{'active' : tabs.activeTab === tab}">
                  <span>{{ tab }}</span>
            </div>
         </div>


         <div class="content-wrap">
            <div class="tab-content" v-if="tabs.activeTab === 'Страхование для моей семьи'">
               <div class="info">
                  <h5 class="content-title">Финансовая защита для вас и ваших родных</h5>
                  <p>Надежные решения, которые обеспечат вас и ваших близких долгосрочной материальной поддержкой на случай непредвиденных событий и помогут сохранить достойный уровень жизни вашей семьи.</p>
               </div>
               
               <div class="links">
                  <p>Вы можете выбрать следующие разделы:</p>
                  <div class="i-button-group">
                     <i-button>накопление</i-button>
                     <i-button>несчастные случаи</i-button>
                     <i-button>страхование дял женщин</i-button>
                     <i-button>страхование для детей</i-button>
                  </div>
               </div>
            </div>

            <div class="tab-content" v-if="tabs.activeTab === 'Альтернатива государственным пенсиям'">

            </div>

            <div class="tab-content" v-if="tabs.activeTab === 'Решения для бизнеса'">

            </div>
         </div>
      </i-container>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class InsuranceProgramsComponent extends Vue {

   tabs: object = null  // иницифализируем табы

   created() {
      this.createdTabs()
   }
 
   /**
    * Вкладки
    */
   createdTabs() {
      this.tabs = {
         tabArray: ['Страхование для моей семьи', 'Альтернатива государственным пенсиям', 'Решения для бизнеса'],
         activeTab: 'Страхование для моей семьи'
      }
   }
}
</script>

<style scoped>

</style>