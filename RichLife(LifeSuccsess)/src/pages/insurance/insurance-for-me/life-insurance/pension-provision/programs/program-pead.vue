<template>
   <layout @showJoinModalFooter="onShowJoinModalFooter" @getInTouch="onGetInTouch">
      <template slot="header">
         <minimal-header-metlife @getInTouch="onGetInTouch" @openNote="openNoteModal" @changeShow="onChangeShow" :innerShowMenu="innerShowMenu" @callUs="onCallUs" class="static" @showJoinModal="onShowJoinModal" @showGetInTouch="onGetInTouch" />

         <!-- <services-static-menu>
            <ul class="static-menu">
               <li class="active"><router-link to="pension-provision">Дополнительное пенсионное обеспечение</router-link></li>
               <li><router-link to="accumulation-programs">Комплексные программы накопления</router-link></li>
            </ul>
         </services-static-menu> -->
      </template>

      <breadcrumbs>
         <router-link to="/">Главная <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="metlife">MetLife <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <!-- <router-link to="insurance-for-me">Страхование для меня <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link> -->
         <router-link to="life-insurance">Страхование жизни <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <router-link to="pension-provision">Дополнительное пенсионное обеспечение <svg><use xlink:href="/assets/img/svg-sprite.svg#arrows-breadcrumb"></use></svg></router-link>
         <span>Дожития до определенного возраста</span>
      </breadcrumbs>

      <section class="section-main i-section">
         <i-container>
            <span class="i-title dancing">Survival</span>
            <h1 class="i-title section-title">Дожития до определенного возраста</h1>
            <h4 class="i-subtitle">Компания "МетЛайф" предлагает решения для альтернативного пенсионного обеспечения и накоплений к определенному событию.</h4>

            <div class="descr-wrap">
               <h4>Страхование на случай доживания до определенного возраста или на определенный срок</h4>
               <div class="descr-block">
                  <h4>Вводный возраст</h4>
                  <p>18-65 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальный возраст на дату окончания программы</h4>
                  <p>75 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Период страхования</h4>
                  <p>сроком 10, 15, 16, 17, 18, 19, 20, 25 лет</p>
                  <p>минимум 10 лет</p>
               </div>
               <div class="descr-block">
                  <h4>Минимальная страховая премия</h4>
                  <p>2500 грн. по программе PEAD. При этом общая страховая премия по пакету должна составлять минимум 4000 грн., из которых минимум 30% по программам страхования дополнительных рисков.</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальная страховая премия</h4>
                  <p>Неограниченная</p>
               </div>
               <div class="descr-block">
                  <h4>Минимальная страховая сумма</h4>
                  <p>15 000 грн</p>
               </div>
               <div class="descr-block">
                  <h4>Максимальная страховая сумма</h4>
                  <p>Не ограничена, при этом необходимо учитывать лимиты страховых сумм, требующих прохождения медицинского обследования.</p>
               </div>
               <div class="descr-block">
                  <h4>Право на Негарантированный Бонус (Дополнительный Инвестиционный Доход)</h4>
                  <p>Предоставляется</p>
               </div>
               <div class="descr-block">
                  <h4>Положение об индексации</h4>
                  <p>Применяется</p>
               </div>
               <div class="descr-block">
                  <h4>Конвертация договора страхования в полностью уплаченный</h4>
                  <p>Автоматически осуществляется по договору долгосрочного страхования жизни после формирования выкупной суммы</p>
               </div>
               <div class="descr-block">
                  <h4>Автоматический кредит</h4>
                  <p>По заявлению Страхователя по договору долгосрочного страхования жизни после формирования выкупной суммы</p>
               </div>
               <div class="descr-block">
                  <h4>Налоговая скидка</h4>
                  <p>Может быть получена на сумму страховой премии по этой программе</p>
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
export default class PageProgramPeadComponents extends Vue {  // Страница - Копмплексные программы накопления

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