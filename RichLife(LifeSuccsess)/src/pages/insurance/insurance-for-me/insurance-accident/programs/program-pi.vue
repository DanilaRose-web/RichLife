<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li class="active"><router-link to="program-pi">Программа страхования PI</router-link></li>
               <li><router-link to="program-pi-traffic">Программа страхования PI traffic</router-link></li>
               <li><router-link to="program-bob">Программа страхования BOB</router-link></li>
               <li><router-link to="program-bi">Программа страхования BI</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-me">Страхование для меня <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <router-link to="insurance-for-me">Страхование от несчастных случаев <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Программа страхования PI</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Program PI</span>
            <h1 class="i-title section-title">Постоянная нетрудоспособность в результате НВ</h1>
            <h4 class="i-subtitle">Несчастный случай – это случайные, внешние, насильственные, внезапные, не вызванные преднамеренно события, произошедшие в течение срока действия Договора Страхование и причинившие тяжкое телесное повреждение или травму нуждается в госпитализации.</h4>

            <div class="descr-wrap">
               <h4>Постоянная нетрудоспособность в результате несчастного случая</h4>
               <div class="descr-block">
                  <h4>Вводный возраст</h4>
                  <p>От 18 до 64 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальный возраст на дату окончания программы</h4>
                  <p>65 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Минимальная страховая премия</h4>
                  <p>Если PI выбрана из программы страхования основных рисков E, PEAD (п. 4.1. заявления о страховании), минимальная страховая премия по PI рассчитывается в соответствии с установленным минимальным размером страховой суммы для данной программы, а минимальная страховая премия по пакету составляет 4 000 грн., из которых минимум 30% по программам страхования дополнительных рисков. Если PI выбрана из программы страхования основных рисков TERM со страховой суммой 50 грн. (п. 4.2. заявления о страховании), минимальная страховая премия по PI рассчитывается в соответствии с установленным минимальным размером страховой суммы для данной программы, а минимальная страховая премия по пакету составляет 500 грн. для взрослых, 400 грн. для детей и 250 грн. при групповом страховании.</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальная страховая премия</h4>
                  <p>Не ограничена</p>
               </div>
               <div class="descr-block">
                  <h4>Минимальная страховая сумма</h4>
                  <p>Если PI выбрана из программы страхования основных рисков E, PEAD (п. 4.1. заявления о страховании), то страховая сумма по ней должна быть равна или превышать страховую сумму по программе страхования основных рисков. Если PI выбрана из программы страхования основных рисков TERM со страховой суммой 50 грн. (п. 4.2. заявления о страховании), минимальная страховая сумма по ней составляет 50 000 грн.</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальная страховая сумма</h4>
                  <p>Не ограничена</p>
               </div>
               <div class="descr-block">
                  <h4>Право на Негарантированный Бонус (Дополнительный инвестиционный доход)</h4>
                  <p>Не предоставляется</p>
               </div>
               <div class="descr-block">
                  <h4>Положение об индексации</h4>
                  <p>Применяется кроме случаев, когда PI покупается с программой страхования основных рисков TERM, выбранной в п.4.1. заявления о страховании</p>
               </div>
               <div class="descr-block">
                  <h4>Выкупная сумма</h4>
                  <p>Отсутствует</p>
               </div>
               <div class="descr-block">
                  <h4>Автоматический кредит</h4>
                  <p>Не предоставляется</p>
               </div>
               <div class="descr-block">
                  <h4>Налоговая скидка</h4>
                  <p>Не предоставляется</p>
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
export default class PageProgramPiComponents extends Vue {  // Страница - Копмплексные программы накопления

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