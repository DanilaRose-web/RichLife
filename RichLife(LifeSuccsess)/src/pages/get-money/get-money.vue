<template>
   <layout-clean> 
      <template slot="header">
         <minimal-header @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" @onClick="onShowJoinModal" @showGetInTouch="getInTouch = true"></minimal-header>
      </template>


      <section class="section-getMoney">
         <i-container>
            <h1 class="i-title getMoney-title">Забирайте прибыль</h1>
            <p class="i-subtitle getMoney-subtitle">Вы можете вывести, заработанные деньги удобным для Вас способом. Для этого заполните форму ниже</p>

            <getMoney-form></getMoney-form>
         </i-container>
      </section>


      <!-- Форма "Присоединиться" -->
      <i-modal :show="showJoinModal" @close="onHideJoinModal" >
         <div class="review-video">
            <join-form></join-form>
         </div>
      </i-modal>

      <template slot="footer">
         <layout-footer @showJoinModalFooter="onShowJoinModalFooter"></layout-footer>
      </template>
   </layout-clean>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component
export default class PageGetMoneyComponent extends Vue {

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

.section-getMoney {
   padding-bottom: 60px;
   height: 100%;
   display: flex;
   align-items: center;
}

.getMoney-title {
   margin: 40px auto 20px auto;
   text-transform: none;
   color: #121B23;
}

.getMoney-subtitle {
   margin-bottom: 80px;
   line-height: 130%;
}
</style>