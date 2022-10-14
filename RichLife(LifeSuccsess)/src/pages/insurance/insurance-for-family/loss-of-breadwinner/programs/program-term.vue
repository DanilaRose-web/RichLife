<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li class="active"><router-link to="program-term">Программа страхования TERM</router-link></li>
               <li><router-link to="program-adob">Программа страхования ADob</router-link></li>
               <li><router-link to="program-ad-traffic">Программа страхования AD Traffic</router-link></li>
               <li><router-link to="program-cpa">Программа страхования CPA</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-family">Страхование для моей семьи <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <router-link to="loss-of-breadwinner">Страхование в случае потери кормильца <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Программа страхования TERM</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Program TERM</span>
            <h1 class="i-title section-title">Страхование на случай смерти до определенного возраста</h1>
            <h4 class="i-subtitle">Компания «МетЛайф» предлагает решения, которые придают вам уверенность в том, что ваша семья будет обеспечена даже в случае досадных жизненных ситуаций с вами как кормильцем.</h4>

            <div class="descr-wrap">
               <h4>Страхование на случай смерти на определенный срок или до определенного возраста</h4>
               <div class="descr-block">
                  <h4>Вводный возраст</h4>
                  <p>От 18 до 60 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальный возраст на дату окончания программы</h4>
                  <p>75 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Период страхования</h4>
                  <p>срок: 10, 15, 16, 17, 18, 19, 20 лет</p>
                  <p>до достижения возраста: 50, 55, 60, 65 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Минимальный срок страхования</h4>
                  <p>10 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Минимальный размер Страховой Суммы</h4>
                  <p>15 000 грн.</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальный размер Страховой Суммы</h4>
                  <p>Не ограничен, при этом нужно учитывать лимиты страховых сумм, требующих прохождения медицинского осмотра</p>
               </div>
               <div class="descr-block">
                  <h4>Право на Негарантированный Бонус (Дополнительный инвестиционный доход)</h4>
                  <p>Не предоставляется</p>
               </div>
               <div class="descr-block">
                  <h4>Положение об индексации</h4>
                  <p>Не применяется</p>
               </div>
               <div class="descr-block">
                  <h4>Выкупная сумма</h4>
                  <p>1 грн.</p>
               </div>
               <div class="descr-block">
                  <h4>Автоматический кредит</h4>
                  <p>Не предоставляется</p>
               </div>
               <div class="descr-block">
                  <h4>Налоговая скидка</h4>
                  <p>Может быть получена на сумму страховой премии по этой программе, если она программа страхования основных рисков по договору долгосрочного страхования жизни, заключенному согласно п.4.1. заявления о страховании</p>
               </div>
            </div>
         </i-container>
      </section>

      <!-- Форма регистрации -->
      <i-modal :contentMaxWidth="'600px'" :show="showJoinModal" @close="onHideJoinModal" >
         <join-form></join-form>
      </i-modal>

      <!-- Модалка проверки авторизации -->
      <i-modal :contentMaxWidth="'600px'" :show="noteGetInTouch" @close="noteGetInTouch = false">
         <notification-get-in-touch @click="onShowJoinModal"></notification-get-in-touch>
      </i-modal>

      <!-- Форма "Оставить заявку" -->
      <i-modal :contentMaxWidth="'600px'" :show="getInTouch" @close="getInTouch = false">
         <get-in-touch></get-in-touch>
      </i-modal>

      <modal-chat :innerOpen="openChat" @closeChat="onCloseChat"></modal-chat>
   </layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

import cookie from "js-cookie"

@Component
export default class PageProgramTermComponents extends Vue {  // Страница - 

   showJoinModal: boolean = false  // флаг на открытие формы join
   getInTouch: boolean = false // флаг на открытие модального окна "оставить заявку"
   openChat: boolean = false // открытие окна с чатом при клике на "связаться с нами" из services-menu
   innerShowMenu: boolean = false
   noteGetInTouch: boolean = false // фдаг на открытие окна с проверкой на авторизацию


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
      this.noteGetInTouch = false
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

   /**
    * Открытие модального окна с проверкой на авторизацию
    */
   openNoteModal() {
      this.noteGetInTouch = true
   }

   /**
    * Открытие модалки на проверку авторизации, при клике на "Оставить заявку"
    */
   onGetInTouch() {
      if (cookie.get('token') == '' || cookie.get('token') == undefined) {
         this.noteGetInTouch = true
      } else {
         this.getInTouch = true
      }
   }

}
</script>

<style scoped>

.static-md-title {
   margin: 70px auto 0 auto;
   font-size: 20px;
   font-weight: 700;
   line-height: 140%;
   color: #121B23;
   text-align: center;
   max-width: 900px;
}

.descr-wrap {
   margin: 0 auto;
   max-width: 1000px;
}

.descr-block {
   margin-top: 60px;
   padding: 20px;
   position: relative;
   background: #F8F9FC;
   border-radius: 15px;
   box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.descr-block::before {
   content: '';
   position: absolute;
   top: -30px;
   left: -30px;
   width: 70px;
   height: 70px;
   background: url('/assets/img/backgrounds/dots-bg.webp') no-repeat center;
   background-size: cover;
   z-index: -1;
}

.descr-wrap h4 {
   font-size: 18px;
   font-weight: 700;
   line-height: 120%;
   color: #121B23;
}

.descr-wrap h4.mt {
   margin-top: 40px;
}

.descr-block p {
   margin-top: 15px;
   font-size: 15px;
   font-weight: 500;
   line-height: 150%;
   color: #121B23;
}

.descr-block p.strong {
   font-size: 17px;
   font-weight: 700;
}

.descr-list {
   margin: 20px 0;
}

</style>