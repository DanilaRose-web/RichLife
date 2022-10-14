<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter"> 
      <template slot="header">
         <!-- <layout-header class="static" @onClick="onShowJoinModal"></layout-header> -->
         <minimal-header @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" @onClick="onShowJoinModal" @showGetInTouch="getInTouch = true"></minimal-header>
      </template>

      <section class="section-take-program">
         <i-container>
            <h1 class="take-program-title i-title">Создайте безопасное будущее прямо сейчас</h1>
            <h3 class="i-subtitle take-program-subtitle">Для оформления программы заполните форму ниже</h3>

            <!-- <take-a-program-form></take-a-program-form> -->
            <program-form></program-form>
         </i-container>
      </section>

      <!-- Форма "Присоединиться" -->
      <i-modal :show="showJoinModal" @close="onHideJoinModal" >
         <div class="review-video">
            <join-form></join-form>
         </div>
      </i-modal>
   </layout>
</template>  

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class PageTakeAProgramComponent extends Vue {

   showJoinModal: boolean = false  // флаг на открытие формы join
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false


   /**
    * Emit, который передает значение флага для открытия формы join из layout (т.к. layout-footer инициализируется в layout, а не на этой странице)
    */
   onShowJoinModalFooter(showJoinModalFooter: boolean) {
      this.showJoinModal = showJoinModalFooter
   }

   /**
    * Открытие модального окна с формой join
    */
   onShowJoinModal() {
      this.showJoinModal = true
      this.$emit('showJoin', this.showJoinModal)
   }

   /**
    * Закрытие модального окна с формой join
    */
   onHideJoinModal() {
      this.showJoinModal = false
   }

   /**
    * Окрытие окна с чатом при клике на "связаться с нами" из services-menu
    */
   onCallUs() {
      this.openChat = true
      this.innerShowMenu = false
   }

   onChangeShow(show: boolean) {
      this.innerShowMenu = show
   }

   /**
    * Передача флага open: false, из компонента modal-chat при закрытии чата
    */
   onCloseChat(open: boolean) {
      this.openChat = open
   }

}
</script>

<style scoped>

.section-take-program {
   padding: 0 0 90px 0;
   display: flex;
   justify-content: center;
   min-height: 100vh;
   width: 100%;
   position: relative;
   background: #F8F9FC;
}

.take-program-title {
   margin: 40px auto 10px auto;
   text-transform: none;
   color: #121B23;
}

.take-program-subtitle {
   margin-bottom: 100px;
}

@media all and (max-width: 450px) {
   .section-take-program { font-size: calc((100vw - 280px)/(450 - 280) * (35 - 28) + 28px); }
   .take-program-subtitle { font-size: calc((100vw - 280px)/(450 - 280) * (19 - 15) + 15px); }
}
</style>