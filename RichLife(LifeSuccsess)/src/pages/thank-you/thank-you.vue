<template>
   <layout-clean> 
      <template slot="header">
         <!-- <layout-header class="static" @onClick="onShowJoinModal"></layout-header> -->
         <minimal-header @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" @onClick="onShowJoinModal" @showGetInTouch="getInTouch = true"></minimal-header>
      </template>


      <section class="section-thank-you">
         <i-container>
            <span class="i-title dancing">Thank You</span>
            <h1 class="i-title thank-you-title">Ваши данные успешно отправлены!</h1>
            <p class="i-text thank-you-text">Мы проверим их корректность и свяжемся с Вами в ближайшее время</p>
            <p class="i-text dancing">Спасибо за доверие! Хорошего дня и отличного настроения</p>
            <div class="button-wrap">
               <i-button :padding="'10px 25px 10px 25px'" @onClick="back">Вернуться в профиль</i-button>
            </div>
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
import { Component } from "vue-property-decorator"

@Component
export default class PageThankYouComponent extends Vue {


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
    * Переход на предыдущую страницу
    */
   back() {
      this.$router.push({ name: 'profile' })
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

.section-thank-you {
   margin-bottom: 80px;
   display: flex;
   align-items: center;
   height: 100%;
}

.thank-you-title {
   text-transform: none;
}

.thank-you-text {
   margin-top: 15px;
   margin-bottom: 15px;
   font-size: 20px;
   text-align: center;
}

.i-text.dancing {
   margin-bottom: 40px;
   font-family: 'Astrum', cursive;
   color: #12be83;
   font-size: 30px;
   line-height: 115%;
   text-align: center;
}

.button-wrap {
   margin-top: 20px;
   display: flex;
   align-items: center;
   justify-content: center;
   width: 100%;
}

@media all and (max-width: 320px) {
   .thank-you-text { font-size: 18px; }
}
</style>